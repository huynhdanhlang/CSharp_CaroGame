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
    public partial class Sign_up : Form
    {
        String username, password, confirm;
        MySqlDataReader reader;
        MySqlCommand cmd;

        public Sign_up()
        {
            InitializeComponent();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            username = txt_Username.Text;
            password = txt_Password.Text;
            confirm = txt_Confirm.Text;
            if (CheckFields())
            {
                MySqlConnection con = MySQL_Connection.Connection;
                string query = "SELECT * FROM `user` WHERE `username`= '" + username + "'";
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                    MessageBox.Show("Username is already used");
                else
                {
                    try
                    {
                        con.Close();
                        con = MySQL_Connection.Connection;
                        /*query = "INSERT INTO `user` VALUES( `full_name` = '" + txt_Name.Text
                            + "', `username` = '" + username + "', `password` = '" + password + "')";*/
                        query = "INSERT INTO `user`(`full_name`, `username`, `password`) " +
                            "VALUES('" + txt_Name.Text + "', '" + username + "', '" + password + "')";
                        cmd = new MySqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Save successfully");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.StackTrace);
                    }
                }
                con.Close();
            }    
        }

        private bool CheckFields()
        {
            if (username.Trim().Equals("") || password.Trim().Equals("") ||
                confirm.Trim().Equals(""))
            {
                MessageBox.Show("Info not valid. Please input again!");
                return false;
            }
            else if (!confirm.Equals(password))
            {
                MessageBox.Show("Password don't match. Please check again!");
                return false;
            }
            return true;           
        }

        #region Mấy cái KeyDown
        private void txt_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Ok_Click(this, new EventArgs());
            }
        }
        private void txt_Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Ok_Click(this, new EventArgs());
            }
        }
        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Ok_Click(this, new EventArgs());
            }
        }
        private void txt_Confirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Ok_Click(this, new EventArgs());
            }
        }
        #endregion
    }
}