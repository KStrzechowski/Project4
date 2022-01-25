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
        private int n = 10;
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

            points[5] = new CustomVector(new double[] { -_size, _size, -_size, 1 });
            points[6] = new CustomVector(new double[] { _size, _size, -_size, 1 });
            points[7] = new CustomVector(new double[] { _size, _size, _size, 1 });
            points[8] = new CustomVector(new double[] { -_size, _size, _size, 1 });

            points[9] = new CustomVector(new double[] { 0, 2.5 * _size, 0, 1 });
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
            triangles = new Triangle[16];
            triangles[0] = new Triangle(points[0], points[1], points[2]);
            triangles[1] = new Triangle(points[0], points[2], points[3]);
            triangles[2] = new Triangle(points[0], points[3], points[4]);
            triangles[3] = new Triangle(points[0], points[4], points[1]);

            triangles[4] = new Triangle(points[1], points[2], points[5]);
            triangles[5] = new Triangle(points[2], points[5], points[6]);
            triangles[6] = new Triangle(points[2], points[3], points[6]);
            triangles[7] = new Triangle(points[3], points[6], points[7]);
            triangles[8] = new Triangle(points[3], points[4], points[7]);
            triangles[9] = new Triangle(points[4], points[7], points[8]);
            triangles[10] = new Triangle(points[4], points[1], points[8]);
            triangles[11] = new Triangle(points[1], points[8], points[5]);

            triangles[12] = new Triangle(points[5], points[6], points[9]);
            triangles[13] = new Triangle(points[6], points[7], points[9]);
            triangles[14] = new Triangle(points[7], points[8], points[9]);
            triangles[15] = new Triangle(points[8], points[5], points[9]);
        }

        public override void Draw()
        {
          /*  ApplyTransformations();
            ProjectingToScreen();

            var drawPoints = new Point[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                drawPoints[i] = new Point((int)points[i][0], -(int)points[i][1]);
            }

            Helpful.DrawLine(Graphics, Color.Black, drawPoints[0], drawPoints[1]);
            Helpful.DrawLine(Graphics, Color.Black, drawPoints[0], drawPoints[2]);
            Helpful.DrawLine(Graphics, Color.Black, drawPoints[0], drawPoints[3]);
            Helpful.DrawLine(Graphics, Color.Black, drawPoints[0], drawPoints[4]);

            Helpful.DrawLine(Graphics, Color.Black, drawPoints[1], drawPoints[2]);
            Helpful.DrawLine(Graphics, Color.Black, drawPoints[2], drawPoints[3]);
            Helpful.DrawLine(Graphics, Color.Black, drawPoints[3], drawPoints[4]);
            Helpful.DrawLine(Graphics, Color.Black, drawPoints[4], drawPoints[1]);

            Helpful.DrawLine(Graphics, Color.Black, drawPoints[1], drawPoints[5]);
            Helpful.DrawLine(Graphics, Color.Black, drawPoints[2], drawPoints[6]);
            Helpful.DrawLine(Graphics, Color.Black, drawPoints[3], drawPoints[7]);
            Helpful.DrawLine(Graphics, Color.Black, drawPoints[4], drawPoints[8]);

            Helpful.DrawLine(Graphics, Color.Black, drawPoints[5], drawPoints[6]);
            Helpful.DrawLine(Graphics, Color.Black, drawPoints[6], drawPoints[7]);
            Helpful.DrawLine(Graphics, Color.Black, drawPoints[7], drawPoints[8]);
            Helpful.DrawLine(Graphics, Color.Black, drawPoints[8], drawPoints[5]);

            Helpful.DrawLine(Graphics, Color.Black, drawPoints[5], drawPoints[9]);
            Helpful.DrawLine(Graphics, Color.Black, drawPoints[6], drawPoints[9]);
            Helpful.DrawLine(Graphics, Color.Black, drawPoints[7], drawPoints[9]);
            Helpful.DrawLine(Graphics, Color.Black, drawPoints[8], drawPoints[9]);*/

            foreach (var triangle in triangles)
            {
                var result = new Triangle(new CustomVector(triangle[0].Values),
                    new CustomVector(triangle[1].Values), new CustomVector(triangle[2].Values));
                result = ApplyTransformations(result);
                result = ProjectingToScreen(result);
                result.Draw();
            }
        }
    }
}
