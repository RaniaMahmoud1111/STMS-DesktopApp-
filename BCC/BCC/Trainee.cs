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
using System.Data.SqlClient;
using System.Xml.Linq;

namespace BCC
{
    public partial class Trainee : Form
    {
        public Trainee()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt;
        DataSet ds;
        SqlDataReader dr;  



        private void Trainee_Load(object sender, EventArgs e)
        {

            conn = new SqlConnection("server=DESKTOP-95A74GO; database=BC_Comunity3;"
              + "Integrated Security=true;");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
            comboBox1.Text = "";

        
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") ||
                  textBox4.Text.Equals("") || textBox5.Text.Equals("") || comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Enter compelete data");
                }
                else
                {
                    string name = textBox1.Text;
                    string phone= textBox2.Text;
                    string ssn=textBox3.Text;
                    string university=textBox4.Text;
                    string faculty =textBox5.Text;
                    int level =int.Parse( comboBox1.Text);


                    string[] ar = name.Split(' ');
                    string a, b, c, d;
                    a = ar[0];
                    b = ar[1];
                    c = ar[2];



                    string query = "insert into sch1.Trainee (fname,sname,tname,what_phone,ssn,university,faculty,te_level)" +
                     "values('"+a+"' ,'"+b+"', '"+c+"' , '"+phone+"','"+ssn+"','"+university+"','"+faculty+"',"+level+");";
                   
                   // MessageBox.Show(query);
                    cmd =new SqlCommand(query, conn);
                    conn.Open();
                    int res= cmd.ExecuteNonQuery();// row affected
                    if(res > 0)
                    {
                        MessageBox.Show(name + " Add successfuly");
                    }
                    else
                    {
                        MessageBox.Show("Error ,Try again");
                    }


                }

            }catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();

            }



        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox6 = (TextBox)sender;
            textBox6.Text = string.Empty;
            textBox6.TextChanged -= textBox6_TextChanged; 
            






        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
             
                string name = textBox7.Text;
                string ssn = textBox8.Text;
                string uni = textBox9.Text;
                string faculty = textBox10.Text;
                int level =int.Parse( comboBox2.Text) ;

                string [] ar=name.Split(' ');
                string a, b, c;
                a= ar[0];
                b= ar[1];
                c= ar[2];

                string query = "update [sch1].[Trainee] set   fname='"+a+"',sname='"+b+"',tname='"+c+"',ssn='"+ssn+"',university='"+uni+"' ,faculty='"+faculty+"',te_level="+level+"  where what_phone='"+textBox6.Text+"';";
              //  MessageBox.Show(query);
                cmd = new SqlCommand(query,conn);
                conn.Open();
                int res=cmd.ExecuteNonQuery();

                if (res >0)
                {
                    MessageBox.Show("Data updated successfuly ");
                }
                else
                {
                    MessageBox.Show("Error, try again");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
            finally { conn.Close(); }   



        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
            TextBox textBox6 = (TextBox)sender;
            textBox6.Text = string.Empty;
            textBox6.TextChanged -= textBox6_TextChanged_1;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                string phone = textBox6.Text;

                ds = new DataSet();
                dt = new DataTable();
                string query = "select fname,sname,tname,ssn,faculty,university,te_level from [sch1].[Trainee] where what_phone='" + phone + "'";
                //fn0 sn1 tn2  ssn3 fa4  uni5 le6
                adapt = new SqlDataAdapter(query, conn);
                adapt.Fill(dt);
              // MessageBox.Show(query);
                conn.Close();
                foreach (DataRow row in dt.Rows)
                {
                    {
                        textBox7.Text = row[0].ToString() +" "+ row[1].ToString() +" "+row[2].ToString();
                        textBox8.Text = row[3].ToString();
                        textBox9.Text = row[5].ToString();
                        textBox10.Text = row[4].ToString();

                        int d = (int)row[6];
                        comboBox2.Text = d + "";
                        //MessageBox.Show("1");
                    }


                }
            }catch(Exception ex)
            { MessageBox.Show("Error"); }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox6.Text=textBox7.Text=textBox8.Text=textBox9.Text=textBox10.Text="";
            comboBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you ready to delete  " +textBox7.Text +"  ?", "Qusetion:",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                try
                {
                    string query = "delete from [sch1].[Trainee] where what_phone='" + textBox6.Text + "'";

                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        MessageBox.Show("this trainee deleted successfuly");
                    }
                    else
                    {
                        MessageBox.Show("Error, try again");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
                finally { conn.Close(); }

            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox3.Items.Clear();
                string query1 = "select distinct faculty from [sch1].[Trainee]";
                adapt = new SqlDataAdapter(query1, conn);
                dt = new DataTable();
                conn.Open();
                adapt.Fill(dt);
                DataRow row = dt.NewRow();
                row[0] = "select a faculty";
                dt.Rows.InsertAt(row, 0);
                comboBox3.DataSource = dt;
                comboBox3.DisplayMember = "faculty";
                comboBox3.ValueMember = "faculty";

                button7.Enabled = false;//unactive

            }catch(Exception ex)
            {
                MessageBox.Show("Error");
            }
            finally { conn.Close(); }   

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            { 
                string query = "select fname+' '+sname +' ' + tname as FullName,what_phone,ssn,te_level,university from [sch1].[Trainee] where faculty='" + comboBox3.SelectedValue + "' order by university, te_level";
                adapt = new SqlDataAdapter(query, conn);

                ds = new DataSet();
                conn.Open();
                adapt.Fill(ds, "trainee of this faculty");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "trainee of this faculty";
                button7.Enabled = false;


            }catch(Exception ex)
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        
        
        
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            button7.Enabled = true;
            comboBox3.DataSource= null;
            comboBox3.Items.Clear();    
        }
    }
}
