using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CinemaApp
{
    internal class UserModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }



        public UserModel(string email, string firstName, string lastName, string password)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }

        public void InsertUser(SqlConnection connection)
        {
            string query = "INSERT INTO users (email, first_name, last_name, password) " +
                           "VALUES (@Email, @FirstName, @LastName, @Password)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@Password", Password);
                command.ExecuteNonQuery();
            }
        }

        public bool CheckIfUserExists(SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM users WHERE email = @Email";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", Email);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        public bool CheckIfNewPasswordIsSameAsOld(SqlConnection connection)
        {
            string query = "SELECT password FROM users WHERE email = @Email";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", Email);

                string oldPassword = (string)command.ExecuteScalar();

                return Password == oldPassword;
            }
        }

        public bool CheckLogin(SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM users WHERE email = @Email AND password = @Password";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Password", Password);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }
    }
}

