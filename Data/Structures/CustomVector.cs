using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Data.Structures
{
    public class CustomVector
    {
        public double[] Values { get; set; }
        public int Size { get; private set; }
        public bool Vertical { get; private set; }

        public CustomVector(int size, bool vertical = true)
        {
            Values = new double[size];
            Vertical = vertical;
            Size = size;
        }

        public CustomVector(double[] values, bool vertical = true)
        {
            Values = values;
            Vertical = vertical;
            Size = values.Length;
        }

        public double this[int a]
        {
            get => Values[a];
            set => Values[a] = value;
        }

        public static CustomVector operator -(CustomVector vector1, CustomVector vector2)
        {
            CustomVector result = new CustomVector(vector1.Size);
            for (int i = 0; i < vector1.Size; i++)
                result[i] = vector1[i] - vector2[i];
            return result;
        }

        public static CustomVector operator +(CustomVector vector1, CustomVector vector2)
        {
            CustomVector result = new CustomVector(vector1.Size);
            for (int i = 0; i < vector1.Size; i++)
                result[i] = vector1[i] + vector2[i];
            return result;
        }

        public static double operator *(CustomVector vector1, CustomVector vector2)
        {
            double result = 0;
            for (int i = 0; i < vector1.Size; i++)
                result += vector1[i] * vector2[i];
            return result;
        }

        public void Normalize()
        {
            double V = 0;
            for (int i = 0; i < Values.Length; i++)
            {
                V += Values[i] * Values[i];
            }
            V = Math.Sqrt(V);

            for (int i = 0; i < Values.Length; i++)
            {
                Values[i] = Values[i] / V;
            }
        }
    }
}
