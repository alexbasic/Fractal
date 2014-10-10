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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mandelbort = new Mandelbort(this.Width, this.Height);
            graphics = this.CreateGraphics();
            mandelbort.Paint();

            //var mandelbort2 = new Mandelbort(10000, 10000);
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
    }
}
