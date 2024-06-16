using System;
using System.Web;

namespace WebForms
{
    public partial class SubmitFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack || !HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Context.ApplicationInstance.CompleteRequest();
                Response.Redirect("Default.aspx");
            }
        }

        protected void UploadFile(object sender, EventArgs e)
        {
            //if (FileUploadControl.HasFile)
            //{
            //    string fileName = FileUploadControl.FileName;
            //    string path = Server.MapPath("~/Files/") + fileName;
            //    FileUploadControl.SaveAs(path);
            //    Response.Redirect("Default.aspx");
            //}
        }
    }
}