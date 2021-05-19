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
        String username;
        public Form_CoCaRo()
        {
            InitializeComponent();
            Control = new Caro_Control();
            grap = panel_banco.CreateGraphics();


        }
        public void initForm(String username)
        {
            this.username = username;
            textBox_username.Text = username;
            this.Text = "Login as " + username;
            textBox_username.Enabled = false;
        }

        

        private void Form_CoCaRo_Load(object sender, EventArgs e)
        {

        }

        private void Draw_Panel_Paint(object sender, PaintEventArgs e)
        {
            Control.VeBanCo(grap);
        }

        private void btn_LAN_Click(object sender, EventArgs e)
        {
            Form_KetNoi frm_ketnoi = new Form_KetNoi();
            frm_ketnoi.Show();
        }
    }
}
