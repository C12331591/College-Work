using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix
{
    public class CMatrix
    {
        private float[,] elements;
        private int rows, cols;

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        public int Cols
        {
            get { return cols; }
            set { cols = value; }
        }

        public CMatrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;

            elements = new float[Rows, Cols];
        }

        public float Get(int row, int col)
        {
            return elements[row, col];
        }

        public void Set(int row, int col, float value)
        {
            elements[row, col] = value;
        }

        public CMatrix Identity()
        {
            CMatrix identity = new CMatrix(rows, rows);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (i == j)
                    {
                        Set(i, j, 1.0f);
                    }
                    else
                    {
                        Set(i, j, 0.0f);
                    }
                }
            }

            return identity;
        }

        public static CMatrix operator +(CMatrix m1, CMatrix m2)
        {
            CMatrix added = new CMatrix(m1.rows, m1.cols);
            
            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m1.cols; j++)
                {
                    added.Set(i, j, m1.Get(i, j) + m2.Get(i, j));
                }
            }

            return added;
        }

        public static CMatrix operator -(CMatrix m)
        {
            CMatrix negative = new CMatrix(m.rows, m.cols);

            for (int i = 0; i < m.rows; i++)
            {
                for (int j = 0; j < m.cols; j++)
                {
                    negative.Set(i, j, -m.Get(i, j));
                }
            }

            return negative;
        }

        public static CMatrix operator -(CMatrix m1, CMatrix m2)
        {
            CMatrix subbed = new CMatrix(m1.rows, m1.cols);

            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m1.cols; j++)
                {
                    subbed.Set(i, j, m1.Get(i, j) - m2.Get(i, j));
                }
            }

            return subbed;
        }

        public static CMatrix operator *(CMatrix m1, CMatrix m2)
        {
            CMatrix multiplied = new CMatrix(m1.rows, m2.cols);

            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m2.cols; j++)
                {
                    //multiplied.Set(i, j, RowByCol(
                }

            }
        }

        private float[] RowByCol(float[] row, float[] col)
        {
            float[] result = new float[row.Length];

            for(int i = 0; i < row.Length; i++)
            {
                result[i] = row[i] * col[i];
            }

            return result;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
