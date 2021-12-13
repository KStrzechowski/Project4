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

        public CustomVector(int size, bool vertical)
        {
            Values = new double[size];
            Vertical = vertical;
        }

        public CustomVector(double[] values, bool vertical)
        {
            Values = values;
            Vertical = vertical;
        }
    }
}
