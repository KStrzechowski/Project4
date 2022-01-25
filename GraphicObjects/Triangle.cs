using Project4.Data.Structures;
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
        CustomVector[] points;
        public Triangle(CustomVector point1, CustomVector point2, CustomVector point3)
        {
            points = new CustomVector[3];
            points[0] = point1;
            points[1] = point2;
            points[2] = point3;
        }

        public CustomVector this[int a]
        {
            get => points[a];
            set => points[a] = value;
        }

        public void SetGraphics(Graphics graphics) => Graphics = graphics;

        public override void Draw()
        {
            var point1 = new Point((int)points[0][0], -(int)points[0][1]);
            var point2 = new Point((int)points[1][0], -(int)points[1][1]);
            var point3 = new Point((int)points[2][0], -(int)points[2][1]);
       
            Helpful.DrawLine(Graphics, Color, point1, point2);
            Helpful.DrawLine(Graphics, Color, point2, point3);
            Helpful.DrawLine(Graphics, Color, point3, point1);
        }
    }
}