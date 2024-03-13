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
        Canvas canvasForOnSameWindow = null;
        Polygon polygon;
        Color defaulEdgeColor = Color.Blue;
        Vertex inside;

        int moving;

        public Form1()
        {
            InitializeComponent();
            CreateCanvas();
            polygon = new Polygon();
            MouseWheel += Form1_MouseWheel;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(canvasForOnSameWindow == null)
            {
                canvasForOnSameWindow = new Canvas(this);
            }
        }

        private void btnAddVertex_Click(object sender, EventArgs e)
        {
            float x = float.Parse(tbXInput.Text);
            float y = float.Parse(tbYInput.Text);

            polygon.Add(new Vertex(x, y));

            canvasForOnSameWindow.Clear();
            canvasForSecondWindow.Clear();
            canvasForOnSameWindow.DrawPolygon(polygon, defaulEdgeColor);
            canvasForSecondWindow.DrawPolygon(polygon, defaulEdgeColor);
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
            canvasForSecondWindow.Clear();
            canvasForOnSameWindow.DrawPolygon(polygon, defaulEdgeColor);
            canvasForSecondWindow.DrawPolygon(polygon, defaulEdgeColor);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            polygon.Clear();

            canvasForOnSameWindow.Clear();
            canvasForSecondWindow.Clear();
        }

        private void btnConvex_Click(object sender, EventArgs e)
        {
            MessageBox.Show(polygon.Convex() ? "poligon je konveksan" : "poligon nije konveksan");
        }

        private void btnPerimetar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(polygon.Perimetar().ToString());
        }

        private void btnSurfaceArea_Click(object sender, EventArgs e)
        {
            MessageBox.Show(polygon.SurfaceArea().ToString());
        }

        private void btnIntersection_Click(object sender, EventArgs e)
        {
            MessageBox.Show(polygon.Intersection() ? "da" : "ne");
        }

        private void ConvexHull_Click(object sender, EventArgs e)
        {
            Polygon convexHull = polygon.ConvexHull();
            canvasForOnSameWindow.DrawPolygon(convexHull, Color.Purple);
            canvasForSecondWindow.DrawPolygon(convexHull, Color.Purple);
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            int delta = e.Delta;
            canvasForOnSameWindow.Zoom(delta);
            canvasForOnSameWindow.Clear();
            canvasForOnSameWindow.DrawPolygon(polygon, defaulEdgeColor);
            if (inside != null)
            {
                canvasForOnSameWindow.DrawVertex(inside, Color.Orange);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Point positionOfScreen = MousePosition;
            Point positionOfMouse = PointToClient(positionOfScreen);
            Vertex mousePosition = new Vertex(positionOfMouse.X, positionOfMouse.Y);

            MessageBox.Show(canvasForOnSameWindow.ScreenToWorldPoint(mousePosition).ToString());
            Vertex mousePositionWorldSpace = canvasForOnSameWindow.ScreenToWorldPoint(mousePosition);
            int index = 0;
            Vertex closest = polygon.vertices[index];

            if(polygon.vertices.Count > 0)
            {
                for (int i = 0; i < polygon.vertices.Count; i++)
                {
                    if (Vertex.Distance(polygon.vertices[i], mousePositionWorldSpace) < Vertex.Distance(polygon.vertices[index], mousePositionWorldSpace))
                    {
                        index = i;
                    }
                }
                closest = polygon.vertices[index];
            }
            if(Vertex.Distance(inside, mousePositionWorldSpace) < Vertex.Distance(closest, mousePositionWorldSpace))
            {
                index = -1;
                closest = inside;
            }
            if(Vertex.Distance(closest, mousePositionWorldSpace) < Canvas.vertexSize / canvasForOnSameWindow.scale)
            {
                MessageBox.Show(index.ToString());
            }

            moving = index;
        }

        private void Inside_Click(object sender, EventArgs e)
        {
            float x = float.Parse(InsideX.Text);
            float y = float.Parse(InsideY.Text);

            Vertex v = new Vertex(x, y);
            inside = v;

            canvasForOnSameWindow.DrawVertex(v, Color.Orange);
            canvasForSecondWindow.DrawVertex(v, Color.Orange);

            MessageBox.Show(polygon.Inside(v).ToString());
        }

        Form canvasForm;
        Canvas canvasForSecondWindow;
        bool createdSecondWindow = false;

        private void CreateCanvas()
        {
            canvasForm = new Form();
            canvasForm.Show();
            canvasForm.ClientSize = new Size(500, 500);
            canvasForm.Paint += CanvasForm_Paint;
            canvasForm.MouseWheel += CanvasForm_MouseWheel;
        }

        private void CanvasForm_Paint(object sender, PaintEventArgs e)
        {
            if(canvasForSecondWindow == null)
            {
                canvasForSecondWindow = new Canvas(canvasForm);
            }
        }


        private void CanvasForm_MouseWheel(object sender, MouseEventArgs e)
        {
            int delta = e.Delta;
            canvasForSecondWindow.Zoom(delta);
            canvasForSecondWindow.Clear();
            canvasForSecondWindow.DrawPolygon(polygon, defaulEdgeColor);
            if(inside != null)
            {
                canvasForSecondWindow.DrawVertex(inside, Color.Orange);
            }
        }
    }
}
