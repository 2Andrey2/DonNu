using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LB7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Битовая картинка pictureBox
        Bitmap pictureBoxBitMap;
        // Битовая картинка динамического изображения
        Bitmap spriteBitMap;
        // Битовая картинка для временного хранения области экрана
        Bitmap cloneBitMap;
        // Графический контекст picturebox
        Graphics g_pictureBox;
        // Графический контекст спрайта
        Graphics g_sprite;
        int x, y;
        int width = 700, height = 400;
        Timer timer;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Создаём Bitmap для pictureBox1 и графический контекст
            pictureBox1.Image = Image.FromFile(@"fon.jpg");
            pictureBoxBitMap = new Bitmap(pictureBox1.Image);
            g_pictureBox = Graphics.FromImage(pictureBox1.Image);
            // Создаём Bitmap для спрайта и графический контекст
            spriteBitMap = new Bitmap(width, height);
            g_sprite = Graphics.FromImage(spriteBitMap);
            // Рисуем линию движения корабля
            g_pictureBox.DrawLine(new Pen(Color.Black, 2), 0, 410, pictureBox1.Width - 1, 410);
            // Рисуем корабль на графическом контексте g_sprite
            DrawSprite();
            // Создаём Bitmap для временного хранения части изображения
            cloneBitMap = new Bitmap(width, height);
            // Задаем начальные координаты вывода движущегося объекта
            x = 0; y = 100;
            // Сохраняем область экрана перед первым выводом объекта
            SavePart(x, y);
            // Выводим корабль на графический контекст g_pictureBox
            g_pictureBox.DrawImage(spriteBitMap, x, y);
            // Перерисовываем pictureBox1
            pictureBox1.Invalidate();
            // Создаём таймер с интервалом 100 миллисекунд
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += new EventHandler(timer1_Tick);
        }
        // Функция рисования спрайта (кораблика)
        void DrawSprite()
        {
            SolidBrush myCorp = new SolidBrush(Color.DarkMagenta);
            SolidBrush myTrum = new SolidBrush(Color.DarkOrchid);
            SolidBrush myTrub = new SolidBrush(Color.DeepPink);
            SolidBrush mySeа = new SolidBrush(Color.Blue);
            //Выбираем перо myPen желтого цвета толщиной в 2 пикселя:
            Pen myWind = new Pen(Color.Yellow, 2);
            // Закрашиваем фигуры
            g_sprite.FillRectangle(myTrub, 300, 125, 75, 75); // 1 труба (прямоугольник)
            g_sprite.FillRectangle(myTrub, 480, 125, 75, 75); // 2 труба (прямоугольник)
            g_sprite.FillPolygon(myCorp, new Point[]      // корпус (трапеция)
              {
                new Point(100,300),new Point(700,300),
                new Point(700,300),new Point(600,400),
                new Point(600,400),new Point(200,400),
                new Point(200,400),new Point(100,300)
              }
            );
            g_sprite.FillRectangle(myTrum, 250, 200, 350, 100); // палуба (прямоугольник)
                                                         // Море - 12 секторов-полуокружностей
            int x = 50;
            int Radius = 50;
            while (x <= pictureBox1.Width - Radius)
            {
                g_sprite.FillPie(mySeа, 0 + x, 375, 50, 50, 0, -180);
                x += 50;
            }
            // Иллюминаторы 
            for (int y = 300; y <= 550; y += 50)
            {
                g_sprite.DrawEllipse(myWind, y, 240, 20, 20); // 6 окружностей
            }
        }
        // Функция сохранения части изображения шириной
        void SavePart(int xt, int yt)
        {
            Rectangle cloneRect = new Rectangle(xt, yt, width, height);
            System.Drawing.Imaging.PixelFormat format = pictureBoxBitMap.PixelFormat;
            // Клонируем изображение, заданное прямоугольной областью
            cloneBitMap = pictureBoxBitMap.Clone(cloneRect, format);
        }
        // Обрабатываем событие от таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Восстанавливаем затёртую область статического изображения
            g_pictureBox.DrawImage(cloneBitMap, x, y);
           
            x += 10;
           
            //if (x > pictureBox1.Width - 700) x = pictureBox1.Location.X;
            if (x > this.Width+700) x = 0;
            
            SavePart(x, y);
           
            g_pictureBox.DrawImage(spriteBitMap, x, y);
            // Перерисовываем pictureBox1
            pictureBox1.Invalidate();
        }
        // Включаем таймер по нажатию на кнопку
        private void button1_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }
    }
}
