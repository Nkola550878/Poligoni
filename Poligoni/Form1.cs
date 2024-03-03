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

        public Form1()
        {
            InitializeComponent();
            CreateCanvas();
            polygon = new Polygon();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            canvasForOnSameWindow = new Canvas(this);
        }

        private void btnAddVertex_Click(object sender, EventArgs e)
        {
            float x = float.Parse(tbXInput.Text);
            float y = float.Parse(tbYInput.Text);

            polygon.Add(new Vertex(x, y));

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

            canvasForOnSameWindow.DrawPolygon(polygon, defaulEdgeColor);
            canvasForSecondWindow.DrawPolygon(polygon, defaulEdgeColor);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            polygon.Clear();

            canvasForOnSameWindow.DrawPolygon(polygon, defaulEdgeColor);
            canvasForSecondWindow.DrawPolygon(polygon, defaulEdgeColor);
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
            canvasForSecondWindow.DrawPolygon(convexHull, Color.Purple);
        }

        Form canvasForm;
        Canvas canvasForSecondWindow;
        private void CreateCanvas()
        {
            canvasForm = new Form();
            canvasForm.Show();
            canvasForm.ClientSize = new Size(500, 500);
            canvasForm.Paint += CanvasForm_Paint;
        }

        private void CanvasForm_Paint(object sender, PaintEventArgs e)
        {
            canvasForSecondWindow = new Canvas(canvasForm);
        }

        private void Inside_Click(object sender, EventArgs e)
        {
            float x = float.Parse(InsideX.Text);
            float y = float.Parse(InsideY.Text);
            Vertex v = new Vertex(x, y);

            MessageBox.Show(polygon.Inside(v).ToString());
        }
    }
}
