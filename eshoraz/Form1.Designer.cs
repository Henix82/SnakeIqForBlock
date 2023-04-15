namespace eshoraz
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonSnake = new System.Windows.Forms.Button();
            this.buttonFeed = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.numericSnake = new System.Windows.Forms.NumericUpDown();
            this.numericFeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSnake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFeed)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1200, 550);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonSnake
            // 
            this.buttonSnake.Location = new System.Drawing.Point(302, 559);
            this.buttonSnake.Name = "buttonSnake";
            this.buttonSnake.Size = new System.Drawing.Size(75, 40);
            this.buttonSnake.TabIndex = 3;
            this.buttonSnake.Text = "Add Snake";
            this.buttonSnake.UseVisualStyleBackColor = true;
            this.buttonSnake.Click += new System.EventHandler(this.buttonSnake_Click);
            // 
            // buttonFeed
            // 
            this.buttonFeed.Location = new System.Drawing.Point(302, 607);
            this.buttonFeed.Name = "buttonFeed";
            this.buttonFeed.Size = new System.Drawing.Size(75, 40);
            this.buttonFeed.TabIndex = 4;
            this.buttonFeed.Text = "Add Feed";
            this.buttonFeed.UseVisualStyleBackColor = true;
            this.buttonFeed.Click += new System.EventHandler(this.buttonFeed_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Location = new System.Drawing.Point(1027, 584);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(90, 41);
            this.buttonRestart.TabIndex = 5;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // numericSnake
            // 
            this.numericSnake.Location = new System.Drawing.Point(150, 569);
            this.numericSnake.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSnake.Name = "numericSnake";
            this.numericSnake.Size = new System.Drawing.Size(120, 22);
            this.numericSnake.TabIndex = 6;
            this.numericSnake.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericFeed
            // 
            this.numericFeed.Location = new System.Drawing.Point(150, 617);
            this.numericFeed.Name = "numericFeed";
            this.numericFeed.Size = new System.Drawing.Size(120, 22);
            this.numericFeed.TabIndex = 7;
            this.numericFeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(89, 571);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Snake";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(98, 619);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Feed";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1200, 653);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericFeed);
            this.Controls.Add(this.numericSnake);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.buttonFeed);
            this.Controls.Add(this.buttonSnake);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSnake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonSnake;
        private System.Windows.Forms.Button buttonFeed;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.NumericUpDown numericSnake;
        private System.Windows.Forms.NumericUpDown numericFeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

