using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractal
{
    public class Vector2
    {
        public double X {get;set;}
        public double Y {get;set;}
    }
    public class Vector3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

    public class Mandelbort
    {
        public Bitmap Canvas {get; set;}

        int maxIterations = 400;
        double kLeangth = 4;

        public Mandelbort(int width, int height) 
        {
            Canvas = new Bitmap(width, height);
        }

        public void Paint(double minRe, double maxRe, double minIm)
        {
            double MaxIm = minIm + (maxRe - minRe) * Canvas.Height / Canvas.Width;

            double Re_factor = (maxRe - minRe) / (Canvas.Width - 1);
            double Im_factor = (MaxIm - minIm) / (Canvas.Height - 1);

            for (int y = 0; y < Canvas.Height; ++y)
            {
                double cy = MaxIm - y * Im_factor; // complex imaginary
                for (int x = 0; x < Canvas.Width;x++)
                {
                    double cx = minRe + x * Re_factor; // complex real
                    var res = GetPointColor(cx, cy);
                    var n = res.Y;
                    int pColor = (int)((n / /*kLeangth*/maxIterations)*255);
                    Color color = (res.X >= kLeangth) ? Color.FromArgb(
                        /*(int)((res.X / kLeangth)*20 )*/(int)(pColor*0.35),
                        pColor/*>190?pColor:5*/, 
                        (int)(pColor*0.8)) : Color.Black;
                    //n, 255 – n, 50 mod n * 3
                    //Color color = (res.X >= kLeangth) ? Color.FromArgb(pColor, 255-pColor, 50 % pColor*3) : Color.Black;
                    Canvas.SetPixel(x, y, color);
                }
            }
            Graphics graphics = Graphics.FromImage(Canvas);
            graphics.DrawString(
                string.Format("Re: ({0} {1}); Im: ({2} {3})",
                minRe.ToString("#0.###"), maxRe.ToString("#0.###"), minIm.ToString("#0.###"), MaxIm.ToString("#0.###")),
                new Font("Arial", 12), new SolidBrush(Color.Yellow), 5,5);

        }

        public Vector2 GetPointColor(double cx, double cy)
        {
            int n=0;
            double x = 0;
            double y = 0;
            double k = 0;
            while (k < kLeangth && n < maxIterations)
            {
                double ix = x * x - y * y + cx;
                double iy = 2 * x * y + cy;
                x = ix;
                y = iy;
                n++;
                k = ix * ix + iy * iy;
            }
            return new Vector2 {X=k, Y=n };
        }
    }
}
