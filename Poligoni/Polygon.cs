using System;
using System.Collections.Generic;
using System.Drawing;
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
                    if (Math.Abs((i - j) % vertices.Count) == 1 || Math.Abs((i - j) % vertices.Count) == vertices.Count - 1) continue;

                    Vector a = new Vector(vertices[i], vertices[(i + 1) % vertices.Count]);
                    Vector b = new Vector(vertices[j], vertices[(j + 1) % vertices.Count]);

                    if (Vector.Intersect(a, b))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Vertex Extreme()
        {
            Vertex extreme = vertices[0];

            for (int i = 1; i < vertices.Count; i++)
            {
                if (vertices[i].X < extreme.X)
                {
                    extreme = vertices[i];
                }
                if (vertices[i].X == extreme.X && vertices[i].Y < extreme.Y)
                {
                    extreme = vertices[i];
                }
            }
            return extreme;
        }

        public Polygon ConvexHull()
        {
            if (vertices.Count == 0) return null;
            Polygon convexHull = new Polygon();
            Vertex extreme = Extreme();
            Vertex current = extreme;

            do
            {
                Vertex nextVertex = null;
                float angle = float.PositiveInfinity;
                for (int i = 0; i < vertices.Count; i++)
                {
                    if (vertices[i] == current) continue;

                    Vector a = Vector.Right;
                    if (convexHull.vertices.Count != 0) a = new Vector(current, convexHull.vertices.Last());
                    Vector b = new Vector(current, vertices[i]);

                    if(angle > Vector.ArcCos(a, b))
                    {
                        angle = Vector.ArcCos(a, b);
                        nextVertex = vertices[i];
                    }

                    if(angle == Vector.ArcCos(a, b) && Vertex.Distance(vertices[i], current) > Vertex.Distance(nextVertex, current))
                    {
                        angle = Vector.ArcCos(a, b);
                        nextVertex = vertices[i];
                    }
                }

                convexHull.Add(current);
                current = nextVertex;

            } while (current != extreme);

            return convexHull;
        }

        public bool Inside(Vertex pointToCheck)
        {
            bool inside = false;
            Vector vLeft = pointToCheck + Vector.Right * (Extreme().X - pointToCheck.X + Math.Sign(Extreme().X - pointToCheck.X));

            for (int i = 0; i < vertices.Count; i++)
            {
                Vertex previousVertex = vertices[(i - 1 + vertices.Count) % vertices.Count];
                Vertex currentVertex = vertices[i];
                Vertex nextVertex = vertices[(i + 1) % vertices.Count];

                Vector currentEdge = new Vector(currentVertex, nextVertex);
                if (Vector.Intersect(vLeft, currentEdge))
                {
                    inside = !inside;
                }

                if (Vector.CrossProduct(vLeft, new Vector(pointToCheck, currentVertex)) == 0 && (currentVertex.X - vLeft.start.X) * (currentVertex.X - vLeft.end.X) < 0)
                {
                    bool oppositeSide = Vector.OppositeSide(new Vector(pointToCheck, currentVertex), previousVertex, nextVertex) > 0;
                    inside = oppositeSide ? !inside : inside;
                    
                    if(Vector.CrossProduct(vLeft, new Vector(pointToCheck, nextVertex)) == 0 && (nextVertex.X - vLeft.start.X) * (nextVertex.X - vLeft.end.X) < 0)
                    {
                        oppositeSide = Vector.OppositeSide(new Vector(pointToCheck, currentVertex), previousVertex, vertices[(i + 2) % vertices.Count]) > 0;
                        inside = oppositeSide ? !inside : inside;
                    }
                }

            }
            return inside;
        }
    }
}
