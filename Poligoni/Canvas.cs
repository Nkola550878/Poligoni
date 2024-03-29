﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poligoni
{
    internal class Canvas
    {
        int sizeX, sizeY;
        int centerX, centerY;

        public Form form;
        public float scale;

        Graphics graphics;
        public static int vertexSize = 10;
        int edgeWidth = 3;

        Color edgeColor = Color.FromArgb(0, 0, 255);
        Color vertexColor = Color.FromArgb(255, 0, 0);
        Color coordianteSystemColor = Color.FromArgb(100, 100, 100);
        Color backgroundColor = Color.FromArgb(255, 255, 255);
        Color vertexInsideCheckColor = Color.FromArgb(255, 165, 0);

        public Canvas(Form l_form)
        {
            sizeX = l_form.ClientSize.Width;
            sizeY = l_form.ClientSize.Height;
            if(sizeX > sizeY) sizeX = sizeY;
            
            centerX = sizeX / 2;
            centerY = sizeY / 2;
            form = l_form;
            scale = 100;

            graphics = form.CreateGraphics();
            DrawCoordinateSystem();
        }

        public Vertex WorldToScreenPoint(Vertex v)
        {
            float x = centerX + v.X * scale;
            float y = centerY - v.Y * scale;
            return new Vertex(x, y);
        }

        public Vertex ScreenToWorldPoint(Vertex v)
        {
            float x = (v.X - centerX) / scale;
            float y = (centerY - v.Y) / scale;
            return new Vertex(x, y);
        }

        public void DrawPolygon(Polygon p, Color c)
        {
            if (p.vertices.Count == 0) return;
            DrawCoordinateSystem();
            for (int i = 0; i < p.vertices.Count; i++)
            {
                DrawEdge(p.vertices[i], p.vertices[(i + 1) % p.vertices.Count], c);
            }
            for (int i = 0; i < p.vertices.Count; i++)
            {
                DrawVertex(p.vertices[i], vertexColor);
            }
        }

        public void DrawVertex(Vertex p, Color c)
        {
            Brush pointBrush = new SolidBrush(c);
            Rectangle square = new Rectangle((int)WorldToScreenPoint(p).X - vertexSize / 2, (int)WorldToScreenPoint(p).Y - vertexSize / 2, vertexSize, vertexSize);
            graphics.FillEllipse(pointBrush, square);
        }

        void DrawEdge(Vertex v1, Vertex v2, Color c)
        {
            Pen edgePen = new Pen(c, edgeWidth);

            graphics.DrawLine(edgePen, WorldToScreenPoint(v1).X, WorldToScreenPoint(v1).Y, WorldToScreenPoint(v2).X, WorldToScreenPoint(v2).Y);
        }

        public void DrawCoordinateSystem()
        {
            Pen coordinateSystemPen = new Pen(coordianteSystemColor);

            graphics.DrawLine(coordinateSystemPen, centerX, 0, centerX, sizeY);
            graphics.DrawLine(coordinateSystemPen, 0, centerY, sizeX, centerY);
        }

        public void Clear()
        {
            graphics.Clear(backgroundColor);
            DrawCoordinateSystem();
        }

        //public Vertex ToCoordinateSystem(Vertex vertex)
        //{
        //    return new Vertex(centerX + (int)(vertex.X * scale - vertexSize / 2), centerY - (int)(vertex.Y * scale + vertexSize / 2));
        //}

        public void Zoom(float amount)
        {
            scale *= (float)Math.Pow(1.1f, -Math.Sign(amount));
        }
    }
}
