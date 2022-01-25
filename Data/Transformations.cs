using Project4.Data.Structures;
using Project4.GraphicObjects.Objects3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Data
{
    public static class Transformations
    {
        public static void Scaling(this BaseObject3D object3D, CustomVector vector)
        {
            var scalingMatrix = new Matrix(4, 4);
            scalingMatrix[0, 0] = vector[0];
            scalingMatrix[1, 1] = vector[1];
            scalingMatrix[2, 2] = vector[2];
            scalingMatrix[3, 3] = 1;

            ApplyTransformation(object3D, scalingMatrix);
        }

        public static void Translation(this BaseObject3D object3D, CustomVector vector)
        {
            var translationMatrix = new Matrix(4, 4);
            translationMatrix[0, 0] = 1;
            translationMatrix[1, 1] = 1;
            translationMatrix[2, 2] = 1;
            translationMatrix[3, 3] = 1;

            translationMatrix[0, 3] = vector[0];
            translationMatrix[1, 3] = vector[1];
            translationMatrix[2, 3] = vector[2];
            
            ApplyTransformation(object3D, translationMatrix);
        }

        public static void RotateX(this BaseObject3D object3D, double angle)
        {
            var rotationMatrix = new Matrix(4, 4);
            rotationMatrix[0, 0] = 1;

            rotationMatrix[1, 1] = Math.Cos(angle);
            rotationMatrix[1, 2] = -Math.Sin(angle);
            rotationMatrix[2, 1] = Math.Sin(angle);
            rotationMatrix[2, 2] = Math.Cos(angle);
            
            rotationMatrix[3, 3] = 1;

            ApplyTransformation(object3D, rotationMatrix);
        }

        public static void RotateY(this BaseObject3D object3D, double angle)
        {
            var rotationMatrix = new Matrix(4, 4);
            rotationMatrix[1, 1] = 1;

            rotationMatrix[0, 0] = Math.Cos(angle);
            rotationMatrix[0, 2] = -Math.Sin(angle);
            rotationMatrix[2, 0] = Math.Sin(angle);
            rotationMatrix[2, 2] = Math.Cos(angle);

            rotationMatrix[3, 3] = 1;

            for (int i = 0; i < object3D.points.Length; i++)
            {
                object3D.points[i] = rotationMatrix * object3D.points[i];
            }
            object3D.CreateTriangles();
        }

        public static void RotateZ(this BaseObject3D object3D, double angle)
        {
            var rotationMatrix = new Matrix(4, 4);
            rotationMatrix[0, 0] = Math.Cos(angle);
            rotationMatrix[0, 1] = -Math.Sin(angle);
            rotationMatrix[1, 0] = Math.Sin(angle);
            rotationMatrix[1, 1] = Math.Cos(angle);

            rotationMatrix[2, 2] = 1;
            rotationMatrix[3, 3] = 1;

            ApplyTransformation(object3D, rotationMatrix);
        }

        public static void ApplyTransformation(this BaseObject3D object3D, Matrix matrix)
        {
            for (int i = 0; i < object3D.points.Length; i++)
            {
                object3D.points[i] = matrix * object3D.points[i];
            }
            object3D.center = matrix * object3D.center;
            object3D.CreateTriangles();
        }
    }
}
