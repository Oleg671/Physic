using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Re2
{
    class risunki
    {
        Pen pen;
        int serx, sery, stx, sty, A, B, sttx, stty;
        int yline; 
        public risunki(double ugl)
        {
            pen = new Pen(Color.Black);
            yline = Convert.ToInt32(Math.Tan(ugl * Math.PI / 180) * 150);
            serx = (400 + 550) / 2;
            sery = (300 - yline + 300) / 2;
            sty = (sery + 300) / 2 - 2;
            stx = (serx + 400) / 2 - 2;
            A = sty - sery + 2;
            B = serx - stx + 2;
            sttx = (stx + serx - 2 - A) / 2;
            stty = (sty + sery - 2 - B) / 2;
        }
        public void DrawEarth(Graphics graph)
        {
            graph.DrawLine(pen, 400, 300, 550, 300);
            graph.DrawLine(pen, 550, 300, 550, 300 - (float)yline);
            graph.DrawLine(pen, 400, 300, 550, 300 - (float)yline);
        }
        public void DrawBody(Graphics graph)
        {
            graph.DrawLine(pen, stx, sty, serx - 2, sery - 2);
            graph.DrawLine(pen, serx - 2, sery - 2, serx - 2 - A, sery - 2 - B);
            graph.DrawLine(pen, stx, sty, stx - A, sty - B);
            graph.DrawLine(pen, stx - A, sty - B, serx - 2 - A, sery - 2 - B);
        }
        public void DrawPowers(Graphics graph, double F, double N, double Fmu)
        {
            pen.Color = Color.Red;
            if (F != 0)
            {
                graph.DrawLine(pen, sttx, stty, sttx + B, stty - A);
            }
            if (N != 0)
            {
                graph.DrawLine(pen, sttx, stty, sttx - A, stty - B);
                graph.DrawLine(pen, sttx, stty, sttx, (float)(stty + B * 1.5));
            }
            if (Fmu != 0)
            {
                graph.DrawLine(pen, sttx, stty, sttx - B, stty + A);
            }
        }
    }
}
