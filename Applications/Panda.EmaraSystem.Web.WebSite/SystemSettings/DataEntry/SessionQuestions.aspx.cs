using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.BLL;

public partial class SystemSettings_DataEntry_SessionQuestions : System.Web.UI.Page
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


    protected void grdQuestions_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblRank = (Label)e.Row.FindControl("lblRank");
        // On page reload, rank is reset to 0
        if (rankUser == 0)
        {
            // Only run this on subsequent pages
            if (currentPageUser > 0)
            {
                // Set rank to current index of page * the number of records to display on GridView page
                rankUser = currentPageUser * grdQuestions.PageSize;
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

    protected void grdQuestions_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        currentPageUser = e.NewPageIndex;
        grdQuestions.PageIndex = e.NewPageIndex;
        BindGrid();

    }

    private void BindGrid()
    {
        try
        {
            List<SessionQuestionData> ds = SessionQuestionDataBLL.GetList();
            grdQuestions.DataSource = ds; //clntBLL.GetAllClients();
            grdQuestions.DataBind();

        }
        catch (Exception ex)
        {

            grdQuestions.EmptyDataText = ex.Message;
            grdQuestions.DataBind();
        }

    }

    protected void btnSave_OnClick(object sender, EventArgs e)
    {

            SessionQuestionData sqData = new SessionQuestionData();
            sqData.SessionQuestion = txtQuestion.Text;
            SessionQuestionDataBLL.Insert(sqData);
            txtQuestion.Text = "";
            BindGrid();
        
    }

    protected void grdQuestions_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id;
        if (e.CommandName == "EditQuestion")
        {
            id = Convert.ToInt32(e.CommandArgument);
            SessionQuestionData sqData = SessionQuestionDataBLL.GetItem(id);
            txtQuestion.Text = sqData.SessionQuestion;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            Application["id"] = id;
        }
        else if (e.CommandName == "DeleteQuestion")
        {
            id = Convert.ToInt32(e.CommandArgument);
            SessionQuestionData sqData = SessionQuestionDataBLL.GetItem(id);
            SessionQuestionDataBLL.Delete(sqData);
            BindGrid();

        }
    }

    protected void btnUpdate_OnClick(object sender, EventArgs e)
    {
        SessionQuestionData sqData = new SessionQuestionData();
        sqData.SessionDataId = Convert.ToInt16(Application["id"]);
        sqData.SessionQuestion = txtQuestion.Text;
        SessionQuestionDataBLL.update(sqData);
        txtQuestion.Text = "";
        btnSave.Visible = true;
        btnUpdate.Visible = false;
        BindGrid();
    }
}