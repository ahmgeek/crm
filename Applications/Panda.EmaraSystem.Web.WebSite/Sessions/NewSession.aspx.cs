using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;
using Notification.Helper;

public partial class Sessions_NewSession : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void grdUser_PreRender(object sender, EventArgs e)
    {

        foreach (GridViewRow item in grdUser.Rows)
        {

            Label lblFullName = (Label)item.FindControl("lblFullName");
            lblFullName.CssClass = "label label-info";

            Label lblAccountNumber = (Label)item.FindControl("lblAccountNumber");
            lblAccountNumber.CssClass = "label label-important";

            Label lblcity = (Label)item.FindControl("lblcity");
            lblcity.CssClass = "label label-inverse";


            Label lblMob = (Label)item.FindControl("lblMob");
            lblMob.CssClass = "label label-success";
        }
    }


    private void BindGrid()
    {
        List<Client> client = ClientBLL.GetList();
            //TODO Bind with client data
    }


}