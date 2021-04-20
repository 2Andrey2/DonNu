using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Lb3_Cards_
{
    public partial class Form1 : Form
    {

        #region Библиотеки
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        const int WH_KEYBOARD_LL = 13; // Номер глобального LowLevel-хука на клавиатуру
        const int
            WM_KEYDOWN = 0x100,       //Key down
            WM_KEYUP = 0x101;         //Key up

        public LowLevelKeyboardProc _proc;

        public static IntPtr hhook = IntPtr.Zero;
        #endregion
        public Form1()
        {
            _proc = HookProc;
            //Запуск хука
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }
        string[] CardsName = { "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Dame", "King", "Ace" };
        int offsetX = 0;
        int offsetY = 0;
        bool drag;
        private void Button1_Click(object sender, EventArgs e)
        {
            Gen();
        }
        public void Gen()
        {
            string[] suit = { "Booba", "Cherva", "Cross", "Pica" };
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    BoxCard box = new BoxCard
                    {
                        Parent = panel1,
                        Location = new System.Drawing.Point(this.Width - this.Width / 4, this.Height - this.Height / 2),
                        Name = "Cards" + CardsName[i],
                        Size = new System.Drawing.Size(765 / 3, 1054 / 3),
                        TabIndex = 0,
                        TabStop = false,
                        Suit = suit[j],
                        valueC = CardsName[i],
                        Image = new Bitmap(@"Card\fon.png"),
                        BackColor = Color.Transparent,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    box.MouseDown += new System.Windows.Forms.MouseEventHandler(this.box_MouseDown);
                    box.MouseUp += new System.Windows.Forms.MouseEventHandler(this.box_MouseUp);
                    box.MouseMove += new System.Windows.Forms.MouseEventHandler(this.box_MouseMove);
                }
            }
            Random ran = new Random();
            for (int i = 0; i < 100; i++)
            {
                int temp = ran.Next(0, panel1.Controls.Count);
                if (panel1.Controls[temp] is BoxCard)
                {
                    BoxCard box = (BoxCard)panel1.Controls[temp];
                    box.BringToFront();
                }
            }
        }
        private void box_MouseDown(object sender, MouseEventArgs e)
        {
            BoxCard box = (BoxCard)sender;
            box.BringToFront();
            box.Image = new Bitmap(@"Card\" + box.valueC + @"\" + box.Suit + @".png");
            box.Size = new Size(box.Size.Width + 50, box.Size.Height + 50);
            drag = true;
            offsetX = e.Location.X;
            offsetY = e.Location.Y;
        }
        Random ran = new Random();
        private void box_MouseUp(object sender, MouseEventArgs e)
        {
            ran.Next(0, 50);
            PictureBox box = (PictureBox)sender;
            for (int i = 0; i < 50; i ++)
            {
                box.Size = new Size(box.Size.Width - 1, box.Size.Height - 1);
            }


            Image img = new Bitmap(box.Image.Width, box.Image.Height);
            using (Graphics g = Graphics.FromImage(img))
            {
                g.TranslateTransform(200,100);
                g.RotateTransform(ran.Next(0, 50)); // поворот на 45 градусов
                g.TranslateTransform(200,100);
                g.DrawImage(box.Image, 0, 0);
            }
            box.Size = new Size(box.Size.Width - 100, box.Size.Height - 100);


            box.Image = img;
            drag = false;
            box.BringToFront();
        }

        private void box_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            if (drag)
            {
                int x = Cursor.Position.X - (this.Left + (this.Size.Width - this.ClientSize.Width) / 2) - offsetX;
                int y = Cursor.Position.Y - (this.Top + (this.Size.Height - this.ClientSize.Height - 4)) - offsetY;
                if (x > 0 && x < this.ClientSize.Width - box.Width)
                    box.Left = x;
                else
                    box.Left = x > 0 ? x = this.ClientSize.Width - box.Width : 0;
                if (y > 0 && y < this.ClientSize.Height - box.Height)
                    box.Top = y;
                else
                    box.Top = y > 0 ? y = this.ClientSize.Height - box.Height : 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Paint += new PaintEventHandler(Panel1_Paint);
            panel1.Refresh();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnhookWindowsHookEx(hhook); //Остановить хук
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(panel1.ClientRectangle, Color.Red, Color.Yellow, 45);

            ColorBlend cblend = new ColorBlend(3)
            {
                Colors = new Color[3] { Color.Red, Color.Yellow, Color.Green },
                Positions = new float[3] { 0f, 0.5f, 1f }
            };

            linearGradientBrush.InterpolationColors = cblend;

            e.Graphics.FillRectangle(linearGradientBrush, panel1.ClientRectangle);
        }
        public void Delbox ()
        {
            BoxCard box;
            int i = 0;
            do
            {
                if (panel1.Controls[i] is BoxCard)
                {
                    box = (BoxCard)panel1.Controls[i];
                    box.Image = null;
                    box = new BoxCard();
                    box = null;
                    panel1.Controls.Remove(panel1.Controls[i]);
                    i = 0;
                }
                i++;
            } while (panel1.Controls.Count != i);
            box = (BoxCard)panel1.Controls[0];
            box.Image = null;
            box = new BoxCard();
            box = null;
            panel1.Controls.Remove(panel1.Controls[0]);
            GC.Collect();
            Gen();
        }
        public IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0 && wParam == (IntPtr)WM_KEYDOWN || code >= 0 && wParam == (IntPtr)260)
            {
                int vkCode = Marshal.ReadInt32(lParam); //Получить код клавиши
                if (vkCode == 113) //Нажатие Esc
                {
                    Delbox();

                }
            }
            return IntPtr.Zero;
        }
    }
}
