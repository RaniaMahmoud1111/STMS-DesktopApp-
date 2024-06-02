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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BCC
{
    public partial class Project_Form : Form
    {
        public Project_Form()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable data;

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Project_Form_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("server=DESKTOP-95A74GO; database=BC_Comunity3;"
            + "Integrated Security=true;");
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals(""))
            {
                MessageBox.Show("enter complete data");
            }
            else
            {
                try
                {
                    string proname = textBox1.Text;
                    string desname = textBox2.Text;
                    string phone = textBox3.Text;
                    string period = textBox4.Text;

                    string q = "insert into [sch1].[project](pro_name,pro_description,leader_id,pro_period_bydays) values" +
                        " ('" + proname + "','" + desname + "',(select m_id from sch1.BC_Memebers where what_phone='" + phone + "')," + period + ")";

                    cmd = new SqlCommand(q, conn);
                    conn.Open();
                    int res = cmd.ExecuteNonQuery();

                    if (res > 0)
                    {
                        MessageBox.Show("data added successfuly");
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";

        }

        void load_update()
        {
            try
            {
                data = new DataTable();
                string q = "select p_id, pro_name ,pro_description, what_phone,stra_date,pro_period_bydays from sch1.Project inner join [sch1].[BC_Memebers]  on leader_id=m_id";
                adapt = new SqlDataAdapter(q, conn);
                conn.Open();
                adapt.Fill(data);
                conn.Close();
                DataRow row = data.NewRow();
                row[0] = 0;
                row[1] = "select project";
                data.Rows.InsertAt(row, 0);
                comboBox1.DataSource = data;
                comboBox1.DisplayMember = "pro_name";
                comboBox1.ValueMember = "p_id";

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error");   
            }

        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            load_update();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text.Equals("select project"))
            {

            }else
            {
                foreach(DataRow y in data.Rows)
                {
                    if (y[0].Equals(comboBox1.SelectedValue))
                    {
                       //  comboBox1.Text.;
                         textBox5.Text= y[4].ToString();//date
                         textBox6.Text=y[3].ToString();//phone
                         textBox7.Text=y[2].ToString();//dec
                         textBox8.Text = y[5].ToString();//period


                    }
                }
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        void update()
        {
            try
            {
                string name = comboBox1.Text;
                string desc = textBox7.Text;
                string phone = textBox6.Text;
                string period = textBox8.Text;

                string q = "update  [sch1].[project] set pro_name='" + name + "' ,pro_description='" + desc + "', leader_id=" +
                   "(select m_id from [sch1].[BC_Memebers] where what_phone='" + phone + "' ),pro_period_bydays='" + period + "' where p_id=" + comboBox1.SelectedValue;
                MessageBox.Show(q);
                MessageBox.Show(name);

                cmd = new SqlCommand(q, conn);
                conn.Open();
                int res=cmd.ExecuteNonQuery();
                if(res>0)
                {
                    MessageBox.Show("data updated successfuly");
                }
                else
                {
                    MessageBox.Show("Error,try again");
                }

            }catch(Exception ex) 
            {
                MessageBox.Show("Error");
            }
            finally { conn.Close(); }   
        }   
        private void button4_Click(object sender, EventArgs e)//update
        {
            update();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {


            if (!comboBox1.Text.Equals("sselect Training"))
            {

                DialogResult result = MessageBox.Show("Are you ready to delete  " + comboBox1.Text + "  ?", "Qusetion:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    try
                    {
                        string query = "delete from  [sch1].[project] where p_id=" + comboBox1.SelectedValue;

                        cmd = new SqlCommand(query, conn);
                        conn.Open();
                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            MessageBox.Show("this project deleted successfuly");
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        void load1()
        {
            try
            {


                string query = "select  distinct year(stra_date) as p_year from [sch1].[project]";

                data = new DataTable();
                adapt = new SqlDataAdapter(query, conn);
                conn.Open();
                adapt.Fill(data);

                comboBox2.DataSource = data;
                comboBox2.DisplayMember = "p_year";//column name that exist in datatable
                comboBox2.ValueMember = "p_year";


            }


            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
            finally { conn.Close(); }
        }

        void load2()//month
        {
            try
            {


                string query = "select  distinct month(stra_date) as p_month from [sch1].[project]";

                data = new DataTable();
                adapt = new SqlDataAdapter(query, conn);
                conn.Open();
                adapt.Fill(data);

                comboBox2.DataSource = data;
                comboBox2.DisplayMember = "p_month";//column name that exist in datatable
                comboBox2.ValueMember = "p_month";


            }


            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
            finally { conn.Close(); }
        }

        void load3()
        {
            
            
                try
                {


                    string query = "select   what_phone as Lphone from [sch1].[BC_Memebers] inner join  [sch1].[project] on m_id=leader_id";

                    data = new DataTable();
                    adapt = new SqlDataAdapter(query, conn);
                    conn.Open();
                    adapt.Fill(data);

                    comboBox2.DataSource = data;
                    comboBox2.DisplayMember = "Lphone";//column name that exist in datatable
                    comboBox2.ValueMember = "Lphone";


                }


                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
                finally { conn.Close(); }
            }

        

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        void display1()//month
        {

            try
            {
                string query = "select pro_name ,pro_description, CONCAT( [m_finame],' ',[m_sname],' ' ,[m_tname]) as  leaderName, what_phone,stra_date,pro_period_bydays from sch1.Project inner join [sch1].[BC_Memebers]  on leader_id=m_id  and month(stra_date)=" + comboBox2.SelectedValue;
                data = new DataTable();
                adapt = new SqlDataAdapter(query, conn);
                conn.Open();
                adapt.Fill(data);
                dataGridView1.DataSource = data;
                // dataGridView1.DataMember = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error,Try again");
            }
            finally { conn.Close(); }
        }

        void display2()//leader
        {

            try
            {
                string query = "select pro_name ,pro_description, CONCAT( [m_finame],' ',[m_sname],' ' ,[m_tname]) as  leaderName, what_phone,stra_date,pro_period_bydays from sch1.Project inner join [sch1].[BC_Memebers]  on leader_id=m_id where what_phone='"+ comboBox2.SelectedValue + "'" ;
                data = new DataTable();
                adapt = new SqlDataAdapter(query, conn);
                conn.Open();
                adapt.Fill(data);
                dataGridView1.DataSource = data;
                // dataGridView1.DataMember = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error,Try again");
            }
            finally { conn.Close(); }
        }
        void display3()//year
        {

            try
            {
                string query = "select pro_name ,pro_description, CONCAT( [m_finame],' ',[m_sname],' ' ,[m_tname]) as  leaderName, what_phone,stra_date,pro_period_bydays from sch1.Project inner join [sch1].[BC_Memebers]  on leader_id=m_id  and year(stra_date)= " + comboBox2.SelectedValue;
                data = new DataTable();
                adapt = new SqlDataAdapter(query, conn);
                conn.Open();
                adapt.Fill(data);
                dataGridView1.DataSource = data;
                // dataGridView1.DataMember = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error,Try again");
            }
            finally { conn.Close(); }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                load3();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            {
                load1();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton3.Checked)
            { load2(); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(radioButton3.Checked)
            {
                display1();
            }else if(radioButton1.Checked)
            {
                display2();
            }
            else if(radioButton2.Checked)
            {
                display3();
            }
            button6.Enabled= false; 
        }

        void clear1()
        {
            dataGridView1.DataSource = null;
            button6.Enabled = true;
            comboBox2.DataSource = null;
            comboBox2.Items.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            clear1();
        }
    }
}
