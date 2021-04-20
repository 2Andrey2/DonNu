using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LB8
{
    class Rock
    {
        public const int col_Rock = 5; // (здесь указать количество)
        public PictureBox[] Rock_mass = new PictureBox[col_Rock]; // Массив камней
        public void Resp(Form1 forma, PictureBox Main, Environment Envi) // Респ камней
        {
            for (int i = 0; i < Rock_mass.Length; i++)
            {
                Rock_mass[i] = new PictureBox();
                Rock_mass[i].BackColor = Color.Transparent;
                Rock_mass[i].Image = Image.FromFile(@"rock.png");
                Rock_mass[i].Size = new Size(Rock_mass[i].Image.Width, Rock_mass[i].Image.Height);
                Rock_mass[i].SizeMode = PictureBoxSizeMode.Zoom;
                Rock_mass[i].Location = Envi.lokation(forma, Rock_mass[i].Image);
                Rock_mass[i].BringToFront();
                Main.Controls.Add(Rock_mass[i]);
            }
        }
    }
}
