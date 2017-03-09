using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ulam_Spiral
{
    public partial class Form1 : Form
    {
        Graphics g;
        SolidBrush bpen, wpen;
        int x, y;
        int point = 2;
        Bitmap bmp;

        Color coln = Color.Blue;
        Color colp = Color.Black;

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res1 = colorDialog1.ShowDialog();
            if (res1 == DialogResult.OK)
            {
                coln = colorDialog1.Color;
                button3.BackColor = coln;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res2 = colorDialog2.ShowDialog();
            if (res2 == DialogResult.OK)
            {
                colp = colorDialog2.Color;
                button2.BackColor = colp;
            }
        }

        //IMAGE
        private void button4_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Convert.ToInt32(numericUpDown1.Value) + 1, Convert.ToInt32(numericUpDown1.Value) + 1);
            decimal n = numericUpDown1.Value;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = Convert.ToInt32(n*n);

            if (numericUpDown1.Value % 2 == 0)
            {
                x = bmp.Size.Width / 2;
                y = bmp.Size.Height / 2;
            }
            else if (numericUpDown1.Value % 2 != 0)
            {
                x = (bmp.Size.Width + 1) / 2;
                y = (bmp.Size.Height + 1) / 2;
            }

            bmp.SetPixel(x, y, coln);

            bool ru = false;
            int times = 1;

            progressBar1.Value = times;

            for (int i = 1; i < n; i++)
            {
                if (ru == true)
                {
                    for (int j = 0; j < i; j++)
                    {
                        x -= 1;
                        times++;
                        if (Calc.Prime(times) == true)
                            bmp.SetPixel(x, y, colp);
                        else
                            bmp.SetPixel(x, y, coln);
                        progressBar1.Value = times;
                    }

                    for (int k = 0; k < i; k++)
                    {
                        y += 1;
                        times++;
                        if (Calc.Prime(times) == true)
                            bmp.SetPixel(x, y, colp);
                        else
                            bmp.SetPixel(x, y, coln);
                        progressBar1.Value = times;
                    }

                    ru = false;
                }
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        x += 1;
                        times++;
                        if (Calc.Prime(times) == true)
                            bmp.SetPixel(x, y, colp);
                        else
                            bmp.SetPixel(x, y, coln);
                        progressBar1.Value = times;
                    }

                    for (int k = 0; k < i; k++)
                    {
                        y -= 1;
                        times++;
                        if (Calc.Prime(times) == true)
                            bmp.SetPixel(x, y, colp);
                        else
                            bmp.SetPixel(x, y, coln);
                        progressBar1.Value = times;
                    }

                    ru = true;
                }
            }
            if (n % 2 != 0)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    x += 1;
                    times++;
                    if (Calc.Prime(times) == true)
                        bmp.SetPixel(x, y, colp);
                    else
                        bmp.SetPixel(x, y, coln);
                    progressBar1.Value = times;
                }
            }
            else
            {
                for (int i = 0; i < n - 1; i++)
                {
                    x -= 1;
                    times++;
                    if (Calc.Prime(times) == true)
                        bmp.SetPixel(x, y, colp);
                    else
                        bmp.SetPixel(x, y, coln);
                    progressBar1.Value = times;
                }
            }

            bmp.Save("ulam_spiral_" + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + '_' + DateTime.Now.Hour.ToString() + '-' + DateTime.Now.Minute.ToString() + '-' + DateTime.Now.Second.ToString() + ".png", ImageFormat.Png);
        }

        //GRAPHICS
        private void button1_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            bpen = new SolidBrush(colp);
            wpen = new SolidBrush(coln);
            point = Convert.ToInt32(numericUpDown2.Value);

            g.Clear(Color.White);

            decimal n = numericUpDown1.Value;
            progressBar1.Maximum = Convert.ToInt32(n * n);

            if (point % 2 == 0)
            {
                x = this.Width / 2 - point / 2;
                y = this.Height / 2 - point / 2;
            }
            else if (point % 2 != 0)
            {
                x = this.Width / 2 - (point + 1) / 2;
                y = this.Height / 2 - (point + 1) / 2;
            }
            
            g.FillRectangle(wpen, new Rectangle(x, y, point, point));

            bool ru = false;
            int times = 1;

            progressBar1.Value = times;

            for (int i = 1; i < n; i++)
            {
                if (ru == true)
                {
                    for (int j = 0; j < i; j++)
                    {
                        x -= point;
                        times++;
                        if (Calc.Prime(times) == true)
                            g.FillRectangle(bpen, new Rectangle(x, y, point, point));
                        else
                            g.FillRectangle(wpen, new Rectangle(x, y, point, point));
                        progressBar1.Value = times;
                        //Thread.Sleep(3);
                    }

                    for (int k = 0; k < i; k++)
                    {
                        y += point;
                        times++;
                        if (Calc.Prime(times) == true)
                            g.FillRectangle(bpen, new Rectangle(x, y, point, point));
                        else
                            g.FillRectangle(wpen, new Rectangle(x, y, point, point));
                        progressBar1.Value = times;
                        //Thread.Sleep(3);
                    }

                    ru = false;
                }
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        x += point;
                        times++;
                        if (Calc.Prime(times) == true)
                            g.FillRectangle(bpen, new Rectangle(x, y, point, point));
                        else
                            g.FillRectangle(wpen, new Rectangle(x, y, point, point));
                        progressBar1.Value = times;
                        //Thread.Sleep(3);
                    }

                    for (int k = 0; k < i; k++)
                    {
                        y -= point;
                        times++;
                        if (Calc.Prime(times) == true)
                            g.FillRectangle(bpen, new Rectangle(x, y, point, point));
                        else
                            g.FillRectangle(wpen, new Rectangle(x, y, point, point));
                        progressBar1.Value = times;
                        //Thread.Sleep(3);
                    }

                    ru = true;
                }
            }
            if (n % 2 != 0)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    x += point;
                    times++;
                    if (Calc.Prime(times) == true)
                        g.FillRectangle(bpen, new Rectangle(x, y, point, point));
                    else
                        g.FillRectangle(wpen, new Rectangle(x, y, point, point));
                    progressBar1.Value = times;
                    //Thread.Sleep(3);
                }
            }
            else
            {
                for (int i = 0; i < n - 1; i++)
                {
                    x -= point;
                    times++;
                    if (Calc.Prime(times) == true)
                        g.FillRectangle(bpen, new Rectangle(x, y, point, point));
                    else
                        g.FillRectangle(wpen, new Rectangle(x, y, point, point));
                    progressBar1.Value = times;
                    //Thread.Sleep(3);
                }
            }

            g.Dispose();
        }

        public Form1()
        {
            InitializeComponent();
        }
    }

    class Calc
    {
        public static bool Prime(decimal a)
        {
            if (a == 2)
                return true;

            bool p = false;
            decimal n = 0;
            int x = 0;

            if (a % 2 != 0)
            {
                n = (a + 1) / 2;
            }
            else
            {
                return false;
            }

            for (decimal i = 2; i < n + 1; i++)
            {
                x = Convert.ToInt32(a % i);

                if (x == 0)
                {
                    p = false;
                    break;
                }
                else
                {
                    p = true;
                    continue;
                }
            }

            return p;
        }

        public static bool Perfect(decimal a)
        {
            List<decimal> dividors = new List<decimal>();
            decimal sum = 0;

            if (a % 2 == 0)
            {
                for (int i = 1; i < a / 2 + 1; i++)
                {
                    if (a % i == 0)
                    {
                        dividors.Add(i);
                    }
                    else
                    {
                        continue;
                    }
                }

                for (int j = 0; j < dividors.Count; j++)
                {
                    sum += dividors[j];
                }

                dividors.Clear();

                if (sum == a)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static decimal Factorial(decimal a)
        {
            if (a <= 0)
                return 1;
            return a * Factorial(a - 1);
        }

        public static decimal Power(decimal a, decimal b)
        {
            decimal result = 1;

            for (int i = 0; i < b; i++)
                result *= a;

            return result;
        }
    }
}
