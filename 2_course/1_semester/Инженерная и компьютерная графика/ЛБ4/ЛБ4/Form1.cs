using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛБ4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int [] temper = { -6, 1, 2, 5, -1, -8, -9, 2, 8, 12, 21, 12, 7, 4, 4,
                -3, 6, 4, 4, 0, -1, -9, 0, 7, 7, 16, 6, 0, -6, 15, 18};
            Graphics ris = pictureBox1.CreateGraphics();
            Pen p = new Pen(Color.Red);
            Font f = new Font("Times new roman", 14);
            StringFormat form = new StringFormat();
            form.Alignment = StringAlignment.Center;
            form.LineAlignment = StringAlignment.Center;
            int x1 = 0; int y1 = pictureBox1.Size.Height / 2;
            int x2 = pictureBox1.Size.Width;
            int y2 = pictureBox1.Size.Height / 2;
            ris.DrawLine(p, x1, y1, x2, y2);
            x1 = 0; y1 = 0;
            x2 = 0; y2 = pictureBox1.Size.Height;
            ris.DrawLine(p, x1, y1, x2, y2);
            int max = -1;
            for (int i = 0; i < temper.Length; i++) {
                if (temper[i] > max)
                    max = temper[i]; 
            }
            int dy = pictureBox1.Size.Height / (2 * max);
            int dx = pictureBox1.Size.Width / 31;
            int y = pictureBox1.Size.Height / 2;
            for (int i = 0; i <= max; i++)
            {
                ris.DrawString(Convert.ToString(i), f, Brushes.Red, 10, y, form);
                ris.DrawLine(p, 0, y, pictureBox1.Size.Width, y);
                y = y - dy;
            }
            y = pictureBox1.Size.Height / 2;
            for (int i = 0; i <= max; i++) {
            ris.DrawString(Convert.ToString(i), f, Brushes.Red,10,y,form);
            ris.DrawLine(p, 0, y, pictureBox1.Size.Width, y);
            y = y + dy;
            }
            // *************** Ставим метки по оси X ********************
            int x = dx;
            for (int i = 1; i <= 31; i++) {
            ris.DrawString(Convert.ToString(i), f, Brushes.Red, x,
            pictureBox1.Size.Height / 2 - 22, form);
            ris.DrawLine(p, x, pictureBox1.Size.Height / 2 - 5 , x,
            pictureBox1.Size.Height / 2 +5);
            x = x + dx;
            }
            p.Dispose();
            // *************** Выводим график температур ***************
            // Задаем цвет и толщину пера для вывода графика температур
            p = new Pen(Color.Green,3);
            // Задаем стиль линии "точечная"
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            // Задаем начальную координату x
            x = dx;
            // Отмечаем кружком значение температуры в первый день
            //g.DrawEllipse(Pens.Red, x - 3, pictureBox1.Size.Height / 2 –
            //t[0] * dy - 3, 6, 6);
            // Организуем цикл по элементам массива температур
            for (int i = 1; i <= temper.Length-1; i++) {
            // Проводим линию из одного значения температуры в другое
            ris.DrawLine(p, x, pictureBox1.Size.Height / 2 - temper[i-1] * dy,
            x+dx, pictureBox1.Size.Height / 2 - temper[i]*dy);
            // Отмечаем кружком значение температуры
            //g.DrawEllipse(Pens.Red,x+dx-3,pictureBox1.Size.Height / 2 –
            //t[i] * dy-3, 6, 6);
            // Переходим к следующему дню месяца
            x = x + dx;
            }
            p.Dispose();
            
        }
    }
}
