using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_CaroGame
{
    public enum KETTHUC
    {
        Draw,
        P1,
        P2,
        P,
        C
    }
    class Caro_Control
    {
        History hs = new History();
        MySqlDataReader reader;
        MySqlCommand cmd;
        public String username, username1;
        public int win, lose;
        public static Pen pen;
        public static SolidBrush sbWhite;
        public static SolidBrush sbBlack;
        public static SolidBrush sbGreen;

        private O_Co[,] _MangOCo;
        private Ban_Co _BanCo;
        public int LuotDi;
        private int _CheDoChoi; //1: PvP, 2: PvC, 3: PvP in LAN
        public bool _SanSang;
        private Stack<O_Co> stk_CacNuocDaDi;
        private Stack<O_Co> stk_CacNuocDaUndo;
        private KETTHUC KetThuc;

        public int CheDoChoi { get => _CheDoChoi; }
        public bool SanSang { get => _SanSang; }

        public Caro_Control()
        {
            //Tao cay but mau do
            pen = new Pen(Color.Red);
            sbWhite = new SolidBrush(Color.White);
            sbBlack = new SolidBrush(Color.Black);
            sbGreen = new SolidBrush(Color.DarkSeaGreen);
            _BanCo = new Ban_Co(20, 20);
            _MangOCo = new O_Co[_BanCo.SoDong, _BanCo.SoCot];
            stk_CacNuocDaDi = new Stack<O_Co>();
            stk_CacNuocDaUndo = new Stack<O_Co>();
            LuotDi = 1;

        }

        public void getUsername(String username)
        {
            this.username = username;
        }

        public void VeBanCo(Graphics g)
        {
            _BanCo.VeBanCo(g);
        }

        public void KhoiTaoMangOCo()
        {
            for (int i = 0; i < _BanCo.SoDong; i++)
                for (int j = 0; j < _BanCo.SoCot; j++)
                {
                    _MangOCo[i, j] = new O_Co(i, j, new Point(j * O_Co._ChieuRong, i * O_Co._ChieuCao), 0);
                }
        }

        public bool DanhCo(int MouseX, int MouseY, Graphics g)
        {
            if (MouseX % O_Co._ChieuRong == 0 || MouseY % O_Co._ChieuCao == 0)
                return false;
            int Cot = MouseX / O_Co._ChieuRong;
            int Dong = MouseY / O_Co._ChieuCao;
            if (_MangOCo[Dong, Cot].SoHuu != 0)
                return false;

            switch (LuotDi)
            {
                case 1:
                    _MangOCo[Dong, Cot].SoHuu = 1;
                    _BanCo.VeQuanCo(g, _MangOCo[Dong, Cot].ViTri, sbBlack);
                    LuotDi = 2;
                    break;
                case 2:
                    _MangOCo[Dong, Cot].SoHuu = 2;
                    _BanCo.VeQuanCo(g, _MangOCo[Dong, Cot].ViTri, sbWhite);
                    LuotDi = 1;
                    break;
                default:
                    MessageBox.Show("Error :(");
                    break;
            }
            stk_CacNuocDaUndo = new Stack<O_Co>();
            O_Co oco = new O_Co(_MangOCo[Dong, Cot].Dong, _MangOCo[Dong, Cot].Cot, _MangOCo[Dong, Cot].ViTri, _MangOCo[Dong, Cot].SoHuu);
            stk_CacNuocDaDi.Push(oco);
            return true;
        }

        public void VeLaiQuanCo(Graphics g)
        {
            foreach (O_Co oco in stk_CacNuocDaDi)
            {
                if (oco.SoHuu == 1)
                    _BanCo.VeQuanCo(g, oco.ViTri, sbBlack);
                else if (oco.SoHuu == 2)
                    _BanCo.VeQuanCo(g, oco.ViTri, sbWhite);
            }
        }


        public void StartPvP(Graphics g)
        {
            _SanSang = true;
            _CheDoChoi = 1;
            LuotDi = 1;
            stk_CacNuocDaDi = new Stack<O_Co>();
            stk_CacNuocDaUndo = new Stack<O_Co>();
            KhoiTaoMangOCo();
            VeBanCo(g);
        }

        public void StartPvC(Graphics g)
        {
            _SanSang = true;
            _CheDoChoi = 2;
            LuotDi = 1;
            stk_CacNuocDaDi = new Stack<O_Co>();
            stk_CacNuocDaUndo = new Stack<O_Co>();
            KhoiTaoMangOCo();
            VeBanCo(g);
        }

        public void StartLAN(Graphics g)
        {
            _SanSang = true;
            LuotDi = 1;
            _CheDoChoi = 3;
            stk_CacNuocDaDi = new Stack<O_Co>();
            stk_CacNuocDaUndo = new Stack<O_Co>();
            KhoiTaoMangOCo();
            VeBanCo(g);

        }

        #region Undo, Redo
        public void Undo(Graphics g)
        {
            if (stk_CacNuocDaDi.Count != 0)
            {
                O_Co oco = stk_CacNuocDaDi.Pop();

                stk_CacNuocDaUndo.Push(new O_Co(oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu));
                _MangOCo[oco.Dong, oco.Cot].SoHuu = 0;
                _BanCo.XoaQuanCo(g, oco.ViTri, sbGreen);
                LuotDi = (LuotDi == 1) ? 2 : 1;

                if (CheDoChoi == 2 || CheDoChoi == 3)
                {
                    O_Co oco2 = stk_CacNuocDaDi.Pop();

                    stk_CacNuocDaUndo.Push(new O_Co(oco2.Dong, oco2.Cot, oco2.ViTri, oco2.SoHuu));
                    _MangOCo[oco2.Dong, oco2.Cot].SoHuu = 0;
                    _BanCo.XoaQuanCo(g, oco2.ViTri, sbGreen);
                    LuotDi = (LuotDi == 1) ? 2 : 1;
                }
            }
        }

        public void Redo(Graphics g)
        {
            if (stk_CacNuocDaUndo.Count != 0)
            {
                O_Co oco = stk_CacNuocDaUndo.Pop();

                stk_CacNuocDaDi.Push(new O_Co(oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu));
                _MangOCo[oco.Dong, oco.Cot].SoHuu = oco.SoHuu;
                _BanCo.VeQuanCo(g, oco.ViTri, oco.SoHuu == 1 ? sbBlack : sbWhite);
                LuotDi = (LuotDi == 1) ? 2 : 1;

                if (CheDoChoi == 2 || CheDoChoi == 3)
                {
                    O_Co oco2 = stk_CacNuocDaUndo.Pop();

                    stk_CacNuocDaDi.Push(new O_Co(oco2.Dong, oco2.Cot, oco2.ViTri, oco2.SoHuu));
                    _MangOCo[oco2.Dong, oco2.Cot].SoHuu = oco2.SoHuu;
                    _BanCo.VeQuanCo(g, oco2.ViTri, oco2.SoHuu == 1 ? sbBlack : sbWhite);
                    LuotDi = (LuotDi == 1) ? 2 : 1;
                }
            }
        }
        #endregion
        #region Xử lý thắng thua
        public void ThongBaoKetThuc()
        {
            MySqlConnection conn = MySQL_Connection.Connection;
            String query = "SELECT num_win,num_lose FROM `user` WHERE `username` = '" + this.username + "'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            string text = File.ReadAllText(@"D:\\history.txt");
            String thua = "";
            switch (KetThuc)
            {
                case KETTHUC.Draw:
                    MessageBox.Show("Draw. Endgame!");
                    conn.Close();
                    break;
                case KETTHUC.P1:
                    MessageBox.Show("Black player wins : )");
                    if (reader.Read())
                    {
                        Label lb = new Label();
                        if (_CheDoChoi == 1)
                        {

                            lb.Text = "Play with friend: Black player win";
                        }
                        else if (_CheDoChoi == 3)
                        {
                            lb.Text = "Play with friend in LAN: You win";
                            thua = "Play with friend in LAN: You lose";
                        }
                        win = reader.GetInt32(0) + 1;
                        MySqlConnection con = MySQL_Connection.Connection;
                        String str = "Update user set num_win=" + win + " where username = '" + this.username + "'";
                        String up = "Update user set history=CONCAT('" + "\n" + lb.Text + " " + DateTime.Now.ToString() + "',history) where username = '" + this.username1 + "'";
                        String up1 = "Update user set history=CONCAT('" + "\n" + thua + " " + DateTime.Now.ToString() + "',history) where username = '" + this.username + "'";
                        String uptext = "Update user set history='" + text + "' where username = '" + this.username + "'";
                        cmd = new MySqlCommand(str, con);
                        reader.Close();
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(uptext, conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(up, conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(up1, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    conn.Close();
                    break;
                case KETTHUC.P2:
                    MessageBox.Show("White player wins : )");
                    if (reader.Read())
                    {
                        Label lb = new Label();
                        if (_CheDoChoi == 1)
                        {

                            lb.Text = "Play with friend: White player win";
                        }
                        else if (_CheDoChoi == 3)
                        {
                            lb.Text = "Play with friend in LAN: You win";
                            thua = "Play with friend in LAN: You lose";

                        }
                        win = reader.GetInt32(0) + 1;

                        MySqlConnection con = MySQL_Connection.Connection;
                        String str = "Update user set num_win=" + win + " where username = '" + this.username + "'";
                        String up = "Update user set history=CONCAT('" + "\n" + lb.Text + " " + DateTime.Now.ToString() + "',history) where username = '" + this.username1 + "'";
                        String up1 = "Update user set history=CONCAT('" + "\n" + thua + " " + DateTime.Now.ToString() + "',history) where username = '" + this.username + "'";
                        String uptext = "Update user set history='" + text + "' where username = '" + this.username + "'";
                        cmd = new MySqlCommand(str, con);
                        reader.Close();
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(uptext, conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(up, conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(up1, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    conn.Close();
                    break;
                case KETTHUC.P:
                    MessageBox.Show("You win", "Congratulations ");
                    if (reader.Read())
                    {
                        Label lb = new Label();
                        lb.Text = "Play with computer: You win";
                        win = reader.GetInt32(0) + 1;

                        MySqlConnection con = MySQL_Connection.Connection;
                        String str = "Update user set num_win=" + win + " where username = '" + this.username + "'";
                        String up = "Update user set history=CONCAT('" + "\n" + lb.Text + " " + DateTime.Now.ToString() + "',history) where username = '" + this.username + "'";
                        String uptext = "Update user set history='" + text + "' where username = '" + this.username + "'";
                        cmd = new MySqlCommand(str, con);
                        reader.Close();
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(uptext, conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(up, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    break;
                case KETTHUC.C:
                    MessageBox.Show("Game Over");
                    if (reader.Read())
                    {
                        Label lb = new Label();
                        lb.Text = "Play with computer: You lose";
                        lose = reader.GetInt32(1) + 1;

                        MySqlConnection con = MySQL_Connection.Connection;
                        String str = "Update user set num_lose=" + lose + " where username = '" + this.username + "'";
                        String up = "Update user set history=CONCAT('" + "\n" + lb.Text + " " + DateTime.Now.ToString() + "',history) where username = '" + this.username + "'";
                        String uptext = "Update user set history='" + text + "' where username = '" + this.username + "'";
                        cmd = new MySqlCommand(str, con);
                        reader.Close();
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(uptext, conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(up, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    break;

            }
            _SanSang = false;

        }

        public bool KiemTraChienThang()
        {
            if (stk_CacNuocDaDi.Count == _BanCo.SoDong * _BanCo.SoCot)
            {
                KetThuc = KETTHUC.Draw;
                return true;
            }

            foreach (O_Co oco in stk_CacNuocDaDi)
            {
                if (DuyetDoc(oco.Dong, oco.Cot, oco.SoHuu) || DuyetNgang(oco.Dong, oco.Cot, oco.SoHuu) ||
                    DuyetCheoXuoi(oco.Dong, oco.Cot, oco.SoHuu) || DuyetCheoNguoc(oco.Dong, oco.Cot, oco.SoHuu))
                {
                    if (_CheDoChoi == 1 || _CheDoChoi == 3)
                        KetThuc = oco.SoHuu == 1 ? KETTHUC.P1 : KETTHUC.P2;
                    else if (_CheDoChoi == 2)
                        KetThuc = oco.SoHuu == 1 ? KETTHUC.P : KETTHUC.C;
                    return true;
                }
            }
            return false;
        }

        private bool DuyetDoc(int crDong, int crCot, int crSoHuu)
        {
            //Quân đang xét nằm từ dòng 16 trở lên
            if (crDong > _BanCo.SoDong - 5)
                return false;

            //Xét coi có đủ 5 quân thẳng cột không
            //Qua được ải này là xác định đủ 5 quân rồi đó
            int dem;
            for (dem = 1; dem < 5; dem++)
                if (_MangOCo[crDong + dem, crCot].SoHuu != crSoHuu)
                    return false;

            //Xét coi 5 quân đó có sát biên trên hay biên dưới không
            //Nếu sát biên thì không thể bị chặn 2 đầu được => Thắng
            if (crDong == 0 || crDong + dem == _BanCo.SoDong)
                return true;

            //Này là trường hợp 5 quân nằm giữa bàn cờ, xét coi có bị chặn 2 đầu không
            if (_MangOCo[crDong - 1, crCot].SoHuu == 0 || _MangOCo[crDong + dem, crCot].SoHuu == 0)
                return true;

            return false;
        }

        private bool DuyetNgang(int crDong, int crCot, int crSoHuu)
        {
            //Quân đang xét có nằm từ cột 16 trở lên không
            if (crCot > _BanCo.SoCot - 5)
                return false;

            //Xét coi có đủ 5 quân thẳng dòng không
            //Qua được ải này là xác định đủ 5 quân rồi đó
            int dem;
            for (dem = 1; dem < 5; dem++)
                if (_MangOCo[crDong, crCot + dem].SoHuu != crSoHuu)
                    return false;

            //Xét coi 5 quân đó có sát biên trái hay biên phải không
            //Nếu sát biên thì không thể bị chặn 2 đầu được => Thắng
            if (crCot == 0 || crCot + dem == _BanCo.SoCot)
                return true;

            //Này là trường hợp 5 quân nằm giữa bàn cờ, xét coi có bị chặn 2 đầu không
            if (_MangOCo[crDong, crCot - 1].SoHuu == 0 || _MangOCo[crDong, crCot + dem].SoHuu == 0)
                return true;

            return false;
        }

        private bool DuyetCheoXuoi(int crDong, int crCot, int crSoHuu)
        {
            //Quân đang xét có nằm từ cột, dòng 16 trở lên không
            if (crDong > _BanCo.SoDong - 5 || crCot > _BanCo.SoCot - 5)
                return false;

            //Xét coi có đủ 5 quân thẳng chéo xuôi không
            //Qua được ải này là xác định đủ 5 quân rồi đó
            int dem;
            for (dem = 1; dem < 5; dem++)
                if (_MangOCo[crDong + dem, crCot + dem].SoHuu != crSoHuu)
                    return false;

            //Xét coi 5 quân đó có sát biên trái trên hay biên phải dưới không
            //Nếu sát thì không thể bị chặn 2 đầu được => Thắng
            if (crDong == 0 || crCot == 0 || crDong + dem == _BanCo.SoDong || crCot + dem == _BanCo.SoCot)
                return true;

            //Này là trường hợp 5 quân nằm giữa bàn cờ, xét coi có bị chặn 2 đầu không
            if (_MangOCo[crDong - 1, crCot - 1].SoHuu == 0 || _MangOCo[crDong + dem, crCot + dem].SoHuu == 0)
                return true;

            return false;
        }

        private bool DuyetCheoNguoc(int crDong, int crCot, int crSoHuu)
        {
            //Quân đang xét có nằm từ dòng 3 trở xuống, cột 16 trở lên không
            if (crDong < 4 || crCot > _BanCo.SoCot - 5)
                return false;

            //Xét coi có đủ 5 quân thẳng chéo ngược không
            //Qua được ải này là xác định đủ 5 quân rồi đó
            int dem;
            for (dem = 1; dem < 5; dem++)
                if (_MangOCo[crDong - dem, crCot + dem].SoHuu != crSoHuu)
                    return false;

            //Xét coi 5 quân đó có sát biên trái dưới hay biên phải trên không
            //Nếu sát biên thì không thể bị chặn 2 đầu được => Thắng
            if (crDong == _BanCo.SoDong - 1 || crCot == 0 || crDong == 4 || crCot + dem == _BanCo.SoCot)
                return true;

            //Này là trường hợp 5 quân nằm giữa bàn cờ, xét coi có bị chặn 2 đầu không
            if (_MangOCo[crDong + 1, crCot - 1].SoHuu == 0 || _MangOCo[crDong - dem, crCot + dem].SoHuu == 0)
                return true;

            return false;
        }
        #endregion

        #region AI
        private long[] MangDiemTanCong = new long[7] { 0, 3, 24, 192, 1536, 12288, 98304 };
        private long[] MangDiemPhongThu = new long[7] { 0, 1, 9, 81, 729, 6561, 59049 };

        //private long[] MangDiemTanCong = new long[7] { 0, 9, 54, 162, 1458, 13112, 118008 };
        //private long[] MangDiemPhongThu = new long[7] { 0, 3, 27, 99, 729, 6561, 59049 };
        public void MayDanh(Graphics g)
        {
            O_Co oco = new O_Co();
            long Max = 0, TanCong, PhongThu, Temp;
            for (int i = 0; i < _BanCo.SoDong; i++)
                for (int j = 0; j < _BanCo.SoCot; j++)
                    if (_MangOCo[i, j].SoHuu == 0)
                    {
                        TanCong = TC_Doc(i, j) + TC_Ngang(i, j) + TC_CheoXuoi(i, j) + TC_CheoNguoc(i, j);
                        PhongThu = PT_Doc(i, j) + PT_Ngang(i, j) + PT_CheoXuoi(i, j) + PT_CheoNguoc(i, j);
                        Temp = TanCong > PhongThu ? TanCong : PhongThu;
                        if (Max < Temp)
                        {
                            Max = Temp;
                            oco = new O_Co(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].ViTri, _MangOCo[i, j].SoHuu);
                        }
                    }
            DanhCo(oco.ViTri.X + 1, oco.ViTri.Y + 1, g);
        }

        #region Tính điểm Tấn Công
        public long TC_Doc(int crDong, int crCot)
        {
            long TongTC = 0;
            int SoQuanTa = 0, SoQuanDich = 0;

            //Duyệt từ trên xuống
            for (int Dem = 1; Dem < 6 && crDong + Dem < _BanCo.SoDong; Dem++)
                if (_MangOCo[crDong + Dem, crCot].SoHuu == 2)
                    SoQuanTa++;
                else if (_MangOCo[crDong + Dem, crCot].SoHuu == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else break;
            //Duyệt từ dưới lên
            for (int Dem = 1; Dem < 6 && crDong - Dem >= 0; Dem++)
                if (_MangOCo[crDong - Dem, crCot].SoHuu == 2)
                    SoQuanTa++;
                else if (_MangOCo[crDong - Dem, crCot].SoHuu == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else break;

            if (SoQuanDich == 2) return 0;
            TongTC -= MangDiemPhongThu[SoQuanDich];
            TongTC += MangDiemTanCong[SoQuanTa];
            return TongTC;
        }

        public long TC_Ngang(int crDong, int crCot)
        {
            long TongTC = 0;
            int SoQuanTa = 0, SoQuanDich = 0;

            //Duyệt từ trái qua
            for (int Dem = 1; Dem < 6 && crCot + Dem < _BanCo.SoCot; Dem++)
                if (_MangOCo[crDong, crCot + Dem].SoHuu == 2)
                    SoQuanTa++;
                else if (_MangOCo[crDong, crCot + Dem].SoHuu == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else break;
            //Duyệt từ phải qua
            for (int Dem = 1; Dem < 6 && crCot - Dem >= 0; Dem++)
                if (_MangOCo[crDong, crCot - Dem].SoHuu == 2)
                    SoQuanTa++;
                else if (_MangOCo[crDong, crCot - Dem].SoHuu == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else break;

            if (SoQuanDich == 2) return 0;
            TongTC -= MangDiemPhongThu[SoQuanDich];
            TongTC += MangDiemTanCong[SoQuanTa];
            return TongTC;
        }

        public long TC_CheoXuoi(int crDong, int crCot)
        {
            long TongTC = 0;
            int SoQuanTa = 0, SoQuanDich = 0;

            //Duyệt từ trái trên đến phải dưới
            for (int Dem = 1; Dem < 6 && crDong + Dem < _BanCo.SoDong && crCot + Dem < _BanCo.SoCot; Dem++)
                if (_MangOCo[crDong + Dem, crCot + Dem].SoHuu == 2)
                    SoQuanTa++;
                else if (_MangOCo[crDong + Dem, crCot + Dem].SoHuu == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else break;
            //Duyệt ngược lại
            for (int Dem = 1; Dem < 6 && crDong - Dem >= 0 && crCot - Dem >= 0; Dem++)
                if (_MangOCo[crDong - Dem, crCot - Dem].SoHuu == 2)
                    SoQuanTa++;
                else if (_MangOCo[crDong - Dem, crCot - Dem].SoHuu == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else break;

            if (SoQuanDich == 2) return 0;
            TongTC -= MangDiemPhongThu[SoQuanDich];
            TongTC += MangDiemTanCong[SoQuanTa];
            return TongTC;
        }

        public long TC_CheoNguoc(int crDong, int crCot)
        {
            long TongTC = 0;
            int SoQuanTa = 0, SoQuanDich = 0;

            //Duyệt từ trái dưới đến phải trên
            for (int Dem = 1; Dem < 6 && crCot + Dem < _BanCo.SoCot && crDong - Dem >= 0; Dem++)
                if (_MangOCo[crDong - Dem, crCot + Dem].SoHuu == 2)
                    SoQuanTa++;
                else if (_MangOCo[crDong - Dem, crCot + Dem].SoHuu == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else break;
            //Duyệt ngược lại
            for (int Dem = 1; Dem < 6 && crCot - Dem >= 0 && crDong + Dem < _BanCo.SoDong; Dem++)
                if (_MangOCo[crDong + Dem, crCot - Dem].SoHuu == 2)
                    SoQuanTa++;
                else if (_MangOCo[crDong + Dem, crCot - Dem].SoHuu == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else break;

            if (SoQuanDich == 2) return 0;
            TongTC -= MangDiemPhongThu[SoQuanDich];
            TongTC += MangDiemTanCong[SoQuanTa];
            return TongTC;
        }
        #endregion

        #region Tính điểm Phòng Thủ
        public long PT_Doc(int crDong, int crCot)
        {
            long TongPT = 0;
            int SoQuanTa = 0, SoQuanDich = 0;

            //Duyệt từ trên xuống
            for (int Dem = 1; Dem < 6 && crDong + Dem < _BanCo.SoDong; Dem++)
                if (_MangOCo[crDong + Dem, crCot].SoHuu == 2)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[crDong + Dem, crCot].SoHuu == 1)
                    SoQuanDich++;
                else break;
            //Duyệt từ dưới lên
            for (int Dem = 1; Dem < 6 && crDong - Dem >= 0; Dem++)
                if (_MangOCo[crDong - Dem, crCot].SoHuu == 2)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[crDong - Dem, crCot].SoHuu == 1)
                    SoQuanDich++;
                else break;

            if (SoQuanTa == 2) return 0;
            TongPT += MangDiemPhongThu[SoQuanDich];
            TongPT -= MangDiemTanCong[SoQuanTa];
            return TongPT;
        }

        public long PT_Ngang(int crDong, int crCot)
        {
            long TongPT = 0;
            int SoQuanTa = 0, SoQuanDich = 0;

            //Duyệt từ trái qua
            for (int Dem = 1; Dem < 6 && crCot + Dem < _BanCo.SoCot; Dem++)
                if (_MangOCo[crDong, crCot + Dem].SoHuu == 2)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[crDong, crCot + Dem].SoHuu == 1)
                    SoQuanDich++;
                else break;
            //Duyệt từ phải qua
            for (int Dem = 1; Dem < 6 && crCot - Dem >= 0; Dem++)
                if (_MangOCo[crDong, crCot - Dem].SoHuu == 2)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[crDong, crCot - Dem].SoHuu == 1)
                    SoQuanDich++;
                else break;

            if (SoQuanTa == 2) return 0;
            TongPT += MangDiemPhongThu[SoQuanDich];
            TongPT -= MangDiemTanCong[SoQuanTa];
            return TongPT;
        }

        public long PT_CheoXuoi(int crDong, int crCot)
        {
            long TongPT = 0;
            int SoQuanTa = 0, SoQuanDich = 0;

            //Duyệt từ trái trên đến phải dưới
            for (int Dem = 1; Dem < 6 && crDong + Dem < _BanCo.SoDong && crCot + Dem < _BanCo.SoCot; Dem++)
                if (_MangOCo[crDong + Dem, crCot + Dem].SoHuu == 2)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[crDong + Dem, crCot + Dem].SoHuu == 1)
                    SoQuanDich++;
                else break;
            //Duyệt ngược lại
            for (int Dem = 1; Dem < 6 && crDong - Dem >= 0 && crCot - Dem >= 0; Dem++)
                if (_MangOCo[crDong - Dem, crCot - Dem].SoHuu == 2)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[crDong - Dem, crCot - Dem].SoHuu == 1)
                    SoQuanDich++;
                else break;

            if (SoQuanTa == 2) return 0;
            TongPT += MangDiemPhongThu[SoQuanDich];
            TongPT -= MangDiemTanCong[SoQuanTa];
            return TongPT;
        }

        public long PT_CheoNguoc(int crDong, int crCot)
        {
            long TongPT = 0;
            int SoQuanTa = 0, SoQuanDich = 0;

            //Duyệt từ trái dưới đến phải trên
            for (int Dem = 1; Dem < 6 && crCot + Dem < _BanCo.SoCot && crDong - Dem >= 0; Dem++)
                if (_MangOCo[crDong - Dem, crCot + Dem].SoHuu == 2)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[crDong - Dem, crCot + Dem].SoHuu == 1)
                    SoQuanDich++;
                else break;
            //Duyệt ngược lại
            for (int Dem = 1; Dem < 6 && crCot - Dem >= 0 && crDong + Dem < _BanCo.SoDong; Dem++)
                if (_MangOCo[crDong + Dem, crCot - Dem].SoHuu == 2)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[crDong + Dem, crCot - Dem].SoHuu == 1)
                    SoQuanDich++;
                else break;

            if (SoQuanTa == 2) return 0;
            TongPT += MangDiemPhongThu[SoQuanDich];
            TongPT -= MangDiemTanCong[SoQuanTa];
            return TongPT;
        }
        #endregion
        #endregion
    }
}
