using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Levenshtein
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
}