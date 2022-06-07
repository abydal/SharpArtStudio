namespace SharpArtStudio
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.numericUpDownSmoothOctave = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonPerlin2D = new System.Windows.Forms.RadioButton();
            this.radioButtonSmooth = new System.Windows.Forms.RadioButton();
            this.numericUpDownPerlin2DOctaves = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownStartPerlin2DBias = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonPerlin1D = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownPerlin1DOctaves = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownPerlin1DBias = new System.Windows.Forms.NumericUpDown();
            this.radioButtonVoronoi = new System.Windows.Forms.RadioButton();
            this.radioButtonVoronoiWorkshop = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownVoronoiPoints = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownVoronoiJitter = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSmoothOctave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerlin2DOctaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartPerlin2DBias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerlin1DOctaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerlin1DBias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVoronoiPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVoronoiJitter)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(1000, 1000);
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMain_Paint);
            // 
            // numericUpDownSmoothOctave
            // 
            this.numericUpDownSmoothOctave.Location = new System.Drawing.Point(1160, 160);
            this.numericUpDownSmoothOctave.Name = "numericUpDownSmoothOctave";
            this.numericUpDownSmoothOctave.Size = new System.Drawing.Size(73, 31);
            this.numericUpDownSmoothOctave.TabIndex = 1;
            this.numericUpDownSmoothOctave.ValueChanged += new System.EventHandler(this.numericUpDownSmoothOctaves_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1018, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Octaves";
            // 
            // radioButtonPerlin2D
            // 
            this.radioButtonPerlin2D.AutoSize = true;
            this.radioButtonPerlin2D.Location = new System.Drawing.Point(1018, 228);
            this.radioButtonPerlin2D.Name = "radioButtonPerlin2D";
            this.radioButtonPerlin2D.Size = new System.Drawing.Size(157, 29);
            this.radioButtonPerlin2D.TabIndex = 3;
            this.radioButtonPerlin2D.Text = "Perlin Noise 2D";
            this.radioButtonPerlin2D.UseVisualStyleBackColor = true;
            this.radioButtonPerlin2D.CheckedChanged += new System.EventHandler(this.radioButtonPerlin_CheckedChanged);
            // 
            // radioButtonSmooth
            // 
            this.radioButtonSmooth.AutoSize = true;
            this.radioButtonSmooth.Checked = true;
            this.radioButtonSmooth.Location = new System.Drawing.Point(1018, 125);
            this.radioButtonSmooth.Name = "radioButtonSmooth";
            this.radioButtonSmooth.Size = new System.Drawing.Size(151, 29);
            this.radioButtonSmooth.TabIndex = 3;
            this.radioButtonSmooth.TabStop = true;
            this.radioButtonSmooth.Text = "Smooth Noise";
            this.radioButtonSmooth.UseVisualStyleBackColor = true;
            this.radioButtonSmooth.CheckedChanged += new System.EventHandler(this.radioButtonSmooth_CheckedChanged);
            // 
            // numericUpDownPerlin2DOctaves
            // 
            this.numericUpDownPerlin2DOctaves.Enabled = false;
            this.numericUpDownPerlin2DOctaves.Location = new System.Drawing.Point(1160, 263);
            this.numericUpDownPerlin2DOctaves.Name = "numericUpDownPerlin2DOctaves";
            this.numericUpDownPerlin2DOctaves.Size = new System.Drawing.Size(73, 31);
            this.numericUpDownPerlin2DOctaves.TabIndex = 1;
            this.numericUpDownPerlin2DOctaves.ValueChanged += new System.EventHandler(this.numericUpDownPerlin2DOctaves_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1018, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Octaves";
            // 
            // numericUpDownStartPerlin2DBias
            // 
            this.numericUpDownStartPerlin2DBias.Enabled = false;
            this.numericUpDownStartPerlin2DBias.Location = new System.Drawing.Point(1160, 300);
            this.numericUpDownStartPerlin2DBias.Name = "numericUpDownStartPerlin2DBias";
            this.numericUpDownStartPerlin2DBias.Size = new System.Drawing.Size(73, 31);
            this.numericUpDownStartPerlin2DBias.TabIndex = 1;
            this.numericUpDownStartPerlin2DBias.ValueChanged += new System.EventHandler(this.numericUpDownStartAmplitude_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1018, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Bias";
            // 
            // radioButtonPerlin1D
            // 
            this.radioButtonPerlin1D.AutoSize = true;
            this.radioButtonPerlin1D.Location = new System.Drawing.Point(1018, 348);
            this.radioButtonPerlin1D.Name = "radioButtonPerlin1D";
            this.radioButtonPerlin1D.Size = new System.Drawing.Size(157, 29);
            this.radioButtonPerlin1D.TabIndex = 3;
            this.radioButtonPerlin1D.Text = "Perlin Noise 1D";
            this.radioButtonPerlin1D.UseVisualStyleBackColor = true;
            this.radioButtonPerlin1D.CheckedChanged += new System.EventHandler(this.radioButtonPerlin1D_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1018, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Octaves";
            // 
            // numericUpDownPerlin1DOctaves
            // 
            this.numericUpDownPerlin1DOctaves.Enabled = false;
            this.numericUpDownPerlin1DOctaves.Location = new System.Drawing.Point(1160, 383);
            this.numericUpDownPerlin1DOctaves.Name = "numericUpDownPerlin1DOctaves";
            this.numericUpDownPerlin1DOctaves.Size = new System.Drawing.Size(73, 31);
            this.numericUpDownPerlin1DOctaves.TabIndex = 1;
            this.numericUpDownPerlin1DOctaves.ValueChanged += new System.EventHandler(this.numericUpDownPerlin1DOctaves_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1018, 426);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Bias";
            // 
            // numericUpDownPerlin1DBias
            // 
            this.numericUpDownPerlin1DBias.Enabled = false;
            this.numericUpDownPerlin1DBias.Location = new System.Drawing.Point(1160, 424);
            this.numericUpDownPerlin1DBias.Name = "numericUpDownPerlin1DBias";
            this.numericUpDownPerlin1DBias.Size = new System.Drawing.Size(73, 31);
            this.numericUpDownPerlin1DBias.TabIndex = 1;
            this.numericUpDownPerlin1DBias.ValueChanged += new System.EventHandler(this.numericUpDownPerlin1DBias_ValueChanged);
            // 
            // radioButtonVoronoi
            // 
            this.radioButtonVoronoi.AutoSize = true;
            this.radioButtonVoronoi.Location = new System.Drawing.Point(1018, 510);
            this.radioButtonVoronoi.Name = "radioButtonVoronoi";
            this.radioButtonVoronoi.Size = new System.Drawing.Size(100, 29);
            this.radioButtonVoronoi.TabIndex = 3;
            this.radioButtonVoronoi.Text = "Voronoi";
            this.radioButtonVoronoi.UseVisualStyleBackColor = true;
            this.radioButtonVoronoi.CheckedChanged += new System.EventHandler(this.radioButtonVoronoi_CheckedChanged);
            // 
            // radioButtonVoronoiWorkshop
            // 
            this.radioButtonVoronoiWorkshop.AutoSize = true;
            this.radioButtonVoronoiWorkshop.Location = new System.Drawing.Point(1018, 600);
            this.radioButtonVoronoiWorkshop.Name = "radioButtonVoronoi";
            this.radioButtonVoronoiWorkshop.Size = new System.Drawing.Size(100, 29);
            this.radioButtonVoronoiWorkshop.TabIndex = 3;
            this.radioButtonVoronoiWorkshop.Text = "Voronoi Workshop";
            this.radioButtonVoronoiWorkshop.UseVisualStyleBackColor = true;
            this.radioButtonVoronoiWorkshop.CheckedChanged += new System.EventHandler(this.radioButtonVoronoiWorkshop_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1018, 542);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Points";
            // 
            // numericUpDownVoronoiPoints
            // 
            this.numericUpDownVoronoiPoints.Enabled = false;
            this.numericUpDownVoronoiPoints.Location = new System.Drawing.Point(1160, 540);
            this.numericUpDownVoronoiPoints.Name = "numericUpDownVoronoiPoints";
            this.numericUpDownVoronoiPoints.Size = new System.Drawing.Size(73, 31);
            this.numericUpDownVoronoiPoints.TabIndex = 1;
            this.numericUpDownVoronoiPoints.ValueChanged += new System.EventHandler(this.numericUpDownVoronoiPoints_ValueChanged);
            // 
            // numericUpDownVoronoiJitter
            // 
            this.numericUpDownVoronoiJitter.Enabled = false;
            this.numericUpDownVoronoiJitter.Location = new System.Drawing.Point(1160, 630);
            this.numericUpDownVoronoiJitter.Name = "numericUpDownVoronoiJitter";
            this.numericUpDownVoronoiJitter.Size = new System.Drawing.Size(73, 31);
            this.numericUpDownVoronoiJitter.TabIndex = 1;
            this.numericUpDownVoronoiJitter.ValueChanged += new System.EventHandler(this.numericUpDownVoronoiJitter_ValueChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 1038);
            this.Controls.Add(this.numericUpDownVoronoiPoints);
            this.Controls.Add(this.numericUpDownVoronoiJitter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButtonVoronoi);
            this.Controls.Add(this.radioButtonVoronoiWorkshop);
            this.Controls.Add(this.numericUpDownPerlin1DBias);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownPerlin1DOctaves);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioButtonPerlin1D);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownStartPerlin2DBias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownPerlin2DOctaves);
            this.Controls.Add(this.radioButtonSmooth);
            this.Controls.Add(this.radioButtonPerlin2D);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownSmoothOctave);
            this.Controls.Add(this.pictureBoxMain);
            this.Name = "MainWindow";
            this.Text = "SharpArtStudio";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSmoothOctave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerlin2DOctaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartPerlin2DBias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerlin1DOctaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerlin1DBias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVoronoiPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVoronoiJitter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.NumericUpDown numericUpDownSmoothOctave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonSmooth;
        private System.Windows.Forms.NumericUpDown numericUpDownPerlin2DOctaves;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownStartPerlin2DBias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonPerlin2D;
        private System.Windows.Forms.RadioButton radioButtonPerlin1D;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownPerlin1DOctaves;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownPerlin1DBias;
        private System.Windows.Forms.RadioButton radioButtonVoronoi;
        private System.Windows.Forms.RadioButton radioButtonVoronoiWorkshop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownVoronoiPoints;
        private System.Windows.Forms.NumericUpDown numericUpDownVoronoiJitter;
    }
}

