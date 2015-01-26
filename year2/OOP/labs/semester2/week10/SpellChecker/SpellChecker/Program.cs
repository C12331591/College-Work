using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpellChecker
{
    class CMatrix
    {
        private int rows, cols;

        public int Cols
        {
            get { return cols; }
            set { cols = value; }
        }

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }
        private float[,] elements;

        public CMatrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            elements = new float[rows, cols];
        }

        public float Get(int row, int col)
        {
            return elements[row, col];
        }
        public void Set(int row, int col, float value)
        {
            elements[row, col] = value;
        }

        public static CMatrix operator +(CMatrix a, CMatrix b)
        {
            CMatrix ret = new CMatrix(a.Rows, a.Cols);
            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < a.Cols; col++)
                {
                    ret.Set(row, col, a.Get(row, col) + b.Get(row, col));
                }
            }
            return ret;
        }

        public static CMatrix operator -(CMatrix a)
        {
            CMatrix ret = new CMatrix(a.Rows, a.Cols);
            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < a.Cols; col++)
                {
                    ret.Set(row, col, -a.Get(row, col));
                }
            }
            return ret;
        }

        public static CMatrix operator -(CMatrix a, CMatrix b)
        {
            return a + (-b);
        }

        public void Identity()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    if (row == col)
                    {
                        Set(row, col, 1);
                    }
                    else
                    {
                        Set(row, col, 0);
                    }
                }
            }
        }

        public static bool operator ==(CMatrix a, CMatrix b)
        {
            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < a.Cols; col++)
                {
                    if (a.Get(row, col) != b.Get(row, col))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator !=(CMatrix a, CMatrix b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            string ret = "";
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    ret += "" + Get(row, col) + " ";
                }
                ret += "\n";
            }
            return ret;
        }

        public static CMatrix operator *(CMatrix a, CMatrix b)
        {
            CMatrix ret = new CMatrix(a.Rows, b.Cols);

            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < b.Cols; col++)
                {
                    float sum = 0.0f;
                    for (int i = 0; i < a.Cols; i++)
                    {
                        sum += a.Get(row, i) * b.Get(i, col);
                    }
                    ret.Set(row, col, sum);
                }
            }

            return ret;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this == (CMatrix)obj;
        }
    }

    class EditDistance
    {
        public static float Min3(float a, float b, float c)
        {
            float min = a;

            if (b < min)
            {
                min = b;
            }

            if (c < min)
            {
                min = c;
            }

            return min;
        }

        public static float MinimumEditDistance(string a, string b)
        {
            CMatrix matrix = new CMatrix(a.Length + 1, b.Length + 1);

            for (int i = 0; i <= a.Length; i++)
            {
                matrix.Set(i, 0, i);
            }

            for (int i = 0; i <= b.Length; i++)
            {
                matrix.Set(0, i, i);
            }

            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    float rightDiagonal = float.MaxValue;

                    if (j < b.Length)//this is needed to avoid an out of bounds exception
                    {
                        rightDiagonal = matrix.Get(i - 1, j + 1);
                    }

                    if (a[i - 1] == b[j - 1])
                    {
                        if (matrix.Get(i - 1, j - 1) < rightDiagonal)
                        {
                            matrix.Set(i, j, matrix.Get(i - 1, j - 1));
                        }
                        else
                        {
                            matrix.Set(i, j, matrix.Get(i - 1, j + 1));
                        }
                    }
                    else
                    {
                        matrix.Set(i, j, Min3(matrix.Get(i - 1, j) + 1.0f, matrix.Get(i - 1, j - 1) + 1.0f, matrix.Get(i, j - 1) + 1.0f));
                    }
                }
            }

            //Console.WriteLine(matrix);
            //not required right now

            return matrix.Get(a.Length, b.Length);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string input = " ";

            while (input != "")
            {
                Console.WriteLine("Enter a Word:");
                input = Console.ReadLine();

                string best = spellCheck(input);

                if (input.ToLower() == best.ToLower())
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Did you mean {0}?", best);
                }
            }
        }

        public static string spellCheck(string input)
        {
            string[] words = System.IO.File.ReadAllLines("words.txt");
            string best = "";
            float bestDist = float.MaxValue;

            foreach (string cur in words)
            {
                float curDist = EditDistance.MinimumEditDistance(cur, input);

                if (curDist == 0.0f)
                {
                    return cur;
                }
                if (curDist < bestDist)
                {
                    best = cur;
                    bestDist = curDist;
                }
            }

            return best;
        }
    }
}
