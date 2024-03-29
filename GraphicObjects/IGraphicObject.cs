﻿using Project4.Data.Structures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math = System.Math;

namespace Project4.GraphicObjects
{
    public interface IGraphicObject
    {
        void Draw();
        Color Color { get; set; }
    }

    public static class Helpful
    {
        public static double GetDistance(Point first, Point second) => 
            Math.Floor((Math.Sqrt(Math.Pow(first.X - second.X, 2) +
            Math.Pow(first.Y - second.Y, 2))));

        public static double GetDistance(CustomVector first, CustomVector second)
        {
            var diffrence = first - second;
            return Math.Sqrt(
                diffrence[0] * diffrence[0] + 
                diffrence[1] * diffrence[1] + 
                diffrence[2] * diffrence[2]
            );
        }


        public static void DrawPoint(Graphics graphics, Color color, Point point, int radius) =>
            graphics.FillEllipse(new SolidBrush(color), point.X - radius, point.Y - radius, radius * 2, radius * 2);

        public static void DrawLine(Graphics graphics, Color color, Point first, Point second) =>
            graphics.DrawLine(new Pen(new SolidBrush(color)), first, second);
    }
}
