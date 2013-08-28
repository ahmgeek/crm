using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;
using Notification.Helper;

public partial class Prescriptions_Prescriptions : System.Web.UI.Page
{

    private int rankUser = 0;
    private int currentPageUser = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
            if (Session["Message"] != null)
            {
                string message = Session["Message"].ToString();
                this.ShowHelperMessage("Info", message, HelperNotify.NotificationType.success);
                Session.Remove("Message");

            }
        }
    }
   protected void timer_Tick(object sender, EventArgs e)
    {
      //  BindGrid();
    }
   protected void grdClients_RowDataBound(object sender, GridViewRowEventArgs e)
   {

       Label lblRank = (Label)e.Row.FindControl("lblRank");
       // On page reload, rank is reset to 0
       if (rankUser == 0)
       {
           // Only run this on subsequent pages
           if (currentPageUser > 0)
           {
               // Set rank to current index of page * the number of records to display on GridView page
               rankUser = currentPageUser * grdClients.PageSize;
           }
       }
       // Make sure we actually found our label
       if (lblRank != null)
       {
           // Increment rank by 1
           rankUser += 1;
           // Set rank label to our new rank value
           lblRank.Text = rankUser.ToString();
       }

   }
   protected void grdClients_PageIndexChanging(object sender, GridViewPageEventArgs e)
   {
       currentPageUser = e.NewPageIndex;
       grdClients.PageIndex = e.NewPageIndex;
       BindGrid();
   }
   protected void grdClients_PreRender(object sender, EventArgs e)
   {

       foreach (GridViewRow item in grdClients.Rows)
       {
           Label lblStatus = (Label)item.FindControl("lblStatus");

           if (lblStatus.Text == "UnServed")
           {
               lblStatus.CssClass = "label label-warning";
           }
           if (lblStatus.Text == "Served")
           {
               lblStatus.CssClass = "label label-success";
           }


           Label lblRank = (Label)item.FindControl("lblRank");

           for (int i = 0; i < rankUser; i++)
           {
               lblRank.CssClass = "badge badge-info";

           }


           Label lblFullName = (Label)item.FindControl("lblFullName");
           lblFullName.CssClass = "label label-info";

           Label lblTime = (Label)item.FindControl("lblTime");
           lblTime.CssClass = "label label-info";
       }
   }

   private void BindGrid()
   {
       try
       {
           List<Sessions> mySession = SessionBLL.GetUnServed();
           grdClients.DataSource = mySession;
           grdClients.DataBind();

       }
       catch (Exception ex)
       {
           grdClients.EmptyDataText = ex.Message;
           grdClients.DataBind();
           
       }
   }
}