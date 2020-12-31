using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ERIS_MIS.Config;

namespace ERIS_MIS
{

    class Config3
    {
        //public static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=eris;";
        // for testing purposes 127.0.0.1 is the localhost equivalent.
        // datasource will be changed to server's ip address for implementation.




        public static MySqlConnection connection;
        public static MySqlCommand command;
        public static MySqlDataAdapter adapter;
        public static MySqlDataReader reader;



    }

    class ErisDatabase :Config3 { 
        public void OpenDBConnection()
        {
            Config3 config = new Config3();
            try
            {
                connection = new MySqlConnection(Config1.connectionString);
                connection.Open();

            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }

            }
        }

        public void CloseConnection()
        {
            connection.Close();
        }


        //private MySqlConnection Connection()
        //{
            
        //    MySqlConnection con = connection;
        //    return con;
         
        //}

        //private MySqlDataReader Reader()
        //{
        //    MySqlDataReader rdr = reader;
        //    return rdr;
        //}


        //private  MySqlDataAdapter Adapter() {
        //    MySqlDataAdapter adpt = adapter;
        //    return adpt;
        //}


        //private MySqlCommand Command() {
        //        MySqlCommand com = command;
        //        return com;
        //    }

        
    }


    

}
