using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNEAKERS1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PanelCambio(new Form4());
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }
        bool siderbarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (siderbarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 47)
                {
                    siderbarExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 200)
                {
                    siderbarExpand = true;
                    sidebarTransition.Stop();
                }
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized; // Maximiza el formulario
            }
            else
            {
                this.WindowState = FormWindowState.Normal; // Restaura el formulario al estado normal
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void PanelCambio(object frompieza)
        {
            if (this.panel2.Controls.Count > 0)
                this.panel2.Controls.RemoveAt(0);
            Form fh = frompieza as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(fh);
            this.panel2.Tag = fh;
            fh.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelCambio(new listacs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PanelCambio(new Form2());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelCambio(new Form3());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PanelCambio(new Form4());
        }
    }
}
