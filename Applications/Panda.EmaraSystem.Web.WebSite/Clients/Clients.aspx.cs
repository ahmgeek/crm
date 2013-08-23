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
            btnDeleteUser.Enabled = false;

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
    }

    void BindGrid()
    {
        try
        {
            List<Client> ds = ClientBLL.GetList();
            grdUsers.DataSource = ds;  //clntBLL.GetAllClients();
            grdUsers.DataBind();

        }
        catch (Exception ex)
        {

            grdUsers.EmptyDataText = ex.Message;
            grdUsers.DataBind();
        }

    }


    protected void chkUser_CheckedChanged(object sender, EventArgs e)
    {
         CheckBox chkUser;
        CheckBox chkAllUser;
        foreach (GridViewRow row in grdUsers.Rows)
        {
            chkUser = (CheckBox)row.Cells[0].FindControl("chkUser");
            chkAllUser = (CheckBox)grdUsers.HeaderRow.Cells[0].FindControl("chkAllUser");
            if (chkUser.Checked)
            {
                chkAllUser.Checked = false;
                //btnDeleteUser.Enabled = true;
                return;
            }
        }
        btnDeleteUser.Enabled = false;
    }
    protected void chkAllUser_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkallUser = (CheckBox)sender;
        //btnDeleteUser.Enabled = chkallUser.Checked;
        CheckBox chkUSer;
        foreach (GridViewRow row in grdUsers.Rows)
        {
            chkUSer = (CheckBox)row.Cells[0].FindControl("chkUser");
            chkUSer.Checked = chkallUser.Checked;
        }
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
            lblFullName.CssClass = "label label-info";

            Label lblAccountNumber = (Label)item.FindControl("lblAccountNumber");
            lblAccountNumber.CssClass = "label label-important";

            Label lblcity = (Label)item.FindControl("lblcity");
            lblcity.CssClass = "label label-inverse";

            Label lblTelephone = (Label)item.FindControl("lblTelephone");
            lblTelephone.CssClass = "label label-success";

            Label lblMob = (Label)item.FindControl("lblMob");
            lblMob.CssClass = "label label-success";

            

        }
    }
}