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
        int scale = 20;

        Graphics graphics;
        int pointSize = 20;

        public Canvas(Form l_form)
        {
            sizeX = l_form.ClientSize.Width;
            sizeY = l_form.ClientSize.Height;
            if(sizeX > sizeY) sizeX = sizeY;
            
            centerX = sizeX / 2;
            centerY = sizeY / 2;
            form = l_form;
        }

        public void DrawPolygon(List<Point> points)
        {
            graphics = form.CreateGraphics();
            //graphics.DrawRectangle(new Pen(Color.Red, 10), 0, 0, 100, 100);
            for (int i = 0; i < points.Count; i++)
            {
                DrawEdge(points[i], points[(i + 1) % points.Count]);
            }
            for (int i = 0; i < points.Count; i++)
            {
                DrawPoint(points[i]);
            }
        }

        void DrawPoint(Point p)
        {
            Brush pointBrush = new SolidBrush(Color.Red);
            Rectangle square = new Rectangle(centerX + (int)p.X * scale - pointSize / 2, centerY + (int)p.Y * scale - pointSize / 2, pointSize, pointSize);
            graphics.FillEllipse(pointBrush, square);
        }

        void DrawEdge(Point p1, Point p2)
        {
            Pen edgePen = new Pen(Color.Blue, 5);

            graphics.DrawLine(edgePen, centerX + p1.X * scale, centerY + p1.Y * scale, centerX + p2.X * scale, centerY + p2.Y * scale);
        }
    }
}
