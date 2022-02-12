using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Project4.Data.Structures;

namespace Project4.GraphicObjects.Objects3D
{
    public class Edge3D : BaseGraphicObject
    {
        public CustomVector _firstVertice;
        public CustomVector _secondVertice;
        public bool Selected { get; set; }
        public Edge3D(CustomVector first, CustomVector second)
        {
            _firstVertice = first;
            _secondVertice = second;
        }

        public double GetLength() => Helpful.GetDistance(_firstVertice, _secondVertice);

        public override void Draw() => Helpful.DrawLine(
            Graphics, 
            this.Color, 
            new Point((int)_firstVertice[0], (int)_firstVertice[1]), 
            new Point((int)_secondVertice[0], (int)_secondVertice[1])
        );

        public void SetGraphics(Graphics graphics) => Graphics = graphics;
    }
}
