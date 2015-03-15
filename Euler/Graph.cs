using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Euler
{
    [Serializable]
    public class Graph
    {
        public static Graph deserialize(string serializedGraph)
        {
            Graph newGraph = null;
            
            FileStream fs = new FileStream(serializedGraph, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                newGraph = (Graph)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            return newGraph;
        }

        private string name = "Untitled";
        private List<Vertex> vertices;
        private Color backgroundColor = Color.White;
        private Color defaultVertexColor = Color.ForestGreen;
        private Color vertexLabelColor = Color.Black;
        private int defaultVertexSize = 10;
        private SquareMatrix adjacencyMatrix;
        private bool vertexLabelVisible = true;
        private Font vertexLabelFont = SystemFonts.DefaultFont;
        private bool graphLabelVisible = true;
        private Font graphLabelFont = new Font(SystemFonts.DefaultFont.FontFamily, 24);
        private Color edgeColor = Color.Black;
        private int edgeWidth = 2;

        public string Name 
        {
            get
            {
                return name;
            } 
            set
            {
                name = value;
            }
        }

        public bool GraphLabelVisible
        {
            get
            {
                return graphLabelVisible;
            }

            set
            {
                graphLabelVisible = value;
            }
        }

        public Font GraphLabelFont
        {
            get
            {
                return graphLabelFont;
            }

            set
            {
                graphLabelFont = value;
            }
        }

        public Color EdgeColor
        {
            get
            {
                return edgeColor;
            }

            set 
            {
                edgeColor = value;
            }
        }

        public int EdgeWidth
        {
            get
            {
                return edgeWidth;
            }

            set
            {
                edgeWidth = value;
            }
        }

        public Font VertexLabelFont
        {
            get
            {
                return vertexLabelFont;
            }

            set
            {
                vertexLabelFont = value;
            }
        }

        public bool VertexLabelVisible
        {
            get
            {
                return vertexLabelVisible;
            }

            set 
            {
                vertexLabelVisible = value;
            }
        }

        public Color VertexLabelColor
        {
            get 
            {
                return vertexLabelColor;
            }

            set
            {
                vertexLabelColor = value;
            }
        }

        public int DefaultVertexSize
        {
            get
            {
                return defaultVertexSize;
            }

            set
            {
                if (value < 5)
                {
                    MessageBox.Show("Too small: cannot be less than 5.");
                }
                else
                {
                    defaultVertexSize = value;

                    DialogResult result = MessageBox.Show("Change existing vertices' radii to " + value + " as well?", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        foreach (Vertex v in vertices)
                        {
                            v.Radius = defaultVertexSize;
                        }
                    }
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

        public Boolean enoughRoomExcludingSelected(int x, int y, Vertex selected)
        {
            Boolean room = true;

            Point clickPoint = new Point(x, y);

            foreach (Vertex v in vertices)
            {
                if (!selected.Equals(v) && distanceBetween(v.Location, clickPoint) < (v.Radius + selected.Radius + 4))
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

        [Browsable(false)]
        public SquareMatrix AdjacencyMatrix
        {
            get
            {
                adjacencyMatrix = new SquareMatrix(this);
                return adjacencyMatrix;
            }
        }

        public Rectangle imageDomain()
        {
            if (vertices.Count == 0)
                return new Rectangle(new Point(0, 0), new Size(10, 10));

            Rectangle domain;

            int leftMost = vertices.ElementAt(0).X - vertices.ElementAt(0).Radius;
            int rightMost = vertices.ElementAt(0).X + vertices.ElementAt(0).Radius;
            int topMost = vertices.ElementAt(0).Y - vertices.ElementAt(0).Radius;
            int bottomMost = vertices.ElementAt(0).Y + vertices.ElementAt(0).Radius;

            foreach (Vertex v in vertices)
            {
                if (v.X - v.Radius < leftMost)
                    leftMost = v.X - v.Radius;
                else if (v.X + v.Radius > rightMost)
                    rightMost = v.X + v.Radius;

                if (v.Y - v.Radius < topMost)
                    topMost = v.Y - v.Radius;
                else if (v.Y + v.Radius > bottomMost)
                    bottomMost = v.Y + v.Radius;
            }

            domain = new Rectangle(new Point(leftMost, topMost), new Size(rightMost - leftMost, bottomMost - topMost));

            return domain;
        }

        public Boolean serialize(string saveFile)
        {
            Boolean success = true;
            FileStream fs = new FileStream(saveFile, FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, this);
            }
            catch (SerializationException e)
            {
                success = false;
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            return success;
        }
    }
}
