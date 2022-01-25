﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.GraphicObjects
{
    public abstract class BaseGraphicObject : IGraphicObject
    {
        public static Graphics Graphics { get; set; }
        public static Bitmap Bitmap { get; set; }
        public Color color = Color.Black;
        public Color Color { get => color; set => color = value; }
        public abstract void Draw();
    }
}
