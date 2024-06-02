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
    public partial class Form1 : Form
    {

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataSet ds;
        DataTable dt;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("server=DESKTOP-95A74GO; database=BC_Comunity3;"
              + "Integrated Security=true;");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        void func()
        {
            try
            {
                string un = textBox1.Text;
                string pass = textBox2.Text;
                string q = "select position from sch1.users where userName='"+un+"' and pass='"+pass+"'";

                cmd= new SqlCommand(q,conn);
               // conn.Open();
                dr= cmd.ExecuteReader();

                string tt = "";
                while (dr.Read())
                {
                  tt=dr.GetString(0);

                    //MessageBox.Show(dr.GetString(0));
                }

                /*Leader
                CO.Leader
                Head Of HR
                Vice Of HR
                Others*/

                if (tt.Equals("Leader")||tt.Equals("CO.Leader")||tt.Equals(" Head Of HR")||tt.Equals("Vice Of HR"))
                {
                 
               
                }
                else if(tt.Equals("Others"))
                {
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;

                }



            }
            catch (Exception ex) { MessageBox.Show("Error"); }

            finally { conn.Close(); }

        }


        private void button1_Click(object sender, EventArgs e)//login
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("Enter complete data");
            }
            else
            {
                try
                {

                    string uName = textBox1.Text;
                    string pass = textBox2.Text;
                  

                    string query = "select count(*) from sch1.users where  userName='"+uName+"' and pass='"+pass+"'";

                    cmd =new SqlCommand(query, conn);

                    conn.Open();
                    int n = (int)cmd.ExecuteScalar();
                    int currentIndex = tabControl1.SelectedIndex;
                    int tab3=(currentIndex+2) % tabControl1.TabCount;

                    if (n > 0 )
                    {
                        func();
                        tabControl1.SelectedIndex=tab3;
                    }
                    else
                        MessageBox.Show("Error, Try Again");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error,userName or Password not valid");
                }
                finally
                {
                    conn.Close();
                }
            }


          
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text  = "";
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals("") || textBox4.Text.Equals("") || comboBox1.Text.Equals(""))
            {
                MessageBox.Show("enter complete data");
            }
            else
            {
                try
                {
                    string name = textBox3.Text;
                    string pass = textBox4.Text;
                    string email = textBox5.Text;
                    string position = comboBox1.Text;
                    string query = "insert into sch1.users values('" + name + "','" + pass + "','" + email + "','" + position + "')";

                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    int res = cmd.ExecuteNonQuery();
                    if(res>0)
                    {
                        MessageBox.Show("Account created successfuly");

                           int currentIndex = tabControl1.SelectedIndex;
                           int tab1=(currentIndex -1) % tabControl1.TabCount;
                           tabControl1.SelectedIndex=tab1;

                    }

                }
                catch(Exception ex )
                {
                    MessageBox.Show("Error,try again");
                }
                finally { conn.Close(); }


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Trainee te=new Trainee();   
            te.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text= string.Empty;
            comboBox1.Text = "";
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)//forget pass
        {
            Enter_Your_Email et=new Enter_Your_Email();
            et.ShowDialog();    





        }

        private void button9_Click_1(object sender, EventArgs e)//sign up
        {
            tabControl1.SelectedIndex = 1;//open tab page of sign up
        }

        private void button5_Click(object sender, EventArgs e)
        {
           Members m=new Members();
            m.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Training_Events tr=new Training_Events();
            tr.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Project_Form project=new Project_Form();
            project.ShowDialog();
        }

      

        private void button10_Click(object sender, EventArgs e)
        {
            Attending at=new Attending();
            at.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button11_Click(object sender, EventArgs e)
        {
            //System.Environment.Exit(0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
