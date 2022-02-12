using Project4.Data.Structures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.GraphicObjects.Objects3D
{
    public abstract class BaseObject3D : BaseGraphicObject
    {
        public CustomVector[] points;
        public CustomVector center;
        protected int _size;
        public Triangle[] triangles;

        public Matrix ModelMatrix;
        public Matrix ProjMatrix;
        public Matrix ViewMatrix;

        public double aspect;
        public Camera camera;

        public void ChangeCamera(Camera camera)
        {
            this.camera = camera;
            initializeMatrixes();
        }

        public BaseObject3D(Camera camera, CustomVector position, int size)
        {
            this.camera = camera;
            this._size = size;
            this.center = position;
            InitializePoints();
            ApplyPosition();
            CreateTriangles();
            initializeMatrixes();
        }

        public abstract void InitializePoints();
        public abstract void CreateTriangles();
        public abstract void ApplyPosition();


        private void initializeMatrixes()
        {
            initializeModelMatrix();
            initializeViewMatrix();
            initializeProjectionMatrix();
        }

        private void initializeModelMatrix()
        {
            var matrix = new Matrix(4, 4);
            matrix[0, 0] = 1;
            matrix[1, 1] = 1;
            matrix[2, 2] = 1;
            matrix[3, 3] = 1;
            ModelMatrix = matrix;
        }

        private void initializeViewMatrix()
        {
            var matrix = new Matrix(4, 4);
            matrix[0, 0] = camera.R[0];
            matrix[0, 1] = camera.R[1];
            matrix[0, 2] = camera.R[2];

            matrix[1, 0] = camera.U[0];
            matrix[1, 1] = camera.U[1];
            matrix[1, 2] = camera.U[2];

            matrix[2, 0] = camera.D[0];
            matrix[2, 1] = camera.D[1];
            matrix[2, 2] = camera.D[2];

            matrix[3, 3] = 1;

            var matrix2 = new Matrix(4, 4);
            matrix2[0, 0] = 1;
            matrix2[1, 1] = 1;
            matrix2[2, 2] = 1;
            matrix2[3, 3] = 1;

            matrix2[0, 3] = -camera.Position[0];
            matrix2[1, 3] = -camera.Position[1];
            matrix2[2, 3] = -camera.Position[2];
            ViewMatrix = matrix * matrix2;
        }
        private void initializeProjectionMatrix()
        {
            var matrix = new Matrix(4, 4);
            aspect = Bitmap.Width / Bitmap.Height;
            matrix[0, 0] = (1 / Math.Tan(camera.fieldOfView / 2)) / aspect;
            matrix[1, 1] = (1 / Math.Tan(camera.fieldOfView / 2));
            matrix[2, 2] = (camera.endingRange + camera.beginningRange) / (camera.endingRange - camera.beginningRange);
            matrix[2, 3] = -(2 * camera.endingRange * camera.beginningRange) / (camera.endingRange - camera.beginningRange);
            matrix[3, 2] = 1;
            ProjMatrix = matrix;
        }

        protected void ApplyTransformations()
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i] =  ProjMatrix * (ViewMatrix * (/*ModelMatrix * */points[i]));
            }
        }

        protected void ProjectingToScreen()
        {
            for (int i = 0; i < points.Length; i++)
            {
                var newPoint = points[i];
                for (int j = 0; j < 4; j++)
                    if (newPoint[3] != 0)
                        newPoint[j] /= newPoint[3];

                newPoint[0] = (newPoint[0] + 1) * Bitmap.Width / 2;
                newPoint[1] = (-newPoint[1] - 1) * Bitmap.Height / 2;
                newPoint[2] = (newPoint[2] + 1) / 2;

                points[i] = newPoint;
            }
        }

        protected Triangle ApplyTransformations(Triangle triangle)
        {
            var result = triangle;
            for (int i = 0; i < 3; i++)
            {
                result[i] = ProjMatrix * (ViewMatrix * (ModelMatrix * triangle[i]));
            }
            return result;
        }

        protected Triangle ProjectingToScreen(Triangle triangle)
        {
            var result = triangle;
            for (int i = 0; i < 3; i++)
            { 
                var newPoint = triangle[i];
                for (int j = 0; j < 4; j++)
                    if (newPoint[3] != 0)
                        newPoint[j] /= newPoint[3];

                newPoint[0] = (newPoint[0] + 1) * Bitmap.Width / 2;
                newPoint[1] = (-newPoint[1] - 1) * Bitmap.Height / 2;
                newPoint[2] = (newPoint[2] + 1) / 2;

                result[i] = newPoint;
            }
            return result;
        }

        protected CustomVector ApplyTransformations(CustomVector point)
        {
            return ProjMatrix * (ViewMatrix * (ModelMatrix * point));
        }

        protected CustomVector ProjectingToScreen(CustomVector point)
        {
            var newPoint = point;
            for (int j = 0; j < 4; j++)
                if (newPoint[3] != 0)
                    newPoint[j] /= newPoint[3];

            newPoint[0] = (newPoint[0] + 1) * Bitmap.Width / 2;
            newPoint[1] = (-newPoint[1] - 1) * Bitmap.Height / 2;
            newPoint[2] = (newPoint[2] + 1) / 2;

            return newPoint;
        }
    }
}
