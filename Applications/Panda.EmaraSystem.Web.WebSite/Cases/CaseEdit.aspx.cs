using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Notification.Helper;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;

public partial class Cases_CaseEdit : System.Web.UI.Page
{
    private int id = 0;
    private Prescription prescription;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.ToString() != string.Empty)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            prescription = PrescriptionBLL.GetByCase(id);
            if (!IsPostBack)
            {
                BindGrid();
                BindRepater();
                BindQuestionRepeater();
                BindPrescriptionData();
            }
        }
        else
        {
            Response.Redirect("View.aspx");
        }
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

        }
        catch (Exception ex)
        {

            grd.EmptyDataText = ex.Message;
            grd.DataBind();
        }

    }

    private void BindPrescriptionData()
    {
        try
        {
            List<PrescriptionCourseData> prsc = PrescriptionCourseDataBLL.GetList();
            lstCourses.DataSource = prsc;
            lstCourses.DataBind();

            List<PrescriptionCdData> prscCdData = PrescriptionCdDataBLL.GetList();
            lstCD.DataSource = prscCdData;
            lstCD.DataBind();

            List<PrescriptionCD> prsCds = PrescriptionCdBLL.GetListByPrescription(prescription.PrescriptionId);
            List<PrescriptionCourses> prsCourseses =
                PrescriptionCoursesBLL.GetListByPrescription(prescription.PrescriptionId);
            foreach (var item in prsCds)
            {
                lstCD.Items.FindByText(item.CdName).Selected = true;

            }
            foreach (var item in prsCourseses)
            {
                lstCourses.Items.FindByText(item.CourseName).Selected = true;

            }

            txtFinalReport.Text = prescription.Report;
            txtComment.Text = prescription.ConfermedComment;
        }
        catch (Exception ex)
        {

            string message = ex.Message.Replace('\n', ' ') + " for CD's Or Courses.";
            this.ShowHelperMessage("Warning",message, HelperNotify.NotificationType.info);
        }

    }
    private void BindRepater()
    {
        //Bind Prescription Session Repeater
        List<PrescriptionSessionData> prscSessionData = PrescriptionSessionDataBLL.GetList();
        repeatSessions.DataSource = prscSessionData;        
        repeatSessions.DataBind();

        List<PrescriptionSession> prscSessions = 
            PrescriptionSessionBLL.GetListByPrescription(prescription.PrescriptionId);

        foreach (RepeaterItem item in repeatSessions.Items)
        {
            TextBox txtCounter = (TextBox)item.FindControl("txtCounter");
            TextBox txtComment = (TextBox)item.FindControl("txtComment");
            CheckBox chkCourse = (CheckBox)item.FindControl("chkCourse");
            TextBox txtSessionName = (TextBox)item.FindControl("txtSessionName");

            foreach (var prsc in prscSessions)
            {
                if (prsc.SessionName == txtSessionName.Text)
                {
                    txtCounter.Text = prsc.Number.ToString();
                    txtComment.Text = prsc.Comment;
                    chkCourse.Checked = true;
                }

            }
        }

    }
    protected void repeatSessions_OnPreRender(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in repeatSessions.Items)
        {

            TextBox txtSessionName = (TextBox)item.FindControl("txtSessionName");
            txtSessionName.ForeColor = System.Drawing.Color.Maroon;

        }
    }
    private void BindQuestionRepeater()
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


    protected void btnUpdate_OnClick(object sender, EventArgs e)
    {
        using (TransactionScope trans = new TransactionScope())
        {
            #region Prescription

            //Objects Init
            Prescription prsc = PrescriptionBLL.GetByCase(id);
            PrescriptionSession prscSession = new PrescriptionSession();
            PrescriptionCD prscCD = new PrescriptionCD();
            PrescriptionCourses prscCourses = new PrescriptionCourses();

           //Lists for Delete purpose.
           List<PrescriptionSession> _prscSession = PrescriptionSessionBLL.GetListByPrescription(prsc.PrescriptionId);
           List<PrescriptionCourses> _prscCourse = PrescriptionCoursesBLL.GetListByPrescription(prsc.PrescriptionId);
           List<PrescriptionCD> _prscCd = PrescriptionCdBLL.GetListByPrescription(prsc.PrescriptionId);


            #region Prescription Update

            prsc.CaseId = id;
            prsc.Report = txtFinalReport.Text;
            prsc.Status = PrescriptionStatus.revised;
            //Init prsc.ConfirmedComment
            prsc.ConfermedComment = txtComment.Text;
            Thread.Sleep(150);
            int prescriptionId = PrescriptionBLL.UpdateByCase(prsc);

            #endregion

            //Prescription CD

            #region Prescription CD
            foreach (PrescriptionCD item in _prscCd)
            {
                PrescriptionCdBLL.Delete(item);
            }

            foreach (ListItem cdItem in lstCD.Items)
            {
                if (cdItem.Selected)
                {
                    prscCD.PrescriptionId = prescription.PrescriptionId;
                    prscCD.CdName = cdItem.Text;
                    prscCD.Note = string.Empty;
                    PrescriptionCdBLL.Insert(prscCD);
                }

                
            }

            #endregion

            //Prescription Courses lest

            #region Prescription Courses lest
            foreach (PrescriptionCourses item in _prscCourse)
            {
                PrescriptionCoursesBLL.Delete(item);
            }

            foreach (ListItem courseItem in lstCourses.Items)
            {
                if (courseItem.Selected)
                {
                    prscCourses.PrescriptionId = prescription.PrescriptionId;
                    prscCourses.CourseName = courseItem.Text;
                    prscCourses.Notes = string.Empty;
                    PrescriptionCoursesBLL.Insert(prscCourses);

                }
            }

            #endregion

            //Prescription Sessions

            #region Prescription Sessions

            foreach (PrescriptionSession item in _prscSession)
            {
                PrescriptionSessionBLL.Delete(item);
            }


            foreach (RepeaterItem sessionItem in repeatSessions.Items)
            {
                prscSession.PrescriptionId = prescription.PrescriptionId;

                CheckBox chkSession = (CheckBox) sessionItem.FindControl("chkCourse");

                if (chkSession.Checked)
                {
                    //Session Name
                    TextBox txtSessionName = (TextBox) sessionItem.FindControl("txtSessionName");
                    prscSession.SessionName = "";
                    prscSession.SessionName = txtSessionName.Text;
                    //Session Counter
                    TextBox txtCounter = (TextBox) sessionItem.FindControl("txtCounter");
                    prscSession.Number = Convert.ToInt32(txtCounter.Text);


                    TextBox txtSessionComment = (TextBox) sessionItem.FindControl("txtComment");
                    prscSession.Comment = "";
                    prscSession.Comment = txtSessionComment.Text;
                    PrescriptionSessionBLL.Insert(prscSession);
                }

            }

            #endregion


            #endregion
            trans.Complete();
            //session fore firing the jquery notify
            string message = "The case has been revised successfully";
            Response.Redirect("/Cases/view.aspx?message=" + message, false);

        }
    }

    protected void btnCancel_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("/Cases/Case.aspx?id=" + id);
    }
}