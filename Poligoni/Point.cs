﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poligoni
{
    internal class Point
    {
        float x, y;

        public Point(float l_x, float l_y)
        {
            x = l_x;
            y = l_y;
        }

        public override string ToString()
        {
            return $"{x} {y}";
        }
    }
}