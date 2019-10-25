using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
     
    public static class HalfDivision
    {
        public static double GetDot( double x)
        {
            return 2 * x * Math.Log10(x); // значение функции в заданной точке

        }

        public static List<pair> SignumShange(double A, double B, double h)// в массиве правая граница интервала где меняется знак
        {
             List<pair> dots = new List<pair>();
            double x = A+0.001;
            double y = GetDot(x);
            while(x<=B)
            {
                x += h;
                if (y * GetDot(x) < 0) dots.Add(new pair(x, GetDot(x)));
                y = GetDot(x);
            }
            return dots;
        }

        public  static double Solve(double A, double B) // возвращает x  середиы 
        {
            return 0;
        }

    }
}
