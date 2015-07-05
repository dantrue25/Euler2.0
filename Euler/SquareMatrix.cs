using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Euler
{
    [Serializable]
    public class SquareMatrix
    {
        private int[,] matrix;
        private int n;
        private bool converge;

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
            if (n == 0)
                return "";

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
            if (n == 0)
                return "";

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
            int[,] temp = (int[,])this.matrix.Clone();
            if (p == 1)
                return new SquareMatrix(this.n, temp);

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

        public double getEigenValue()
        {
            if (n == 0)
                throw new Exception("Cannot get an Eigen Value of a graph with no vertices.");
            int[,] A = (int[,])this.matrix.Clone();
            const int maxIterations = 100000;
            // Keeps iterating until the difference of the Eigen vector approximations are less than this
            const double accuracy = 0.0001;

            int count = 0;
            double[] tmp = new double[this.n];
            double[] b = new double[this.n];
            double[] bTemp = new double[this.n];
            double norm = 0;

            for (int i = 0; i < this.n; i++)
            {
                b.SetValue(1, i);
            }

            /* 
                * Main loop: 
                * keeps recalculating the Eigen Vector until either the Euclidean distance between
                * the current iteration and the last iteration is smaller than 'accuracy' or
                * the loop has reached the 'maxIteration' limit.
                */
            while (euclideanDist(b, bTemp) >= accuracy)
            {
                for (int index = 0; index < this.n; index++)
                {
                    bTemp[index] = b[index];
                }

                // calculate the matrix-by-vector product Ab
                for (int i = 0; i < this.n; i++)
                {
                    tmp[i] = 0;
                    for (int j = 0; j < this.n; j++)
                        tmp[i] += A[i, j] * b[j];
                    // dot product of i-th row in A with the column vector b
                }

                // Calculate the length of the resultant vector
                double norm_sq = 0;
                for (int k = 0; k < this.n; k++)
                    norm_sq += tmp[k] * tmp[k];
                norm = Math.Sqrt(norm_sq);

                // If norm is not 0, Normalize tmp, and put it in vector 'b'
                if (norm != 0)
                {
                    for (int l = 0; l < this.n; l++)
                        b[l] = tmp[l] / norm;
                }
                else
                {
                    for (int l = 0; l < this.n; l++)
                        b[l] = 0;
                }

                // Check if iteration count has exceeded the maximum
                count++;
                if (count >= maxIterations)
                {
                    for (int l = 0; l < this.n; l++)
                        A[l, l] += 1;
                    SquareMatrix A2 = new SquareMatrix(this.n, A);
                    return A2.getEigenValue() - 1;
                }
            }

            // Divide each entry in the vector by the last value.
            double divisor = 1;
            for (int i = 0; i < this.n; i++)
            {
                if (b[this.n - 1 - i] != 0)
                {
                    divisor = b[this.n - 1 - i];
                    break;
                }
            }

            for (int x = 0; x < this.n; x++)
            {
                b[x] /= divisor;
            }

            // Set the graph's Eigen value. It is a public variable in this class.
            return norm;
        }

        public double[] getDomEigenVector()
        {
            if (n == 0)
                return null;

            converge = true;

            int[,] A = (int[,])this.matrix.Clone();
            const int maxIterations = 100000;
            // Keeps iterating until the difference of the Eigen vector approximations are less than this
            const double accuracy = 0.0001;

            int count = 0;
            double[] tmp = new double[this.n];
            double[] b = new double[this.n];
            double[] bTemp = new double[this.n];
            double norm = 0;

            for (int i = 0; i < this.n; i++)
            {
                b.SetValue(1, i);
            }

            /* 
             * Main loop: 
             * keeps recalculating the Eigen Vector until either the Euclidean distance between
             * the current iteration and the last iteration is smaller than 'accuracy' or
             * the loop has reached the 'maxIteration' limit.
             */
            while (euclideanDist(b, bTemp) >= accuracy)
            {
                for (int index = 0; index < this.n; index++)
                {
                    bTemp[index] = b[index];
                }

                // calculate the matrix-by-vector product Ab
                for (int i = 0; i < this.n; i++)
                {
                    tmp[i] = 0;
                    for (int j = 0; j < this.n; j++)
                        tmp[i] += A[i, j] * b[j];
                    // dot product of i-th row in A with the column vector b
                }

                // Calculate the length of the resultant vector
                double norm_sq = 0;
                for (int k = 0; k < this.n; k++)
                    norm_sq += tmp[k] * tmp[k];
                norm = Math.Sqrt(norm_sq);

                // If norm is not 0, Normalize tmp, and put it in vector 'b'
                if (norm != 0)
                {
                    for (int l = 0; l < this.n; l++)
                        b[l] = tmp[l] / norm;
                }
                else
                {
                    for (int l = 0; l < this.n; l++)
                        b[l] = 0;
                }

                // Check if iteration count has exceeded the maximum
                count++;
                if (count >= maxIterations)
                {
                    converge = false;

                    for (int l = 0; l < this.n; l++)
                        A[l, l] += 1;
                    SquareMatrix A2 = new SquareMatrix(this.n, A);
                    double[] eigenVec2 = A2.getDomEigenVector();
                    return eigenVec2;
                }
            }

            // Divide each entry in the vector by the last value.
            double divisor = 1;
            for (int i = 0; i < this.n; i++)
            {
                if (b[this.n - 1 - i] >= (1.0/this.n))
                {
                    divisor = b[this.n - 1 - i];
                    break;
                }
            }

            for (int x = 0; x < this.n; x++)
            {
                b[x] /= divisor;
            }

            // Set the graph's Eigen value. It is a public variable in this class.
            //eigenVal = norm;

            return b;
        }

        // Calculate the Euclidean distance between two vectors of the same length
        private double euclideanDist(double[] vect1, double[] vect2)
        {
            if (vect1.Length != vect2.Length)
                throw new Exception();

            int length = vect1.Length;
            double dist = 0.0;

            for (int i = 0; i < this.n; i++)
            {
                dist += Math.Pow((vect1[i] - vect2[i]), 2);
            }

            dist = Math.Sqrt(dist);

            return dist;
        }

        public string getEigenVectorString()
        {
            string output = "";
            double[] eigenVector = this.getDomEigenVector();

            if (eigenVector == null)
                return "";
            
            int length = eigenVector.Length;

            for (int i = 0; i < length; i++)
            {
                output += "" + string.Format("{0:0.000}", eigenVector[i]) + "\n";
            }

            output = output.Substring(0, Math.Max(0, output.Length - 1));

            if (!converge)
                output += "\n\nThis is not the only dominant Eigen Vector.";

            return output;
        }

        public string getEigenValueString()
        {
            double eigenValue = this.getEigenValue();

            return string.Format("{0:0.000}", eigenValue) + "\n";
        }

        public Bitmap makeMatrixImage()
        {
            Form form = new Form();
            Graphics GFX;
            Bitmap matrixImg;
            Bitmap matrExport;
            int[,] matrix = this.matrix;
            String power = "1";

            int maxNumLen;
            int n = (int)Math.Sqrt(matrix.Length);
            if (n == 0)
                return null;

            // Find the largest number in the matrix, then calculate how many digits it contains
            int maxNum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] > maxNum)
                        maxNum = matrix[i, j];
                }
            }

            if (maxNum == 0)
                maxNumLen = 1;
            else
                maxNumLen = (int)(Math.Log10((maxNum + 1) * 1.0) + 1);

            matrixImg = new Bitmap(60 + (30 + 5 * (maxNumLen - 1)) * n, 60 + 30 * n);
            form.Size = new System.Drawing.Size(130 + (30 + 5 * (maxNumLen - 1)) * n, 110 + 30 * n);
            GFX = Graphics.FromImage(matrixImg);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    GFX.DrawString("" + matrix[i, j], new Font("Ariel", 10),
                                   new SolidBrush(Color.Black), new Point(47 + j * (30 + 5 * (maxNumLen - 1)), 42 + i * 30));
                }
            }

            // Left-side matrix notation
            Point start = new Point(30, 50);
            Point end = new Point(30, 20 + n * 30);
            GFX.DrawLine(new Pen(new SolidBrush(Color.Black), 3), start, end);

            GFX.DrawArc(new Pen(new SolidBrush(Color.Black), 3),
                        new Rectangle(start.X, start.Y - 20, 20, 40),
                        180, 90);
            GFX.DrawArc(new Pen(new SolidBrush(Color.Black), 3),
                        new Rectangle(end.X, end.Y - 21, 20, 40),
                        90, 90);

            // Right-side matrix notation
            start = new Point(48 + n * (30 + 5 * (maxNumLen - 1)), 50);
            end = new Point(48 + n * (30 + 5 * (maxNumLen - 1)), 20 + n * 30);
            GFX.DrawLine(new Pen(new SolidBrush(Color.Black), 3), start, end);

            GFX.DrawArc(new Pen(new SolidBrush(Color.Black), 3),
                        new Rectangle(start.X - 20, start.Y - 20, 20, 40),
                        270, 90);
            GFX.DrawArc(new Pen(new SolidBrush(Color.Black), 3),
                        new Rectangle(end.X - 20, end.Y - 21, 20, 40),
                        360, 90);

            Graphics showM = form.CreateGraphics();
            showM.DrawString("A   = ", new Font("Arial", 16), new SolidBrush(Color.Black), 10, (form.Height / 2 - 30));
            if (Convert.ToDecimal(power) != 1)
                showM.DrawString(power, new Font("Arial", 10), new SolidBrush(Color.Black), 25, (form.Height / 2 - 37));
            showM.DrawImage(matrixImg, 40, 0);


            // Create a new Bitmap that has both the matrix and its label (A^x = )
            matrExport = new Bitmap(130 + (30 + 5 * (maxNumLen - 1)) * n, 110 + 30 * n);
            Graphics export = Graphics.FromImage(matrExport);
            export.DrawString("A   = ", new Font("Arial", 16), new SolidBrush(Color.Black), 10, (form.Height / 2 - 30));

            // Do not put power if it is just 1
            if (Convert.ToDecimal(power) != 1)
                export.DrawString(power, new Font("Arial", 10), new SolidBrush(Color.Black), 25, (form.Height / 2 - 37));

            export.DrawImage(matrixImg, 40, 0);


            return matrExport;  // Bitmap of the matrix AND label
        }
    }
}
