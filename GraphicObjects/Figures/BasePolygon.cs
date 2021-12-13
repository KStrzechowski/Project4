using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.GraphicObjects.Figures
{
    public abstract class BasePolygon : IShape, IGraphicObject
    {
        protected List<Vertice> _vertices;
        public bool Selected { get; set; }
        public Graphics Graphics { get; set; }
        public Color Color { get; set; }
        public BasePolygon()
        {
            _vertices = new List<Vertice>();
            this.Color = Color.Black;
        }

        public virtual bool CheckIfClicked(Point point)
        {
            bool result = false;
            int j = _vertices.Count() - 1;
            for (int i = 0; i < _vertices.Count(); i++)
            {
                if (_vertices[i].Location.Y < point.Y && _vertices[j].Location.Y >= point.Y
                    || _vertices[j].Location.Y < point.Y && _vertices[i].Location.Y >= point.Y)
                {
                    if (_vertices[i].Location.X + (point.Y -
                        (double)_vertices[i].Location.Y) / ((double)_vertices[j].Location.Y -
                        _vertices[i].Location.Y) * (_vertices[j].Location.X - _vertices[i].Location.X)
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
            if (_vertices.Count < 3)
                return;
            Color color = Selected ? Color.Blue : this.Color;

            foreach (var vertice in _vertices)
                vertice.Draw();

            for (int i = 0; i < _vertices.Count - 1; i++)
                Helpful.DrawLine(this.Graphics, color, _vertices[i].Location, _vertices[i + 1].Location);
            Helpful.DrawLine(this.Graphics, color, _vertices[^1].Location, _vertices[0].Location);
        }

        public virtual void Move(Point startingPoint, Point endingPoint)
        {
            foreach (var vertice in _vertices)
            {
                vertice.Move(startingPoint, endingPoint);
            }
        }
    }
}
