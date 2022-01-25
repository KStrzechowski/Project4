using Project4.Data.Structures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.GraphicObjects.Objects3D
{
    public class Tetrahedron : BaseObject3D
    {
        private int n = 4;
        public Tetrahedron(Camera camera, CustomVector position, int size) : base(camera, position, size)
        {
        }
        
        public override void InitializePoints()
        {
            points = new CustomVector[4];
            points[0] = new CustomVector(new double[] { 0, 0, 0, 1});
            points[1] = new CustomVector(new double[] { 1, 0, 0, 1 });
            points[2] = new CustomVector(new double[] { 0, 1, 0, 1 });
            points[3] = new CustomVector(new double[] { 0, 0, 1, 1 });

            for (int i = 0; i < 4; i++)
                points[i] = new CustomVector(new double[] { 15 + points[i][0], 3 + points[i][1], points[i][2], 1 });
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
            triangles = new Triangle[4];
            triangles[0] = new Triangle(points[0], points[2], points[1]);
            triangles[1] = new Triangle(points[0], points[3], points[2]);
            triangles[2] = new Triangle(points[1], points[2], points[3]);
            triangles[3] = new Triangle(points[0], points[1], points[3]);
        }

        public override void Draw()
        {
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
