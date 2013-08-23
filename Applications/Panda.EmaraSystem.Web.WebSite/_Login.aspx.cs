using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Panda.EmaraSystem.BLL;
using Notification.Helper;

public partial class _Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.ToString() == string.Empty)
        {
            
        }
        else
        {
            if (Request.QueryString["Shit"] == "Error")
            {
                this.ShowHelperMessage("Warning", "Wrong Crednintal", HelperNotify.NotificationType.error);
            }
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (UsersBLL.ValidateUser(txtUserName.Text,txtPass.Text))
        {
            FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkSaveMe.Checked);
            if (Request.QueryString.ToString().Contains("ReturnUrl"))
            {
                Response.Redirect(Request.QueryString["ReturnUrl"]);
            }
            Response.Redirect("/Default.aspx?message");
        }
        else
        {
            Response.Redirect("_Login.aspx?Shit=Error");
        }
    }
}