using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_CaroGame
{
    class Caro_Control
    {
        public static Pen pen;


        private Ban_Co _BanCo;
        public Caro_Control()
        {
            //Tao cay but mau do
            pen = new Pen(Color.Red);
            _BanCo = new Ban_Co(20, 20);
        }

        public void VeBanCo(Graphics g)
        {
            _BanCo.VeBanCo(g);
        }
    }


}
