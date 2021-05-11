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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
    }
}
