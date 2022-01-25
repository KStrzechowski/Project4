using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.GraphicObjects
{
    public class Edge : BaseGraphicObject
    {
        public Vertice _firstVertice;
        public Vertice _secondVertice;
        public bool Selected { get; set; }
        public Edge(Vertice first, Vertice second)
        {
            _firstVertice = first;
            _secondVertice = second;
            this.Color = Color.Black;
        }

        public double GetLength() => Helpful.GetDistance(_firstVertice.Location, _secondVertice.Location);

        public override void Draw() => Helpful.DrawLine(Graphics, this.Color, _firstVertice.Location, _secondVertice.Location);

        public void SetGraphics(Graphics graphics) => Graphics = graphics;
    }
}
