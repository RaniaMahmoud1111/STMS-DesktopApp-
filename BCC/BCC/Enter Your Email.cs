using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BCC
{
    public partial class Enter_Your_Email : Form
    {
        public Enter_Your_Email()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader rd;


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string email = textBox1.Text;
                string query = "select pass from sch1.users where email='" + email + "'";

                cmd = new SqlCommand(query, conn);
                conn.Open();
                rd = cmd.ExecuteReader();
                string tt= "";
                while (rd.Read())
                {
                   MessageBox.Show(rd.GetString(0));//show student
                }


            }catch(Exception ex) {
                MessageBox.Show("Error");
            }
            finally { conn.Close(); }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Enter_Your_Email_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("server=DESKTOP-95A74GO; database=BC_Comunity3;"
              + "Integrated Security=true;");
        }
    }
}
