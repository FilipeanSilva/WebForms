using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using WebForms.Models.Users;

namespace WebForms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text; // Assuming you already have secure password hashing logic

            User user = new User();
            user.Name = username;
            user.Password = password;

            SQLUserRepository userRepository = new SQLUserRepository(new AppDbContext());
        }

        //protected void btnLogin_Click(object sender, EventArgs e)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string username = txtUsername.Text;
        //        string password = txtPassword.Text; // Assuming you already have secure password hashing logic

        //        string selectQuery = "SELECT UserId, Username, PasswordHash, Salt FROM Users " +
        //                            "WHERE Username = @username";

        //        using (SqlCommand command = new SqlCommand(selectQuery, connection))
        //        {
        //            command.Parameters.AddWithValue("@username", username);

        //            // Compare hashed password instead of plain text (replace with your logic)
        //            string hashedPassword = password;
        //            var reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                String dbPW = reader["PasswordHash"].ToString();
        //                var salt = reader["Salt"];
        //                var userHashedSalted = hashPassword($"{password}{salt}");

        //                if (reader["Username"].ToString() == txtUsername.Text && userHashedSalted == dbPW)
        //                {
        //                    lblMessage.Text = "Login successful!";
        //                    Session["Username"] = txtUsername.Text;
        //                    Session["UserId"] = reader["UserId"];
        //                    FormsAuthentication.SetAuthCookie(txtUsername.Text, false);
        //                    Response.BufferOutput = true;
        //                    reader.Close();
        //                    connection.Close();
        //                    Context.ApplicationInstance.CompleteRequest();
        //                    Response.Redirect("Default.aspx");
        //                }
        //                else
        //                {
        //                    lblMessage.Text = "Login failed!";
        //                }
        //            }
        //            lblMessage.Text = "Login failed!";
        //            reader.Close();
        //        }
        //        connection.Close();
        //    }
        //}
        private string hashPassword(string password)
        {
            var sha256 = System.Security.Cryptography.SHA256.Create();
            var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            var hashedPassword = sha256.ComputeHash(passwordBytes);

            return Convert.ToBase64String(hashedPassword);
        }
    }
}