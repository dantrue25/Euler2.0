using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.ObjectModel;

namespace Euler
{
    public class Graph
    {
        private List<Vertex> vertices;
        private Color backgroundColor = Color.White;
        private Color defaultVertexColor = Color.ForestGreen;
        private int defaultVertexSize = 10;
        private int[,] adjacencyMatrix;
        
        public int DefaultVertexSize
        {
            get
            {
                return defaultVertexSize;
            }

            set
            {
                defaultVertexSize = value;
                foreach (Vertex v in vertices)
                {
                    v.Radius = defaultVertexSize;
                }
            }
        }

        public Color DefaultVertexColor
        {
            get
            {
                return defaultVertexColor;
            }

            set
            {
                defaultVertexColor = value;
                foreach (Vertex v in vertices)
                {
                    v.Color = defaultVertexColor;
                }
            }
        }

        public int NumberOfVertices
        {
            get
            {
                return vertices.Count;
            }
        }

        public ReadOnlyCollection<Vertex> Vertices
        {
            get
            {
                return vertices.AsReadOnly();
            }
        }

        public Graph()
        {
            vertices = new List<Vertex>();
        }

        public void addVertex(Vertex v)
        {
            if(enoughRoom(v))
                this.vertices.Add(v);
            else
                MessageBox.Show("Not enough room for Vertex: " + v.Name + " at location (" + v.X + ", " + v.Y + ")");
        }

        public void removeVertex(Vertex v)
        {
            foreach (Vertex possibleNeighbor in vertices)
                possibleNeighbor.removeNeighbor(v);
                
            this.vertices.Remove(v);
        }

        public Vertex getVertex(int x, int y)
        {
            Vertex found = null;
            Point clickPoint = new Point(x, y);

            foreach (Vertex v in this.vertices)
            {
                double dist = distanceBetween(v.Location, clickPoint);

                if (dist < v.Radius)
                {
                    found = v;
                    break;
                }
            }

            return found;
        }

        public Vertex getVertex(string name)
        {
            Vertex found = null;

            foreach (Vertex v in this.vertices)
            {
                if (v.Name.Equals(name))
                {
                    found = v;
                    break;
                }
            }

            return found;
        }

        public Boolean enoughRoom(int x, int y)
        {
            Boolean room = true;

            Point clickPoint = new Point(x, y);

            foreach (Vertex v in vertices)
            {
                if (distanceBetween(v.Location, clickPoint) < (v.Radius + defaultVertexSize + 4))
                    return false;
            }

            return room;
        }

        public Boolean enoughRoom(Vertex check)
        {
            Boolean room = true;

            Point clickPoint = check.Location;

            foreach (Vertex v in vertices)
            {
                if (distanceBetween(v.Location, clickPoint) < (v.Radius + defaultVertexSize + 4))
                    return false;
            }

            return room;
        }

        public Color BackgroundColor
        {
            get
            {
                return backgroundColor;
            }
            set
            {
                backgroundColor = value;
            }
        }

        public string getNextVertexName()
        {
            int num = 1;

            string newName = "Vertex " + num;
            while (vertices.Contains(getVertex(newName)))
            {
                num++;
                newName = "Vertex " + num;
            }

            return newName;
        }

        public double distanceBetween(Point p1, Point p2)
        {
            double dX = p1.X - p2.X;
            double dY = p1.Y - p2.Y;
            dX *= dX;
            dY *= dY;
            double dist = Math.Pow((dX + dY), .5);

            return dist;
        }

        public int[,] AdjacencyMatrix
        {
            get
            {
                adjacencyMatrix = new int[NumberOfVertices, NumberOfVertices];
                foreach (Vertex v in vertices)
                {
                    foreach (Vertex n in v.Neighbors)
                    {
                        adjacencyMatrix[v.indexInGraph(), n.indexInGraph()] = 1;
                    }
                }
                return adjacencyMatrix;
            }
        }

        public string adjacencyMatrixStringBasic()
        {
            string output = "";
            int[,] adj = AdjacencyMatrix;

            for (int i = 0; i < NumberOfVertices; i++)
            {
                for (int j = 0; j < NumberOfVertices; j++)
                {
                    output += "" + adj[i, j] + " ";
                }
                output = output.Substring(0, output.Length - 1);
                output += "\n";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
    }
}
