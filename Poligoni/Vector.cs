using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poligoni
{
    internal class Vector
    {
        public Vertex start;
        public Vertex end;

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

        public static Vector operator *(Vector v, float f)
        {
            return new Vector(0, 0, v.centered.X * f, v.centered.Y * f);
        }

        public static Vector operator +(Vertex vertex, Vector vector)
        {
            return new Vector(vector.start.X + vertex.X, vector.start.Y + vertex.Y, vector.end.X + vertex.X, vector.end.Y + vertex.Y);
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

        public static int OppositeSide(Vector v, Vertex v1, Vertex v2)
        {
            Vector temp1 = new Vector(v.start, v1);
            Vector temp2 = new Vector(v.start, v2);
            float crossProduct1 = CrossProduct(temp1, v);
            float crossProduct2 = CrossProduct(v, temp2);
            float crossProduct = crossProduct1 * crossProduct2;
            if (crossProduct < 0) return 0;
            if (crossProduct > 0) return 1;
            if (crossProduct1 != 0 || crossProduct2 != 0) return -1;
            return -2;
        }

        public static bool Intersect(Vector v1, Vector v2)
        {
            int oppositeSide1 = OppositeSide(v1, v2.start, v2.end);
            int oppositeSide2 = OppositeSide(v2, v1.start, v1.end);

            if(oppositeSide1 * oppositeSide2 == 0)
            {
                return false;
            }
            if(oppositeSide1 + oppositeSide2 == 0)
            {
                return true;
            }
            if(oppositeSide1 + oppositeSide2 == -4)
            {
                if (v1.start == v2.start || v1.start == v2.end || v1.end == v2.start || v1.end == v2.end)
                {
                    return true;
                }
                if (Math.Max(v1.start.X, v1.end.X) < Math.Min(v2.start.X, v2.end.X) || Math.Max(v2.start.X, v2.end.X) < Math.Min(v1.start.X, v1.end.X))
                {
                    return false;
                }
                if (Math.Max(v1.start.Y, v1.end.Y) < Math.Min(v2.start.Y, v2.end.Y) || Math.Max(v2.start.Y, v2.end.Y) < Math.Min(v1.start.Y, v1.end.Y))
                {
                    return false;
                }

                return true;
            }
            return true;
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
