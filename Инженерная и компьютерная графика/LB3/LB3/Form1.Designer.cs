namespace LB3
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.infile = new System.Windows.Forms.Button();
            this.kleaning = new System.Windows.Forms.Button();
            this.themap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // infile
            // 
            this.infile.Location = new System.Drawing.Point(12, 395);
            this.infile.Name = "infile";
            this.infile.Size = new System.Drawing.Size(100, 29);
            this.infile.TabIndex = 1;
            this.infile.Text = "Запись в файл";
            this.infile.UseVisualStyleBackColor = true;
            this.infile.Click += new System.EventHandler(this.infile_Click);
            // 
            // kleaning
            // 
            this.kleaning.Location = new System.Drawing.Point(790, 395);
            this.kleaning.Name = "kleaning";
            this.kleaning.Size = new System.Drawing.Size(100, 29);
            this.kleaning.TabIndex = 2;
            this.kleaning.Text = "Очистка";
            this.kleaning.UseVisualStyleBackColor = true;
            this.kleaning.Click += new System.EventHandler(this.kleaning_Click);
            // 
            // themap
            // 
            this.themap.Location = new System.Drawing.Point(397, 395);
            this.themap.Name = "themap";
            this.themap.Size = new System.Drawing.Size(100, 29);
            this.themap.TabIndex = 3;
            this.themap.Text = "Отображение";
            this.themap.UseVisualStyleBackColor = true;
            this.themap.Click += new System.EventHandler(this.themap_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 377);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(878, 377);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 436);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.themap);
            this.Controls.Add(this.kleaning);
            this.Controls.Add(this.infile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button infile;
        private System.Windows.Forms.Button kleaning;
        private System.Windows.Forms.Button themap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

