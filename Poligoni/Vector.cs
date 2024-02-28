using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poligoni
{
    internal class Vector
    {
        Vertex start;
        Vertex end;

        Vertex centered;
        public Vertex Centered
        {
            get 
            { 
                return centered;
            }
        }

        float distance;

        public Vector(Vertex l_start, Vertex l_end)
        {
            start = l_start; 
            end = l_end;

            centered = l_end - l_start;
            distance = Vertex.Distance(start, end);
        }

        public Vector(float l_x1, float l_y1, float l_x2, float l_y2)
        {
            start = new Vertex(l_x1, l_y1);
            end = new Vertex(l_x2, l_y2);
        }

        public static float DotProduct(Vertex v1, Vertex v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }

        public static float CrossProduct(Vertex v1, Vertex v2)
        {
            return v1.X * v2.Y - v1.Y * v2.X;
        }
    }
}
