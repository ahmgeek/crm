using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;

public partial class Cases_ManageCases : System.Web.UI.Page
{
    private int rankUser = 0;
    private int currentPageUser = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.ToString()== string.Empty)
            {
                BindGrid();
            }
            else
            {
                switch (Request.QueryString["caseStatus"])
                {
                    case "Confirmed": BindGrid(PrescriptionStatus.confirmed);
                        break;
                    case "OnHold": BindGrid(PrescriptionStatus.onhold);
                        break;
                    case "Revised": BindGrid(PrescriptionStatus.revised);
                        break;
                    default: BindGrid();
                        break;
                }
            }

        }
    }
    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblRank = (Label)e.Row.FindControl("lblRank");
        // On page reload, rank is reset to 0
        if (rankUser == 0)
        {
            // Only run this on subsequent pages
            if (currentPageUser > 0)
            {
                // Set rank to current index of page * the number of records to display on GridView page
                rankUser = currentPageUser * grd.PageSize;
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
    protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        currentPageUser = e.NewPageIndex;
        grd.PageIndex = e.NewPageIndex;

        BindGrid();
    }
    protected void grd_PreRender(object sender, EventArgs e)
    {

        foreach (GridViewRow item in grd.Rows)
        {

            Label lblRank = (Label)item.FindControl("lblRank");

            for (int i = 0; i < rankUser; i++)
            {
                lblRank.CssClass = "badge";

            }


            Label lblFullName = (Label)item.FindControl("lblFullName");
            lblFullName.CssClass = "label label-inverse";

            Label lblCaseNum = (Label)item.FindControl("lblCaseNum");
            lblCaseNum.CssClass = "label label-info";

            Label lblCreation = (Label)item.FindControl("lblCreation");
            lblCreation.CssClass = "label label-info";


            Label lblMob = (Label)item.FindControl("lblMob");
            lblMob.CssClass = "label label-info";

            Label lblGender = (Label)item.FindControl("lblGender");
            lblGender.CssClass = "label label-info";

            Label lblStatus = (Label)item.FindControl("lblStatus");
            if (lblStatus.Text == "confirmed")
            {
                lblStatus.CssClass = "label label-success";

            }
            else if (lblStatus.Text == "onhold")
            {
                lblStatus.CssClass = "label label-important";
            }
            else if (lblStatus.Text == "revised")
            {
                lblStatus.CssClass = "label label-inverse";
            }


        }
    }
    protected void grd_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewCommand")
        {
            Response.Redirect("/Cases/Case.aspx?id=" + e.CommandArgument);
        }
    }

    void BindGrid(PrescriptionStatus state)
    {
        try
        {
            List<ClientCase> ds = ClientCaseBLL.GetListView();
            List<ClientCase> _clientCases = new List<ClientCase>();

            //Filtration
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].PrescriptionStatus == state)
                {
                    _clientCases.Add(ds[i]);
                }

            }
            grd.DataSource = _clientCases;
            grd.DataBind();


        }
        catch (Exception ex)
        {

            grd.EmptyDataText = ex.Message;
            grd.DataBind();
        }

    }
    void BindGrid()
    {
        try
        {
            List<ClientCase> ds = ClientCaseBLL.GetListView();
            List<ClientCase> _clientCases = new List<ClientCase>();

            ////Filtration
            //for (int i = 0; i < ds.Count; i++)
            //{
            //    if (ds[i].PrescriptionStatus == state)
            //    {
            //        _clientCases.Add(ds[i]);
            //    }

            //}
            grd.DataSource = ds;
            grd.DataBind();


        }
        catch (Exception ex)
        {

            grd.EmptyDataText = ex.Message;
            grd.DataBind();
        }

    }


    protected void btnConfirmed_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageCases.aspx?caseStatus=Confirmed");
    }
    protected void btnOnHold_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageCases.aspx?caseStatus=OnHold");
    }
    protected void btnClosed_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageCases.aspx?caseStatus=Revised");

    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageCases.aspx");
    }
}