using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace shop.Сonnection
{
    static class MySqlData
    {
        static public string StrOne(string query)
        {
            string ret="";
            ConnectionString connectionString = new ConnectionString();
            MySqlConnection con = new MySqlConnection(connectionString.connectionString);
            try
            {
                con.Open();
                
                MySqlCommand cmd = new MySqlCommand(query, con);
                if (cmd.ExecuteScalar() == null)
                    ret = "";
                else
                    ret += cmd.ExecuteScalar().ToString();
                
            }
            catch (Exception)
            {
                ret = "";
            }
            finally
            {
                con.Close();
            }
            return ret;
        }
        static public bool Delete(string query)
        {
            ConnectionString connectionString = new ConnectionString();
            MySqlConnection con = new MySqlConnection(connectionString.connectionString);
            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(query, con);
                int check = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }
        static public DataTable LoadData(string query)
        {
            DataTable tb = new DataTable();
            ConnectionString connectionString = new ConnectionString();
            MySqlConnection con = new MySqlConnection(connectionString.connectionString);
            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(tb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tb.Clear();
            }
            finally
            {
                con.Close();
            }
            return tb;
        }
        static public string[] Reader(string query)
        {
            string[] arr= new string[0];
            ConnectionString connectionString = new ConnectionString();
            MySqlConnection con = new MySqlConnection(connectionString.connectionString);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length-1] = reader.GetString(0);
                }
                reader.Close();
            }
            catch (Exception)
            {
                arr = new string[1] { "falsess" };
            }
            finally
            {
                con.Close();
            }
            return arr;
        }
    }
}
