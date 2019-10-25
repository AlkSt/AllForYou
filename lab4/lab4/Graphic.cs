using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Graphic : Form
    {
        Graphics graf;
        Pen pen = new Pen(Color.Black, 2);
        double _begin;
        double _end;
        double _left;
        double _right;
        List<pair> _dots;
        public Graphic(List<pair> dots) //(double begin, double end, double left, double right)
        {
            InitializeComponent();
            graf = CreateGraphics();
            _begin = dots[0].x;
            _end = dots[0].y;

            _left = dots[1].x ;
            _right = dots[1].y;
            _dots = dots;


        }
        private void Graphic_Shown(object sender, EventArgs e)
        {

            for (int i = 0; i <_dots.Count-1; i++)
            {MessageBox.Show("Сдедующий щаг?");
                graf.Clear(BackColor);
                //Thread.Sleep(700);
                
                _begin = _dots[i].x;
                _end = _dots[i].y;

                _left = _dots[i+1].x;
                _right = _dots[i+1].y;

                double LastPoint = _end;
            int x1, y1, x2, y2;
            double step = 0.01, x = _begin, y = 0;
            int X = 1000, Y = 1000;
            int x0  = this.ClientSize.Height / 2, y0 = this.ClientSize.Height/2;
            while (HalfDivision.GetDot(_end) * Y + y0 > ClientSize.Height || _end * X + x0 > ClientSize.Width*0.8)
            {
                X -= 1; //x1 / (ClientSize.Width / 2);
                Y -= 1;// y1 / (ClientSize.Width / 2);
            }
            pen.Color = BackColor;


                graf.DrawLine(pen, x0*X, 0, y0, ClientSize.Height);
                graf.DrawLine(pen, 0, y0, ClientSize.Width, y0*Y);
                pen.Width = 1;
            //for (int i = 0; i < ClientSize.Width/X; i++)
            //{
            //    graf.DrawLine(pen, x0 - 3, Y * i, x0 + 3, Y * i);
            //    graf.DrawLine(pen, X * i, y0 + 3, X * i, y0 - 3);

            //}
            y = HalfDivision.GetDot(x);
            x1 = this.ClientSize.Height;// (int)(X * x + x0);
            y1 = this.ClientSize.Height;//(int)(-1 * Y * y + y0);
            pen.Width = 2;


            while (x < LastPoint )
            {
                
                x += step;
                y = HalfDivision.GetDot(x);
                x2 = (int)(x0 + x * X);
                y2 = (int)(y0 - y * Y);
                graf.DrawLine(pen, x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
                if (x > _left && x < _right)
                    pen.Color = Color.Red;
                else pen.Color = Color.Black;
                Console.WriteLine(x + " " + y);
            }
        }
        }
    }  
}
