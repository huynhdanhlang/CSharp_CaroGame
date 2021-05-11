using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_CaroGame
{
    public partial class Form_CoCaRo : Form
    {
        private Caro_Control Control;
        private Graphics grap;
        public Form_CoCaRo()
        {
            InitializeComponent();
            Control = new Caro_Control();
            grap = panel_banco.CreateGraphics();
            textBox_host.Text = "127.0.0.1";
            textBox_port.Text = "8080";

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chơiTrongLANIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_host.Enabled = true;
            textBox_port.Enabled = true;
            button_connect.Enabled = true;
        }

        private void đánhVơiNgườiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_host.Enabled = false;
            textBox_port.Enabled = false;
            button_connect.Enabled = false;
        }

        private void đánhVớiMáyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_host.Enabled = false;
            textBox_port.Enabled = false;
            button_connect.Enabled = false;
        }

        private void Form_CoCaRo_Load(object sender, EventArgs e)
        {

        }

        private void Draw_Panel_Paint(object sender, PaintEventArgs e)
        {
            Control.VeBanCo(grap);
        }
    }
}
