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

            canvasForOnSameWindow.DrawPolygon(polygon);
            canvasForSecondWindow.DrawPolygon(polygon);
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

            canvasForOnSameWindow.DrawPolygon(polygon);
            canvasForSecondWindow.DrawPolygon(polygon);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            polygon.Clear();

            canvasForOnSameWindow.DrawPolygon(polygon);
            canvasForSecondWindow.DrawPolygon(polygon);
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
    }
}
