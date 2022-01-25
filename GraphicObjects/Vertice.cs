using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.GraphicObjects
{
    public class Vertice : BaseGraphicObject
    {
        public Point Location { get; set; }
        public bool Selected { get; set; }

        public Vertice(Point location)
        {
            Location = location;
            this.Color = Color.Orange;
        }

        public override void Draw()
        {
            int radius = 5;
            Color color = Selected ? Color.Blue : this.Color;
            
            if (Selected)
                Helpful.DrawPoint(Graphics, color, Location, radius);
            else
                Helpful.DrawPoint(Graphics, color, Location, radius);
        }

        public void SetGraphics(Graphics graphics) => Graphics = graphics;
    }
}
