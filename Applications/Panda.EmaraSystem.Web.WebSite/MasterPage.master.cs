using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Panda.EmaraSystem.BLL;
using Notification.Helper;

public partial class MasterPage : System.Web.UI.MasterPage
{
    UsersBLL u = new UsersBLL();
    protected void Page_Load(object sender, EventArgs e)
    {        UsersBLL u = new UsersBLL();

        if (Request.IsAuthenticated)
        {
            litName.Text = u.GetUser().UserName;
        }
        else
        {
            Response.Redirect("/_Login.aspx?ReturnUrl="+Request.Url.PathAndQuery);
        }
    }


    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("/_Login.aspx");
    }
    protected void btnSetting_Click(object sender, EventArgs e)
    {
        Response.Redirect("/SystemSettings/Stuff.aspx?name=" + u.GetUser().UserName);
    }
}
