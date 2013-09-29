using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;
using Notification.Helper;

public partial class Clients_Clients : System.Web.UI.Page
{
    private int rankUser = 0;
    private int currentPageUser = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.ToString() != string.Empty)
        {
            string message = Request.QueryString["message"];
            this.ShowHelperMessage("Info", message, HelperNotify.NotificationType.info);
        }
       
        if (!IsPostBack)
        {
            BindGrid();

        }
        
    }



    protected void grdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblRank = (Label)e.Row.FindControl("lblRank");
        // On page reload, rank is reset to 0
        if (rankUser == 0)
        {
            // Only run this on subsequent pages
            if (currentPageUser > 0)
            {
                // Set rank to current index of page * the number of records to display on GridView page
                rankUser = currentPageUser * grdUsers.PageSize;
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
    protected void grdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        currentPageUser = e.NewPageIndex;
        grdUsers.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void grdUsers_PreRender(object sender, EventArgs e)
    {

        foreach (GridViewRow item in grdUsers.Rows)
        {

            Label lblRank = (Label)item.FindControl("lblRank");

            for (int i = 0; i < rankUser; i++)
            {
                lblRank.CssClass = "badge";

            }


            Label lblFullName = (Label)item.FindControl("lblFullName");
            lblFullName.CssClass = "label label-inverse";

            Label lblRegister = (Label)item.FindControl("lblRegister");
            lblRegister.CssClass = "label label-info";

            Label lblCity = (Label)item.FindControl("lblCity");
            lblCity.CssClass = "label label-info";


            Label lblMob = (Label)item.FindControl("lblMob");
            lblMob.CssClass = "label label-info";

            Label lblRelatives = (Label)item.FindControl("lblRelation");
            if (lblRelatives.Text == "yes")
            {
                lblRelatives.CssClass = "label label-success";

            }
            else
            {
                lblRelatives.CssClass = "label label-important";
            }


        }
    }
    protected void grdUsers_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditCommand")
        {
            Response.Redirect("/Clients/ClientsDetail.aspx?id=" + e.CommandArgument);
        }
    }

    void BindGrid()
    {
        try
        {
            List<Client> ds = ClientBLL.GetList();
            grdUsers.DataSource = ds;  
            grdUsers.DataBind();

        }
        catch (Exception ex)
        {

            grdUsers.EmptyDataText = ex.Message;
            grdUsers.DataBind();
        }

    }



    //protected void btnDeleteUser_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        CheckBox chkUSer;
    //        Literal litId;
    //        foreach (GridViewRow row in grdUsers.Rows)
    //        {
    //            chkUSer = (CheckBox)row.Cells[1].FindControl("chkUser");
    //            if (chkUSer.Checked)
    //            {
    //                litId = (Literal)row.Cells[6].FindControl("litClientId");
    //                int id = Convert.ToInt32(litId.Text);
    //                //Client client = ClientBLL.GetItem(id);
    //               // ClientBLL.Delete(client);
    //            }
    //        }
    //        BindGrid();
    //        string message = "The client has been removed";
    //        this.ShowHelperMessage("Succeeded", message, HelperNotify.NotificationType.success);

    //    }
    //    catch (Exception ex)
    //    {
    //        string message = ex.Message;
    //        this.ShowHelperMessage("Succeeded", message, HelperNotify.NotificationType.success);
    //    }
               
    //}
   
}