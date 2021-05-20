using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_CaroGame
{
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
    }
}
