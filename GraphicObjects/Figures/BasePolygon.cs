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
        public BasePolygon()
        {

        }

        public virtual bool CheckIfClicked(Point point)
        {
            throw new NotImplementedException();
        }

        public virtual void Draw()
        {
            throw new NotImplementedException();
        }

        public virtual void Move(Point startingPoint, Point endingPoint)
        {
            throw new NotImplementedException();
        }

        public virtual void Select()
        {
            throw new NotImplementedException();
        }

        public virtual void UnSelect()
        {
            throw new NotImplementedException();
        }
    }
}
