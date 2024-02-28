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
        public Form1()
        {
            InitializeComponent();
        }

        List<Vertex> vertices = new List<Vertex>();

        private void btnAddVertex_Click(object sender, EventArgs e)
        {
            float x = float.Parse(tbXInput.Text);
            float y = float.Parse(tbYInput.Text);

            vertices.Add(new Vertex(x, y));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string folder = tbFolder.Text;
            if(folder == "")
            {
                MessageBox.Show("Nije moguce da folder nema ime");
                return;
            }
            StreamWriter sw = new StreamWriter($"{folder}.txt");
            foreach (Vertex p in vertices)
            {
                sw.WriteLine(p.ToString());
            }
            sw.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string folder = tbFolder.Text;
            if (folder == "")
            {
                MessageBox.Show("Nije moguce da folder nema ime");
                return;
            }
            folder = $"{folder}.txt";
            if (Directory.Exists(folder)) return;
            StreamReader sr = new StreamReader(folder);
            while (true)
            {
                string temp1 = sr.ReadLine();
                if (temp1 == "" || temp1 == null) break;
                string[] temp2 = temp1.Split(' ');
                float x = float.Parse(temp2[0]);
                float y = float.Parse(temp2[1]);
                vertices.Add(new Vertex(x, y));
            }

            Canvas canvas = new Canvas(this);
            canvas.DrawPolygon(vertices);
        }
    }
}
