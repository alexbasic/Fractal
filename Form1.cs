using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractal
{
    public partial class Form1 : Form
    {
        Mandelbort mandelbort;
        Graphics graphics;

        double MinRe = -0.6f; // real
        double MaxRe = -0.4f;
        double MinIm = -0.7f; // imaginary

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mandelbort = new Mandelbort(this.Width, this.Height);
            graphics = this.CreateGraphics();

            //orig
            //double MinRe = -2.0f; // real
            //double MaxRe = 1.0f;
            //double MinIm = -1.0f; // imaginary

            //2
            //double MinRe = -1.80991280915827;
            //double MaxRe = -1.80991280652736;
            //double MinIm = -4.76644643672749E-5;
            //double MinIm = -4.76670952784024E-5;
            ////MaxIm=-4.76644643672749E-5

            mandelbort.Paint(MinRe, MaxRe, MinIm);

            //Its do save into bitmap
            //var mandelbort2 = new Mandelbort(20000, 15000);
            //mandelbort2.Paint();
            //mandelbort2.Canvas.Save("c:\\temp\\m.bmp");
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //graphics.DrawImageUnscaled(mandelbort.Canvas, 0,0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.DrawImageUnscaled(mandelbort.Canvas, 0, 0);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            //
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //e.X;
            //e.Y;
            //ClientSize.Width;
            //ClientSize.Height;
            var halfWidth = (ClientSize.Width / 2);
            var halfHeight = (ClientSize.Height / 2);

            double horizClickPoint = ((double)(e.X - halfWidth)) / ClientSize.Width;
            double vertClockPoint = ((double)(e.Y - halfHeight)) / ClientSize.Height;

            Console.WriteLine("x: {0}, y: {1}", horizClickPoint, vertClockPoint);

            if (e.Button == MouseButtons.Left)
            {
            }

            if (e.Button == MouseButtons.Right)
            {
            }
        }
    }
}
