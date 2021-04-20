using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LB3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int col = 0;
        int number = 0;
        string ActualName = "";
        static public string textcopyright = "Stoc";
        string PathSave = "";
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                PictureMain.Image = new Bitmap(dialog.FileName);
            }
        }
        private void OpenDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            number = 0;
            col = 0;
            panel1.Controls.Clear();
            dataGridView1.Rows.Clear();
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            if (dialog.SelectedPath != "")
            {
                string[] second = Directory.GetFiles(dialog.SelectedPath);
                for (int i = 0; i < second.Length; i++)
                {
                    if (second[i].Contains(".jpg") == true)
                    {
                        ModPichers box = new ModPichers();
                        box.Parent = panel1;
                        box.Location = new System.Drawing.Point(0, 17 + col);
                        box.Name = "pictureBox" + number;
                        box.Size = new System.Drawing.Size(250, 150);
                        box.TabIndex = 0;
                        box.TabStop = false;
                        box.SizeMode = PictureBoxSizeMode.Zoom;
                        box.Image = new Bitmap(second[i]);
                        box.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Pictur_PreviewKeyDown);
                        box.Width = Convert.ToString(box.Image.Width);
                        box.Height = Convert.ToString(box.Image.Height);
                        box.file = second[i];
                        box.Click += new System.EventHandler(this.PicturCol_Click);
                        col += 140;
                        number++;
                    }
                }
            }
        }
        private void PicturCol_Click(object sender, EventArgs e)
        {
            ModPichers newsender = (ModPichers)sender;
            PictureMain.Image = newsender.Image;
            newsender.Image = new Bitmap(PictureMain.Image);
            ActualName = newsender.Name;
            if (newsender.origin != null)
            {
                PictureMain.Image = newsender.origin;
            }
            newsender.Focus();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(PictureMain.Image);
            g.DrawString(textcopyright, new Font("Arial", 100), new SolidBrush(Color.Red), new Point(0, PictureMain.Image.Height - PictureMain.Image.Height / 2));
            g.DrawImage(new Bitmap("prin.png"), 0, 0, 1280, 720); //логотип
            g.Dispose();
            PictureMain.Image = PictureMain.Image;
            if (panel1.Controls.Count != 0)
            {
                graf(PictureMain.Image);
            }
        }
        private void graf(Image image)
        {
            bool flag = true;
            Control[] mass = panel1.Controls.Find(ActualName, flag);
            if (mass != null)
            {
                ModPichers box = (ModPichers)mass[0];
                Graphics g = Graphics.FromImage(box.Image);
                g.DrawImage(new Bitmap("voskl.png"), 0, 0, 142 * 3, 119 * 3); //логотип
                box.Image = box.Image;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = textcopyright;
                dataGridView1.Rows[dataGridView1.Rows.Count-1].Cells[1].Value = box.Width;
                dataGridView1.Rows[dataGridView1.Rows.Count-1].Cells[2].Value = box.Height;
                dataGridView1.Rows[dataGridView1.Rows.Count-1].Cells[0].Value = box.file;

                box.origin = image;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "grafic files (*.png)|*.png|All files (*.*)|*.*";
            dialog.ShowDialog();
            if (dialog.FileName != "") { PictureMain.Image.Save(dialog.FileName); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PathSave != "")
            {
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    ModPichers box = (ModPichers)panel1.Controls[i];
                    Graphics g = Graphics.FromImage(box.Image);
                    g.DrawString(textcopyright, new Font("Arial", 100), new SolidBrush(Color.Red), new Point(0, box.Image.Height - box.Image.Height / 5));
                    g.DrawImage(new Bitmap("prin.png"), box.Image.Width - ((box.Image.Width / 2) + 720), 0, 1280, 720); //логотип
                    g.Dispose();
                    box.Image.Save(PathSave + @"\Картинка" + i + ".png");
                }
                MessageBox.Show("Все картинки обрвботвны и добавлены по указаному пути");
            }
            else
            {
                MessageBox.Show("Введите путь сохранения");
            }
        }

        private void copyrightTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            input input = new input();
            input.Show();
        }

        private void copyrightDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            PathSave = dialog.SelectedPath;
        }
        private void Pictur_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            int flag = 0;
            if (e.KeyCode == Keys.Delete)
            {
                PictureBox box = (PictureBox)sender;
                box.Dispose();
                panel1.Controls.Remove(box);
                for (int i = 0; i < panel1.Controls.Count - 1; i++)
                {
                    if (panel1.Controls[i].Location.Y != panel1.Controls[i + 1].Location.Y - 140 && flag == 0)
                    {
                        flag = i;
                        break;
                    }
                }
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if (flag < i)
                    {
                        panel1.Controls[i].Location = new Point(panel1.Controls[i].Location.X, panel1.Controls[i].Location.Y - 140);
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addCopyrightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button3_Click(sender,e);
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void batchModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
        //if (e.KeyCode == Keys.Delete)
        //{
        //    foreach (Control cl in this.Controls)
        //        if (cl.Focused)
        //        {
        //            PictureBox box = (PictureBox)cl;
        //            box.Dispose();
        //            panel1.Controls.Remove(box);
        //            for (int i = 0; i < panel1.Controls.Count - 1; i ++) 
        //            {
        //                if (panel1.Controls[i].Location.Y != panel1.Controls[i + 1].Location.Y - 140)
        //                {
        //                    MessageBox.Show("Сработало");
        //                }
        //            }
        //        }
        //}
    }
}
