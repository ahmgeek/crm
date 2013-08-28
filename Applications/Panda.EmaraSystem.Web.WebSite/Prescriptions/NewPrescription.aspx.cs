using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;
using Notification.Helper;
using System.Threading;
using System.Transactions;

public partial class Prescriptions_NewPrescriptions : System.Web.UI.Page
{
    int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.ToString() != string.Empty)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                BindGrid();
                BindRepeater();
                BindSessionRepeater();
                BindArrays();
            }

        }
        else
        {
            Response.Redirect("/Prescriptions/Prescriptions.aspx");
        }
    }

    private void BindGrid()
    {
        try
        {
            Client _client = ClientBLL.GetItem(id);
            List<Client> list = new List<Client>();
            list.Add(_client);
            grdUser.DataSource = list;
            grdUser.DataBind();
            BindDate();
        }
        catch (Exception ex)
        {
            grdUser.EmptyDataText = ex.Message;
            grdUser.DataBind();
        }
        
    }
    private void BindDate()
    {
        lblDate.Text = DateTime.Now.ToShortDateString();
        lblTime.Text = DateTime.Now.ToShortTimeString();

        Sessions mySession = SessionBLL.GetByClient(id);
        txtReport.Text = mySession.Report;
    }
    private void BindRepeater()
    {
        try
        {
            List<SessionQuestion> list = SessionQuestionBLL.GetClientList(id);
            questionRepeater.DataSource = list;
            questionRepeater.DataBind();
        }
        catch (Exception ex)
        {
            this.ShowHelperMessage("Error", ex.Message, HelperNotify.NotificationType.error);
        }
    }


    protected void grdUser_PreRender(object sender, EventArgs e)
    {

        foreach (GridViewRow item in grdUser.Rows)
        {

            Label lblFullName = (Label)item.FindControl("lblFullName");
            lblFullName.CssClass = "label label-important";

            Label lblAccountNumber = (Label)item.FindControl("lblAccountNumber");
            lblAccountNumber.CssClass = "label label-info";

            Label lblcity = (Label)item.FindControl("lblcity");
            lblcity.CssClass = "label label-inverse";


            Label lblMob = (Label)item.FindControl("lblMob");
            lblMob.CssClass = "label label-success";

            Label lblBirth = (Label)item.FindControl("lblBirth");
            lblBirth.CssClass = "label label-inverse";


            Label lblgender = (Label)item.FindControl("lblgender");
            lblgender.CssClass = "label label-info";

            //
        }
    }
    protected void grdUser_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.CssClass = "success";

    }


    private void BindSessionRepeater()
    {
        try
        {
            List<PrescriptionSession> mySessions = new List<PrescriptionSession>();
            mySessions.Add(new PrescriptionSession { SessionName = "TLT 1" });
            mySessions.Add(new PrescriptionSession { SessionName = "TLT 2" });
            mySessions.Add(new PrescriptionSession { SessionName = "TLT 3" });
            mySessions.Add(new PrescriptionSession { SessionName = "TLT 4" });
            mySessions.Add(new PrescriptionSession { SessionName = "TLT 5" });
            mySessions.Add(new PrescriptionSession { SessionName = "TLT 6" });
            mySessions.Add(new PrescriptionSession { SessionName = "TLT 7" });
            mySessions.Add(new PrescriptionSession { SessionName = "energy " });
            mySessions.Add(new PrescriptionSession { SessionName = "Dr Ahmad " });
            mySessions.Add(new PrescriptionSession { SessionName = "Other sessions" });
            mySessions.Add(new PrescriptionSession { SessionName = "جلسات مخاوف" });
            repeatSessions.DataSource = mySessions;
            repeatSessions.DataBind();

        }
        catch (Exception ex)
        {
            this.ShowHelperMessage("Error", ex.Message, HelperNotify.NotificationType.error);
        }
    }


    private void BindArrays()
    {
        string[] cd = { "التعامل مع الناس",
                          "مفجرات الثقة بالنفس",
                          "التخلص من الوساوس" ,
                          "مواجهة المخاوف",
                          "العلاقات الزوجية",
                          "التعامل مع المراهقين",
                          "المذاكرة بسهولة واستمتاع"};


        string[] Courses = { "قوة الكلمة والتفكير",
                          "ثورة الاهداف",
                          "الثبات الانفعالى والتحكم فى الغضب" ,
                          "الطاقة الحيوية والشفاء الذاتى",
                          "تربية الاطفال",
                          "تربية الاولاد",
                          "الوزن المثالى ",
                           "تطبيقات الجذب"};

        for (int i = 0; i < cd.Length; i++)
        {
            lstCourses.Items.Add(Courses[i]);
            lstCD.Items.Add(cd[i]);
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            using (TransactionScope trans = new TransactionScope())
            {

                #region INIT
                Prescription presc = new Prescription();
                PrescriptionCD prescCd = new PrescriptionCD();
                PrescriptionCourses prescCourses = new PrescriptionCourses();
                PrescriptionSession prescSession = new PrescriptionSession();
                #endregion
                Sessions session = SessionBLL.GetByClient(id);


                // Prescription Insertion 
                #region Prescription Insertion
                presc.SessionId = session.SessionId;
                presc.ClientId = id;
                presc.DateTime = DateTime.Now;
                presc.Report = txtFinalReport.Text;
                presc.IsServed = IsServed.UnServed;
                int prescriptionId = PrescriptionBLL.Insert(presc);
                Thread.Sleep(150);
                #endregion

                //Prescription Courseslst
                #region Prescription Courseslst
                foreach (ListItem item in lstCourses.Items)
                {
                    if (item.Selected)
                    {
                        prescCourses.PrescriptionId = prescriptionId;
                        prescCourses.CourseName = item.Text;
                        prescCourses.Notes = string.Empty;
                        PrescriptionCoursesBLL.Insert(prescCourses);

                    }
                }
                Thread.Sleep(150);
                #endregion

                //Prescription CD
                #region Prescription CD
                foreach (ListItem item in lstCD.Items)
                {
                    if (item.Selected)
                    {
                        prescCd.PrescriptionId = prescriptionId;
                        prescCd.CdName = item.Text;
                        prescCd.Note = string.Empty;
                        PrescriptionCdBLL.Insert(prescCd);

                    }
                }
                Thread.Sleep(150);

                #endregion





                //Prescription Sessions
                #region Prescription Sessions
                foreach (RepeaterItem item in repeatSessions.Items)
                {
                    prescSession.PrescriptionId = prescriptionId;

                    CheckBox chkSession = (CheckBox)item.FindControl("chkCourse");

                    if (chkSession.Checked)
                    {
                        //Session Name
                        TextBox txtSessionName = (TextBox)item.FindControl("txtSessionName");
                        prescSession.SessionName = "";
                        prescSession.SessionName = txtSessionName.Text;
                        //Session Counter
                        TextBox txtCounter = (TextBox)item.FindControl("txtCounter");
                        prescSession.Number = Convert.ToInt32(txtCounter.Text);


                        TextBox txtComment = (TextBox)item.FindControl("txtComment");
                        prescSession.Comment = "";
                        prescSession.Comment = txtComment.Text;
                        PrescriptionSessionBLL.Insert(prescSession);
                    }

                }
                #endregion


                trans.Complete();
            }
            Session["Message"] = " Report Has Been Sent ";
            Response.Redirect("/Prescriptions/Prescriptions.aspx", false);

        }
        catch (Exception ex)
        {
            Session["Message"] = "";
            Session["Message"] = ex.Message;
            Response.Redirect("/Prescriptions/Prescriptions.aspx", false);

        }
    }
}  
