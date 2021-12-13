using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.GraphicObjects
{
    public class Edge : IGraphicObject
    {
        public Vertice _firstVertice;
        public Vertice _secondVertice;
        public bool Selected { get; set; }
        public Graphics Graphics { get; set; }
        public Color Color { get; set; }
        public Edge(Vertice first, Vertice second)
        {
            _firstVertice = first;
            _secondVertice = second;
            this.Color = Color.Black;
        }

        public double GetLength() => Helpful.GetDistance(_firstVertice.Location, _secondVertice.Location);

        public bool CheckIfClicked(Point position)
        {
            if (GetLength() + 3 >= (Helpful.GetDistance(_firstVertice.Location, position)
                + Helpful.GetDistance(_secondVertice.Location, position)))
                return true;
            else
                return false;
        }

        public void Draw() => Helpful.DrawLine(this.Graphics, this.Color, _firstVertice.Location, _secondVertice.Location);

        public void Move(Point startingPoint, Point endingPoint)
        {
            _firstVertice.Move(startingPoint, endingPoint);
            _secondVertice.Move(startingPoint, endingPoint);
        }
    }
}
