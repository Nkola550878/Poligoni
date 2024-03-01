using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poligoni
{
    internal class Polygon
    {
        public List<Vertex> vertices;

        public Polygon()
        {
            vertices = new List<Vertex>();
        }

        public Polygon(List<Vertex> l_vertices)
        {
            vertices = l_vertices;
        }

        public void Add(Vertex l_v)
        {
            vertices.Add(l_v);
        }

        public void Clear()
        {
            vertices = new List<Vertex>();
        }

        public float SurfaceArea()
        {
            float area = 0;
            for (int i = 0; i < vertices.Count; i++)
            {
                area += vertices[i].X * vertices[(i + 1) % vertices.Count].Y - vertices[(i + 1) % vertices.Count].X * vertices[i].Y;
            }
            area = Math.Abs(area) / 2;
            return area;
        }

        public float Perimetar()
        {
            float perimetar = 0;
            for (int i = 0; i < vertices.Count; i++)
            {
                perimetar += Vertex.Distance(vertices[i], vertices[(i + 1) % vertices.Count]);
            }
            return perimetar;
        }

        public bool Convex()
        {
            int n = 0;
            for (int i = 0; i < vertices.Count; i++)
            {
                Vector v1 = new Vector(vertices[i], vertices[(i + 1) % vertices.Count]);
                Vector v2 = new Vector(vertices[(i + 1) % vertices.Count], vertices[(i + 2) % vertices.Count]);

                n += Vector.CrossProduct(v1.Centered, v2.Centered) > 0 ? 1 : -1;
            }
            if (Math.Abs(n) == vertices.Count)
            {
                return true;
            }
            return false;
        }

        public void Load(string fileName)
        {
            Clear();
            if (fileName == "")
            {
                MessageBox.Show("Nije moguce da folder nema ime");
                return;
            }
            fileName = $"{fileName}.txt";
            if (!File.Exists(fileName))
            {
                MessageBox.Show("File ne postoji");
                return;
            }
            StreamReader sr = new StreamReader(fileName);
            while (true)
            {
                string temp1 = sr.ReadLine();
                if (temp1 == "" || temp1 == null) break;
                string[] temp2 = temp1.Split(' ');
                float x = float.Parse(temp2[0]);
                float y = float.Parse(temp2[1]);
                vertices.Add(new Vertex(x, y));
            }
        }

        public void Save(string fileName)
        {
            if (fileName == "")
            {
                MessageBox.Show("Nije moguce da folder nema ime");
                return;
            }
            StreamWriter sw = new StreamWriter($"{fileName}.txt");
            foreach (Vertex p in vertices)
            {
                sw.WriteLine(p.ToString());
            }
            sw.Close();
        }

        public bool Intersection()
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = i + 1; j < vertices.Count; j++)
                {
                    if (Math.Abs(i - j % vertices.Count) == 1) continue;

                    Vector a = new Vector(vertices[i], vertices[(i + 1) % vertices.Count]);
                    Vector b = new Vector(vertices[j], vertices[(j + 1) % vertices.Count]);

                    if (Vector.Intersection(a, b))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
