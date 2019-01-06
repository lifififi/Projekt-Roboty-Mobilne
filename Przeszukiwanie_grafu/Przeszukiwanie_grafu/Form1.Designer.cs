namespace Przeszukiwanie_grafu
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.grafButton = new System.Windows.Forms.Button();
            this.sciezkaButton = new System.Windows.Forms.Button();
            this.liczbaWierzcholkow = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.wierzcholkiButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.slowA = new System.Windows.Forms.Button();
            this.mediumA = new System.Windows.Forms.Button();
            this.fastA = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.animacja = new System.Windows.Forms.CheckBox();
            this.RRTsciezka = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.buttonRRT = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.czasLabel = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.liczbaWierzcholkow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // grafButton
            // 
            this.grafButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grafButton.Location = new System.Drawing.Point(152, 31);
            this.grafButton.Name = "grafButton";
            this.grafButton.Size = new System.Drawing.Size(114, 23);
            this.grafButton.TabIndex = 0;
            this.grafButton.Text = "Rysuj Graf";
            this.grafButton.UseVisualStyleBackColor = false;
            this.grafButton.Click += new System.EventHandler(this.RysujGraf_Click);
            // 
            // sciezkaButton
            // 
            this.sciezkaButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.sciezkaButton.Location = new System.Drawing.Point(152, 60);
            this.sciezkaButton.Name = "sciezkaButton";
            this.sciezkaButton.Size = new System.Drawing.Size(114, 23);
            this.sciezkaButton.TabIndex = 1;
            this.sciezkaButton.Text = "Rysuj Ścieżkę";
            this.sciezkaButton.UseVisualStyleBackColor = false;
            this.sciezkaButton.Click += new System.EventHandler(this.sciezkaButton_Click);
            // 
            // liczbaWierzcholkow
            // 
            this.liczbaWierzcholkow.LargeChange = 100;
            this.liczbaWierzcholkow.Location = new System.Drawing.Point(9, 25);
            this.liczbaWierzcholkow.Maximum = 3000;
            this.liczbaWierzcholkow.Minimum = 1000;
            this.liczbaWierzcholkow.Name = "liczbaWierzcholkow";
            this.liczbaWierzcholkow.Size = new System.Drawing.Size(90, 45);
            this.liczbaWierzcholkow.SmallChange = 100;
            this.liczbaWierzcholkow.TabIndex = 100;
            this.liczbaWierzcholkow.TickFrequency = 100;
            this.liczbaWierzcholkow.Value = 1000;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(3, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(898, 604);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Liczba wierzchołków";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "3000";
            // 
            // wierzcholkiButton
            // 
            this.wierzcholkiButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.wierzcholkiButton.Location = new System.Drawing.Point(152, 4);
            this.wierzcholkiButton.Name = "wierzcholkiButton";
            this.wierzcholkiButton.Size = new System.Drawing.Size(114, 23);
            this.wierzcholkiButton.TabIndex = 104;
            this.wierzcholkiButton.Text = "Generuj wierzcholki";
            this.wierzcholkiButton.UseVisualStyleBackColor = false;
            this.wierzcholkiButton.Click += new System.EventHandler(this.GenerujWierzcholki_Click);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.Red;
            this.resetButton.Location = new System.Drawing.Point(840, 28);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(61, 28);
            this.resetButton.TabIndex = 105;
            this.resetButton.Text = "RESET";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Linen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.wierzcholkiButton);
            this.panel1.Controls.Add(this.grafButton);
            this.panel1.Controls.Add(this.sciezkaButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.liczbaWierzcholkow);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 91);
            this.panel1.TabIndex = 106;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 108;
            this.label6.Text = "3.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 107;
            this.label5.Text = "2.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "1.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 105;
            this.label2.Text = "1000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(119, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 24);
            this.label7.TabIndex = 109;
            this.label7.Text = "PRM";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Linen;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.slowA);
            this.panel2.Controls.Add(this.mediumA);
            this.panel2.Controls.Add(this.fastA);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(287, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(272, 91);
            this.panel2.TabIndex = 109;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // slowA
            // 
            this.slowA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.slowA.Location = new System.Drawing.Point(153, 60);
            this.slowA.Name = "slowA";
            this.slowA.Size = new System.Drawing.Size(114, 23);
            this.slowA.TabIndex = 111;
            this.slowA.Text = "Szukaj ";
            this.slowA.UseVisualStyleBackColor = false;
            this.slowA.Click += new System.EventHandler(this.AlgorytmAGwiazdka);
            // 
            // mediumA
            // 
            this.mediumA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mediumA.Location = new System.Drawing.Point(155, 34);
            this.mediumA.Name = "mediumA";
            this.mediumA.Size = new System.Drawing.Size(114, 23);
            this.mediumA.TabIndex = 110;
            this.mediumA.Text = "Szukaj ";
            this.mediumA.UseVisualStyleBackColor = false;
            this.mediumA.Click += new System.EventHandler(this.AlgorytmAGwiazdka);
            // 
            // fastA
            // 
            this.fastA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fastA.Location = new System.Drawing.Point(155, 7);
            this.fastA.Name = "fastA";
            this.fastA.Size = new System.Drawing.Size(114, 23);
            this.fastA.TabIndex = 109;
            this.fastA.Text = "Szukaj ";
            this.fastA.UseVisualStyleBackColor = false;
            this.fastA.Click += new System.EventHandler(this.AlgorytmAGwiazdka);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 13);
            this.label8.TabIndex = 108;
            this.label8.Text = "3. Wolno (Nakrótsza Trasa)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 13);
            this.label9.TabIndex = 107;
            this.label9.Text = "2. Średnio (Optymalna Trasa)";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 13);
            this.label10.TabIndex = 106;
            this.label10.Text = "1. Szybko (Dłuższa Trasa)";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(283, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(286, 24);
            this.label11.TabIndex = 110;
            this.label11.Text = "Metoda rastrowa -Algorytm A*";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(682, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 24);
            this.label12.TabIndex = 112;
            this.label12.Text = "RRT";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Linen;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.animacja);
            this.panel3.Controls.Add(this.RRTsciezka);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.trackBar1);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.buttonRRT);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(565, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(272, 91);
            this.panel3.TabIndex = 113;
            // 
            // animacja
            // 
            this.animacja.AutoSize = true;
            this.animacja.Location = new System.Drawing.Point(155, 39);
            this.animacja.Name = "animacja";
            this.animacja.Size = new System.Drawing.Size(69, 17);
            this.animacja.TabIndex = 1002;
            this.animacja.Text = "Animacja";
            this.animacja.UseVisualStyleBackColor = true;
            // 
            // RRTsciezka
            // 
            this.RRTsciezka.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RRTsciezka.Location = new System.Drawing.Point(155, 62);
            this.RRTsciezka.Name = "RRTsciezka";
            this.RRTsciezka.Size = new System.Drawing.Size(114, 23);
            this.RRTsciezka.TabIndex = 1001;
            this.RRTsciezka.Text = "Rysuj Ścieżkę";
            this.RRTsciezka.UseVisualStyleBackColor = false;
            this.RRTsciezka.Click += new System.EventHandler(this.RRTsciezka_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(72, 57);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 13);
            this.label18.TabIndex = 114;
            this.label18.Text = "30 000";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 57);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 114;
            this.label17.Text = "3000";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1000;
            this.trackBar1.Location = new System.Drawing.Point(13, 25);
            this.trackBar1.Maximum = 30000;
            this.trackBar1.Minimum = 3000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(90, 45);
            this.trackBar1.SmallChange = 1000;
            this.trackBar1.TabIndex = 1000;
            this.trackBar1.TickFrequency = 1000;
            this.trackBar1.Value = 8000;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 13);
            this.label16.TabIndex = 111;
            this.label16.Text = "Liczba wierzchołków";
            // 
            // buttonRRT
            // 
            this.buttonRRT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonRRT.Location = new System.Drawing.Point(155, 9);
            this.buttonRRT.Name = "buttonRRT";
            this.buttonRRT.Size = new System.Drawing.Size(114, 23);
            this.buttonRRT.TabIndex = 109;
            this.buttonRRT.Text = "Twórz drzewo";
            this.buttonRRT.UseVisualStyleBackColor = false;
            this.buttonRRT.Click += new System.EventHandler(this.buttonRRT_Click_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(133, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 13);
            this.label13.TabIndex = 107;
            this.label13.Text = "2.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(133, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 13);
            this.label14.TabIndex = 106;
            this.label14.Text = "1.";
            // 
            // czasLabel
            // 
            this.czasLabel.AutoSize = true;
            this.czasLabel.Location = new System.Drawing.Point(846, 84);
            this.czasLabel.Name = "czasLabel";
            this.czasLabel.Size = new System.Drawing.Size(31, 13);
            this.czasLabel.TabIndex = 1002;
            this.czasLabel.Text = "--:--:--";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(843, 68);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 13);
            this.label19.TabIndex = 1003;
            this.label19.Text = "CZAS:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(907, 728);
            this.Controls.Add(this.czasLabel);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.liczbaWierzcholkow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button grafButton;
        private System.Windows.Forms.Button sciezkaButton;
        private System.Windows.Forms.TrackBar liczbaWierzcholkow;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button wierzcholkiButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button fastA;
        private System.Windows.Forms.Button slowA;
        private System.Windows.Forms.Button mediumA;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox animacja;
        private System.Windows.Forms.Button RRTsciezka;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button buttonRRT;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label czasLabel;
        private System.Windows.Forms.Label label19;
    }
}

