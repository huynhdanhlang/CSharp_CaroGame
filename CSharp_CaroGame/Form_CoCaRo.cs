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
            Control.KhoiTaoMangOCo();

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
            Control.VeLaiQuanCo(grap);
        }

        private void btn_LAN_Click(object sender, EventArgs e)
        {
            Form_KetNoi frm_ketnoi = new Form_KetNoi();
            frm_ketnoi.Show();
            //if() Nhan Connect thi moi lam tiep
            SetButton();
        }

        private void panel_banco_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Control.SanSang)
                return;
            Control.DanhCo(e.X, e.Y, grap);

            if (Control.KiemTraChienThang())
            {
                Control.ThongBaoKetThuc();
                Replay();
            }
                
        }

        private void btn_Frient_Click(object sender, EventArgs e)
        {
            //grap.Clear(panel_banco.BackColor);
            Control.StartPvP(grap);

            SetButton();
        }

        private void btn_Replay_Click(object sender, EventArgs e)
        {
            Replay();
        }

        private void btn_Undo_Click(object sender, EventArgs e)
        {
            Control.Undo(grap);
        }

        private void btn_Redo_Click(object sender, EventArgs e)
        {
            Control.Redo(grap);
        }

        private void btn_Computer_Click(object sender, EventArgs e)
        {
            SetButton();
        }

        public void SetButton()
        {
            btn_Frient.Enabled = false;
            btn_Computer.Enabled = false;
            btn_LAN.Enabled = false;
            btn_Replay.Enabled = true;

            btn_Undo.Visible = true;
            btn_Redo.Visible = true;
            label1.Visible = true;
            pgb_Time.Visible = true;
        }

        public void Replay()
        {
            Control.Reset(grap);
            grap.Clear(panel_banco.BackColor);
            //Control.StartPvP(grap);

            btn_Frient.Enabled = true;
            btn_Computer.Enabled = true;
            btn_LAN.Enabled = true;
            btn_Replay.Enabled = false;

            btn_Undo.Visible = false;
            btn_Redo.Visible = false;
            label1.Visible = false;
            pgb_Time.Visible = false;
        } 
    }
}
