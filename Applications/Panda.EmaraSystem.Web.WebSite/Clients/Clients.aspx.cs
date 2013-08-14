using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;


public partial class Clients_Clients : System.Web.UI.Page
{
    private int rankUser = 0;
    private int currentPageUser = 0;
    ClientBLL clntBLL = new ClientBLL();
    ClientBO clntBO = new ClientBO();
    
    protected void Page_Load(object sender, EventArgs e)
    {
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

        grdUsers.DataSource = clntBLL.GetAllClients();
        grdUsers.DataBind();
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
                btnDeleteUser.Enabled = true;
                return;
            }
        }
        btnDeleteUser.Enabled = false;
    }
    protected void chkAllUser_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkallUser = (CheckBox)sender;
        btnDeleteUser.Enabled = chkallUser.Checked;
        CheckBox chkUSer;
        foreach (GridViewRow row in grdUsers.Rows)
        {
            chkUSer = (CheckBox)row.Cells[0].FindControl("chkUser");
            chkUSer.Checked = chkallUser.Checked;
        }
    }
}