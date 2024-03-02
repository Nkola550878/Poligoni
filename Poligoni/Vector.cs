using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
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
        float distance;

        public Vertex Centered
        {
            get 
            { 
                return centered;
            }
        }

        public static Vector Right
        {
            get
            {
                return new Vector(0, 0, 1, 0);
            }
        }

        public Vector(Vertex l_start, Vertex l_end)
        {
            start = l_start; 
            end = l_end;

            centered = end - start;
            distance = Vertex.Distance(start, end);
        }

        public Vector(float l_x1, float l_y1, float l_x2, float l_y2)
        {
            start = new Vertex(l_x1, l_y1);
            end = new Vertex(l_x2, l_y2);

            centered = end - start;
            distance = Vertex.Distance(start, end);
        }

        public static float DotProduct(Vertex v1, Vertex v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }

        public static float DotProduct(Vector v1, Vector v2)
        {
            return (v1.end - v1.start).X * (v2.end - v2.start).X + (v1.end - v1.start).Y * (v2.end - v2.start).Y;
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
            bool suprotnaStrana1 = CrossProduct(tempStart1, v1) * CrossProduct(v1, tempEnd1) >= 0;

            Vector tempStart2 = new Vector(v2.start, v1.start);
            Vector tempEnd2 = new Vector(v2.start, v1.end);
            bool suprotnaStrana2 = CrossProduct(tempStart2, v2) * CrossProduct(v2, tempEnd2) >= 0;

            return suprotnaStrana1 && suprotnaStrana2;
        }

        public static float Cos(Vector v1, Vector v2)
        {
            float dotProduct = DotProduct(v1, v2);

            return dotProduct / (v1.distance * v2.distance);
        }

        public static float ArcCos(Vector v1, Vector v2)
        {
            double absoluteAngle = Math.Acos(Cos(v1, v2));
            float angle = (float)absoluteAngle * Math.Sign(CrossProduct(v1, v2));
            return angle;
        }

        public override string ToString()
        {
            return $"({start.X}, {start.Y}), ({end.X}, {end.Y})";
        }
    }
}
