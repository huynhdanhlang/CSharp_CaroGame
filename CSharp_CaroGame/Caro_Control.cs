using System;
using System.Collections.Generic;
using System.Drawing;
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
        Com
    }
    class Caro_Control
    {
        public static Pen pen;
        public static SolidBrush sbWhite;
        public static SolidBrush sbBlack;
        public static SolidBrush sbGreen;

        private O_Co[,] _MangOCo;
        private Ban_Co _BanCo;
        private int LuotDi;
        public bool _SanSang;
        private Stack<O_Co> stk_CacNuocDaDi;
        private Stack<O_Co> stk_CacNuocDaUndo;
        private KETTHUC KetThuc; 

        public bool SanSang { get => _SanSang; }

        public Caro_Control()
        {
            //Tao cay but mau do
            pen = new Pen(Color.Red);
            sbWhite= new SolidBrush(Color.White);
            sbBlack= new SolidBrush(Color.Black);
            sbGreen = new SolidBrush(Color.DarkSeaGreen);
            _BanCo = new Ban_Co(20, 20);
            _MangOCo = new O_Co[_BanCo.SoDong, _BanCo.SoCot];
            stk_CacNuocDaDi = new Stack<O_Co>();
            stk_CacNuocDaUndo = new Stack<O_Co>();
            LuotDi = 1;
        }

        public void VeBanCo(Graphics g)
        {
            _BanCo.VeBanCo(g);
        }

        public void KhoiTaoMangOCo()
        {
            for (int i=0; i< _BanCo.SoDong; i++)
                for (int j=0; j< _BanCo.SoCot; j++)
                {
                    _MangOCo[i, j] = new O_Co(i, j, new Point(j*O_Co._ChieuRong, i*O_Co._ChieuCao), 0);
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
            foreach(O_Co oco in stk_CacNuocDaDi)
            {
                if (oco.SoHuu== 1)
                    _BanCo.VeQuanCo(g, oco.ViTri, sbBlack);
                else if (oco.SoHuu == 2)
                    _BanCo.VeQuanCo(g, oco.ViTri, sbWhite);
            }
        }

        public void StartPvP(Graphics g)
        {
            _SanSang = true;
            /*stk_CacNuocDaDi = new List<O_Co>();
            KhoiTaoMangOCo();
            VeBanCo(g);*/
        }

        public void Reset(Graphics g)
        {
            _SanSang = false;
            stk_CacNuocDaDi = new Stack<O_Co>();
            stk_CacNuocDaUndo = new Stack<O_Co>();
            LuotDi = 1;
            KhoiTaoMangOCo();
            VeBanCo(g);
        }

        public void Undo(Graphics g)
        {
            if(stk_CacNuocDaDi.Count != 0)
            {
                O_Co oco = stk_CacNuocDaDi.Pop();

                stk_CacNuocDaUndo.Push(new O_Co(oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu));
                _MangOCo[oco.Dong, oco.Cot].SoHuu = 0;
                _BanCo.XoaQuanCo(g, oco.ViTri, sbGreen);
                LuotDi= (LuotDi == 1) ? 2 : 1;
            }
        }

        public void Redo(Graphics g)
        {
            if (stk_CacNuocDaUndo.Count != 0)
            {
                O_Co oco = stk_CacNuocDaUndo.Pop();

                stk_CacNuocDaDi.Push(new O_Co(oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu));
                _MangOCo[oco.Dong, oco.Cot].SoHuu = oco.SoHuu;
                _BanCo.VeQuanCo(g, oco.ViTri, oco.SoHuu == 1 ? sbBlack:sbWhite);
                LuotDi = (LuotDi == 1) ? 2 : 1;
            }
        }

        #region Xử lý thắng thua
        public void ThongBaoKetThuc()
        {
            switch (KetThuc)
            {
                case KETTHUC.Draw:
                    MessageBox.Show("Draw. Endgame!");
                    break;
                case KETTHUC.P1:
                    MessageBox.Show("Black player wins :)");
                    break;
                case KETTHUC.P2:
                    MessageBox.Show("White player wins :)");
                    break;
                case KETTHUC.Com:
                    MessageBox.Show("Game Over");
                    break;
            }
            _SanSang = false;
        }

        public bool KiemTraChienThang()
        {
            if(stk_CacNuocDaDi.Count == _BanCo.SoDong * _BanCo.SoCot)
            {
                KetThuc = KETTHUC.Draw;
                return true;
            }

            foreach (O_Co oco in stk_CacNuocDaDi)
            {
                if(DuyetDoc(oco.Dong, oco.Cot, oco.SoHuu) || DuyetNgang(oco.Dong, oco.Cot, oco.SoHuu) ||
                    DuyetCheoXuoi(oco.Dong, oco.Cot, oco.SoHuu) || DuyetCheoNguoc(oco.Dong, oco.Cot, oco.SoHuu))
                {
                    KetThuc = oco.SoHuu == 1 ? KETTHUC.P1 : KETTHUC.P2;
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
            //Quân đang xét có nằm từ cột 16 trở lên không
            if (crDong < 4 || crCot > _BanCo.SoCot - 5)
                return false;

            //Xét coi có đủ 5 quân thẳng dòng không
            //Qua được ải này là xác định đủ 5 quân rồi đó
            int dem;
            for (dem = 1; dem < 5; dem++)
                if (_MangOCo[crDong - dem, crCot + dem].SoHuu != crSoHuu)
                    return false;

            //Xét coi 5 quân đó có sát biên trái hay biên phải không
            //Nếu sát biên thì không thể bị chặn 2 đầu được => Thắng
            if (crDong == _BanCo.SoDong -1 || crCot == 0 || crDong == 4 || crCot + dem == _BanCo.SoCot)
                return true;

            //Này là trường hợp 5 quân nằm giữa bàn cờ, xét coi có bị chặn 2 đầu không
            if (_MangOCo[crDong + 1, crCot - 1].SoHuu == 0 || _MangOCo[crDong - dem, crCot + dem].SoHuu == 0)
                return true;

            return false;
        }
        #endregion
    }
}
