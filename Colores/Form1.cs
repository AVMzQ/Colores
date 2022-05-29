using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cambiacolor(int r, int g, int b)
        {
            if (rdb_fondo.Checked)
            {
                lbl_Texto.BackColor = Color.FromArgb(r, g, b);
            }
            else
            {
                lbl_Texto.ForeColor = Color.FromArgb(r, g, b);
            }
        }

        private void CYMK()
        {
            double c, c2, y, y2, m, m2, k, k2;
            double rp, gp, bp;
            rp = Convert.ToDouble(hsb_Rojo.Value) / 245;
            gp = Convert.ToDouble(hsb_Verde.Value) / 245;
            bp = Convert.ToDouble(hsb_Azul.Value) / 245;

            if (rp > gp && rp > bp)
            {
                k = 1 - rp;
                k2 = k * 100;
                textBox4.Text = Convert.ToString(k2);

                c=(1-rp-k2)/(1-k2);
                c2 = c * 100;
                textBox1.Text = Convert.ToString(c2);

                m=(1-gp-k2)/(1-k2);
                m2 = m * 100;
                textBox2.Text = Convert.ToString(m2);

                y=(1-bp-k2)/(1-k2);
                y2 = y * 100;
                textBox3.Text = Convert.ToString(y2);
            }
            else if (gp > rp && gp > bp)
            {
                k = 1 - gp;
                k2 = k * 100;
                textBox4.Text = Convert.ToString(k2);

                c = (1 - rp - k2) / (1 - k2);
                c2 = c * 100;
                textBox1.Text = Convert.ToString(c2);

                m = (1 - gp - k2) / (1 - k2);
                m2 = m * 100;
                textBox2.Text = Convert.ToString(m2);

                y = (1 - bp - k2) / (1 - k2);
                y2 = y * 100;
                textBox3.Text = Convert.ToString(y2);
            }
            else if (bp > gp && bp > rp)
            {
                k = 1 - bp;
                k2 = k * 100;
                textBox4.Text = Convert.ToString(k2);

                c = (1 - rp - k2) / (1 - k2);
                c2 = c * 100;
                textBox1.Text = Convert.ToString(c2);

                m = (1 - gp - k2) / (1 - k2);
                m2 = m * 100;
                textBox2.Text = Convert.ToString(m2);

                y = (1 - bp - k2) / (1 - k2);
                y2 = y * 100;
                textBox3.Text = Convert.ToString(y2);
            }
        }

        private void HSV()
        {
            double h, h2, v, s;
            double rp, gp, bp, cmin, cmax, dif;
            rp = Convert.ToDouble(hsb_Rojo.Value) / 245;
            gp = Convert.ToDouble(hsb_Verde.Value) / 245;
            bp = Convert.ToDouble(hsb_Azul.Value) / 245;

            cmax = Math.Max(rp, Math.Max(gp, bp));
            cmin = Math.Min(rp, Math.Min(gp, bp));
            dif = cmax - cmin;
            h = -1;
            s = -1;

            if (dif==0)
            {
                textBox5.Text = Convert.ToString(0);
                textBox6.Text = Convert.ToString(0);
                textBox7.Text = Convert.ToString(0);
            }
            else if (cmax==rp)
            {
                h = (60 * ((gp - bp) / dif) + 360) % 360; 
                h2 = h;
                textBox5.Text = Convert.ToString(h2);

                s = (dif/cmax) * 100;
                textBox6.Text = Convert.ToString(s);

                v = cmax * 100;
                textBox7.Text = Convert.ToString(v);
            }
            else if (cmax==gp)
            {
                h = (60 * ((gp - bp) / dif) + 120) % 360; 
                h2 = h;
                textBox5.Text = Convert.ToString(h2);

                s = (dif / cmax) * 100;
                textBox6.Text = Convert.ToString(s);

                v = cmax * 100;
                textBox7.Text = Convert.ToString(v);
            }
            else if (cmax == bp)
            {
                h = (60 * ((gp - bp) / dif) + 240) % 360; 
                h2 = h;
                textBox5.Text = Convert.ToString(h2);

                s = (dif/cmax) * 100;
                textBox6.Text = Convert.ToString(s);

                v = cmax * 100;
                textBox7.Text = Convert.ToString(v);
            }
        }

        private void HSL()
        {
            double l, l2, h, h2, s, s2;
            double rp, gp, bp, cmin, cmax, dif;
            rp = Convert.ToDouble(hsb_Rojo.Value) / 245;
            gp = Convert.ToDouble(hsb_Verde.Value) / 245;
            bp = Convert.ToDouble(hsb_Azul.Value) / 245;

            cmax = Math.Max(rp, Math.Max(gp, bp));
            cmin = Math.Min(rp, Math.Min(gp, bp));
            dif = cmax - cmin;

            l = (cmax + cmin) / 2;
            l2 = l * 100;
            textBox10.Text = Convert.ToString(l2);

            if (dif == 0)
            {
                textBox8.Text = Convert.ToString(0);
                textBox9.Text = Convert.ToString(0);
            }
            else
            {
                if (l < 0.5)
                {
                    s = (cmax - cmin) / (cmax + cmin);
                    s2 = s * 100;
                    textBox9.Text = Convert.ToString(s2);
                }
                else if (l > 0.5)
                {
                    s = (cmax - cmin) / (2.0 - cmax + cmin);
                    s2 = s * 100;
                    textBox9.Text = Convert.ToString(s2);
                }

                if (rp > gp && rp > bp)
                {
                    h = (gp - bp) / (cmax - cmin);
                    h2 = h * 60;
                    textBox8.Text = Convert.ToString(h2);
                }
                if (gp > rp && gp > bp)
                {
                    h = 2.0 + (bp - rp) / (cmax - cmin);
                    h2 = h * 60;
                    textBox8.Text = Convert.ToString(h2);
                }
                if (rp > gp && rp > bp)
                {
                    h = 4.0 + (rp - gp) / (cmax - cmin);
                    h2 = h * 60;
                    textBox8.Text = Convert.ToString(h2);
                }
            }
        }

        private void HEXA()
        {
            int rh, gh, bh;
            string r, g, b;
            rh = Convert.ToUInt16(hsb_Rojo.Value);
            gh = Convert.ToUInt16(hsb_Verde.Value);
            bh = Convert.ToUInt16(hsb_Azul.Value);;

            r = Convert.ToString(rh, 16);
            g = Convert.ToString(gh, 16);
            b = Convert.ToString(bh, 16);

            textBox13.Text = Convert.ToString(r+g+b);
        }
        private void cambiavalores()
        {
            txt_Rojo.Text = hsb_Rojo.Value.ToString();
            txt_Verde.Text = hsb_Verde.Value.ToString();
            txt_Azul.Text = hsb_Azul.Value.ToString();
            int red = hsb_Rojo.Value;
            int green = hsb_Verde.Value;
            int blue = hsb_Azul.Value;
            cambiacolor(red, green, blue);
        }
        private void rbt_fondo_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.rdb_fondo.Checked = true;
            this.cambiavalores();
            this.CYMK();
            this.HSV();
            this.HSL();
            this.HEXA();
        }

        private void hsb_Rojo_Scroll(object sender, ScrollEventArgs e)
        {
            cambiavalores();
            this.CYMK();
            this.HSV();
            this.HSL();
            this.HEXA();
        }

        private void hsb_Verde_Scroll(object sender, ScrollEventArgs e)
        {
            cambiavalores();
            this.CYMK();
            this.HSV();
            this.HSL();
            this.HEXA();
        }

        private void hsb_Azul_Scroll(object sender, ScrollEventArgs e)
        {
            cambiavalores();
            this.CYMK();
            this.HSV();
            this.HSL();
            this.HEXA();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            textBox13.Text = textBox13.Text.ToUpper().ToString();         
        }
    }
}

