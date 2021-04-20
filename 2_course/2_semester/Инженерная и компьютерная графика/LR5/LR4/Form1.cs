using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LR4
{
    public partial class Form1 : Form
    {
        const int NMAX = 500;
        const double BIG = 1.0e30;
        Graphics dc; Pen p;
        int n; int[] v; double[] x; double[] y;
        ComboBox tbComboBox1;
        // Для динамических TextBox
        public const int bh = 40; public const int bw = 40;
        public static int iRows = 40, iColumns = 2;
        public TextBox[,] tbArray;
        public Form1()
        {
            InitializeComponent();
            v = new int[NMAX];
            x = new double[NMAX];
            y = new double[NMAX];
            x[0] = 1; x[1] = 6; x[2] = 6; x[3] = 4; x[4] = 4; x[5] = 5; x[6] = 5; x[7] = 2; x[8] = 2; x[9] = 3; x[10] = 3; x[11] = 1;
            x[12] = 7; x[13] = 12; x[14] = 12; x[15] = 10; x[16] = 10; x[17] = 11; x[18] = 11; x[19] = 9; x[20] = 9; x[21] = 10; x[22] = 10; x[23] = 6; x[24] = 4; x[25] = 1; x[26] = 3; x[27] = 4; x[28] = 2; x[29] = 5; x[30] = 3; x[31] = 3; x[32] = 1; x[33] = 1; x[34] = 6; x[35] = 6; x[36] = 7; x[37] = 4; x[38] = 5; x[39] = 8; x[40] = 4; x[41] = 5;
            y[0] = 1; y[1] = 1; y[2] = 4; y[3] = 4; y[4] = 3; y[5] = 3; y[6] = 2; y[7] = 2; y[8] = 3; y[9] = 3; y[10] = 4; y[11] = 4;
            y[12] = 1; y[13] = 1; y[14] = 4; y[15] = 4; y[16] = 3; y[17] = 3; y[18] = 2; y[19] = 2; y[20] = 3; y[21] = 3; y[22] = 4; y[23] = 4; y[24] = 4; y[25] = 5; y[26] = 5; y[27] = 6; y[28] = 2; y[29] = 3; y[30] = 3; y[31] = 4; y[32] = 4; y[33] = 1; y[34] = 1; y[35] = 4; y[36] = 5; y[37] = 3; y[38] = 3; y[39] = 4; y[40] = 3; y[41] = 3;
            dc = pictureBox1.CreateGraphics();
            p = new Pen(Brushes.Red, 1);
            // Создание динамического ComboBox
            tbComboBox1 = new ComboBox()
            {
                Location = new Point(1, 1),
                Width = 121,
                Height = 21
            };

            panel1.Controls.Add(tbComboBox1);
            for (int i = 0; i < NMAX; i++) { tbComboBox1.Items.Add(i); }
            tbComboBox1.SelectedItem = 12;
            // Создание динамических TextBox
            Create(iRows, iColumns);
        }
        // Создаёт динамически TextBoxы для ввода координат вершин полигона
        public void Create(int rows, int columns)
        {
            tbArray = new TextBox[rows, columns]; int y1 = 1;
            for (int i = 0; i < rows; i++)
            {
                int x1 = 140; y1 += bh - 10;
                for (int j = 0; j < columns; j++)
                {
                    tbArray[i, j] = new TextBox(); tbArray[i, j].Name = "TextBox" + i + j;
                    panel1.Controls.Add(tbArray[i, j]);
                    tbArray[i, j].SetBounds(x1, y1, bw, bh);
                    x1 += bw;

                }
                tbArray[i, 0].Text = x[i].ToString("R");
                tbArray[i, 1].Text = y[i].ToString("R");

            }
        }
        /* Метод преобразования вещественной координаты X в целую */
        private int IX(double x)
        { double xx = x * (pictureBox1.Size.Width / 10.0) + 0.5; return (int)xx; }
        /* Метод преобразования вещественной координаты Y в целую */
        private int IY(double y)
        {
            double yy = pictureBox1.Size.Height - y * (pictureBox1.Size.Height / 7.0) + 0.5;

            return (int)yy;
        }
        /* Своя функция вычечивания линии (экран 10х7 условных единиц) */
        private void Draw(double x1, double y1, double x2, double y2)
        {
            Point point1 = new Point(IX(x1), IY(y1)); Point point2 = new Point(IX(x2), IY(y2));
            dc.DrawLine(p, point1, point2);
        }
        private unsafe bool counter_clock(int h, int i, int j, double* pdist)
        {
            double xh = x[v[h]], xi = x[v[i]], xj = x[v[j]],
            yh = y[v[h]], yi = y[v[i]], yj = y[v[j]],
            x_hi, y_hi, x_hj, y_hj, Determ;
            x_hi = xi - xh; y_hi = yi - yh; x_hj = xj - xh; y_hj = yj - yh;
            *pdist = x_hj * x_hj + y_hj * y_hj;
            Determ = x_hi * y_hj - x_hj * y_hi;
            return (Determ > 1e-6);
        }
        private void draw_polygon()
        {
            int i; double xold, yold;
            xold = x[n - 1]; yold = y[n - 1];
            for (i = 0; i < n; i++)
            {
                Draw(xold, yold, x[i], y[i]); xold = x[i]; yold = y[i];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        /* Основная программа */
        private unsafe void button1_Click(object sender, EventArgs e)
        {
            int i, h, j, m, k, imin = 0; double diag, min_diag;
            n = Convert.ToInt16(tbComboBox1.SelectedItem.ToString());
            if (n >= NMAX)
            {

                MessageBox.Show("Количество вершин слишком велико!", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            for (i = 0; i < n; i++)
            {
                x[i] = Convert.ToDouble(tbArray[i, 0].Text);
                y[i] = Convert.ToDouble(tbArray[i, 1].Text);
                v[i] = i;
            }
            m = n;
            draw_polygon();
            // Задаём штриховую линию (длина штриха, промежуток, длина штриха, промежуток)
            float[] dashValues = { 5, 5, 5, 5 }; p.DashPattern = dashValues;
            while (m > 3)
            {
                min_diag = BIG;
                for (i = 0; i < m; i++)
                {
                    h = (i == 0 ? m - 1 : i - 1); j = (i == m - 1 ? 0 : i + 1);
                    if (counter_clock(h, i, j, &diag) && (diag < min_diag))
                    {
                        min_diag = diag; imin = i;
                    }
                }
                i = imin; h = (i == 0 ? m - 1 : i - 1); j = (i == m - 1 ? 0 : i + 1);
                if (min_diag == BIG)
                {
                    MessageBox.Show("Неправильное направление обхода!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Application.Exit();
                }
                Draw(x[v[h]], y[v[h]], x[v[j]], y[v[j]]);
                m--;
                for (k = i; k < m; k++) v[k] = v[k + 1];
            }
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
        }
    }
}
