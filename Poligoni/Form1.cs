using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poligoni
{
    public partial class Form1 : Form
    {
        Color defaultColor = Color.Blue;
        Color hullColor = Color.Purple;

        Color insideColor = Color.Green;
        Color outsideColor = Color.Red;

        Canvas canvasForOnSameWindow = null;
        Polygon polygon;
        Vertex inside;
        Vertex mousePosition;
        bool mouseDown;
        int moving = -2;

        public Form1()
        {
            InitializeComponent();
            polygon = new Polygon();
            MouseWheel += Form1_MouseWheel;
            inside = new Vertex(0, 0);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(canvasForOnSameWindow == null)
            {
                canvasForOnSameWindow = new Canvas(this);
                canvasForOnSameWindow.DrawVertex(inside, outsideColor);
            }
        }


        #region Buttons

        private void btnAddVertex_Click(object sender, EventArgs e)
        {
            float x = float.Parse(tbXInput.Text);
            float y = float.Parse(tbYInput.Text);

            polygon.Add(new Vertex(x, y));

            canvasForOnSameWindow.Clear();

            canvasForOnSameWindow.DrawVertex(inside, polygon.Inside(inside) ? insideColor : outsideColor);
            canvasForOnSameWindow.DrawPolygon(polygon, defaultColor);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string folder = tbFolder.Text;
            polygon.Save(folder);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string folder = tbFolder.Text;
            polygon.Load(folder);

            canvasForOnSameWindow.Clear();
            canvasForOnSameWindow.DrawVertex(inside, polygon.Inside(inside) ? insideColor : outsideColor);
            canvasForOnSameWindow.DrawPolygon(polygon, defaultColor);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            polygon.Clear();

            canvasForOnSameWindow.Clear();
            canvasForOnSameWindow.DrawVertex(inside, Color.Red);
        }

        private void btnConvex_Click(object sender, EventArgs e)
        {
            MessageBox.Show(polygon.Convex() ? "poligon je konveksan" : "poligon nije konveksan");
        }

        private void btnPerimetar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(polygon.Perimetar().ToString());
        }

        private void btnIntersection_Click(object sender, EventArgs e)
        {
            MessageBox.Show(polygon.Intersection() ? "da" : "ne");
        }

        private void btnSurfaceArea_Click(object sender, EventArgs e)
        {
            MessageBox.Show(polygon.SurfaceArea().ToString());
        }

        private void ConvexHull_Click(object sender, EventArgs e)
        {
            Polygon convexHull = polygon.ConvexHull();
            canvasForOnSameWindow.DrawPolygon(convexHull, hullColor);
        }

        #endregion

        #region Moving verteces

        private void Select(Canvas canvas)
        {
            Point positionOfScreen = MousePosition;
            Point positionOfMouse = canvas.form.PointToClient(positionOfScreen);
            Vertex mousePosition = new Vertex(positionOfMouse.X, positionOfMouse.Y);

            Vertex mousePositionWorldSpace = canvas.ScreenToWorldPoint(mousePosition);
            int index = 0;
            Vertex closest = null;

            if (polygon.vertices.Count > 0)
            {
                closest = polygon.vertices[index];
                for (int i = 0; i < polygon.vertices.Count; i++)
                {
                    if (Vertex.Distance(polygon.vertices[i], mousePositionWorldSpace) < Vertex.Distance(polygon.vertices[index], mousePositionWorldSpace))
                    {
                        index = i;
                    }
                }
                closest = polygon.vertices[index];
            }
            if(closest != null)
            {
                if (Vertex.Distance(inside, mousePositionWorldSpace) < Vertex.Distance(closest, mousePositionWorldSpace))
                {
                    index = -1;
                    closest = inside;
                }
            }
            if(closest == null)
            {
                index = -1;
                closest = inside;
            }
            if (Vertex.Distance(closest, mousePositionWorldSpace) < Canvas.vertexSize / canvas.scale)
            {
                moving = index;
                return;
            }
            moving = -2;
            tbXInput.Text = "";
            tbYInput.Text = "";
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (!mouseDown) return;
            Vertex currentMousePosition = new Vertex(PointToClient(MousePosition));
            if (mousePosition == currentMousePosition)
            {
                return;
            }
            mousePosition = currentMousePosition;
            if (moving == -2) return;
            if (moving == -1)
            {
                Vertex v = new Vertex(Clamp(mousePosition.X, 0, ClientSize.Height), Clamp(mousePosition.Y, 0, ClientSize.Height));
                inside = canvasForOnSameWindow.ScreenToWorldPoint(v);
                tbXInput.Text = inside.X.ToString();
                tbYInput.Text = inside.Y.ToString();
                
            }
            if(moving >= 0)
            {
                Vertex v = new Vertex(Clamp(mousePosition.X, 0, ClientSize.Height), Clamp(mousePosition.Y, 0, ClientSize.Height));
                polygon.vertices[moving] = canvasForOnSameWindow.ScreenToWorldPoint(v);
                tbXInput.Text = polygon.vertices[moving].X.ToString();
                tbYInput.Text = polygon.vertices[moving].Y.ToString();
            }

            canvasForOnSameWindow.Clear();
            canvasForOnSameWindow.DrawVertex(inside, polygon.Inside(inside) ? insideColor : outsideColor);
            canvasForOnSameWindow.DrawPolygon(polygon, defaultColor);
        }

        void Deselect()
        {
            mouseDown = false;
        }

        #endregion

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            int delta = e.Delta;
            canvasForOnSameWindow.Zoom(delta);
            canvasForOnSameWindow.Clear();
            canvasForOnSameWindow.DrawPolygon(polygon, defaultColor);
            canvasForOnSameWindow.DrawVertex(inside, polygon.Inside(inside) ? insideColor : outsideColor);
        }

        public static float Clamp(float value, float min, float max)
        {
            if (min > max) throw new MinGreaterThanMaxException();
            if(value < min)
            {
                return min;
            }
            if(value > max)
            {
                return max;
            }
            return value;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(PointToClient(MousePosition).X < ClientSize.Height)
            {
                Select(canvasForOnSameWindow);
                mouseDown = true;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Deselect();
        }

        private void tbXInput_TextChanged(object sender, EventArgs e)
        {
            if (mouseDown) return;
            if (moving < 0) return;
            if (tbXInput.Text == "" || tbXInput.Text == "-") polygon.vertices[moving].X = 0;
            else polygon.vertices[moving].X = float.Parse(tbXInput.Text);

            canvasForOnSameWindow.Clear();
            canvasForOnSameWindow.DrawPolygon(polygon, defaultColor);
            canvasForOnSameWindow.DrawVertex(inside, polygon.Inside(inside) ? insideColor : outsideColor);
        }

        private void tbYInput_TextChanged(object sender, EventArgs e)
        {
            if (mouseDown) return;
            if (moving == -2) return;
            if(moving >= 0) polygon.vertices[moving].Y = (tbYInput.Text == "" || tbYInput.Text == "-") ? 0 : float.Parse(tbYInput.Text);
            if (moving == -1) inside.Y = (tbYInput.Text == "" || tbYInput.Text == "-") ? 0 : float.Parse(tbYInput.Text);

            canvasForOnSameWindow.Clear();
            canvasForOnSameWindow.DrawPolygon(polygon, defaultColor);
            canvasForOnSameWindow.DrawVertex(inside, polygon.Inside(inside) ? insideColor : outsideColor);
        }

        private void DeleteVertex_Click(object sender, EventArgs e)
        {
            if (moving < 0) return;
            polygon.vertices.Remove(polygon.vertices[moving]);

            canvasForOnSameWindow.Clear();
            canvasForOnSameWindow.DrawPolygon(polygon, defaultColor);
            canvasForOnSameWindow.DrawVertex(inside, polygon.Inside(inside) ? insideColor : outsideColor);
        }
    }
}
