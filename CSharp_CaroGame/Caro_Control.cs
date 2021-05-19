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

        private O_Co[,] _MangOCo;
        private Ban_Co _BanCo;
        private int LuotDi;
        public bool _SanSang;
        private List<O_Co> list_CacNuocDaDi;

        public bool SanSang { get => _SanSang; }

        public Caro_Control()
        {
            //Tao cay but mau do
            pen = new Pen(Color.Red);
            sbWhite= new SolidBrush(Color.White);
            sbBlack= new SolidBrush(Color.Black);
            _BanCo = new Ban_Co(20, 20);
            _MangOCo = new O_Co[_BanCo.SoDong, _BanCo.SoCot];
            list_CacNuocDaDi = new List<O_Co>();
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
            
            list_CacNuocDaDi.Add(_MangOCo[Dong, Cot]);
            return true;
        }

        public void VeLaiQuanCo(Graphics g)
        {
            foreach(O_Co oco in list_CacNuocDaDi)
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
            list_CacNuocDaDi = new List<O_Co>();
            KhoiTaoMangOCo();
            VeBanCo(g);
        }
    }
}
