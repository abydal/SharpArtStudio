using System;
using System.Drawing;
using System.Windows.Forms;
using static SharpArtStudio.NoiseFunctions;

namespace SharpArtStudio
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeComponents();
            EnableSmoothMode();
        }

        private void InitializeComponents()
        {
            this.numericUpDownStartPerlin2DBias.Value = (decimal).1;
            this.numericUpDownStartPerlin2DBias.Maximum = 5;
            this.numericUpDownStartPerlin2DBias.Minimum = (decimal)0.1;
            this.numericUpDownStartPerlin2DBias.Increment = (decimal)0.1;
            this.numericUpDownStartPerlin2DBias.DecimalPlaces = 1;

            this.numericUpDownPerlin1DBias.Value = (decimal)2.0;
            this.numericUpDownPerlin1DBias.Maximum = 4;
            this.numericUpDownPerlin1DBias.Minimum = (decimal)0.1;
            this.numericUpDownPerlin1DBias.Increment = (decimal)0.1;
            this.numericUpDownPerlin1DBias.DecimalPlaces = 1;

            this.numericUpDownSmoothOctave.Value = 1;
            this.numericUpDownSmoothOctave.Maximum = 10;
            this.numericUpDownSmoothOctave.Minimum = 1;
            this.numericUpDownSmoothOctave.Increment = 1;

            this.numericUpDownPerlin2DOctaves.Value = 1;
            this.numericUpDownPerlin2DOctaves.Maximum = 10;
            this.numericUpDownPerlin2DOctaves.Minimum = 1;
            this.numericUpDownPerlin2DOctaves.Increment = 1;

            this.numericUpDownPerlin1DOctaves.Value = 1;
            this.numericUpDownPerlin1DOctaves.Maximum = 10;
            this.numericUpDownPerlin1DOctaves.Minimum = 1;
            this.numericUpDownPerlin1DOctaves.Increment = 1;

            this.numericUpDownVoronoiPoints.Value = 50;
            this.numericUpDownVoronoiPoints.Maximum = 10000;
            this.numericUpDownVoronoiPoints.Minimum = 10;
            this.numericUpDownVoronoiPoints.Increment = 5;

            this.numericUpDownVoronoiJitter.Value = (decimal).5;
            this.numericUpDownVoronoiJitter.Maximum = (decimal)1.0;
            this.numericUpDownVoronoiJitter.Minimum = (decimal)0;
            this.numericUpDownVoronoiJitter.Increment = (decimal)0.1;
            this.numericUpDownVoronoiJitter.DecimalPlaces = 1;
        }

        enum Mode
        {
            Perlin1D,
            Perlin2D,
            Smooth,
            Voronoi,
            VoronoiWorkshop
        }

        private void EnableSmoothMode()
        {
            mode = Mode.Smooth;
            numericUpDownSmoothOctave.Enabled = true;

            DisablePerlin1DMode();
            DisablePerlin2DMode();
            DisableVoronoiMode();
            DisableVoronoiWorsksopMode();
        }

        private void EnablePerlin1DMode()
        {
            mode = Mode.Perlin1D;
            numericUpDownPerlin1DOctaves.Enabled = true;
            numericUpDownPerlin1DBias.Enabled = true;

            DisableSmoothMode();
            DisablePerlin2DMode();
            DisableVoronoiMode();
            DisableVoronoiWorsksopMode();
        }

        private void EnableVoronoiMode()
        {
            mode = Mode.Voronoi;
            
            numericUpDownVoronoiPoints.Enabled = true;

            DisablePerlin1DMode();
            DisablePerlin2DMode();
            DisableSmoothMode();
            DisableVoronoiWorsksopMode();
        }

        private void EnableVoronoiWorkshopMode()
        {
            mode = Mode.VoronoiWorkshop;
            numericUpDownVoronoiJitter.Enabled = true;

            DisablePerlin1DMode();
            DisablePerlin2DMode();
            DisableSmoothMode();
            DisableVoronoiMode();
        }

        private void EnablePerlin2DMode()
        {
            mode = Mode.Perlin2D;
            numericUpDownPerlin2DOctaves.Enabled = true;
            numericUpDownStartPerlin2DBias.Enabled = true;

            DisableSmoothMode();
            DisablePerlin1DMode();
            DisableVoronoiMode();
            DisableVoronoiWorsksopMode();
        }

        private void DisableVoronoiMode()
        {
            radioButtonVoronoi.Checked = false;
            numericUpDownVoronoiPoints.Enabled = false;
        }

        private void DisableVoronoiWorsksopMode()
        {
            radioButtonVoronoiWorkshop.Checked = false;
            numericUpDownVoronoiJitter.Enabled = false;
        }

        private void DisablePerlin1DMode()
        {
            radioButtonPerlin1D.Checked = false;
            numericUpDownPerlin1DOctaves.Enabled = false;
            numericUpDownPerlin1DBias.Enabled = false;
        }

        private void DisablePerlin2DMode()
        {
            radioButtonPerlin2D.Checked = false;
            numericUpDownPerlin2DOctaves.Enabled = false;
            numericUpDownStartPerlin2DBias.Enabled = false;
        }

        private void DisableSmoothMode()
        {
            radioButtonSmooth.Checked = false;
            numericUpDownSmoothOctave.Enabled = false;
        }

        private Mode mode = Mode.Perlin2D;

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            var bmp = new Bitmap(1024, 1024);

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            
            byte[] buffer = null; 

            switch (mode)
            {
                case Mode.Perlin2D:
                    {
                        float[][] noise2D = Noise2D(bmp.Width, bmp.Height);
                        float[][] result = PerlinNoise2D(noise2D, bmp.Width, bmp.Height, (int)numericUpDownPerlin2DOctaves.Value, (float)numericUpDownStartPerlin2DBias.Value);
                        buffer = NormalizeToRgb2D(result, bmp.Width, bmp.Height);
                    }
                    break;
                case Mode.Smooth:
                    {
                        float[][] noise2D = Noise2D(bmp.Width, bmp.Height);
                        float[][] result = GeneratSmoothNoise(noise2D, bmp.Width, bmp.Height, (int)numericUpDownSmoothOctave.Value);
                        buffer = NormalizeToRgb2D(result, bmp.Width, bmp.Height);
                    }
                    break;
                case Mode.Perlin1D:
                    {
                        float[] noise = Noise1D(bmp.Width); 
                        float[] result = PerlinNoise1D(noise, bmp.Width, (int)numericUpDownPerlin1DOctaves.Value, (float)numericUpDownPerlin1DBias.Value);
                        buffer = NormalizeToRgb1D(result, bmp.Width, bmp.Height,250,500);
                    }
                    break;
                case Mode.Voronoi:
                    {
                        vec2[] points = RandomPoints((int)numericUpDownVoronoiPoints.Value);
                        buffer = DrawVoronoi(points, bmp.Width, bmp.Height);
                    }
                    break;
                case Mode.VoronoiWorkshop:
                    {
                        float[,] voronoi = VoronoiWorkshop.DrawVoronoi(bmp.Width, bmp.Height, 20, 20, (float)numericUpDownVoronoiJitter.Value, true);
                        buffer = NormalizeToRgb2D(voronoi, bmp.Width, bmp.Height);
                    }
                    break;

            }
            
            System.Runtime.InteropServices.Marshal.Copy(buffer, 0, ptr, bytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            e.Graphics.DrawImage(bmp,0,0,1024,1024);
        }

        

        private void radioButtonSmooth_CheckedChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                EnableSmoothMode();
            }
            pictureBoxMain.Refresh();
        }

        private void radioButtonPerlin_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                EnablePerlin2DMode();
            }
            pictureBoxMain.Refresh();
        }

        private void numericUpDownPersistance_ValueChanged(object sender, EventArgs e)
        {
            pictureBoxMain.Refresh();
        }

        private void numericUpDownStartAmplitude_ValueChanged(object sender, EventArgs e)
        {
            pictureBoxMain.Refresh();
        }

        private void radioButtonPerlin1D_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                EnablePerlin1DMode();
            }

            pictureBoxMain.Refresh();
        }

        private void numericUpDownPerlin1DOctaves_ValueChanged(object sender, EventArgs e)
        {
            pictureBoxMain.Refresh();
        }

        private void numericUpDownPerlin2DOctaves_ValueChanged(object sender, EventArgs e)
        {
            pictureBoxMain.Refresh();
        }

        private void numericUpDownSmoothOctaves_ValueChanged(object sender, EventArgs e)
        {
            pictureBoxMain.Refresh();
        }

        private void numericUpDownPerlin1DBias_ValueChanged(object sender, EventArgs e)
        {
            pictureBoxMain.Refresh();
        }

        private void numericUpDownVoronoiPoints_ValueChanged(object sender, EventArgs e)
        {
            pictureBoxMain.Refresh();
        }

        private void numericUpDownVoronoiJitter_ValueChanged(object sender, EventArgs e)
        {
            pictureBoxMain.Refresh();
        }

        private void radioButtonVoronoi_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                EnableVoronoiMode();
            }

            pictureBoxMain.Refresh();
        }

        private void radioButtonVoronoiWorkshop_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                EnableVoronoiWorkshopMode();
            }

            pictureBoxMain.Refresh();
        }
    }
}
