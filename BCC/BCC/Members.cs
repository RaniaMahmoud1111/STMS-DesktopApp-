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
using System.IO;

namespace BCC
{
    public partial class Members : Form
    {
        public Members()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand cmd;
        SqlCommand cm;
        SqlDataAdapter adapt;
        SqlDataReader dr;
        DataSet ds;
        DataTable dt;
        byte[] phData;
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
            
            TextBox textBox5=(TextBox)sender;
            textBox5.Text = string.Empty;

            textBox5.TextChanged -= textBox5_TextChanged;
          
        }

        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
          //  textBox9.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)//
        {
            //textBox9.Clear();
        }

        private void tabPage1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_MouseClick_1(object sender, MouseEventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            //textBox5.Clear();
        }

        private void Members_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("server=DESKTOP-95A74GO; database=BC_Comunity3;"
               + "Integrated Security=true;");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("")
                || comboBox1.SelectedIndex == -1 || textBox4.Text.Equals("")
                || textBox5.Text.Equals("") || textBox6.Text.Equals("") || textBox7.Text.Equals("")
                || textBox8.Text.Equals("") ||
                (radioButton1.Checked == false &&  radioButton2.Checked == false) ||
                (radioButton3.Checked == false &&  radioButton4.Checked == false) ||

                (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked== false
            && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false)
            
             )
                {
                    MessageBox.Show("Enter complete data");
                }

                else
                {
                    string name = textBox1.Text;
                    string[] ar = name.Split(' ');
                    string a, b, c, d;
                    a = ar[0];
                    b = ar[1];
                    c = ar[2];
                    d = ar[3];


                    string university = textBox2.Text;
                    string faculty = textBox3.Text;
                    int level = int.Parse(comboBox1.Text);

                    string ssn = textBox4.Text;

                    string address = textBox5.Text;
                    string[] ar2 = address.Split(' ');
                    string x, y, z;
                    x = ar2[0]; 
                    y = ar2[1];
                    z = ar2[2];


                   
                   string phone=textBox6.Text;
                    string email=textBox7.Text;

                    Boolean ID;
                    if (radioButton1.Checked == true)
                        ID = true;
                    else
                        ID = false;

                    Boolean T_shirt;
                    if (radioButton3.Checked == true)
                        T_shirt = true;
                    else
                        T_shirt = false;

                    string skills=textBox8.Text;


                    string s = "";

                    if (checkBox1.Checked)
                    {
                        s += checkBox1.Text + ",";
                    }

                    if (checkBox2.Checked)
                    {
                        s += checkBox2.Text + ",";
                    }

                    if (checkBox3.Checked)
                    {
                        s += checkBox3.Text + ",";
                    }

                    if (checkBox4.Checked)
                    {
                        s += checkBox4.Text + ",";
                    }

                    if (checkBox5.Checked)
                    {
                        s += checkBox5.Text + ",";
                    }

                    if (checkBox6.Checked)
                    {
                        s += checkBox6.Text + ",";
                    }

                    if (checkBox7.Checked)
                    {
                        s += checkBox7.Text + ",";
                    }

                    if (checkBox8.Checked)
                    {
                        s += checkBox8.Text + ",";
                    }

                    if (checkBox9.Checked)
                    {
                        s += checkBox9.Text + ",";
                    }

                    if (checkBox10.Checked)
                    {
                        s += checkBox10.Text ;
                    }
                   // MessageBox.Show(phData + "");


                    string q1 = "insert into sch1.BC_Memebers( [m_finame],[m_sname],[m_tname],[m_foname],[faculty] ,[f_level] ,[ssn],[city_name],[center_name],[street_name],[university],[what_phone],[email],photo,[HaveID],[HaveA_T_Shirt],[skills_experience],teamName) values('" + a + "' ,'" + b + "','" + c + "','" + d + "','" + textBox3.Text + "'," + comboBox1.Text + ",'" + textBox4.Text + "', '" + x + "','" + y + "','" + z + "','" + textBox2.Text + "','" + textBox7.Text + "','" + textBox6.Text + "',"+ @phData+",'"+ID+"','"+T_shirt+"','" + textBox8.Text + "','"+s+"')";

                    cm = new SqlCommand(q1, conn);
                    conn.Open();
                    int res=cm.ExecuteNonQuery();
                    conn.Close();


                    if(res>0)
                    {
                        MessageBox.Show(textBox1.Text + " added successfuly");
                    }
                    else
                    {
                        MessageBox.Show("Error, try again");
                    }

                }

            }
            catch(Exception ex) {
                MessageBox.Show("Error");
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

       
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            string imgloc = "";

            try
            {
                OpenFileDialog  dialog= new OpenFileDialog();   
               dialog.Filter="jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All files(*.*)|*.*";

                if(dialog.ShowDialog() == DialogResult.OK)
                {
                   imgloc = dialog.FileName;
                     image1.ImageLocation=imgloc;
                     phData= File.ReadAllBytes(imgloc);
                    
                    //mage1.Image=new Bitmap(dialog.FileName);

                }


            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                   
            }

        }
    }
}
