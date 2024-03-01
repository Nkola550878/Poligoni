using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

        public static Vertex Zero
        {
            get
            {
                return new Vertex(0f, 0f);
            }
        }

        public override string ToString()
        {
            return $"{x} {y}";
        }

        public static Vertex operator -(Vertex v1, Vertex v2)
        {
            return new Vertex(v1.x - v2.x, v1.y - v2.y);
        }

        public static float Distance(Vertex a1, Vertex a2)
        {
            return (float)Math.Sqrt(Math.Pow(a1.x - a2.x, 2) + Math.Pow(a1.y - a2.y, 2));
        }
    }
}
