using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;




public partial class WaitingList_WaitingList : System.Web.UI.Page
{
    private int rankUser = 0;
    private int currentPageUser = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                grdWaitList.EmptyDataText = ex.Message;
                grdWaitList.DataBind();
            }
        }

    }





    void BindGrid()
    {
            List<WaitingList> ds = WaitingListBLL.GetList();
            grdWaitList.DataSource = ds;
            grdWaitList.DataBind();

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
                rankUser = currentPageUser * grdWaitList.PageSize;
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
        grdWaitList.PageIndex = e.NewPageIndex;
    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkall = (CheckBox)sender;
        //btnDeleteUser.Enabled = chkallUser.Checked;
        CheckBox chk;
        foreach (GridViewRow row in grdWaitList.Rows)
        {
            chk = (CheckBox)row.Cells[0].FindControl("chk");
            chk.Checked = chkall.Checked;
        }
    }
    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk;
        CheckBox chkAll;
        foreach (GridViewRow row in grdWaitList.Rows)
        {
            chk = (CheckBox)row.Cells[0].FindControl("chk");
            chkAll = (CheckBox) grdWaitList.HeaderRow.Cells[0].FindControl("chkAll");
            if (chk.Checked)
            {
                chkAll.Checked = false;
                //btnDeleteUser.Enabled = true;
                return;
            }
        }
    }
    protected void grdWaitList_Load(object sender, EventArgs e)
    {
        #region Status Colored
        Label lblStatus = (Label)grdWaitList.Rows[0].FindControl("lblStatus");

        if (lblStatus.Text == "UnServed")
        {
            lblStatus.CssClass = "label label-warning";
        }
        if (lblStatus.Text == "Served")
        {
            lblStatus.CssClass = "label label-success";
        }
        #endregion

        #region Rank Colored
        Label lblRank = (Label)grdWaitList.Rows[0].FindControl("lblRank");

        for (int i = 0; i < rankUser; i++)
        {
            lblRank.CssClass = "badge badge-info";

        }

        #endregion

        #region Name Colored
        Label lblFullName = (Label)grdWaitList.Rows[0].FindControl("lblFullName");
        lblFullName.CssClass = "label label-info";
        #endregion

        #region Time Colored
        Label lblTime = (Label)grdWaitList.Rows[0].FindControl("lblTime");
        string date = lblTime.Text.Substring(0, 10);
        string time = lblTime.Text.Substring(10, 11);



        Label lblDate = (Label)grdWaitList.Rows[0].FindControl("lblDate");
        Label lblNewTime = (Label)grdWaitList.Rows[0].FindControl("lblNewTime");

        lblDate.Text = date;
        lblDate.CssClass = "label label-info";


        lblNewTime.Text = time;
        lblNewTime.CssClass = "label";


        
       
        #endregion

        //Stoped Here
    }
}