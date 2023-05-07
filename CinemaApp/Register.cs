using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace CinemaApp
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login(); 
            lg.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = @"Server=DESKTOP-HQR4O6U\SQLEXPRESS; Database=TestDB; Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter your Usersname!");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter your Email!");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Please enter your Phone!");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Please enter your Password!");
            }
            else if (textBox5.Text != textBox4.Text || textBox5.Text == "")
            {
                MessageBox.Show("Please confirm your password again!");
            }
            else
            {
                try
                {
                    string query = "Insert into UserLogin(Name,EmailId,LoginId,Password) Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    con.Open();
                    da.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Congratulation! Your account created!");
                    ClearData();
                }
                catch
                {
                    MessageBox.Show("Error occured...");
                }
                finally
                {
                    con.Close();
                }
            }
            }
        //Clear data after submit
        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.PasswordChar= '*';
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
