using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.GraphicObjects
{
    public interface IGraphicObject
    {
        void Draw();
        void Select();
        void UnSelect();
        public void Move(Point startingPoint, Point endingPoint);
        public bool CheckIfClicked(Point point);
    }
}
