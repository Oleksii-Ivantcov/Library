using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryForms
{
    public partial class Form1 : Form
    {
        readonly List<string[]> _data = new List<string[]>();
        public Form1()
        {
            InitializeComponent();
            LoadData();
            OutPut();
        }
        private void LoadData()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
                "Data Source=192.168.0.101, 1433;" +
                "Network Library=DBMSSOCN;" +
                "Initial Catalog=Library;" +
                "User id=Test;" +
                "Password=Qwer1234;";
            string sqlExpression = "SELECT * FROM Reader ORDER BY Id_Reader";
            try
            {
                conn.Open();
                Console.WriteLine(conn.State);
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    _data.Add(new string[6]);
                    _data[_data.Count - 1][0] = reader[0].ToString();
                    _data[_data.Count - 1][1] = reader[1].ToString();
                    _data[_data.Count - 1][2] = reader[2].ToString();
                    _data[_data.Count - 1][3] = reader[3].ToString();
                    _data[_data.Count - 1][4] = reader[4].ToString();
                    _data[_data.Count - 1][5] = reader[5].ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                conn.Close();
                Console.WriteLine(conn.State);
            }
        }

        private void OutPut()
        {
            foreach (var item in _data)
            {
                dataGridView1.Rows.Add(item);
            }
        }
    }
}
