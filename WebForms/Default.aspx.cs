using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                AuthenticatedContent.Visible = true;
                NonAuthenticatedContent.Visible = false;

                string userName = Session["Username"] as string;
                if (!string.IsNullOrEmpty(userName))
                {
                    litUserName.Text = userName;
                }
                ShowFilesTable();
            }
            else
            {
                AuthenticatedContent.Visible = false;
                NonAuthenticatedContent.Visible = true;
            }
        }

        private void ShowFilesTable()
        {
            int userId = GetCurrentUserId(); // Implement this method to retrieve UserId from Session

            if (userId != 0) // Check if UserId is valid
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT Id, Name, Path, Description FROM Files WHERE UserId = @userId";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }

        private int GetCurrentUserId()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // Retrieve UserId from session or wherever it's stored during authentication
                if (Session["UserId"] != null)
                {
                    return Convert.ToInt32(Session["UserId"]);
                }
            }
            return 0; // Return 0 or handle appropriately if UserId is not available
        }
    }
}