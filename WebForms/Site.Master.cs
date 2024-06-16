using System;
using System.Web;
using System.Web.UI;

namespace WebForms
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                loginLinkPlaceHolder.Visible = false;
                RegisterPlaceHolder.Visible = false;
                LogOutPlaceHolder.Visible = true;
            }
            else
            {
                LogOutPlaceHolder.Visible = false;
            }
        }
    }
}