using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace LB3
{
    public partial class Form1 : Form
    {
        // Объявляем объект "g" класса Graphics
        Graphics g;
        string filename = @"Strings.txt";
        string[] sm = {
        "First line", "Second line", "Third line",
        "Fourth line", "Fifth line", "Sixth line",
        "Seventh line", "Eighth line", "Ninth line",
        "Tenth line", "Eleven line"};
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void infile_Click(object sender, EventArgs e)
        {
            StreamWriter f = new StreamWriter(new FileStream(filename,
            FileMode.Create, FileAccess.Write));

            foreach (string s in sm) { f.WriteLine(s); }
            f.Close();
            MessageBox.Show("15 строк записано в файл !");
        }

        private void kleaning_Click(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(255, 255, 255));
            File.Delete(filename);
            MessageBox.Show("Файл Strings.txt удалён !");
        }

        private void themap_Click(object sender, EventArgs e)
        {
            int k = 0;
            // Чтение строк из файла
            try
            {
                StreamReader f = new StreamReader(new FileStream(filename,
                FileMode.Open, FileAccess.Read));
                for (int i = 0; i < 15; i++) { sm[i] = f.ReadLine(); }
                f.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            // **** Отображение строк разными шрифтами и выравниванием **
            pictureBox1.BackColor = Color.FromName("Azure");
            pictureBox1.Refresh();
            for (int i = 0; i < 11; i++)
            {
                // Отображение первой группы строк
                if ((i >= 0) && (i <= 7))
                {
                    Font fn = new Font("Courier New", 18, FontStyle.Regular);
                    StringFormat sf =
                    (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Far;
                    g.DrawString(sm[i], fn, Brushes.Red,
                    new RectangleF(200, 30 + i * 20, pictureBox1.Size.Width - (pictureBox1.Size.Width/2),
                    pictureBox1.Size.Height - (pictureBox1.Size.Height)), sf);
                    fn.Dispose();
                }
                // Отображение второй группы строк
                if ((i >= 8) && (i <= 9))
                {
                    Font fn = new Font("Arial", 24, FontStyle.Italic);
                    StringFormat sf =
                    (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Far;
                    g.DrawString(sm[i], fn, Brushes.Black,
                    new RectangleF(0 + k * 10, 0, (pictureBox1.Size.Width - pictureBox1.Size.Width+70),
                    pictureBox1.Size.Height - 20), sf);
                    fn.Dispose();
                    k = i + 1;
                }
                // Отображение третьей группы строк
                if (i == 10)
                {                 
                    Font fn = new Font("Times New Roman", 24, FontStyle.Bold);
                    StringFormat sf =
                    (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Green,
                    new RectangleF(200, 200/*<- Изменить*/, pictureBox1.Size.Width - (pictureBox1.Size.Width/2),
                    pictureBox1.Size.Height - 20), sf);
                    fn.Dispose();
                }

            }
        }

    }
}
