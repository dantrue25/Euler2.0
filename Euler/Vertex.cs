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
    
    public class Vertex
    {
        private List<Vertex> neighbors;
        private Graph parent;
        private string name;
        private int x;
        private int y;

        public Vertex(int x, int y, Graph g)
        {
            this.name = g.getNextVertexName();
            this.x = x;
            this.y = y;
            this.Color = g.DefaultVertexColor;
            this.neighbors = new List<Vertex>();
            this.Radius = g.DefaultVertexSize;
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
                parent.removeVertex(this);
                
                if (parent.enoughRoom(value, this.y))
                    this.x = value;
                else
                    MessageBox.Show("Too close to another vertex");
                
                parent.addVertex(this);
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
                parent.removeVertex(this);

                if (parent.enoughRoom(this.x, value))
                    this.y = value;
                else
                    MessageBox.Show("Too close to another vertex");

                parent.addVertex(this);
            }
        }

        public Point Location
        {
            get
            {
                return new Point(this.x, this.y);
            }
        }
        public Color Color { get; set; }
        public int Radius { get; set; }

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
