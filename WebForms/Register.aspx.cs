using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WebForms
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string username = txtUsername.Text;
                string password = txtPassword.Text;

                Random rand = new Random();
                int salt = rand.Next();
                string saltedPw = $"{password}{salt}";
                string hashedPassword = hashPassword(saltedPw);

                string insertQuery = "IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = @username) " +
                                    "BEGIN " +
                                    "INSERT INTO Users (Username, PasswordHash, Salt) " +
                                    "VALUES (@username, @hashedPassword, @Salt); " +
                                    "END";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@hashedPassword", hashedPassword); // Replace with your password hashing logic
                    command.Parameters.AddWithValue("@Salt", salt); // Replace with your password hashing logic

                    command.ExecuteNonQuery();
                }

                connection.Close();

                Context.ApplicationInstance.CompleteRequest();
                Response.Redirect("Login.aspx");
            }
        }

        private string hashPassword(string password)
        {
            var sha256 = System.Security.Cryptography.SHA256.Create();
            var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            var hashedPassword = sha256.ComputeHash(passwordBytes);

            return Convert.ToBase64String(hashedPassword);
        }
    }
}