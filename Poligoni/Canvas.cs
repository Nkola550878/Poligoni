using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poligoni
{
    internal class Canvas
    {
        int sizeX, sizeY;
        int centerX, centerY;

        Form form;
        int scale = 100;

        Graphics graphics;
        int vertexSize = 10;
        int edgeWidth = 3;

        Color edgeColor = Color.FromArgb(0, 0, 255);
        Color vertexColor = Color.FromArgb(255, 0, 0);
        Color coordianteSystemColor = Color.FromArgb(100, 100, 100);

        Color backgroundColor = Color.FromArgb(255, 255, 255);

        public Canvas(Form l_form)
        {
            sizeX = l_form.ClientSize.Width;
            sizeY = l_form.ClientSize.Height;
            if(sizeX > sizeY) sizeX = sizeY;
            
            centerX = sizeX / 2;
            centerY = sizeY / 2;
            form = l_form;

            graphics = form.CreateGraphics();
            DrawCoordinateSystem();
        }

        public void DrawPolygon(List<Vertex> points)
        {
            graphics.Clear(backgroundColor);
            DrawCoordinateSystem();
            for (int i = 0; i < points.Count; i++)
            {
                DrawEdge(points[i], points[(i + 1) % points.Count]);
            }
            for (int i = 0; i < points.Count; i++)
            {
                DrawVertex(points[i]);
            }
        }

        void DrawVertex(Vertex p)
        {
            Brush pointBrush = new SolidBrush(vertexColor);
            Rectangle square = new Rectangle(centerX + (int)(p.X * scale - vertexSize / 2), centerY - (int)(p.Y * scale + vertexSize / 2), vertexSize, vertexSize);
            graphics.FillEllipse(pointBrush, square);
        }

        void DrawEdge(Vertex v1, Vertex v2)
        {
            Pen edgePen = new Pen(edgeColor, edgeWidth);

            graphics.DrawLine(edgePen, centerX + v1.X * scale, centerY - v1.Y * scale, centerX + v2.X * scale, centerY - v2.Y * scale);
        }

        public void DrawCoordinateSystem()
        {
            Pen coordinateSystemPen = new Pen(coordianteSystemColor);

            graphics.DrawLine(coordinateSystemPen, centerX, 0, centerX, 2 * sizeY);
            graphics.DrawLine(coordinateSystemPen, 0, centerY, 2 * centerX, centerY);
        }
    }
}
