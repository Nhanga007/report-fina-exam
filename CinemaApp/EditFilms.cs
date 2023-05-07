using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
namespace CinemaApp
{
    public partial class EditFilms : Form
    {
        public EditFilms()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connection = @"Server=DESKTOP-HQR4O6U\SQLEXPRESS; Database=TestDB; Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Film Name!");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter Director Name!");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Please enter year!");
            }
            else
            {
                try
                {
                    string query = "Insert into Film(FilmName, Director, Year) Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    con.Open();
                    da.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Add successfull!");
                    LoadDataGripView();
                    ClearData();
                }
                catch(Exception a)
                {
                    MessageBox.Show("Error occured...");
                }
            }
        }
        //Clear data after submit
        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy giá trị của tên từ cột "Tên phim" trong dòng đang chọn
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["FilmName"].Value.ToString();

            }

        }
        private void LoadDataGripView()
        {
            
            string connection = @"Server=DESKTOP-HQR4O6U\SQLEXPRESS; Database=TestDB; Integrated Security=True";
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Film", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void EditFilms_Load(object sender, EventArgs e)
        {
            string connection = @"Server=DESKTOP-HQR4O6U\SQLEXPRESS; Database=TestDB; Integrated Security=True";
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Film", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
       
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please provide Name");
                return;
            }
            try
            {

                
                    string connectionString = @"Server=DESKTOP-HQR4O6U\SQLEXPRESS; Database=TestDB; Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("DELETE from Film where FilmName=@FilmName", connection);
                        command.Parameters.AddWithValue("@FilmName", textBox1.Text);
                        int rowsAffected = command.ExecuteNonQuery();
                        LoadDataGripView();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Changed Successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Changed Failed!");
                        }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home("");
            hm.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

