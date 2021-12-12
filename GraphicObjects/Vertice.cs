using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.GraphicObjects
{
    public class Vertice : IGraphicObject
    {
        public Point Location { get; set; }
        public bool Selected { get; set; }
        public Graphics Graphic { get; set; }

        public Vertice(Point location)
        {
            Location = location;
        }

        public bool CheckIfClicked(Point point)
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            int radius = 5;
            if (Selected)
                Helpful.DrawPoint(Graphic, Color.Black, Location, radius);
            else
                Helpful.DrawPoint(Graphic, Color.Orange, Location, radius);
        }

        public void Move(Point startingPoint, Point endingPoint)
        {
            var position = new Point(endingPoint.X + (Location.X - startingPoint.X),
                endingPoint.Y + (Location.Y - startingPoint.Y));
            Location = position;
        }
    }
}
