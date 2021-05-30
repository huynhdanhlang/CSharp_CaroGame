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

    public partial class Login_Form : Form
    {
        String username, password;
        MySqlDataReader reader;
        MySqlCommand cmd;

        public Login_Form()
        {
            InitializeComponent();

        }

        private void textBox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void textBox_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = MySQL_Connection.Connection;
            username = textBox_username.Text;
            password = textBox_password.Text;
            string query = "SELECT username,password FROM `user` WHERE `username` = '" + username + "' AND `password`= '" + password + "'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                this.Hide();
                Form_CoCaRo frm_caro = new Form_CoCaRo();
                frm_caro.initForm(username);
                frm_caro.Closed += (s, args) => this.Close();
                conn.Close();
                frm_caro.Show();
                conn.Close();

            }
            else
            {
                MessageBox.Show("Info not valid. Please input again");
            }

        }
    }
}

