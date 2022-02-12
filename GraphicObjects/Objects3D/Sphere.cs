using Project4.Data;
using Project4.Data.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Project4.GraphicObjects.Objects3D
{
    public class Sphere : BaseObject3D
    {
        private int n;
        public Sphere(Camera camera, CustomVector position, int size) : base(camera, position, size)
        {
        }

        public override void InitializePoints()
        {
            n = 25;
            points = new CustomVector[(n + 1) * (n + 1)];
            double latFactor = Math.PI / n;
            double lonFactor = 2 * Math.PI / n;
            for (int i = 0; i < n + 1; i++)
            {
                double lat = i * latFactor;
                for (int j = 0; j < n + 1; j++)
                {
                    double lon = j * lonFactor;
                    // _size = r of our sphere
                    double x = _size * Math.Sin(lat) * Math.Cos(lon);
                    double y = _size * Math.Cos(lat);
                    double z = _size * Math.Sin(lat) * Math.Sin(lon);
                    points[i * (n + 1) + j] = new CustomVector(new double[] { x, y, z, 1 });
                }
            }
        }

        public override void ApplyPosition()
        {
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    points[i * (n + 1) + j] = new CustomVector(new double[] {
                        points[i * (n + 1) + j][0] + center[0],
                        points[i * (n + 1) + j][1] + center[1],
                        points[i * (n + 1) + j][2] + center[2], 
                        1 
                    });
                }
            }
        }

        public override void CreateTriangles()
        {
            triangles = new Triangle[2 * n * n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    triangles[i * n + j] = new Triangle(
                        points[i * (n + 1) + j],
                        points[i * (n + 1) + j + 1],
                        points[(i + 1) * (n + 1) + j], 
                        Color.Blue
                    );
                    triangles[n * n + i * n + j] = new Triangle(
                        points[(i + 1) * (n + 1) + j],
                        points[i * (n + 1) + j + 1],
                        points[(i + 1) * (n + 1) + j + 1], 
                        Color.Black
                    );
                }
            }
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
