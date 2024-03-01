using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static float CrossProduct(Vector v1, Vector v2)
        {
            return (v1.end - v1.start).X * (v2.end - v2.start).Y - (v1.end - v1.start).Y * (v2.end - v2.start).X;
        }

        public static bool Intersection(Vector v1, Vector v2)
        {
            Vector tempStart1 = new Vector(v1.start, v2.start);
            Vector tempEnd1 = new Vector(v1.start, v2.end);
            bool suprotnaStrana1 = CrossProduct(tempStart1, v1) * CrossProduct(v1, tempEnd1) > 0;
            //MessageBox.Show($"{CrossProduct(tempStart1, v1)}, {CrossProduct(v1, tempEnd1)}");

            Vector tempStart2 = new Vector(v2.start, v1.start);
            Vector tempEnd2 = new Vector(v2.start, v1.end);
            bool suprotnaStrana2 = CrossProduct(tempStart2, v2) * CrossProduct(v2, tempEnd2) > 0;
            //MessageBox.Show($"{CrossProduct(tempStart2, v1)}, {CrossProduct(v1, tempEnd2)}");

            return suprotnaStrana1 && suprotnaStrana2;
        }
    }
}
