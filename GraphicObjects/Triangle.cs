using Project4.Data.Structures;
using Project4.GraphicObjects.Objects3D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.GraphicObjects
{
    public class Triangle : BaseGraphicObject
    {
        private CustomVector[] vertices;

        public Triangle()
        {
            vertices = new CustomVector[3];
            vertices[0] = new CustomVector(4);
            vertices[1] = new CustomVector(4);
            vertices[2] = new CustomVector(4);
        }

        public Triangle(CustomVector point1, CustomVector point2, CustomVector point3)
        {
            vertices = new CustomVector[3];
            vertices[0] = point1;
            vertices[1] = point2;
            vertices[2] = point3;
        }

        public Triangle(CustomVector point1, CustomVector point2, CustomVector point3, Color color)
        {
            vertices = new CustomVector[3];
            vertices[0] = point1;
            vertices[1] = point2;
            vertices[2] = point3;
            Color = color;
        }



        public CustomVector this[int a]
        {
            get => vertices[a];
            set => vertices[a] = value;
        }

        public void SetGraphics(Graphics graphics) => Graphics = graphics;

        public override void Draw()
        {
            var points = new CustomVector[3];
            // Creating new array, because we don't want to change original order of vertices
            for (int i = 0; i < 3; i++)
                points[i] = new CustomVector(new double[]{ vertices[i][0], -vertices[i][1], -vertices[i][2] });
            // Sorting vertices by y coordinate
            points = points.OrderBy(x => x[1]).ToArray();

            var distance1 = CalculateDistance2D(points[0], points[1]);
            var distance2 = CalculateDistance2D(points[0], points[2]);
            var distance3 = CalculateDistance2D(points[1], points[2]);

            for (int y = (int)points[0][1] + 1; y <= (int)points[1][1]; y++)
            {
                var vector1 = CalculatePointPosition(points[0], points[1], y, distance1);
                var vector2 = CalculatePointPosition(points[0], points[2], y, distance2);
                ColorLine(vector1, vector2);
            }

            for (int y = (int)points[1][1] + 1; y <= (int)points[2][1]; y++) 
            {
                var vector1 = CalculatePointPosition(points[1], points[2], y, distance2);
                var vector2 = CalculatePointPosition(points[0], points[2], y, distance3);
                ColorLine(vector1, vector2);
            }
        }

        public void ColorLine(CustomVector vector1, CustomVector vector2)
        {
            int y = (int)vector1[1];
            double x1, x2, z1, z2;
            if (y < 0 || y >= ScreenHeight)
                return;
            if (vector1[0] > vector2[0])
            {
                var temp = vector1;
                vector1 = vector2;
                vector2 = temp;
            }
            x1 = vector1[0];
            x2 = vector2[0];
            z1 = vector1[2];
            z2 = vector2[2];

            double distance = x2 - x1;
            for (int i = (int)x1; i <= (int)x2; i++)
            {
                if (i >= 0 && i < ScreenWidth)
                {
                    var ratio = (i - x1) / distance;
                    var z = (z1 * ratio + z2 * (1 - ratio));

                    if (ZBuffor[i, y] > z)
                    {
                        ZBuffor[i, y] = z;
                        Bitmap.SetPixel(i, y, Color);
                    }
                }
            }
        }

        private CustomVector CalculatePointPosition(CustomVector vector1, CustomVector vector2, int height, double distance)
        {
            var result = new CustomVector(3);
            result[1] = height;
            if (vector1[0] > vector2[0])
            {
                var temp = vector1;
                vector1 = vector2;
                vector2 = temp;
            }
            if (vector1[0] == vector2[0])
            {
                result[0] = vector1[0];
                result[2] = vector1[2];
                return result;
            }
    

            result[0] = (vector1[0] + Math.Abs(
                (vector1[1] - height) * 
                (vector1[0] - vector2[0]) / 
                (vector1[1] - vector2[1])
            ));
            double ratio = Math.Abs((vector1[1] - height) / distance);
            result[2] = vector1[2] * ratio + vector2[2] * (1 - ratio);
            return result;
        }

        private double CalculateDistance2D(CustomVector vector1, CustomVector vector2)
        {
            var diffrence = vector1 - vector2;
            return Math.Sqrt(
                (diffrence[0] * diffrence[0]) +
                (diffrence[1] * diffrence[1])
            );
        }
    }
}