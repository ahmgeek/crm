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
    private int rankUser2 = 0;
    private int currentPageUser = 0;
    private int currentPageUser2 = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
                BindGrid();
                BindUnservedGrid();

        }

    }





    void BindGrid()
    {
        try
        {
            List<WaitingList> ds = WaitingListBLL.GetServedList();
            grdWaitList.DataSource = ds;
            grdWaitList.DataBind();
            
        }
        catch (Exception ex)
        {

            grdWaitList.EmptyDataText = ex.Message;
            grdWaitList.DataBind();
        }


    }

    void BindUnservedGrid()
    {
        try
        {
            List<WaitingList> ds = WaitingListBLL.GetUnServedList();
            grdUnServed.DataSource = ds;
            grdUnServed.DataBind();

        }
        catch (Exception ex)
        {

            grdUnServed.EmptyDataText = ex.Message;
            grdUnServed.DataBind();
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
        BindGrid();
    }
    protected void grdWaitList_PreRender(object sender, EventArgs e)
    {

        foreach (GridViewRow item in grdWaitList.Rows)
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
        string date = lblTime.Text.Substring(0, 10);
        string time = lblTime.Text.Substring(10, 11);



        Label lblDate = (Label)item.FindControl("lblDate");
        Label lblNewTime = (Label)item.FindControl("lblNewTime");

        lblDate.Text = date;
        lblDate.CssClass = "label label-info";


        lblNewTime.Text = time;
        lblNewTime.CssClass = "label";
        }
    }





    protected void grdUnServed_PreRender(object sender, EventArgs e)
    {
        foreach (GridViewRow item in grdUnServed.Rows)
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
            string date = lblTime.Text.Substring(0, 10);
            string time = lblTime.Text.Substring(10, 11);



            Label lblDate = (Label)item.FindControl("lblDate");
            Label lblNewTime = (Label)item.FindControl("lblNewTime");

            lblDate.Text = date;
            lblDate.CssClass = "label label-info";


            lblNewTime.Text = time;
            lblNewTime.CssClass = "label";
        }

    }
    protected void grdUnServed_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        currentPageUser2 = e.NewPageIndex;
        grdUnServed.PageIndex = e.NewPageIndex;
        BindUnservedGrid();
    }
    protected void grdUnServed_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblRank = (Label)e.Row.FindControl("lblRank");
        // On page reload, rank is reset to 0
        if (rankUser2 == 0)
        {
            // Only run this on subsequent pages
            if (currentPageUser2 > 0)
            {
                // Set rank to current index of page * the number of records to display on GridView page
                rankUser2 = currentPageUser2 * grdUnServed.PageSize;
            }
        }
        // Make sure we actually found our label
        if (lblRank != null)
        {
            // Increment rank by 1
            rankUser2 += 1;
            // Set rank label to our new rank value
            lblRank.Text = rankUser2.ToString();

        }
    }
}


