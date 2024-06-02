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

namespace BCC
{
    public partial class Training_Events : Form
    {
        public Training_Events()
        {
            InitializeComponent();
        }
        SqlConnection conn ;
        SqlCommand cmd ;
        SqlDataAdapter adapt ;
        SqlDataReader reader ;
        DataSet ds ;
        DataTable data;
        private void Training_Events_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("server=DESKTOP-95A74GO;database=BC_Comunity3;"
                   + "Integrated Security=true");
        }


        void loadUpdate()
        {

            data = new DataTable();
            adapt = new SqlDataAdapter("select T_id ,t_name ,CONCAT( day(star_date) , '/',month(star_date),'/',year(star_date),'  cannot updated')  TrainingDate, t_period_bydays , place , what_phone from [sch1].[Training] inner join [sch1].[BC_Memebers] on instractor_id=[BC_Memebers].m_id", conn);
            conn.Open();
            adapt.Fill(data);
            conn.Close();

          DataRow row=data.NewRow();
            row[0] = 0;
            row[1] = "select Training";
            data.Rows.InsertAt(row, 0);
            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "t_name";
            comboBox1.ValueMember = "T_id";

        }

        void clear_update()
        {
            textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = "";
            comboBox1.SelectedValue = 0;//means that combobox.displaymemebers="select training"

        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("")
                || textBox3.Text.Equals("") || textBox4.Text.Equals(""))
                MessageBox.Show("enter complete data");
            else
            {
                try
                {
                    string name = textBox1.Text;
                    int period = int.Parse(textBox2.Text);
                    string place = textBox3.Text;
                    string phone =textBox4.Text;

                    string query = "insert into [BC_Comunity3].[sch1].[Training]([t_name],[t_period_bydays],[place],[instractor_id]) values('"+name+"',"+period+",'"+place+"',( select m_id from [sch1].[BC_Memebers]where  what_phone='"+phone+"'))";
                    cmd = new SqlCommand(query, conn);

                    conn.Open();
                    int res=cmd.ExecuteNonQuery();

                    if(res>0)
                    {
                        MessageBox.Show(name + " Training added successfuly");
                    }else
                    {
                        MessageBox.Show("Error,Try Again");
                    }




                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Error");
                }

                finally 
                { 
                    conn.Close();
                }
            }

        




        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";



        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try {
                int peroid = int.Parse(textBox7.Text);
                string place=textBox6.Text;
                string phone=textBox5.Text;

               
              string query = "update [sch1].[Training] set t_period_bydays= "+peroid+",place='"+place+"',instractor_id=(select m_id from [sch1].[BC_Memebers] where what_phone='"+phone+"' )  where T_id="+comboBox1.SelectedValue;

                cmd = new SqlCommand(query, conn);
                conn.Open();
                int res=cmd.ExecuteNonQuery();
                if(res>0)
                {
                    MessageBox.Show("data updated successfuly");
                }
                else
                {
                    MessageBox.Show("Error, try again");
                }

                clear_update();
                //loadUpdate();

            }
            catch (Exception ex) { 
            
            MessageBox.Show("Error");
            }finally { conn.Close(); }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text.Equals("select Training"))
            {

            }
            else//id[0] name[1]  date[2]  peroid[3] place[4] instractorWphone[5]
            {
                foreach(DataRow y in data.Rows)
                {
                    if (y[0].Equals(comboBox1.SelectedValue))
                    {
                        textBox8.Text = y[2].ToString();
                        textBox7.Text = y[3].ToString();
                        textBox6.Text= y[4].ToString();
                        textBox5.Text = y[5].ToString();//phone


                    }

                }

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //update_func

            loadUpdate();



        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear_update();
        }

        private void button6_Click(object sender, EventArgs e)
        {




        }

       
        
        private void button7_Click(object sender, EventArgs e)
        {

            if (!comboBox1.Text.Equals("sselect Training"))
            {

                DialogResult result = MessageBox.Show("Are you ready to delete  " + comboBox1.Text + "  ?", "Qusetion:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    try
                    {
                        string query = "delete from [sch1].[Training] where T_id=" + comboBox1.SelectedValue;

                        cmd = new SqlCommand(query, conn);
                        conn.Open();
                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            MessageBox.Show("this training deleted successfuly");
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
        void load1()//years
        {
            try
            {
         

                string query = "select  distinct year(star_date) as T_year from [sch1].[Training]";
                
                data = new DataTable();
                adapt = new SqlDataAdapter(query, conn);
                conn.Open();
                adapt.Fill(data);
            
               comboBox3.DataSource = data; 
               comboBox3.DisplayMember = "T_year";//column name that exist in datatable
               comboBox3.ValueMember = "T_year";
      

            }


            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
            finally { conn.Close(); }   



        }
        void load2()//months
        {
            try
            {
                string query = "select  distinct month(star_date)  as T_month from [sch1].[Training]";

                data = new DataTable();
                adapt = new SqlDataAdapter(query, conn);
                conn.Open();
                adapt.Fill(data);
                comboBox3.DataSource = data;
                comboBox3.DisplayMember = "T_month";
                comboBox3.ValueMember = "T_month";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error,try again");
            }
            finally { conn.Close(); }

        }

        void load3()//place
        {
            try
            {
                string query = "select  distinct place  as T_place from [sch1].[Training]";
                data = new DataTable();
                adapt = new SqlDataAdapter(query, conn);
                conn.Open();
                adapt.Fill(data);
                comboBox3.DataSource = data;
                comboBox3.DisplayMember = "T_place";
                comboBox3.ValueMember = "T_place";


            } catch (Exception ex)
            {
                MessageBox.Show("Error, try again");
            }
            finally { conn.Close(); }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            //
            //by Years
            // by Months
            //by Place

            if (comboBox2.Text.Equals("by Years"))
            {
                label11.Text = "select a year";
                load1();
            }
            else if(comboBox2.Text.Equals("by Months"))
            {
                label11.Text = "select a month";
                load2();
            }
            else
            {
                label11.Text = "select place";
                load3();

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
          //  if(comboBox2.se)
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        void display1()//years
        {
            try
            {
                string query = "select t_name as TrainingName,star_date as StartDateOfTraining ,t_period_bydays,place as T_place  , m_finame+' '+[m_sname]+' ' + [m_tname]+' ' as InstractorName, what_phone as InstractorW_Phone from [sch1].[Training] inner join [sch1].[BC_Memebers]  on instractor_id=[BC_Memebers].m_id  and year(star_date)=" + comboBox3.SelectedValue;
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
        void display2()//months
        {
            try
            {
                string query = "select t_name as TrainingName,star_date as StartDateOfTraining ,t_period_bydays,place as T_place  , m_finame+' '+[m_sname]+' ' + [m_tname]+' ' as InstractorName, what_phone as InstractorW_Phone from [sch1].[Training] inner join [sch1].[BC_Memebers]  on instractor_id=[BC_Memebers].m_id  and month(star_date)=" + comboBox3.SelectedValue;
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
        void display3()//place
        {
            try
            {
                string query = "select t_name as TrainingName,star_date as StartDateOfTraining ,t_period_bydays,place as T_place  , m_finame+' '+[m_sname]+' ' + [m_tname]+' ' as InstractorName, what_phone as InstractorW_Phone from [sch1].[Training] inner join [sch1].[BC_Memebers]  on instractor_id=[BC_Memebers].m_id  and place='" + comboBox3.SelectedValue+"'";
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
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (comboBox2.Text.Equals("by Years"))
            {                
                display1();
            }
            else if (comboBox2.Text.Equals("by Months"))
            {               
                display2();
            }
            else
            {               
                display3();
            }
            button6.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button6.Enabled = true;
            dataGridView1.DataSource = null;
            comboBox2.Text = "";
            comboBox3.DataSource = null;

            label11.Text = "Select";
        }
    }
}
