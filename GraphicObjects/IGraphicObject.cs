﻿using System;
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
        bool Selected { get; set; }
        Graphics Graphic { get; set; }
        public void Move(Point startingPoint, Point endingPoint);
        public bool CheckIfClicked(Point point);
    }

    public static class Helpful
    {
        public static double GetDistance(Point first, Point second) => 
            Math.Floor((Math.Sqrt(Math.Pow(first.X - second.X, 2) +
            Math.Pow(first.Y - second.Y, 2))));

        public static void DrawLine(Graphics graphics, Color color, Point first, Point second) =>
            graphics.DrawLine(new Pen(new SolidBrush(color)), first, second);
    }
}
