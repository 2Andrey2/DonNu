using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB5
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            this.Show();
            g = this.CreateGraphics();
            g.DrawString("Кликните мышкой по элементу PictureBox",
            new Font("Arial", 10, FontStyle.Regular), Brushes.Red, 0, 0);
            g.Dispose();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            g = pictureBox1.CreateGraphics();
            Point[] point = new Point[9] { new Point(120, 20),
            new Point(180, 30), new Point(240, 20),
            new Point(300, 30), new Point(360, 20),
            new Point(420, 30), new Point(420, 80),
            new Point(360, 90), new Point(100, 80)
            };
            g.FillPolygon(Brushes.Red, point);
            Font fn = new Font("Arial", 10, FontStyle.Bold);
            StringFormat sf = new StringFormat();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            string s = "Средняя цена автомобилей в городах - милионниках";
            g.DrawString(s, fn, Brushes.Black, new Rectangle(125, 20, 300, 70), sf);
            g.DrawRectangle(new Pen(Color.Blue, 1), 0, 0,
            pictureBox1.Width - 1, pictureBox1.Height - 1);
            int nachalo_x = 50; int konec_x = pictureBox1.Width - 10;
            int nachalo_y = 120; int konec_y = pictureBox1.Height - 30;
            g.DrawLine(new Pen(Color.Black, 1), nachalo_x, konec_y,
            konec_x, konec_y);
            g.DrawLine(new Pen(Color.Black, 1), nachalo_x, nachalo_y,
            nachalo_x, konec_y);
            string[] year = new string[8] { "Москва", "Санкт-Петербург", "Красноярск", "Екатиринбург", "Ростов-на-Дону", "Новосибирск", "Челябинск", "Пермь" };
            int[] value = new int[8] { 1371170, 1209600, 1136400, 1120320, 1089060, 1088440, 1064890, 1028400 };
            int max = -1;
            for (int i = 0; i < value.Length; i++) { if (value[i] > max) max = value[i]; }
            double mash = 5.0;
            double dy = (konec_y - nachalo_y) / (max / mash);
            int widthRect = ((konec_x - nachalo_x) / value.Length) / 2;
            SolidBrush sb = new SolidBrush(Color.CornflowerBlue);
            //Разные выводы диаграмм !!!!!!!!!!!!!!!!!!!!!!
            Brush sb1 = new SolidBrush(Color.Orange);
            HatchBrush hb = new HatchBrush(HatchStyle.DiagonalBrick, Color.Gray, Color.Brown);
            Image img = Image.FromFile("img.bmp");
            TextureBrush tb = new TextureBrush(img);

            int x = nachalo_x + widthRect;
            for (int i = 0; i < value.Length; i++)
            {
                Rectangle rect = new Rectangle(x, konec_y - (int)(dy * (value[i] /
                mash)), widthRect, (int)(dy * (value[i] / mash)));
                if (i < 3) g.FillRectangle(sb, rect);
                if (i == 3) g.FillRectangle(sb1, rect);
                if ((i > 3) && (i < 6)) g.FillRectangle(hb, rect);
                if ((i >= 6) && (i < 8)) g.FillRectangle(tb, rect);
                g.DrawRectangle(new Pen(Color.Black, 1), rect);
                x += 2 * widthRect;
            }
            Pen p = new Pen(Color.Blue, 2);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            fn = new Font("Arial", 8, FontStyle.Bold);
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < value.Length; i++)
            {
                g.DrawLine(p, nachalo_x - 5, konec_y - (int)(dy * (value[i] /
                mash)), konec_x, konec_y - (int)(dy * (value[i] / mash)));
                g.DrawString(value[i].ToString(), fn, Brushes.Black,
                new Rectangle(1, konec_y - (int)(dy * (value[i] / mash)) -
                (int)fn.Size, 60, 20), sf);
            }
            sf.Alignment = StringAlignment.Center;
            x = nachalo_x + widthRect + widthRect / 2;
            for (int i = 0; i < year.Length; i++)
            {
                g.DrawLine(new Pen(Color.Black, 1), x, konec_y - 5, x,
                konec_y + 5);
                g.DrawString(year[i], fn, Brushes.Black, new Rectangle(x - 25,
                konec_y + 5, 50, 22), sf);
                x += 2 * widthRect;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
