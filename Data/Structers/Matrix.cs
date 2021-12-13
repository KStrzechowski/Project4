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

        public double[] GetColumn(int i) =>
            Enumerable.Range(0, Values.GetLength(1))
                .Select(x => Values[x, i])
                .ToArray();

        public double[] GetRow(int i) =>
            Enumerable.Range(0, Values.GetLength(1))
                .Select(x => Values[i, x])
                .ToArray();
    }
}
