﻿using System;
using System.Web.Security;
using WebForms.Data;
using WebForms.Services;

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
            string password = txtPassword.Text;

            UserService userRepository = new UserService();
            User User = userRepository.Login(username, password);
            if (User != null)
            {
                lblMessage.Text = "Login successful!";
                Session["Username"] = txtUsername.Text;
                Session["UserId"] = User.UserID;
                FormsAuthentication.SetAuthCookie(txtUsername.Text, false);
                Response.BufferOutput = true;
                Context.ApplicationInstance.CompleteRequest();
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMessage.Text = "Login failed!";
            }
        }

        /*
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string username = txtUsername.Text;
                string password = txtPassword.Text; // Assuming you already have secure password hashing logic

                string selectQuery = "SELECT UserId, Username, PasswordHash, Salt FROM Users " +
                                    "WHERE Username = @username";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    // Compare hashed password instead of plain text (replace with your logic)
                    string hashedPassword = password;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String dbPW = reader["PasswordHash"].ToString();
                        var salt = reader["Salt"];
                        var userHashedSalted = hashPassword($"{password}{salt}");

                        if (reader["Username"].ToString() == txtUsername.Text && userHashedSalted == dbPW)
                        {
                            lblMessage.Text = "Login successful!";
                            Session["Username"] = txtUsername.Text;
                            Session["UserId"] = reader["UserId"];
                            FormsAuthentication.SetAuthCookie(txtUsername.Text, false);
                            Response.BufferOutput = true;
                            reader.Close();
                            connection.Close();
                            Context.ApplicationInstance.CompleteRequest();
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            lblMessage.Text = "Login failed!";
                        }
                    }
                    lblMessage.Text = "Login failed!";
                    reader.Close();
                }
                connection.Close();
            }
        }
        
        */
    }
}