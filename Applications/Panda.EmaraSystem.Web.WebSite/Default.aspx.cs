using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Notification.Helper;
using Panda.EmaraSystem.BLL;

public partial class _Default : System.Web.UI.Page
{
    UsersBLL u = new UsersBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            if (Request.QueryString.ToString() != string.Empty)
            {
                string name = u.GetUser().UserName;
                this.ShowHelperMessage("Welcome", "Welcome back " + name, HelperNotify.NotificationType.success);
            }
        }
    }
}