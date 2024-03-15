using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public Vertex(Point l_p)
        {
            x = l_p.X;
            y = l_p.Y;
        }

        public static Vertex Zero
        {
            get
            {
                return new Vertex(0f, 0f);
            }
        }

        public static bool operator ==(Vertex v1, Vertex v2)
        {
            if (v1 is null && v2 is null) return true;
            if ((v1 is null && !(v2 is null)) || (!(v1 is null) && v2 is null)) return false;
            //MessageBox.Show((v1.X == v2.X && v1.Y == v2.Y).ToString());
            if(v1.X == v2.X && v1.Y == v2.Y)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Vertex v1, Vertex v2)
        {
            return !(v1 == v2);
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
            if (a1 == null || a2 == null) return float.PositiveInfinity;
            return (float)Math.Sqrt(Math.Pow(a1.x - a2.x, 2) + Math.Pow(a1.y - a2.y, 2));
        }
    }
}
