using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;
using System.Data.SqlTypes;
using Notification.Helper;
public partial class Calls_Call : System.Web.UI.Page
{
    int id = 0;
    string userName;
    SqlDateTime NullDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        UsersBLL user = new UsersBLL();

        userName = user.GetUser().UserName;

        if (Request.QueryString.ToString() != string.Empty)
        {
           // AvilabelityCheck();
            if (rdStatusList.SelectedValue == "3")
            {
                this.ShowHelperMessage("Warning","You are going to deactivate this client and closing his case",HelperNotify.NotificationType.error);
            }
           
            id = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                BindGrid();
                if (rdStatusList.SelectedValue == "1")
                {
                    BindRepeater();
                }
            }

        }
        else
        {
            Response.Redirect("/Cases/View.aspx");
        }
    }
    protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void grd_PreRender(object sender, EventArgs e)
    {
        foreach (GridViewRow item in grd.Rows)
        {

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

            Label lblCaseStatus = (Label)item.FindControl("lblCaseStatus");
            if (lblCaseStatus.Text == "confirmed")
            {
                lblCaseStatus.CssClass = "label label-success";

            }
            else if (lblCaseStatus.Text == "onhold")
            {
                lblCaseStatus.CssClass = "label label-important";
            }
            else if (lblCaseStatus.Text == "revised")
            {
                lblCaseStatus.CssClass = "label label-inverse";
            }
            

            Label lblRelation = (Label)item.FindControl("lblRelation");
            if (lblRelation.Text == string.Empty)
            {
                lblRelation.Text = "------------- ------------ -----------";
            }
            lblRelation.CssClass = "label label-inverse";

        }
    }

    private void BindGrid()
    {

        try
        {
            //Client Grid
            ClientCase _clientCase = ClientCaseBLL.GetItem(id);
            List<ClientCase> list = new List<ClientCase>();
            list.Add(_clientCase);
            grd.DataSource = list;
            grd.DataBind();

            //CD Grid
            Prescription presc = PrescriptionBLL.GetByCase(id);


            grdCd.DataSource = presc.PrescriptionCds;
            grdCd.DataBind();
            //Course Grid
            grdCourses.DataSource = presc.PrescriptionCourseses;
            grdCourses.DataBind(); ;
            //Sessions Grid
            grdSessions.DataSource = presc.PrescriptionSessions;
            grdSessions.DataBind(); ;
            //Report Bind
            txtFinalReport.Text = presc.Report;
            if (presc.Status == PrescriptionStatus.revised)
            {
                pnlRevised.Visible = true;
                txtComment.Text = presc.ConfermedComment;

            }
        }
        catch (Exception ex)
        {

            grd.EmptyDataText = ex.Message;
            grd.DataBind();
        }

    }

    private void BindRepeater()
    {
        try
        {
            Sessions session = SessionBLL.GetByCase(Convert.ToInt32(Request.QueryString["id"]));
            questionRepeater.DataSource = session.SessionQuestions;
            questionRepeater.DataBind();
            txtReport.Text = session.Report;
        }
        catch (Exception ex)
        {

            grd.EmptyDataText = ex.Message;
            grd.DataBind();
        }

    }

    protected void questionRepeater_PreRender(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in questionRepeater.Items)
        {
            Label answer = (Label)item.FindControl("lblAnswer");
            if (answer.Text == string.Empty)
            {
                answer.Text = "-----";
            };
        }
    }


    protected void rdStatusList_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (rdStatusList.SelectedValue == "1")
        {
            btnSave.Enabled = true;
            pnlAvailble.Visible = true;
        }
        else if(rdStatusList.SelectedValue == "2")
        {
            btnSave.Enabled = true;
            pnlAvailble.Visible = false;
        }
        else if (rdStatusList.SelectedValue == "3")
        {
            btnSave.Enabled = true;
            pnlAvailble.Visible = false;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (rdStatusList.SelectedValue == "1")
        {
            FirstCall fCall = new FirstCall();
            fCall.CaseId = id;
            fCall.dateTime = DateTime.Now;
            fCall.Report = txtCallReport.Text;
            fCall.TechnichalReport = txtTechnichalReport.Text;
            fCall.VisitDate = Convert.ToDateTime(txtVisitDate.Text);
            // Fix the bug am here
            fCall.VisitTime = txtTime.Text;
            fCall.Status = FirstCallStatus.available;
            fCall.Notes = txtNotes.Text;
            fCall.CreatedBy = userName;


            fCall.FcallId = FirstCallBLL.Insert(fCall);
        }
        else if (rdStatusList.SelectedValue == "2")
        {
            FirstCall fCall = new FirstCall();
            fCall.CaseId = id;
            fCall.dateTime = DateTime.Now;
            fCall.Report = "";
            fCall.TechnichalReport = "";
            fCall.VisitDate = (DateTime)(NullDate);
            fCall.VisitTime = "";
            fCall.Status = FirstCallStatus.onhold;
            fCall.Notes = "";
            fCall.CreatedBy = userName;
            fCall.FcallId = FirstCallBLL.Insert(fCall);

        }
        else if (rdStatusList.SelectedValue == "3")
        {
            //TODO : deactivate the account
        }
    }


}