﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Euler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            pictureBox1.MouseLeave += new EventHandler(pictureBox1_MouseLeave);
            pictureBox1.MouseEnter += new EventHandler(pictureBox1_MouseEnter);
            propertyGrid1.PropertyValueChanged += new PropertyValueChangedEventHandler(propertyGrid1_PropertyValueChanged);
            
            graph = new Graph();
            editMode = 0;
            printGraph();

            graphCursor = Cursors.Hand;
            label2.Text = "Properties for Graph";
            propertyGrid1.SelectedObject = graph;
            toolStripStatusLabel1.Text = "Ready";
            toolStripStatusLabel3.Text = "";
            showButtonInUse(toolStripButtonSelect);
            toolTip1.Active = false;
        }

        void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = graphCursor;
        }

        void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "";
            Cursor = Cursors.Arrow;
        }

        void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            propertyGrid1.Refresh();
            printGraph();
        }

        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel3.Text = "(" + e.X + ", " + e.Y + ")";
            if (editMode == 1 && !graph.enoughRoom(e.X, e.Y))
            {
                Cursor = Cursors.No;
            }
            else
                Cursor = graphCursor;
            
            
            if(editMode == 0 || editMode == 2)
            {
                Vertex v = graph.getVertex(e.X, e.Y);
                if (v != null)
                {
                    toolTip1.Active = true;
                    toolTip1.Show(v.Name, pictureBox1);
                }
                else
                    toolTip1.Active = false;
            }
        }

        void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selected = graph.getVertex(e.X, e.Y);
            }

            else if (e.Button == MouseButtons.Left)
            {
                switch (editMode)
                {
                    case (0):
                        selected = graph.getVertex(e.X, e.Y);
                        printGraph();
                        break;
                    case (1):
                        if(graph.enoughRoom(e.X, e.Y))
                        {
                            graph.addVertex(new Vertex(e.X, e.Y, graph));
                            selected = graph.getVertex(e.X, e.Y);
                            richTextBox1.Text = graph.adjacencyMatrixStringBasic();
                        }
                        printGraph();
                        break;
                    case (2):
                        if (selected != null)
                        {
                            Vertex secondVertex = graph.getVertex(e.X, e.Y);
                            if (secondVertex != null)
                            {
                                selected.addNeighbor(secondVertex);
                                secondVertex.addNeighbor(selected);
                                selected = null;
                                printGraph();
                                richTextBox1.Text = graph.adjacencyMatrixStringBasic();
                            }
                            else
                            {
                                selected = null;
                                printGraph();
                            }
                        }
                        else
                        {
                            selected = graph.getVertex(e.X, e.Y);
                            printGraph();
                        }
                        break;
                    default:
                        break;
                }
            }
            
            propertyGrid1.SelectedObject = graph;
            label2.Text = "Properties for Graph";
            if (selected != null)
            {
                label2.Text = "Properties for " + selected.Name;
                propertyGrid1.SelectedObject = selected;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            printGraph();
            base.OnPaint(e);
        }

        public void printGraph()
        {
            graphImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(graphImage);
            graphics.Clear(graph.BackgroundColor);
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            foreach (Vertex v in graph.Vertices)
            {
                foreach (Vertex n in v.Neighbors)
                {
                    graphics.DrawLine(Pens.Black, v.Location, n.Location);
                }
            }

            foreach (Vertex v in graph.Vertices)
            {
                if(selected != null && v.X == selected.X && v.Y == selected.Y)
                    graphics.FillEllipse(new SolidBrush(blendColor(selected.Color, Color.White, .5)), v.X - v.Radius - 4, v.Y - v.Radius - 4, v.Radius * 2 + 8, v.Radius * 2 + 8);
                graphics.FillEllipse(new SolidBrush(v.Color), v.X - v.Radius, v.Y - v.Radius, v.Radius * 2, v.Radius * 2);
            }

            pictureBox1.Image = graphImage;
        }

        public Color blendColor(Color color, Color backColor, double amount)
        {
            byte r = (byte)((color.R * amount) + backColor.R * (1 - amount));
            byte g = (byte)((color.G * amount) + backColor.G * (1 - amount));
            byte b = (byte)((color.B * amount) + backColor.B * (1 - amount));
            return Color.FromArgb(r, g, b);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            printGraph();
        }

        public Bitmap graphImage;
        private Graphics graphics;
        public Graph graph;
        public Vertex selected;
        private int editMode;
        private Cursor graphCursor;

        private void toolStripButtonSelect_Click(object sender, EventArgs e)
        {
            graphCursor = Cursors.Hand;
            showButtonInUse(toolStripButtonSelect);
            toolStripStatusLabel1.Text = "Ready";
            editMode = 0;
        }

        private void toolStripButtonAddVertex_Click(object sender, EventArgs e)
        {
            graphCursor = Cursors.Cross;
            showButtonInUse(toolStripButtonAddVertex);
            toolStripStatusLabel1.Text = "Add vertices to graph";
            editMode = 1;
        }

        private void showButtonInUse(ToolStripButton b)
        {
            b.BackColor = Color.LightBlue;
            foreach (ToolStripButton tsb in toolStrip1.Items)
            {
                if (tsb != b)
                {
                    tsb.BackColor = SystemColors.Control;
                }
            }
        }

        private void toolStripButtonDeleteVertex_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                graph.removeVertex(selected);
            }
            richTextBox1.Text = graph.adjacencyMatrixStringBasic();
        }

        private void toolStripButtonAddEdge_Click(object sender, EventArgs e)
        {
            graphCursor = Cursors.Hand;
            selected = null;
            showButtonInUse(toolStripButtonAddEdge);
            toolStripStatusLabel1.Text = "Click first vertex that you want to add an edge to";
            editMode = 2;
        }
    }
}