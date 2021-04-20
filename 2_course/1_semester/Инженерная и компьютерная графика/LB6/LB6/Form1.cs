using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace LB6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush House = new SolidBrush(Color.Gray);
            SolidBrush houseWindow = new SolidBrush(Color.Yellow);
            SolidBrush Sky = new SolidBrush(Color.Blue);
            SolidBrush Sun = new SolidBrush(Color.Orange);
            SolidBrush Earth = new SolidBrush(Color.Green);
            SolidBrush Too = new SolidBrush(Color.Gray);
            g.PageUnit = GraphicsUnit.Millimeter;
            int WidthInMM = Convert.ToInt16((pictureBox1.Size.Width - 1) / g.DpiX * 25.4);
            int HeightInMM = Convert.ToInt16((pictureBox1.Size.Height - 1) / g.DpiY * 25.4);
            int HeightInMM2 = Convert.ToInt16((pictureBox1.Size.Height * 0.5) / g.DpiY * 25.4);
            g.FillRectangle(Sky,0,0, WidthInMM, HeightInMM2);
            g.FillRectangle(Earth, 0, HeightInMM / 2, WidthInMM, HeightInMM/2);
            Random rund = new Random();
            int[] mass = new int[10];
            int temp = 35;
            for (int i = 1; i < 11; i++)
            {
                metka:
                int distance = rund.Next(20, 35);
                if (distance - temp < 20)
                {
                    g.FillRectangle(House, i * distance, HeightInMM - 50, 15, 50);
                    mass[i-1] = i * distance;
                    temp = i * distance;
                }
                else
                {
                    goto metka;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        g.FillRectangle(houseWindow, mass[i] + j *3 + 1, HeightInMM - k * 5 - 5, 2, 2);
                    }
                }
            }
            g.FillEllipse(Sun, 10, 10, 20, 20);
            g.DrawEllipse(Pens.Yellow, 10, 10, 20, 20);

            Image img = Image.FromFile("img.bmp");
            TextureBrush tb = new TextureBrush(img);
            g.FillEllipse(tb, 15, -15, 500, 50);
        }
    }
}
