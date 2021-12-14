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
        public Graphics Graphics { get; private set; }
        public Color Color { get; set; }

        public Vertice(Point location, Graphics graphics)
        {
            this.Graphics = graphics;
            Location = location;
            this.Color = Color.Orange;
        }

        public bool CheckIfClicked(Point point)
        {
            if ((Math.Pow(Location.X - point.X, 2) + Math.Pow(Location.Y - point.Y, 2)) < 50)
                return true;
            else
                return false;
        }

        public void Draw()
        {
            int radius = 5;
            Color color = Selected ? Color.Blue : this.Color;
            
            if (Selected)
                Helpful.DrawPoint(this.Graphics, color, Location, radius);
            else
                Helpful.DrawPoint(this.Graphics, color, Location, radius);
        }

        public void Move(Point startingPoint, Point endingPoint)
        {
            var position = new Point(endingPoint.X + (Location.X - startingPoint.X),
                endingPoint.Y + (Location.Y - startingPoint.Y));
            Location = position;
        }

        public void SetGraphics(Graphics graphics) => Graphics = graphics;
    }
}
