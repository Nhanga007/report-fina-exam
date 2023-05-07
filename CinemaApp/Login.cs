using System.Data.SqlClient;
namespace CinemaApp
{
    public partial class Login : Form
    {
        public object Password { get; private set; }

        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register form = new Register();   
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = @"Server=DESKTOP-HQR4O6U\SQLEXPRESS; Database=TestDB; Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "SELECT Name, Password from UserLogin where Name= @username and Password= @password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text); 

            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter your Usersname");
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("Please enter your Password");
            }
            else
            {
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.HasRows)
                    {
                        Home f = new Home("");
                        this.Hide();
                        f.ShowDialog();
                        this.Close();
                    }
                }
                catch(Exception a)
                {
                    MessageBox.Show("Login fail");
                    MessageBox.Show(a.Message);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}