using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Project4.Data.Structures;
using Project4.GraphicObjects;

namespace Project4.Data
{
    public static class Calculations
    {
       /* public static Matrix Multiply(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.Values.GetLength(1) != secondMatrix.Values.GetLength(0))
                throw new ArgumentException();

            Matrix resultMatrix = new Matrix(firstMatrix.Values.GetLength(0), secondMatrix.Values.GetLength(1));
            for (int i = 0; i < resultMatrix.Values.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.Values.GetLength(1); j++)
                {
                    resultMatrix.Values[i, j] = Multiply(firstMatrix.GetRow(i), secondMatrix.GetColumn(j));
                }
            }
            return resultMatrix;
        }

        public static CustomVector Multiply(CustomVector vector, Matrix matrix)
        {
            if (vector.Vertical || matrix.Values.GetLength(0) != vector.Values.Length)
                throw new ArgumentException();

            CustomVector resultVector = new CustomVector(matrix.Values.GetLength(0), true);
            for (int i = 0; i < matrix.Values.GetLength(1); i++)
            {
                resultVector.Values[i] = Multiply(matrix.GetColumn(i), vector.Values);
            }
            return resultVector;
        }

        public static CustomVector Multiply(Matrix matrix, CustomVector vector)
        {
            if (!vector.Vertical || matrix.Values.GetLength(1) != vector.Values.Length)
                throw new ArgumentException();

            CustomVector resultVector = new CustomVector(matrix.Values.GetLength(0), true);
            for (int i = 0; i < matrix.Values.GetLength(0); i++)
            {
                resultVector.Values[i] = Multiply(matrix.GetRow(i), vector.Values);
            }
            return resultVector;
        }

        public static double Multiply(CustomVector horizontalVector, CustomVector verticalVector)
        {
            if (horizontalVector.Values.Length != verticalVector.Values.Length)
                throw new ArgumentException();

            return Multiply(horizontalVector.Values, verticalVector.Values);
        }*/

        public static double Multiply(double[] horizontal, double[] vertical)
        {
            double result = 0;
            for (int i = 0; i < horizontal.Length; i++)
                result += horizontal[i] * vertical[i];
            return result;
        }

        public static CustomVector VectorProduct(CustomVector vector1, CustomVector vector2)
        {
            var vector = new CustomVector(vector1.Values.Length);
            vector[0] = vector1[1] * vector2[2] - vector1[2] * vector2[1];
            vector[1] = vector1[2] * vector2[0] - vector1[0] * vector2[2];
            vector[2] = vector1[0] * vector2[1] - vector1[1] * vector2[0];
            return vector;
        }

        public static CustomVector NormalVectorFromTriangle(Triangle triangle)
        {
            var U = new CustomVector(new double[] { triangle[1][0] - triangle[0][0], triangle[1][1] - triangle[0][1], triangle[1][2] - triangle[0][2] });
            var V = new CustomVector(new double[] { triangle[2][0] - triangle[0][0], triangle[2][1] - triangle[0][1], triangle[2][2] - triangle[0][2] });

            var Normal = new CustomVector(new double[]
            {
                U[1] * V[2] - U[2] * V[1],
                U[2] * V[0] - U[0] * V[2],
                U[0] * V[1] - U[1] * V[0],
            });

            var l = Math.Sqrt(
                Normal[0] * Normal[0] +
                Normal[1] * Normal[1] +
                Normal[2] * Normal[2]
            );

            if (l != 0)
            {
                Normal[0] = Normal[0] / l;
                Normal[1] = Normal[1] / l;
                Normal[2] = Normal[2] / l;
            }

            return Normal;
        }
    }
}
