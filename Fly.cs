using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Re2
{
    class Fly
    {
        double V, x, y, xma, tma, hma, ugl;
        const double g = 9.8;
        public Fly(double V, double ugol)
        {
            this.V = V;
            ugl = ugol * Math.PI / 180;
            tma = 2 * V * Math.Sin(ugl) / g;
            xma = (V * Math.Cos(ugl)) * tma;
            hma = V * V * Math.Sin(ugl) * Math.Sin(ugl) / (2 * g);
            x = 0;
            y = 0;
        }
        public double ComeBack(string inn)
        {
            if (inn == "x")
                return x;
            else if (inn == "y")
                return y;
            else if (inn == "V")
                return V;
            else if (inn == "xma")
                return xma;
            else if (inn == "hma")
                return hma;
            else if (inn == "tma")
                return tma;
            else
                return 0;
        }
        public void Change(double t)
        {
            x = (V * Math.Cos(ugl)) * t;
            y = (V * Math.Sin(ugl)) * t - g * t * t / 2;
        }
    }
}
