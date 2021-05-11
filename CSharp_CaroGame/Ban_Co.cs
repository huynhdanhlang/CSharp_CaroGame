using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_CaroGame
{
    class Ban_Co
    {
        private int _SoDong;
        private int _SoCot;

        public Ban_Co()
        {
            _SoDong = 0;
            _SoCot = 0;
        }

        public Ban_Co(int soDong, int soCot)
        {
            _SoDong = soDong;
            _SoCot = soCot;
        }

        public void VeBanCo(Graphics g)
        {
            //Vẽ cột mỗi cột cách nhau 25 đơn vị
            for (int i = 0; i <= _SoCot; i++)
            {
                g.DrawLine(Caro_Control.pen, i * O_Co._ChieuRong, 0, i * O_Co._ChieuRong, _SoDong * O_Co._ChieuCao);

            }
            //vẽ dòng mỗi dòng cách nhau 25 đơn vị
            for (int j = 0; j <= _SoDong; j++)
            {
                g.DrawLine(Caro_Control.pen, 0, j * O_Co._ChieuCao, _SoCot * O_Co._ChieuCao, j * O_Co._ChieuCao);

            }
        }
    }
}
