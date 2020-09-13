using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Выбираем перо myPen красного цвета толщиной в 1 пиксел:
            Pen myPen = new Pen(Color.Red, 1);
            // Объявляем объект «g» класса Graphics и предоставляем
            // ему возможность рисования на pictureBox1:
            Graphics g = pictureBox1.CreateGraphics();
            // Рисуем прямоугольник:
            g.DrawRectangle(myPen, 0, 0, pictureBox1.Size.Width - 1,
            pictureBox1.Size.Height - 1);
            g.Dispose();
        }
        protected override void OnPaint(PaintEventArgs e){
            // Получаем объект Graphics
            Graphics g = pictureBox2.CreateGraphics();
            // Рисуем линию
            g.DrawLine(Pens.Red, 10, 5, 110, 15);
            // Рисуем эллипс
            Graphics s = pictureBox3.CreateGraphics();
            s.DrawEllipse(Pens.Blue, 10, 20, 110, 45);
            // Рисуем прямоугольник
            Graphics k = pictureBox4.CreateGraphics();
            k.DrawRectangle(Pens.Green, 10, 70, 110, 45);
            // Рисуем закрашенный эллипс
            Graphics l = pictureBox5.CreateGraphics();
            l.FillEllipse(Brushes.Blue, 130, 20, 110, 45);
            // Рисуем закрашенный прямоугольник
            Graphics c = pictureBox6.CreateGraphics();
            c.FillRectangle(Brushes.Green, 130, 70, 110, 45);
            
        }
    }
}
