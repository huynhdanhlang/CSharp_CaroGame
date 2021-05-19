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
    public partial class Form_KetNoi : Form
    {
        public Form_KetNoi()
        {
            InitializeComponent();
            txt_IP.Text = "127.0.0.1";
            txt_Port.Text = "8080";
        }
    }
}
