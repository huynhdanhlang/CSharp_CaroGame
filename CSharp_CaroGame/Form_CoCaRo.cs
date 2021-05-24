using MySql.Data.MySqlClient;
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
            Control.getUsername(username);
        }



        private void Form_CoCaRo_Load(object sender, EventArgs e)
        {

        }

        private void Draw_Panel_Paint(object sender, PaintEventArgs e)
        {
            Control.VeBanCo(grap);
            Control.VeLaiQuanCo(grap);
        }
        #region Mấy sự kiện Click
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

            if (Control.DanhCo(e.X, e.Y, grap))
            {
                if (Control.KiemTraChienThang())
                {
                    Control.ThongBaoKetThuc();
                    Replay();
                }
                else
                {
                    if (Control.CheDoChoi == 2)
                    {
                        Control.MayDanh(grap);
                        if (Control.KiemTraChienThang())
                        {
                            Control.ThongBaoKetThuc();
                            Replay();
                        }
                    }
                }
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

        private void btn_Computer_Click(object sender, EventArgs e)
        {
            Control.StartPvC(grap);
            SetButton();
        }
        #endregion

        #region Undo, Redo
        private void btn_Undo_Click(object sender, EventArgs e)
        {
            Control.Undo(grap);
        }

        private void btn_Redo_Click(object sender, EventArgs e)
        {
            Control.Redo(grap);
        }
        #endregion

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

        private void btn_History_Click(object sender, EventArgs e)
        {
            //Hiển thị lịch sử chơi của người chơi
            History hs = new History();
            hs.Visible = true;
            hs.Show();
            MySqlConnection conn = MySQL_Connection.Connection;
            MySqlDataReader reader;
            String query = "Select num_win,num_lose,history from user where username = '" + this.username + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                String x = reader.GetString(2);
                int y = reader.GetInt32(0);
                int z = reader.GetInt32(1);
                hs.textBox_win.Text = y.ToString();
                hs.textBox_lose.Text = z.ToString();
                hs.textBox_lose.Enabled = false;
                hs.textBox_win.Enabled = false;
                string[] lines = x.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
                Label[] lb = new Label[25];
                for (int i = 1; i < lines.Length; i++)
                {
                    String ss = lines[i].ToString();

                    if (ss.Contains("thua"))
                    {
                        lb[i] = new Label();
                        lb[i].BackColor = Color.Red;
                        lb[i].Height = 23;
                        lb[i].Width = 530;
                        lb[i].Text = lines[i];
                        lb[i].Location = new Point(30, 25 + (i * 30));
                        hs.panel_history.Controls.Add(lb[i]);
                        reader.Close();

                    }
                    if (ss.Contains("thắng"))
                    {
                        lb[i] = new Label();
                        lb[i].BackColor = Color.Green;
                        lb[i].Height = 23;
                        lb[i].Width = 530;
                        lb[i].Text = lines[i];
                        lb[i].Location = new Point(30, 25 + (i * 30));
                        hs.panel_history.Controls.Add(lb[i]);
                        reader.Close();

                    }

                }

                conn.Close();
            }

        }
    }
}
