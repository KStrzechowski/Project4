using Project4.Data;
using Project4.Data.Structures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.GraphicObjects.Objects3D
{
    public class Diamond : BaseObject3D
    {
        private int n = 14;
        public Diamond(Camera camera, CustomVector position, int size) : base(camera, position, size)
        {
        }

        public override void InitializePoints()
        {
            points = new CustomVector[n];
            points[0] = new CustomVector(new double[] { 0, -2.5 * _size, 0, 1 });

            points[1] = new CustomVector(new double[] { -_size, -_size, -_size, 1 });
            points[2] = new CustomVector(new double[] { _size, -_size, -_size, 1 });
            points[3] = new CustomVector(new double[] { _size, -_size, _size, 1 });
            points[4] = new CustomVector(new double[] { -_size, -_size, _size, 1 });

            points[5] = new CustomVector(new double[] { 0, 0, -1.5 * _size, 1 });
            points[6] = new CustomVector(new double[] { 1.5 * _size, 0, 0, 1 });
            points[7] = new CustomVector(new double[] { 0, 0, 1.5 * _size, 1 });
            points[8] = new CustomVector(new double[] { -1.5 * _size, 0, 0, 1 });

            points[9] = new CustomVector(new double[] { -_size, _size, -_size, 1 });
            points[10] = new CustomVector(new double[] { _size, _size, -_size, 1 });
            points[11] = new CustomVector(new double[] { _size, _size, _size, 1 });
            points[12] = new CustomVector(new double[] { -_size, _size, _size, 1 });

            points[13] = new CustomVector(new double[] { 0, 2.5 * _size, 0, 1 });
        }
        public override void ApplyPosition()
        {
            for (int i = 0; i < n; i++)
            {
                points[i] = new CustomVector(new double[] { points[i][0] + center[0], points[i][1] + center[1], points[i][2] + center[2], 1 });
            }
        }

        public override void CreateTriangles()
        {
            triangles = new Triangle[24];

            for (int i = 0; i < 4; i++)
                triangles[i] = new Triangle(points[0], points[i + 1], (i + 2 != 5 ? points[i + 2] : points[1]), Color.Yellow);

            {
                triangles[4] = new Triangle(points[1], points[5], points[2], Color.Green);
                triangles[5] = new Triangle(points[2], points[5], points[10], Color.Green);
                triangles[6] = new Triangle(points[10], points[5], points[9], Color.Green);
                triangles[7] = new Triangle(points[9], points[5], points[1], Color.Green);
            }
            {
                triangles[8] = new Triangle(points[2], points[6], points[3], Color.Blue);
                triangles[9] = new Triangle(points[3], points[6], points[11], Color.Blue);
                triangles[10] = new Triangle(points[11], points[6], points[10], Color.Blue);
                triangles[11] = new Triangle(points[10], points[6], points[2], Color.Blue);
            }
            {
                triangles[12] = new Triangle(points[3], points[7], points[4], Color.Red);
                triangles[13] = new Triangle(points[4], points[7], points[12], Color.Red);
                triangles[14] = new Triangle(points[12], points[7], points[11], Color.Red);
                triangles[15] = new Triangle(points[11], points[7], points[3], Color.Red);
            }
            {
                triangles[16] = new Triangle(points[4], points[8], points[1], Color.Orange);
                triangles[17] = new Triangle(points[1], points[8], points[9], Color.Orange);
                triangles[18] = new Triangle(points[9], points[8], points[12], Color.Orange);
                triangles[19] = new Triangle(points[12], points[8], points[4], Color.Orange);
            }


            for (int i = 0; i < 4; i++)
                triangles[20 + i] = new Triangle(points[9 + i], points[13], (10 + i != 13 ? points[10 + i] : points[9]), Color.Purple);
        }

        public override void Draw()
        {
            var visionVector = camera.Target - camera.Position;

            foreach (var triangle in triangles)
            {
                var result = new Triangle(new CustomVector(triangle[0].Values),
                    new CustomVector(triangle[1].Values), new CustomVector(triangle[2].Values), triangle.Color);
                result = ApplyTransformations(result);
                result[0].Normalize();
                result[1].Normalize();
                result[2].Normalize();

                result = ProjectingToScreen(result);

                var normalVector = Calculations.NormalVectorFromTriangle(result);
                if (visionVector * normalVector > 0)
                {
                    result.Draw();
                }
            }
        }
    }
}
