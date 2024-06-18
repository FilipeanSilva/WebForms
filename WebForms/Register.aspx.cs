using System;
using System.Web.Security;
using WebForms.Data;
using WebForms.Services;

namespace WebForms
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            UserService userRepository = new UserService();

            User newUser = new User
            {
                Username = username,
                PasswordHash = password
            };

            User User = userRepository.Register(newUser);
            if (User != null)
            {
                Session["Username"] = txtUsername.Text;
                Session["UserId"] = User.UserID;
                FormsAuthentication.SetAuthCookie(txtUsername.Text, false);
                Response.BufferOutput = true;
                Context.ApplicationInstance.CompleteRequest();
                Response.Redirect("Login.aspx");
            }
            else
            {
                LabelStatus.Text = "Login failed!";
                LabelStatus.Visible = true;
            }
        }
    }
}
