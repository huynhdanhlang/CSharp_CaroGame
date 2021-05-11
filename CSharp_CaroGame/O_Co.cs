using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_CaroGame
{
    class O_Co
    {
        public const int _ChieuRong = 25;
        public const int _ChieuCao = 25;

        private int _Dong;
        private int _Cot;
        private Point _ViTri;
        private int _SoHuu;

        // Đóng gói các thuộc tính
        public int Dong { get => _Dong; set => _Dong = value; }
        public int Cot { get => _Cot; set => _Cot = value; }
        public Point ViTri { get => _ViTri; set => _ViTri = value; }
        public int SoHuu { get => _SoHuu; set => _SoHuu = value; }

    }
}
