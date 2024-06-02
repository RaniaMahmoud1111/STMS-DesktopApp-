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
    public partial class Attending : Form
    {
        public Attending()
        {
            InitializeComponent();
        }
        SqlCommand cmd,cm,c,a,b,d;
        SqlConnection conn;
        SqlDataAdapter adapt;
        SqlDataReader dr1,dr2,dr3;
        


        private void Attending_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("server=DESKTOP-95A74GO; database=BC_Comunity3;"
            + "Integrated Security=true;");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals(""))
            {
                MessageBox.Show("Enter Complete data");
            }
            else
            {
                try
                {
                    string Trainingn = textBox1.Text;
                    string year = textBox3.Text;
                    string month = textBox4.Text;

                    string q1 = "(select T_id from sch1.Training where year(star_date)=" + year + " and MONTH(star_date)=" + month + " and t_name like('%" + Trainingn + "%'))";

                    cmd = new SqlCommand(q1, conn);

                    string phone = textBox2.Text;
                    string q2 = "(select te_id from sch1.Trainee where what_phone='" + phone + "')";

                    cm = new SqlCommand(q2, conn);
                    conn.Open();
                    int m = (int)cmd.ExecuteScalar();
                    int id = (int)cm.ExecuteScalar();

                    string q3 = "insert into dbo.attend(training_id,trainee_id)values(" + m + "," + id + ")";
                    c = new SqlCommand(q3, conn);
                    int res = c.ExecuteNonQuery();

                    if (m > 0 && id > 0 && res > 0)
                    {
                        MessageBox.Show("data add successfuly");
                    }
                    else
                    {
                        MessageBox.Show("Error,try again");
                    }


                }
                catch (Exception ex)
                { MessageBox.Show("Error"); }
                finally { conn.Close(); }


            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string Trainingn = textBox1.Text;
                string year = textBox3.Text;
                string month = textBox4.Text;

                string q1 = "(select T_id from sch1.Training where year(star_date)=" + year + " and MONTH(star_date)=" + month + " and t_name like('%" + Trainingn + "%'))";

                cmd = new SqlCommand(q1, conn);

                string phone = textBox2.Text;
                string q2 = "(select te_id from sch1.Trainee where what_phone='" + phone + "')";

                cm = new SqlCommand(q2, conn);
                conn.Open();
                int m = (int)cmd.ExecuteScalar();
                int id = (int)cm.ExecuteScalar();

                string q3 = "select count(*) from dbo.attend where training_id=" + m + " and trainee_id=" + id + ";";
                c = new SqlCommand(q3, conn);
                int res = c.ExecuteNonQuery();

                string q4 = "select CONCAT(fname,' ' ,sname,' ' ,tname) from sch1.Trainee where te_id=" + id + "";
                a = new SqlCommand(q4, conn);
                dr1 = a.ExecuteReader();

                string traineename = "";
                while (dr1.Read())
                {
                    traineename=dr1.GetString(1);
                  //  MessageBox.Show(dr1.GetString(0));//show student
                }
                string q5 = "select t_name from sch1.Training where T_id=" + m + "";
                b=new SqlCommand(q5, conn);
                dr2 = b.ExecuteReader();
                                string tt= "";
                while (dr2.Read())
                {
                    /*
MessageBox.Show(dr2.GetString(0));//show student
                
                   }*/

                   
                }

                
                if (m > 0 && id > 0 && res > 0)
                {
                    MessageBox.Show(""+res+" Times");
                }
                else
                {
                    MessageBox.Show("Error,try again");
                }


            }
            catch (Exception ex)
            { MessageBox.Show("Error"); }
            finally { conn.Close(); }


        }
    }

   

        

     
    }

