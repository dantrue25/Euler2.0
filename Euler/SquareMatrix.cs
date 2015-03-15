using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class SquareMatrix
    {
        private int[,] matrix;
        private int n;

        public SquareMatrix(int n)
        {
            this.n = n;
            this.matrix = new int[n, n];
        }

        public SquareMatrix(int n, int[,] matrix)
        {
            this.n = n;
            this.matrix = matrix;
        }

        public SquareMatrix(Graph g)
        {
            this.n = g.NumberOfVertices;
            this.matrix = new int[n, n];

            foreach (Vertex v in g.Vertices)
            {
                foreach (Vertex neighbor in v.Neighbors)
                {
                    this.matrix[v.indexInGraph(), neighbor.indexInGraph()] = 1;
                }
            }
        }

        public string toStringBasic()
        {
            string output = "";

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    output += "" + matrix[i, j] + " ";
                }
                output = output.Substring(0, output.Length - 1);
                output += "\n";
            }
            output = output.Substring(0, Math.Max(0, output.Length - 1));
            return output;
        }

        public string toStringWolframAlpha()
        {
            string output = "{";

            for (int i = 0; i < n; i++)
            {
                output += "{";
                for (int j = 0; j < n; j++)
                {
                    output += "" + matrix[i, j] + ",";
                }
                output = output.Substring(0, output.Length - 1);
                output += "},";
            }
            output = output.Substring(0, output.Length - 1);
            output += "}";
            return output;
        }

        public string toStringMatlab()
        {
            string output = "[";

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    output += "" + matrix[i, j] + " ";
                }
                output = output.Substring(0, output.Length - 1);
                output += "; ";
            }
            output = output.Substring(0, Math.Max(0, output.Length - 2));
            output += "]";
            return output;
        }

        public SquareMatrix toThePower(int p)
        {
            int[,] temp = this.matrix;
            int[,] adjPow = new int[this.n, this.n];
            for (int i = 1; i < p; i++)
            {
                adjPow = new int[n, n];
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                        for (int l = 0; l < n; l++)
                            adjPow[k, l] += temp[k, j] * this.matrix[j, l];

                temp = adjPow;
            }

            return new SquareMatrix(this.n, adjPow);
        }
    }
}
