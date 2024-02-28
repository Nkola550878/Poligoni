using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poligoni
{
    internal class Vertex
    {
        float x, y;
        public float X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public float Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public Vertex(float l_x, float l_y)
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
