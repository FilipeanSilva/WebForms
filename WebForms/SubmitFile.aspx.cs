using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace WebForms
{
    public partial class SubmitFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Context.ApplicationInstance.CompleteRequest();
                Response.Redirect("Default.aspx");
            }
        }

        protected void UploadFile(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                    string filePath = Path.Combine(Server.MapPath("~/Files"), FileUpload.FileName); // Construct the full file path

                    if (!Directory.Exists(Server.MapPath("~/Files"))) // Check if directory exists
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Files")); // Create if necessary
                    }

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string fileName = FileUpload.FileName;
                        string description = txtDescription.Text; // Assuming you have a textbox for description (optional)
                        int userId = Convert.ToInt32(Session["UserId"]);
                        string insertQuery = "INSERT INTO Files (Name, Path, Description, UserId) VALUES (@fileName, @filePath, @description, @UserId)";
                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@fileName", fileName);
                            command.Parameters.AddWithValue("@filePath", filePath); // Store the full path
                            command.Parameters.AddWithValue("@description", description); // Optional
                            command.Parameters.AddWithValue("@UserId", userId); // Optional

                            command.ExecuteNonQuery();
                            FileUpload.SaveAs(filePath); // Save the file to the server

                            lblMessage.Text = "File uploaded successfully!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error uploading file: " + ex.Message;
                }
            }
            else
            {
                lblMessage.Text = "Please select a file to upload.";
            }
        }
    }
}