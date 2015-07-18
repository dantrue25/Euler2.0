using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Euler
{
    public partial class MainForm : Form
    {
        // Graph editing mode constants
        private const int 
            SELECT_MOVE   = 0, 
            ADD_VERTEX    = 1, 
            DELETE_VERTEX = 2, 
            ADD_EDGE      = 3,  
            DELETE_EDGE   = 4, 
            SELECT_AREA   = 5,
            ADD_DIRECTED  = 6;
        // Adjacency matrix output constants
        private const int 
            BASIC_ADJ     = 10, 
            WOLFRAM_ADJ   = 11, 
            MATLAB_ADJ    = 12, 
            IMAGE_ADJ     = 13;
        // Graph analysis output constants
        private const int 
            POWER_ADJ     = 20, 
            EIGEN_VEC     = 21, 
            EIGEN_VAL     = 22;

        // Main form's constructor
        public MainForm()
        {
            InitializeComponent();
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            pictureBox1.MouseLeave += new EventHandler(pictureBox1_MouseLeave);
            pictureBox1.MouseEnter += new EventHandler(pictureBox1_MouseEnter);
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            propertyGrid1.PropertyValueChanged += new PropertyValueChangedEventHandler(propertyGrid1_PropertyValueChanged);
            
            graph = new Graph();
            editMode = SELECT_MOVE;

            comboBoxAdjPower.SelectedIndex = 1;
            selectedOutput = BASIC_ADJ;
            graphCursor = Cursors.Arrow;
            label2.Text = "Properties for Graph";
            propertyGrid1.SelectedObject = graph;
            toolStripStatusLabelBottomLeftHint.Text = "Ready";
            toolStripStatusLabel3.Text = "";
            showButtonInUse(toolStripButtonSelectMoveVertex);
            toolTip1.Active = true;
            graphImage = new Bitmap(Math.Min(1000, pictureBox1.Width), Math.Min(1000, pictureBox1.Height));
            printGraph();
        }

        void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            propertyGrid1.Refresh();
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
            resetMatrixTextBoxes();
            printGraph();
        }

        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel3.Text = "(" + e.X + ", " + e.Y + ")";
            if (editMode == ADD_VERTEX && !graph.enoughRoom(e.X, e.Y))
            {
                Cursor = Cursors.No;
            }
            else
                Cursor = graphCursor;

            if (editMode == SELECT_MOVE 
                && e.Button == MouseButtons.Left 
                && selected != null
                && e.X - selected.Radius > 0 && e.X + selected.Radius < pictureBox1.Width
                && e.Y - selected.Radius > 0 && e.Y + selected.Radius < pictureBox1.Height)
            {
                toolTip1.Active = false;
                if (graph.enoughRoomExcludingSelected(e.X, e.Y, selected))
                {
                    Cursor = Cursors.SizeAll;
                    selected.Location = new Point(e.X, e.Y);
                }
                else
                    Cursor = Cursors.No;
                printGraph();
            }
            else if ((editMode == SELECT_MOVE || editMode == ADD_EDGE) 
                && e.Button != MouseButtons.Left 
                && e.X > 0 && e.X < pictureBox1.Width 
                && e.Y > 0 && e.Y < pictureBox1.Height)
            {
                Vertex v = graph.getVertex(e.X, e.Y);
                if (v != null)
                {
                    if (!toolTip1.Active)
                    {                        
                        toolTip1.Show(v.Name, pictureBox1, v.Location.X, v.Location.Y - 30);
                        toolTip1.Active = true;
                        toolTip1.Show(v.Name, pictureBox1, v.Location.X, v.Location.Y - 30);
                    }
                }
                else
                    toolTip1.Active = false;
            }

            if (editMode == ADD_EDGE || editMode == DELETE_EDGE)
            {
                if (graph.getVertex(e.X, e.Y) != null)
                    Cursor = Cursors.Cross;
            }

            if (editMode == SELECT_AREA
                && e.Button == MouseButtons.Left
                && e.X > 0 && e.X < pictureBox1.Width
                && e.Y > 0 && e.Y < pictureBox1.Height)
            {
                graphImageDomain.Size = new Size(Math.Abs(e.X - clickPoint.X), Math.Abs(e.Y - clickPoint.Y));
                graphImageDomain.Location = new Point(Math.Min(e.X, clickPoint.X), Math.Min(e.Y, clickPoint.Y));
                printGraph();
            }
        }

        void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripRightClickPictureBox.Items.Clear();
                selected = graph.getVertex(e.X, e.Y);
                if (selected == null)
                {
                    contextMenuStripRightClickPictureBox.Items.Add(copyGraphImageToolStripMenuItem);
                }
                else
                {
                    deleteToolStripMenuItem.Text = "Delete " + selected.Name;
                    contextMenuStripRightClickPictureBox.Items.Add(deleteToolStripMenuItem);
                    contextMenuStripRightClickPictureBox.Items.Add(copyGraphImageToolStripMenuItem);
                }

                if (editMode == SELECT_AREA)
                {
                    if (graphImageDomain.Size.Width != 0 || graphImageDomain.Size.Height != 0)
                        contextMenuStripRightClickPictureBox.Items.Add(copyGraphImageSubsectionToolStripMenuItem);
                }
                contextMenuStripRightClickPictureBox.Show(pictureBox1.PointToScreen(e.Location));
            }

            else if (e.Button == MouseButtons.Left)
            {
                switch (editMode)
                {
                    case (SELECT_MOVE):
                        selected = graph.getVertex(e.X, e.Y);
                        if(selected != null)
                            Cursor.Position = pictureBox1.PointToScreen(selected.Location);
                        printGraph();
                        break;
                    case (ADD_VERTEX):
                        if(graph.enoughRoom(e.X, e.Y))
                        {
                            graph.addVertex(new Vertex(e.X, e.Y, graph));
                            selected = graph.getVertex(e.X, e.Y);
                        }
                        resetMatrixTextBoxes();
                        printGraph();
                        break;
                    case (DELETE_VERTEX):
                        selected = graph.getVertex(e.X, e.Y);
                        graph.removeVertex(selected);
                        selected = null;
                        resetMatrixTextBoxes();
                        printGraph();
                        break;
                    case (ADD_EDGE):
                        if (selected == null)
                        {
                            selected = graph.getVertex(e.X, e.Y);
                            toolStripStatusLabelBottomLeftHint.Text = "Add edge: Now click on the vertex you wish to add as a neighbor.";

                            printGraph();
                        }
                        else
                        {
                            Vertex secondVertex = graph.getVertex(e.X, e.Y);
                            if (secondVertex != null)
                            {
                                selected.addNeighbor(secondVertex);
                                secondVertex.addNeighbor(selected);
                                selected = null;

                                resetMatrixTextBoxes();
                                printGraph();
                            }
                            else
                            {
                                selected = null;
                                printGraph();
                            }
                            toolStripStatusLabelBottomLeftHint.Text = "Add edge: Click on the vertex that you want to add an edge to.";
                        }
                        break;
                    case (ADD_DIRECTED):
                        if (selected == null)
                        {
                            selected = graph.getVertex(e.X, e.Y);
                            toolStripStatusLabelBottomLeftHint.Text = "Add edge: Now click on the vertex you wish to add as a neighbor.";

                            printGraph();
                        }
                        else
                        {
                            Vertex secondVertex = graph.getVertex(e.X, e.Y);
                            if (secondVertex != null)
                            {
                                selected.addNeighbor(secondVertex);
                                selected = null;

                                resetMatrixTextBoxes();
                                printGraph();
                            }
                            else
                            {
                                selected = null;
                                printGraph();
                            }
                            toolStripStatusLabelBottomLeftHint.Text = "Add edge: Click on the vertex that you want to add an edge to.";
                        }
                        break;
                    case (DELETE_EDGE):
                        if (selected == null)
                        {
                            selected = graph.getVertex(e.X, e.Y);
                            toolStripStatusLabelBottomLeftHint.Text = "Delete edge: Now click on the vertex you wish to remove as a neighbor.";
                            printGraph();
                        }
                        else
                        {
                            Vertex secondVertex = graph.getVertex(e.X, e.Y);
                            if (secondVertex != null)
                            {
                                selected.removeNeighbor(secondVertex);
                                secondVertex.removeNeighbor(selected);
                                selected = null;

                                resetMatrixTextBoxes();
                                printGraph();
                            }
                            else
                            {
                                selected = null;
                                printGraph();
                            }
                            toolStripStatusLabelBottomLeftHint.Text = "Delete edge: Click on the vertex you want to remove the edge from.";
                        }
                        break;
                    case(SELECT_AREA):
                        clickPoint = e.Location;
                        graphImageDomain.Size = new Size(0, 0);
                        break;
                    default:
                        break;
                }
            }
            
            if (selected != null)
            {
                label2.Text = "Properties for " + selected.Name;
                propertyGrid1.SelectedObject = selected;
            }
            else
            {
                propertyGrid1.SelectedObject = graph;
                label2.Text = "Properties for Graph";
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            resetMatrixTextBoxes();
            printGraph();
            base.OnPaint(e);
        }

        public void printGraph()
        {
            if (graphImage.Size != pictureBox1.Size)
                graphImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            graphics = Graphics.FromImage(graphImage);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.Clear(graph.BackgroundColor);

            // Draw edges
            foreach (Vertex v in graph.Vertices)
            {
                foreach (Vertex n in v.Neighbors)
                {
                    // Loop to itself
                    if (v.Equals(n))
                        graphics.DrawEllipse(new Pen(graph.EdgeColor, graph.EdgeWidth), (int) (v.X - 2.8 * v.Radius), (int) (v.Y - 2.8 * v.Radius), 3 * v.Radius, 3 * v.Radius);
                    
                    // Directed
                    if (!n.Neighbors.Contains(v))
                    {
                        Pen regularPen = new Pen(graph.EdgeColor, graph.EdgeWidth);
                        Pen arrowPen = new Pen(graph.EdgeColor, graph.ArrowSize);
                        arrowPen.EndCap = LineCap.ArrowAnchor;
                        graphics.DrawLine(regularPen, v.Location, getLocationForDirectedEdge(v.Location, n.Location, n.Radius + graph.ArrowSize));
                        graphics.DrawLine(arrowPen, getLocationForDirectedEdge(v.Location, n.Location, n.Radius + graph.ArrowSize), getLocationForDirectedEdge(v.Location, n.Location, n.Radius));
                    }
                    // Undirected
                    else
                    {
                        graphics.DrawLine(new Pen(graph.EdgeColor, graph.EdgeWidth), v.Location, n.Location);
                    }
                }
            }

            // Draw vertices
            foreach (Vertex v in graph.Vertices)
            {
                if(selected != null && v.X == selected.X && v.Y == selected.Y)
                    graphics.FillEllipse(new SolidBrush(blendColor(selected.Color, Color.White, .5)), v.X - v.Radius - 4, v.Y - v.Radius - 4, v.Radius * 2 + 8, v.Radius * 2 + 8);
                graphics.FillEllipse(new SolidBrush(v.Color), v.X - v.Radius, v.Y - v.Radius, v.Radius * 2, v.Radius * 2);
            }

            // If visible, draw vertex names
            if (graph.VertexLabelVisible)
            {
                foreach (Vertex v in graph.Vertices)
                {
                    if(graph.BackgroundColor.Equals(Color.Transparent))
                        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                    Size nameSize = TextRenderer.MeasureText(v.Name, graph.VertexLabelFont);
                    //graphics.DrawRectangle(Pens.Black, new Rectangle(v.X - nameSize.Width / 2, v.Y - v.Radius - nameSize.Height - 10, nameSize.Width, nameSize.Height));
                    graphics.DrawString(v.Name, graph.VertexLabelFont, new SolidBrush(graph.VertexLabelColor), v.X - nameSize.Width / 2, v.Y - v.Radius - nameSize.Height - 10);
                }
            }

            // If visible, draw graph name
            if(graph.GraphLabelVisible)
            {
                if (graph.BackgroundColor.Equals(Color.Transparent))
                    graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                Size nameSize = TextRenderer.MeasureText(graph.Name, graph.GraphLabelFont);
                graphics.DrawString(graph.Name, graph.GraphLabelFont,Brushes.Black, pictureBox1.Width / 2 - nameSize.Width / 2, 20);
            }

            // If edit mode is Select Area
            if (editMode == SELECT_AREA)
            {
                Pen dashed = new Pen(Color.Black, 1);
                dashed.DashPattern = new float[]{2f, 2f};
                graphics.DrawRectangle(dashed, graphImageDomain);
            }

            pictureBox1.Image = graphImage;
        }

        private Point getLocationForDirectedEdge(Point start, Point end, int radius)
        {
            double width, height;
            width = end.X - start.X;
            height = -(end.Y - start.Y);

            double newHypotenuse = Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2)) - radius;

            double angle = Math.Atan(height / width);

            Point arrowPoint = new Point();

            if (width < 0 && height <= 0)
            {
                arrowPoint.X = (int)(start.X - newHypotenuse * Math.Cos(angle));
                arrowPoint.Y = (int)(start.Y + newHypotenuse * Math.Sin(angle));
            }
            else if (width < 0 && height >= 0)
            {
                arrowPoint.X = (int)(start.X - newHypotenuse * Math.Cos(angle));
                arrowPoint.Y = (int)(start.Y + newHypotenuse * Math.Sin(angle));
            }
            else if (width >= 0 && height <= 0)
            {
                arrowPoint.X = (int)(start.X + newHypotenuse * Math.Cos(angle));
                arrowPoint.Y = (int)(start.Y - newHypotenuse * Math.Sin(angle));
            }
            else if (width >= 0 && height >= 0)
            {
                arrowPoint.X = (int)(start.X + newHypotenuse * Math.Cos(angle));
                arrowPoint.Y = (int)(start.Y - newHypotenuse * Math.Sin(angle));
            }

            return arrowPoint;
        }

        private void resetMatrixTextBoxes()
        {
            SquareMatrix adjacencyMatrix = graph.AdjacencyMatrix;

            switch (selectedOutput)
            {
                case(BASIC_ADJ):
                    richTextBoxBasic.Text = adjacencyMatrix.toStringBasic();
                    break;
                case(WOLFRAM_ADJ):
                    richTextBoxWolframAlpha.Text = adjacencyMatrix.toStringWolframAlpha();
                    break;
                case(MATLAB_ADJ):
                    richTextBoxMatlab.Text = adjacencyMatrix.toStringMatlab();
                    break;
                case(POWER_ADJ):
                    richTextBoxPower.Text = adjacencyMatrix.toThePower(comboBoxAdjPower.SelectedIndex + 1).toStringBasic();
                    break;
                case(EIGEN_VEC):
                    richTextBoxEigenVector.Text = adjacencyMatrix.getEigenVectorString();
                    break;
                case(EIGEN_VAL):
                    richTextBoxEigenValue.Text = adjacencyMatrix.getEigenValueString();
                    break;
                case(IMAGE_ADJ):
                    pictureBox2.Image = adjacencyMatrix.makeMatrixImage();
                    break;
                default:
                    break;
            }
            
        }

        private void resetGUI()
        {
            graphCursor = Cursors.Arrow;
            showButtonInUse(toolStripButtonSelectMoveVertex);
            toolStripStatusLabelBottomLeftHint.Text = "Ready";
            editMode = SELECT_MOVE;
            propertyGrid1.SelectedObject = graph;
            label2.Text = "Properties for Graph";
            resetMatrixTextBoxes();
            printGraph();
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
            resetMatrixTextBoxes();
            printGraph();
        }

        public Bitmap graphImage;
        private Graphics graphics;
        public Graph graph;
        public Vertex selected;
        private int editMode;
        private Cursor graphCursor;
        private int selectedOutput;
        private Rectangle graphImageDomain;
        private Point clickPoint;

        private void showButtonInUse(ToolStripButton b)
        {
            b.BackColor = Color.LightBlue;
            foreach (ToolStripButton tsb in toolStripGraphTools.Items)
            {
                if (tsb != b)
                {
                    tsb.BackColor = SystemColors.Control;
                }
            }
        }

        private void toolStripButtonSelect_Click(object sender, EventArgs e)
        {
            graphCursor = Cursors.Arrow;
            showButtonInUse(toolStripButtonSelectMoveVertex);
            toolStripStatusLabelBottomLeftHint.Text = "Ready";
            editMode = SELECT_MOVE;
        }

        private void toolStripButtonAddVertex_Click(object sender, EventArgs e)
        {
            graphCursor = Cursors.Cross;
            showButtonInUse(toolStripButtonAddVertex);
            toolStripStatusLabelBottomLeftHint.Text = "Add vertices to graph";
            editMode = ADD_VERTEX;
        }

        private void toolStripButtonDeleteVertex_Click(object sender, EventArgs e)
        {
            graphCursor = Cursors.Arrow;
            selected = null;
            showButtonInUse(toolStripButtonDeleteVertex);
            toolStripStatusLabelBottomLeftHint.Text = "Delete Vertex: Click on the vertex that you want to remove.";
            editMode = DELETE_VERTEX;
        }

        private void toolStripButtonAddEdge_Click(object sender, EventArgs e)
        {
            graphCursor = Cursors.Arrow;
            selected = null;
            showButtonInUse(toolStripButtonAddEdge);
            toolStripStatusLabelBottomLeftHint.Text = "Add edge: Click on the vertex that you want to add an edge to.";
            editMode = ADD_EDGE;
        }

        private void toolStripButtonDeleteEdge_Click(object sender, EventArgs e)
        {
            graphCursor = Cursors.Arrow;
            selected = null;
            showButtonInUse(toolStripButtonDeleteEdge);
            toolStripStatusLabelBottomLeftHint.Text = "Delete edge: Click on the vertex you want to remove the edge from.";
            editMode = DELETE_EDGE;
        }

        private void toolStripButtonAddEdgeDirected_Click(object sender, EventArgs e)
        {
            graphCursor = Cursors.Arrow;
            selected = null;
            showButtonInUse(toolStripButtonAddEdgeDirected);
            toolStripStatusLabelBottomLeftHint.Text = "Add edge: Click on the vertex that you want to add an edge to.";
            editMode = ADD_DIRECTED;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Euler Graph Files|*.egf";
            saveDialog.OverwritePrompt = true;
            saveDialog.FileName = graph.Name;

            DialogResult result = saveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = saveDialog.FileName;
                string graphNameWithExtension = fileName.Substring(fileName.LastIndexOf(Path.DirectorySeparatorChar) + 1);
                graph.Name = graphNameWithExtension.Substring(0, graphNameWithExtension.Length - 4);
                if (!graph.serialize(fileName))
                    MessageBox.Show("Error:\nGraph did not save correctly!");
                else
                {
                    selected = null;
                    propertyGrid1.SelectedObject = graph;
                    printGraph();
                    propertyGrid1.Refresh();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Euler Graph Files|*.egf";

            DialogResult result = openDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String fileName = openDialog.FileName;
                this.graph = Graph.deserialize(fileName);
                if (graph == null)
                    MessageBox.Show("Error:\nCould not open file correctly.");
                else
                {
                    resetGUI();
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedOutput = tabControl1.SelectedIndex;

            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    selectedOutput = BASIC_ADJ;
                    break;
                case 1:
                    selectedOutput = WOLFRAM_ADJ;
                    break;
                case 2:
                    selectedOutput = MATLAB_ADJ;
                    break;
                case 3:
                    selectedOutput = POWER_ADJ;
                    break;
                case 4:
                    selectedOutput = EIGEN_VEC;
                    break;
                case 5:
                    selectedOutput = EIGEN_VAL;
                    break;
                case 6:
                    selectedOutput = IMAGE_ADJ;
                    break;
                default:
                    break;

            }
            resetMatrixTextBoxes();
        }

        private void copyGraphImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(graphImage);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(selected != null)
                graph.removeVertex(selected);

            resetMatrixTextBoxes();
            printGraph();
        }

        private void toolStripButtonSelectArea_Click(object sender, EventArgs e)
        {
            graphCursor = Cursors.Arrow;
            selected = null;
            showButtonInUse(toolStripButtonSelectArea);
            toolStripStatusLabelBottomLeftHint.Text = "Select a section of the graph image.";
            graphImageDomain = new Rectangle();
            editMode = SELECT_AREA;
        }

        private void copyGraphImageSubsectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage
            (
                graphImage.Clone
                (
                    new Rectangle
                    (
                        new Point(graphImageDomain.X + 1, graphImageDomain.Y + 1), 
                        new Size(graphImageDomain.Size.Width - 1, graphImageDomain.Size.Height - 1)
                    ), 
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb
                )
            );
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetMatrixTextBoxes();
        }
    }
}
