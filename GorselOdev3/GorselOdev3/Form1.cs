using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorselOdev3
{
    public partial class Form1 : Form
    {


        Bitmap resim = new Bitmap(300, 300);
        Bitmap gray_resim = new Bitmap(300, 300);
        Bitmap bitmap_resim = new Bitmap(300, 300);
        Bitmap pikselOP_resim = new Bitmap(300, 300);

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();


            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = new Bitmap(OpenFileDialog1.FileName);

                Graphics.FromImage(resim).DrawImage(pictureBox1.Image, 0, 0, 300, 300);


            }
            Graphics.FromImage(gray_resim).DrawImage(pictureBox1.Image, 0, 0, 300, 300);
            Graphics.FromImage(bitmap_resim).DrawImage(pictureBox1.Image, 0, 0, 300, 300);
            Graphics.FromImage(pikselOP_resim).DrawImage(pictureBox1.Image, 0, 0, 300, 300);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();

            if (resim != null)
            {
                int x, y;
                x = Convert.ToInt32(textBox1.Text);
                y = Convert.ToInt32(textBox2.Text);

                Color renk = resim.GetPixel(x, y);
                panel1.BackColor = renk;
                int r, g, b, a;
                r = renk.R;
                g = renk.G;
                b = renk.B;
                a = renk.A;
                textBox3.Text = a + "-" + r + "-" + g + "-" + b;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int gray;
            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {
                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);
                    gray = (r + g + b) / 3;
                    gray_resim.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox2.Image = gray_resim;
            this.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                Color renk;
                int r, g, b;
                int gray, threshold;
                threshold = Convert.ToInt32(textBox4.Text);
                for (int x = 0; x < 300; x++)
                {
                    for (int y = 0; y < 300; y++)
                    {
                        renk = resim.GetPixel(x, y);
                        r = Convert.ToInt32(renk.R);
                        g = Convert.ToInt32(renk.G);
                        b = Convert.ToInt32(renk.B);
                        gray = (r + g + b) / 3;
                        if (gray > threshold)
                        {
                            bitmap_resim.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        }
                        else
                        {
                            bitmap_resim.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                        }
                    }
                }
                pictureBox2.Image = bitmap_resim;
            }
            else
            {
                MessageBox.Show("Eşik Değeri Girin");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int darken;
            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {

                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);
                    // red için işlemler
                    darken = r - 128;
                    r = darken;
                    if (darken < 0) r = 0;
                    // red için işlemler
                    // green için işlemler
                    darken = g - 128;
                    g = darken;
                    if (darken < 0) g = 0;
                    // green için işlemler
                    // blue için işlemler
                    darken = b - 128;
                    b = darken;
                    if (darken < 0) b = 0;
                    // blue için işlemler
                    pikselOP_resim.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox2.Image = pikselOP_resim;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int L_contrast;
            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {

                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);
                    // red için işlemler
                    L_contrast = r / 2;
                    r = L_contrast;

                    // red için işlemler
                    // green için işlemler
                    L_contrast = g / 2;
                    g = L_contrast;

                    // green için işlemler
                    // blue için işlemler
                    L_contrast = b / 2;
                    b = L_contrast;

                    // blue için işlemler
                    pikselOP_resim.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox2.Image = pikselOP_resim;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int N_L_contrast;
            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {

                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);
                    // red için işlemler
                    N_L_contrast = (int)(Math.Pow((r / 255), 0.33)) * 255;
                    r = N_L_contrast;

                    // red için işlemler
                    // green için işlemler
                    N_L_contrast = (int)(Math.Pow((g / 255), 0.33)) * 255;
                    g = N_L_contrast;

                    // green için işlemler
                    // blue için işlemler
                    N_L_contrast = (int)(Math.Pow((b / 255), 0.33)) * 255;
                    b = N_L_contrast;

                    // blue için işlemler
                    pikselOP_resim.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox2.Image = pikselOP_resim;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int N_R_contrast;
            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {

                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);
                    // red için işlemler
                    N_R_contrast = (int)((Math.Pow((r / 255), 2)) * 255);
                    r = N_R_contrast;

                    // red için işlemler
                    // green için işlemler
                    N_R_contrast = (int)((Math.Pow((g / 255), 2)) * 255);
                    g = N_R_contrast;

                    // green için işlemler
                    // blue için işlemler
                    N_R_contrast = (int)((Math.Pow((b / 255), 2)) * 255);
                    b = N_R_contrast;

                    // blue için işlemler
                    pikselOP_resim.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox2.Image = pikselOP_resim;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int invert;
            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {

                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);
                    // red için işlemler
                    invert = 255 - r;
                    r = invert;
                    if (invert < 0) r = 0;
                    // red için işlemler
                    // green için işlemler
                    invert = 255 - g;
                    g = invert;
                    if (invert < 0) g = 0;
                    // green için işlemler
                    // blue için işlemler
                    invert = 255 - b;
                    b = invert;
                    if (invert < 0) b = 0;
                    // blue için işlemler
                    pikselOP_resim.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox2.Image = pikselOP_resim;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int Lighteen;
            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {

                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);
                    // red için işlemler
                    Lighteen = r + 128;
                    r = Lighteen;
                    if (Lighteen > 255) r = 255;
                    // red için işlemler
                    // green için işlemler
                    Lighteen = g + 128;
                    g = Lighteen;
                    if (Lighteen > 255) g = 255;
                    // green için işlemler
                    // blue için işlemler
                    Lighteen = b + 128;
                    b = Lighteen;
                    if (Lighteen > 255) b = 255;
                    // blue için işlemler
                    pikselOP_resim.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox2.Image = pikselOP_resim;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int R_contrast;
            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {

                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);
                    // red için işlemler
                    R_contrast = r * 2;
                    r = R_contrast;
                    if (R_contrast > 255) r = 255;
                    // red için işlemler
                    // green için işlemler
                    R_contrast = g * 2;
                    g = R_contrast;
                    if (R_contrast > 255) g = 255;
                    // green için işlemler
                    // blue için işlemler
                    R_contrast = b * 2;
                    b = R_contrast;
                    if (R_contrast > 255) b = 255;
                    // blue için işlemler
                    pikselOP_resim.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox2.Image = pikselOP_resim;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



