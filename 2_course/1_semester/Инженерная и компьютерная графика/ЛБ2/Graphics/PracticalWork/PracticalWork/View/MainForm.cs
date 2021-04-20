using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PracticalWork
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            pictureBox1.Paint += DrawCoordinateSystem;
            btnPixel.Click += DrawPixelСhart;

            btnClear.Click += (s, e) =>
            {
                pictureBox1.Invalidate();
            };
        }

        private void DrawCoordinateSystem(object sender, PaintEventArgs args)
        {
            var graphics = args.Graphics;

            var control = sender as Control;

            var width = control.Size.Width;
            var height = control.Size.Height;

            graphics.DrawRectangle(
                Pens.Black,
                new Rectangle(new Point(0, 0),
                new Size(width - 1, height - 1)));

            graphics.DrawLine(
                Pens.Black,
                new Point(width / 2, 0),
                new Point(width / 2, height));

            graphics.DrawLine(
                Pens.Black,
                new Point(0, height / 2),
                new Point(width, height / 2));
        }

        private void DrawPixelСhart(object sender, EventArgs e)
        {
            var graphics = pictureBox1.CreateGraphics();
            graphics.PageUnit = GraphicsUnit.Pixel;

            graphics.TranslateTransform((float)pictureBox1.Width / 2, (float)pictureBox1.Height / 2);
            graphics.ScaleTransform(4, 4);

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var points = new List<PointF>();

            for (float i = (float)(-10); i <= (float)(10); i++)
            {

                points.Add(new PointF
                {
                    X = i,
                    Y = i * 3 + i - 4
                });
            }

            var pen = new Pen(Color.Red, 0.5f);

            graphics.DrawCurve(pen, points.ToArray());
        }
    }
}
