using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;


public partial class SystemSettings_DataEntry_Sessions : System.Web.UI.Page
{
    private int rankUser = 0;
    private int currentPageUser = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }

    }

    private void BindGrid()
    {
        try
        {
            List<PrescriptionSessionData> ds = PrescriptionSessionDataBLL.GetList();
            grd.DataSource = ds; //clntBLL.GetAllClients();
            grd.DataBind();

        }
        catch (Exception ex)
        {

            grd.EmptyDataText = ex.Message;
            grd.DataBind();
        }

    }

    protected void btnSave_OnClick(object sender, EventArgs e)
    {
        PrescriptionSessionData prscSessionData = new PrescriptionSessionData();
        prscSessionData.SessionDataName = txtData.Text;
        PrescriptionSessionDataBLL.Insert(prscSessionData);
        txtData.Text = "";
        BindGrid();

    }

    protected void btnUpdate_OnClick(object sender, EventArgs e)
    {
        PrescriptionSessionData prscSessionData = new PrescriptionSessionData();
        prscSessionData.SessionDataId = Convert.ToInt16(Application["id"]);
        prscSessionData.SessionDataName = txtData.Text;
        PrescriptionSessionDataBLL.update(prscSessionData);
        txtData.Text = "";
        btnSave.Visible = true;
        btnUpdate.Visible = false;
        BindGrid();
    }

    protected void grd_OnRowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void grd_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        currentPageUser = e.NewPageIndex;
        grd.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void grd_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id;
        if (e.CommandName == "EditCommand")
        {
            id = Convert.ToInt32(e.CommandArgument);
            PrescriptionSessionData prsSessionData = PrescriptionSessionDataBLL.GetItem(id);
            txtData.Text = prsSessionData.SessionDataName;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            Application["id"] = id;
        }
        else if (e.CommandName == "DeleteCommand")
        {
            id = Convert.ToInt32(e.CommandArgument);
            PrescriptionSessionData prsSessionData = PrescriptionSessionDataBLL.GetItem(id);
            PrescriptionSessionDataBLL.Delete(prsSessionData);
            BindGrid();

        }
    }
}