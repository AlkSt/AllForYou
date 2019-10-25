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
    public partial class Form1 : Form
    {
        
        //для показа будем создавать массив точек что бы потом изменть рисунок
            // в х значение начала в y - коонца
        public static List<pair> new_dots = new List<pair>();
        public static double A, B, h, E;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            A = double.Parse(textBox1.Text);
            B = double.Parse(textBox2.Text);
            h = double.Parse(textBox3.Text);
            E = double.Parse(textBox4.Text);

            List<pair> dot = new List<pair>(); ; // правые значения точек где меняется знак
            dot = HalfDivision.SignumShange(A, B, h);

            for (int i = 0; i < dot.Count; i++)//вывод этих точек
            {
                label5.Text += ("[" + (dot[i].x - h) + "  " + dot[i].x + "] ");
            }
            label5.Text += "\n";
            //рисуем просто график
            //Graphic graph = new Graphic(A, B , dot[0].x - h, dot[0].x);
            //graph.Show();
            new_dots.Add(new pair(A, B));
            //теперь рассматриваем только первый подозрительный отрезок
            A = dot[0].x - h;
            B = dot[0].x ;
            new_dots.Add(new pair(A, B));
            Accurate();

            label5.Text += ("[" +A+ "  " + B+ "] - приближенно");
        }

        public static void Accurate()
        {
            
            
           
            while (B - A > E) // пока точность не достгнута
            {
                // берем первый наш подозрительный отрезк
                double C = A +(B - A) / 2; // это его середина
                                        //смотрим правую и левую часть 
                                        // где точка
                if (HalfDivision.SignumShange(A, C, (C - A) ).Count > 0)//в левой
                {                   
                    B = C;
                }
                else// в правой
                {                   
                    A = C;                    
                }

                new_dots.Add(new pair(A, B));// добавили точку

            }
            Print(new_dots);
        }

         public static void Print( List<pair> dots)
        {
            Graphic graphe = new Graphic(new_dots);
            graphe.Show();
        }
    }
}
