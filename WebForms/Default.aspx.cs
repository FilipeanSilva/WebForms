using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Data;
using WebForms.Services;

namespace WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.User.Identity.IsAuthenticated)
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
            int userId = GetCurrentUserId();

            if (userId != 0)
            {
                GridView1.AutoGenerateColumns = false;

                FileServices filesService = new FileServices();
                List<File> filesList = filesService.GetAllFiles(userId);

                GridView1.DataSource = filesList;
                GridView1.DataBind();
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

        protected void DownloadFile(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                int fileId = Convert.ToInt32(GridView1.DataKeys[rowIndex]["Id"]);
                FileServices filesService = new FileServices();
                File file = filesService.GetFileById(fileId);

                string path = file.Path;
                string fileName = path.Substring(path.LastIndexOf("\\") + 1);

                string contentType = "application/octet-stream";
                Response.Clear();
                Response.ContentType = contentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.TransmitFile(path);
                Response.End();
            }
        }
    }
}