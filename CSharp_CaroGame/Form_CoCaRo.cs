using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_CaroGame
{
    public partial class Form_CoCaRo : Form
    {
        private Caro_Control Control;
        private Graphics grap;
        SocketManager socket;
        String username;
        public static int cdStep = 100;
        public static int cdTime = 10000;
        public static int cdInterval = 100;
        public Form_CoCaRo()
        {

            InitializeComponent();
            Control = new Caro_Control();
            socket = new SocketManager();
            Control.KhoiTaoMangOCo();
            grap = panel_banco.CreateGraphics();
            exitLANToolStripMenuItem.Click += btnExit_Click;
            pgb_Time.Value = 0;
            pgb_Time.Maximum = cdTime;
            pgb_Time.Step = cdStep;
            timer1.Interval = cdInterval;
        }
        public void initForm(String username)
        {
            this.username = username;
            textBox_username.Text = username;
            this.Text = "Login as " + username;
            textBox_username.Enabled = false;
            Control.getUsername(username);

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Do you want to exit!", "Exit", MessageBoxButtons.YesNo); ;
            if (Control.CheDoChoi != 3)
            {
                if (dlr == DialogResult.Yes)
                {

                    Application.Exit();
                }
            }

            else
            {
                if (dlr == DialogResult.Yes)
                {
                    try
                    {
                        socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                    }
                    catch { }

                    Application.Exit();
                }
            }

        }
        private void Form_CoCaRo_Load(object sender, EventArgs e)
        {
            btn_Redo.Visible = true;
            btn_Undo.Visible = true;
            pgb_Time.Visible = true;
        }

        private void Draw_Panel_Paint(object sender, PaintEventArgs e)
        {
            Control.VeBanCo(grap);
            Control.VeLaiQuanCo(grap);
        }

        #region Mấy sự kiện Click
        private void btn_Frient_Click(object sender, EventArgs e)
        {
            grap.Clear(panel_banco.BackColor);
            Control.StartPvP(grap);
            pgb_Time.Value = 0;
            timer1.Start();
        }

        private void btn_Computer_Click(object sender, EventArgs e)
        {
            grap.Clear(panel_banco.BackColor);
            Control.StartPvC(grap);
            pgb_Time.Value = 0;
            timer1.Start();
        }

        private void btn_LAN_Click(object sender, EventArgs e)
        {

            grap.Clear(panel_banco.BackColor);
            Control.StartLAN(grap);
            socket.IP = textBox_IP.Text;
            if (!socket.ConnectServer())
            {
                socket.isServer = true;
                panel_banco.Enabled = true;
                socket.CreateServer();

            }
            else
            {
                socket.isServer = false;
                panel_banco.Enabled = false;
                Listen();
                MessageBox.Show("Kết nối thành công. Trận đấu sẵn sàng");
            }
            timer1.Stop();
            pgb_Time.Value = 0;
        }

        private void panel_banco_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Control.SanSang)
                return;

            if (Control.DanhCo(e.X, e.Y, grap))
            {
                if (Control.CheDoChoi == 1)
                {
                    if (Control.KiemTraChienThang())
                    {
                        timer1.Stop();
                        Control.ThongBaoKetThuc();
                        return;
                    }
                }

                else if (Control.CheDoChoi == 2)
                {
                    if (Control.KiemTraChienThang())
                    {
                        timer1.Stop();
                        Control.ThongBaoKetThuc();
                        return;
                    }
                    else
                    {
                        Control.MayDanh(grap);
                        if (Control.KiemTraChienThang())
                        {
                            timer1.Stop();
                            Control.ThongBaoKetThuc();
                            return;
                        }
                    }
                    
                }

                else if (Control.CheDoChoi == 3)
                {
                    panel_banco.Enabled = false;
                    socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", e.Location));
                    Listen();
                    if (Control.KiemTraChienThang())
                    {
                        timer1.Stop();
                        Control.ThongBaoKetThuc();
                        return;
                    }
                }

            }

            timer1.Start();
            pgb_Time.Value = 0;

        }

        void Listen()
        {

            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)socket.Receive();

                    ProcessData(data);
                }
                catch { }
            });
            listenThread.IsBackground = true;
            listenThread.Start();

        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {

                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        panel_banco.Enabled = false;
                    }));
                    break;

                case (int)SocketCommand.QUIT:
                    timer1.Stop();
                    MessageBox.Show("The opponent has left the match!");
                    Control._SanSang = false;

                    break;

                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        pgb_Time.Value = 0;
                        timer1.Start();
                        OtherPlayerMark(data.Point);
                    }));

                    break;
                case (int)SocketCommand.END_GAME:
                    break;
                case (int)SocketCommand.UNDO:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        timer1.Start();
                        pgb_Time.Value = 0;
                        Control.Undo(grap);
                    }));
                    break;
                case (int)SocketCommand.REDO:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        timer1.Start();
                        pgb_Time.Value = 0;
                        Control.Redo(grap);
                    }));
                    break;
                default:
                    break;
            }
            Listen();
        }
        public void OtherPlayerMark(Point point)
        {
            if (!Control.SanSang)
                return;
            if (Control.DanhCo(point.X, point.Y, grap))
            {
                panel_banco.Enabled = true;
                if (Control.KiemTraChienThang())
                {
                    timer1.Stop();
                    Control.ThongBaoKetThuc();
                }
            }
        }
        
        private void btn_Replay_Click(object sender, EventArgs e)
        {

            if (Control.CheDoChoi == 0)
            {
                MessageBox.Show("Haven't selected game mode!", "Notification");
            }
            else if (Control.CheDoChoi == 1)
            {
                Reset();
                Control.StartPvP(grap);
            }
            else if (Control.CheDoChoi == 2)
            {
                Reset();
                Control.StartPvC(grap);
            }
            else if (Control.CheDoChoi == 3)
            {
                socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point()));
                grap.Clear(panel_banco.BackColor);
                Control.StartLAN(grap);
                panel_banco.Enabled = true;
                timer1.Start();
                pgb_Time.Value = 0;
            }
        }

        
        #endregion

        #region Undo, Redo
        private void btn_Undo_Click(object sender, EventArgs e)
        {
            Control.Undo(grap);
            timer1.Start();
            pgb_Time.Value = 0;
            if (Control.CheDoChoi == 3)
            {
                socket.Send(new SocketData((int)SocketCommand.UNDO, "", new Point()));
            }
        }

        private void btn_Redo_Click(object sender, EventArgs e)
        {
            Control.Redo(grap);
            timer1.Start();
            pgb_Time.Value = 0;
            if (Control.CheDoChoi == 3)
            {
                socket.Send(new SocketData((int)SocketCommand.REDO, "", new Point()));
            }
        }
        #endregion

        private void NewGame()
        {
            Control.StartLAN(grap);

            timer1.Start();
            pgb_Time.Value = 0;
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
                string filePath = @"D:\\history.txt";
                System.IO.File.WriteAllLines(filePath, lines);
                String[] line1 = File.ReadLines(filePath).Take(11).ToArray();
                System.IO.File.WriteAllLines(filePath, line1);
                Label[] lb = new Label[11];
                int linecount = line1.Length;
                for (int i = 1; i < linecount; i++)
                {
                    String ss = line1[i].ToString();

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            pgb_Time.PerformStep();
            if (pgb_Time.Value >= pgb_Time.Maximum)
            {
                timer1.Stop();
                Control.ThongBaoKetThuc();
            }
        }

        private void Form_CoCaRo_Shown(object sender, EventArgs e)
        {
            textBox_IP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(textBox_IP.Text))
            {
                textBox_IP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }

        private void Reset()
        {
            grap.Clear(panel_banco.BackColor);
            timer1.Start();
            pgb_Time.Value = 0;
        } 
    }
}
