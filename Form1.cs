using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EulerMethodODE
{
    public partial class Form1 : Form
    {
        private double x, y, x1, h, f1;
        private double y1 = 1; // y1 ni boshlang'ich qiymatga tenglaymiz
        private int n;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (x > x1)
            {
                timer1.Dispose();
                return;
            }

            f1 = f(x, y);
            x += h;
            y += f1 * h;

            Graphics g = pictureBox1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;

            double scaleFactorX = (pictureBox1.Width - 100) / (x1 - 1);
            double scaleFactorY = (pictureBox1.Height - 100) / (n * h);

            int xPixel = (int)((x - 1) * scaleFactorX) + centerX;
            int yPixel = centerY - (int)(y * scaleFactorY);

            Pen pen = new Pen(Color.Blue, 2);
            g.DrawEllipse(pen, xPixel - 5, yPixel - 5, 10, 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x = 1;
            y = 1;
            x1 = 2;
            n = 10;
            h = (x1 - x) / n;
            timer1.Interval = 100;
        }

        private double f(double x, double y)
        {
            return (y / x + x * x);
        }
    }
}
