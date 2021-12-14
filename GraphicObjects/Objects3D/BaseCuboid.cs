using Project4.GraphicObjects.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.GraphicObjects.Objects3D
{
    public abstract class BaseCuboid : IGraphicObject
    {
        private BasePolygon _frontPolygon;
        private BasePolygon _backPolygon;
        private int _x;
        private int _y;
        public bool Selected { get; set; }
        public Graphics Graphics { get; private set; }
        public Color Color { get; set; }

        public BaseCuboid(Graphics graphics)
        {
            this.Graphics = graphics;
            this.Color = Color.Black;

            _frontPolygon = new ConcretePolygon(graphics);
            _backPolygon = new ConcretePolygon(graphics);
            _x = 50;
            _y = 50;
        }

        public void AddVertice(Vertice vertice)
        {
            _frontPolygon.AddVertice(vertice);
            _backPolygon.AddVertice(new Vertice(new Point(vertice.Location.X + _x, vertice.Location.Y + _y), this.Graphics));
        }

        public void Draw()
        {
            if (_frontPolygon.Vertices.Count < 3)
                return; 

            _frontPolygon.Draw();
            _backPolygon.Draw();

            for (int i = 0; i < _frontPolygon.Vertices.Count; i++)
            {
                Helpful.DrawLine(this.Graphics, this.Color, _frontPolygon.Vertices[i].Location, _backPolygon.Vertices[i].Location);
            }
        }

        public void Move(Point startingPoint, Point endingPoint)
        {
            _frontPolygon.Move(startingPoint, endingPoint);
            _backPolygon.Move(startingPoint, endingPoint);
        }

        public bool CheckIfClicked(Point point)
        {
            if (_frontPolygon.CheckIfClicked(point) || _backPolygon.CheckIfClicked(point))
                return true;
            else
                return false;
        }

        public void SetGraphics(Graphics graphics)
        {
            this.Graphics = graphics;
            _frontPolygon.SetGraphics(graphics);
            _backPolygon.SetGraphics(graphics);
        }
    }
}
