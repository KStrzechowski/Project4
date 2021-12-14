using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.GraphicObjects.Figures
{
    public abstract class BasePolygon : IGraphicObject
    {
        public List<Vertice> Vertices;
        public bool Selected { get; set; }
        public Graphics Graphics { get; private set; }
        public Color Color { get; set; }
        public BasePolygon(Graphics graphics)
        {
            this.Graphics = graphics;
            Vertices = new List<Vertice>();
            this.Color = Color.Black;
        }

        public virtual bool CheckIfClicked(Point point)
        {
            bool result = false;
            int j = Vertices.Count() - 1;
            for (int i = 0; i < Vertices.Count(); i++)
            {
                if (Vertices[i].Location.Y < point.Y && Vertices[j].Location.Y >= point.Y
                    || Vertices[j].Location.Y < point.Y && Vertices[i].Location.Y >= point.Y)
                {
                    if (Vertices[i].Location.X + (point.Y -
                        (double)Vertices[i].Location.Y) / ((double)Vertices[j].Location.Y -
                        Vertices[i].Location.Y) * (Vertices[j].Location.X - Vertices[i].Location.X)
                        < point.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        public virtual void Draw()
        {
            if (Vertices.Count < 3)
                return;
            Color color = Selected ? Color.Blue : this.Color;

            foreach (var vertice in Vertices)
                vertice.Draw();

            for (int i = 0; i < Vertices.Count - 1; i++)
                Helpful.DrawLine(this.Graphics, color, Vertices[i].Location, Vertices[i + 1].Location);
            Helpful.DrawLine(this.Graphics, color, Vertices[^1].Location, Vertices[0].Location);
        }

        public virtual void Move(Point startingPoint, Point endingPoint)
        {
            foreach (var vertice in Vertices)
            {
                vertice.Move(startingPoint, endingPoint);
            }
        }

        public virtual void AddVertice(Vertice vertice)
        {
            Vertices.Add(vertice);
            vertice.SetGraphics(Graphics);
        }

        public void SetGraphics(Graphics graphics)
        {
            this.Graphics = graphics;
            foreach (var vertice in Vertices)
            {
                vertice.SetGraphics(graphics);
            }
        }
    }
}
