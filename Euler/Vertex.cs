using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Euler
{
    [Serializable]
    public class Vertex
    {
        private List<Vertex> neighbors;
        private Graph parent;
        private string name;
        private int x;
        private int y;
        private int radius;

        public Vertex(int x, int y, Graph g)
        {
            this.name = g.getNextVertexName();
            this.x = x;
            this.y = y;
            this.Color = g.DefaultVertexColor;
            this.neighbors = new List<Vertex>();
            this.radius = g.DefaultVertexSize;
            this.parent = g;
        }

        public string Name 
        { 
            get
            {
                return name;
            }
            set
            {
                if (parent.getVertex(value) != null && parent.getVertex(value) != this)
                {
                    System.Windows.Forms.MessageBox.Show("Invalid name : \n" + value + " is the name of a vertex already in the current graph.");
                }
                else
                    name = value;
            } 
        }
        
        public int X 
        {
            get
            {
                return this.x;
            }
            set
            {
                if (parent.enoughRoomExcludingSelected(value, this.y, this))
                    this.x = Math.Max(0, value);
                else
                    MessageBox.Show("Too close to another vertex");
            }
        }
        
        public int Y 
        {
            get
            {
                return this.y;
            }
            set
            {
                if (parent.enoughRoomExcludingSelected(this.x, value, this))
                    this.y = Math.Max(0, value);
                else
                    MessageBox.Show("Too close to another vertex");
            }
        }

        public Point Location
        {
            get
            {
                return new Point(this.x, this.y);
            }

            set
            {
                if(parent.enoughRoomExcludingSelected(value.X, value.Y, this))
                {
                    this.x = Math.Max(0, value.X);
                    this.y = Math.Max(0, value.Y);
                }
            }
        }
        
        public Color Color { get; set; }
        
        public int Radius {
            get
            {
                return radius;
            }
            set
            {
                radius = Math.Max(5, value);
            }
        }

        public ReadOnlyCollection<Vertex> Neighbors { 
            get
            {
                return neighbors.AsReadOnly();           
            }
        }

        public void addNeighbor(Vertex v)
        {
            if(!neighbors.Contains(v))
                neighbors.Add(v);
        }

        public void removeNeighbor(Vertex v)
        {
            neighbors.Remove(v);
        }

        public int indexInGraph()
        {
            return parent.Vertices.IndexOf(this);
        }
    }
}
