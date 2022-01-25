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
        public bool Vertical { get; private set; }

        public CustomVector(int size, bool vertical = true)
        {
            Values = new double[size];
            Vertical = vertical;
        }

        public CustomVector(double[] values, bool vertical = true)
        {
            Values = values;
            Vertical = vertical;
        }

        public double this[int a]
        {
            get => Values[a];
            set => Values[a] = value;
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
