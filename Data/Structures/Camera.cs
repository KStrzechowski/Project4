using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Data.Structures
{
    public class Camera
    {
        public CustomVector Position { get; set; }
        public CustomVector Target { get; set; }
        public CustomVector UpWorld { get; set; }
        public CustomVector D { get; set; }
        public CustomVector R { get; set; }
        public CustomVector U { get; set; }
        public int beginningRange;
        public int endingRange;
        public double fieldOfView;
        public Camera(CustomVector position, CustomVector target)
        {
            Position = position;
            Target = target;
            beginningRange = 5;
            endingRange = 150;
            fieldOfView = 0.785398;
            UpWorld = new CustomVector(new double[]{0, 1, 0});
            initializeVectors();
     
        }

        public void initializeVectors()
        {
            var vectorD = new CustomVector(3);
            vectorD[0] = Position[0] - Target[0];
            vectorD[1] = Position[1] - Target[1];
            vectorD[2] = Position[2] - Target[2];
            D = vectorD;
            R = Calculations.VectorProduct(UpWorld, D);
            U = Calculations.VectorProduct(D, R);
            D.Normalize();
            R.Normalize();
            U.Normalize();
        }

        public void ChangePosition(CustomVector vector)
        {
            Position = vector;
            initializeVectors();
        }

        public void ChangeTarget(CustomVector vector)
        {
            Target = vector;
            initializeVectors();
        }
    }
}
