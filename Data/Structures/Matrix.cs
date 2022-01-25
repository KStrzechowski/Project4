using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Data.Structures
{
    public class Matrix
    {
        public double[,] Values { get; set; }
        public Matrix(double[,] values)
        {
            Values = values;
        }

        public Matrix(int height, int width)
        {
            Values = new double[height, width];
        }

        public double this[int a, int b]
        {
            get => Values[a, b];
            set => Values[a, b] = value;
        }

        public double[] GetColumn(int i) =>
            Enumerable.Range(0, Values.GetLength(1))
                .Select(x => Values[x, i])
                .ToArray();

        public double[] GetRow(int i) =>
            Enumerable.Range(0, Values.GetLength(1))
                .Select(x => Values[i, x])
                .ToArray();

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Values.GetLength(1) != matrix2.Values.GetLength(0))
                throw new ArgumentException();

            Matrix resultMatrix = new Matrix(matrix1.Values.GetLength(0), matrix2.Values.GetLength(1));
            for (int i = 0; i < resultMatrix.Values.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.Values.GetLength(1); j++)
                {
                    resultMatrix.Values[i, j] = Calculations.Multiply(matrix1.GetRow(i), matrix2.GetColumn(j));
                }
            }
            return resultMatrix;
        }

        public static CustomVector operator *(Matrix matrix, CustomVector vector)
        {
            if (!vector.Vertical || matrix.Values.GetLength(1) != vector.Values.Length)
                throw new ArgumentException();

            CustomVector resultVector = new CustomVector(matrix.Values.GetLength(0), true);
            for (int i = 0; i < matrix.Values.GetLength(0); i++)
            {
                resultVector.Values[i] = Calculations.Multiply(matrix.GetRow(i), vector.Values);
            }
            return resultVector;
        }
    }
}
