using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace CSharp_CaroGame
{
    class MySQL_Connection
    {
        static string host = "localhost";
        static string database = "mydatabase";
        static string user = "root";

        private static MySqlConnection _Connection;
        public static MySqlConnection Connection
        {
            get
            {
                if (_Connection == null)
                {
                    string cs = "server='" + host + "';user id='" + user + "';password='';database='" + database + "'";
                    _Connection = new MySqlConnection(cs);
                }

                if (_Connection.State == ConnectionState.Closed)
                    try
                    {
                        _Connection.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can not connect to server");
                        //handle your exception here
                    }
                return _Connection;
            }
        }


    }


}
