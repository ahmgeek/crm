using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using Notification.Helper;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;
using Countreis.CountryList;
using System.Data.SqlClient;
using System.Threading;
using System.Transactions;

public partial class Clients_NewClient : System.Web.UI.Page
{
    private string userName;

    protected void Page_Load(object sender, EventArgs e)
    {
        UsersBLL user = new UsersBLL();
        userName = user.GetUser().UserName;

        //pnlClient.Visible = true;
        if (!IsPostBack)
        {
            txtCaseNumber.Text = GetUniqueId.GetRandomString();
            CountryBind();
            BindRepater();
            BindPrescriptionData();
        }

    }


    #region InterFace Methods

    private void CountryBind()
    {
        drpCountry.DataSource = Countries.BindCountries();
        drpCountry.DataBind();
    }

    //Relation Scree Methods
    public bool HasArelation()
    {
        if (rdlst.SelectedIndex == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void rdlst_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (HasArelation())
        {
            BindClients();
            pnlRelation.Visible = true;
        }
        else
        {
            pnlRelation.Visible = false;
        }
    }

    private void BindClients()
    {
        try
        {
            drpClients.DataSource = ClientBLL.GetList();
            drpClients.DataTextField = "FullName";
            drpClients.DataValueField = "ClientId";
            drpClients.DataBind();
        }
        catch (Exception)
        {
            this.ShowHelperMessage("Error", "There is no clients so far", HelperNotify.NotificationType.error);
        }


    }
  
    private void BindRepater()
    {
        try
        {
            List<SessionQuestionData> questions = SessionQuestionDataBLL.GetList();
            questionRepeater.DataSource = questions;
            questionRepeater.DataBind();

            //Bind Prescription Session Repeater
            List<PrescriptionSessionData> prscSessionData = PrescriptionSessionDataBLL.GetList();
            repeatSessions.DataSource = prscSessionData;
            repeatSessions.DataBind();
        }
        catch (Exception)
        {

            this.ShowHelperMessage("Warning", "Please Fill Questions table or Sessions table first", HelperNotify.NotificationType.error);
        }
      
    }

    private void BindPrescriptionData()
    {
        try
        {
            List<PrescriptionCourseData> prscCourseData = PrescriptionCourseDataBLL.GetList();
            lstCourses.DataSource = prscCourseData;
            lstCourses.DataBind();

            List<PrescriptionCdData> prscCdData = PrescriptionCdDataBLL.GetList();
            lstCD.DataSource = prscCdData;
            lstCD.DataBind();

        }
        catch (Exception)
        {

            this.ShowHelperMessage("Warning", "Please Fill Course table or CD's table first", HelperNotify.NotificationType.error);
        }
    }



    #endregion



    protected void repeatSessions_OnPreRender(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in repeatSessions.Items)
        {

            TextBox txtSessionName = (TextBox) item.FindControl("txtSessionName");
            txtSessionName.ForeColor = System.Drawing.Color.Maroon;

        }
    }

    protected void btnSendToConfirm_OnClick(object sender, EventArgs e)
    {
        try
        {
            using (TransactionScope trans = new TransactionScope())
            {
                #region Objects

                //Client Object
                Client client = new Client();

                //Case object
                ClientCase clientCase = new ClientCase();

                //Session ibject
                Sessions casesession = new Sessions();
                SessionQuestion sessionQuestions = new SessionQuestion();

                //Prescription Object
                Prescription prsc = new Prescription();

                PrescriptionSession prescSession = new PrescriptionSession();
                PrescriptionCourses prscCourse = new PrescriptionCourses();
                PrescriptionCD prscCd = new PrescriptionCD();

                #endregion

                #region CLient and relation data

                //Load the data into the object
                client.FirstName = txtFName.Text;
                client.MiddleName = txtMiddleName.Text;
                client.SurrName = txtSurrName.Text;
                client.CreationDate = DateTime.Now;
                client.CreatedBy = userName;
                client.IsActive = IsActive.Active;
                client.Notes = txtNotes.Text;
                //ClientDetail
                client.CLientId = client.CLientId;
                client.City = txtCity.Text;
                client.Country = drpCountry.Text;
                client.Address = txtAdress.Text;
                client.Telephone = txtTelephone.Text;
                client.Mob = txtMob.Text;
                client.DateOfBirth = Convert.ToDateTime(txtDateOf.Text);
                client.Gender = drpGender.Text;
                if (HasArelation())
                {
                    client.HasArelation = HasRelations.yes;
                }
                else
                {
                    client.HasArelation = HasRelations.no;
                }
                client.CLientId = ClientBLL.Insert(client);
                Thread.Sleep(150);

                #region Relation Data

                if (HasArelation())
                {
                    Relatives relative = new Relatives();
                    relative.ClientId = client.CLientId;
                    relative.CLientRelId = Convert.ToInt32(drpClients.SelectedItem.Value);
                    relative.RelationName = txtRelName.Text;
                    Thread.Sleep(150);
                    RelativesBLL.Insert(relative);
                }

                #endregion

                #endregion


                #region Client case

                clientCase.ClientId = client.CLientId;
                clientCase.CaseNumber = txtCaseNumber.Text;
                clientCase.CaseStatus = CaseStatus.opened;
                clientCase.dateTime = DateTime.Now;
                Thread.Sleep(150);
                clientCase.CaseId = ClientCaseBLL.Insert(clientCase);

                #endregion

                #region Questions and answers

                //Session Insertion
                casesession.CaseId = clientCase.CaseId;
                casesession.Report = txtReport.Text;
                casesession.Notes = string.Empty;

                //Session Questions Insertion
                Thread.Sleep(150);
                int sessionId = SessionBLL.Insert(casesession);
                foreach (RepeaterItem item in questionRepeater.Items)
                {
                    sessionQuestions.SessionId = sessionId;
                    Label lblQuestion = (Label)item.FindControl("lblQuestion");
                    sessionQuestions.Question = lblQuestion.Text;

                    TextBox txtAns = (TextBox)item.FindControl("txtAns");
                    sessionQuestions.Answer = "";
                    sessionQuestions.Answer = txtAns.Text;
                    if (txtAns != null)
                    {
                        SessionQuestionBLL.Insert(sessionQuestions);
                    }
                }

                #endregion

                #region Prescription

                #region Prescription Insertion

                prsc.CaseId = clientCase.CaseId;
                prsc.Report = txtFinalReport.Text;
                prsc.Status = PrescriptionStatus.onhold;
                //Init prsc.ConfirmedComment
                prsc.ConfermedComment = string.Empty;
                Thread.Sleep(150);
                int prescriptionId = PrescriptionBLL.Insert(prsc);

                #endregion

                //Prescription CD

                #region Prescription CD

                foreach (ListItem cdItem in lstCD.Items)
                {
                    if (cdItem.Selected)
                    {
                        prscCd.PrescriptionId = prescriptionId;
                        prscCd.CdName = cdItem.Text;
                        prscCd.Note = string.Empty;
                        PrescriptionCdBLL.Insert(prscCd);

                    }
                }

                #endregion

                //Prescription Coursesls

                #region Prescription Courseslst

                foreach (ListItem courseItem in lstCourses.Items)
                {
                    if (courseItem.Selected)
                    {
                        prscCourse.PrescriptionId = prescriptionId;
                        prscCourse.CourseName = courseItem.Text;
                        prscCourse.Notes = string.Empty;
                        PrescriptionCoursesBLL.Insert(prscCourse);

                    }
                }

                #endregion

                //Prescription Sessions

                #region Prescription Sessions

                foreach (RepeaterItem sessionItem in repeatSessions.Items)
                {
                    prescSession.PrescriptionId = prescriptionId;

                    CheckBox chkSession = (CheckBox)sessionItem.FindControl("chkCourse");

                    if (chkSession.Checked)
                    {
                        //Session Name
                        TextBox txtSessionName = (TextBox)sessionItem.FindControl("txtSessionName");
                        prescSession.SessionName = "";
                        prescSession.SessionName = txtSessionName.Text;
                        //Session Counter
                        TextBox txtCounter = (TextBox)sessionItem.FindControl("txtCounter");
                        prescSession.Number = Convert.ToInt32(txtCounter.Text);


                        TextBox txtComment = (TextBox)sessionItem.FindControl("txtComment");
                        prescSession.Comment = "";
                        prescSession.Comment = txtComment.Text;
                        PrescriptionSessionBLL.Insert(prescSession);
                    }

                }

                #endregion


                #endregion

                trans.Complete();
                //session fore firing the jquery notify
                string message = "CLient has been saved and waiting to be revised";
                Response.Redirect("/Clients/Clients.aspx?message=" + message, false);
            }
        }


        catch (Exception ex)
        {
            string message = ex.Message;
            Response.Redirect("/Clients/Clients.aspx?message=" + message, false);
        }
    }
}