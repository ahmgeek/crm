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

public partial class Sessions_NewSession : System.Web.UI.Page
{
    int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.ToString()!= string.Empty)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                BindGrid();
                BindRepeater();
            }

        }
        else
        {
            Response.Redirect("/Sessions/Sessions.aspx");
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
        }
    }


    private void BindGrid()
    {

        Client _client = ClientBLL.GetItem(id);
        List<Client> list = new List<Client>();
        list.Add(_client);
        grdUser.DataSource = list;
        grdUser.DataBind();
        BindDate();
    }

    private void BindDate()
    {
        lblDate.Text = DateTime.Now.ToShortDateString();
        lblTime.Text = DateTime.Now.ToShortTimeString();
    }
    protected void grdUser_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.CssClass = "success";
    }



    private void BindRepeater()
    {
        List<SessionQuestion> questions = new List<SessionQuestion>();
        questions.Add(new SessionQuestion { Question = "نوع الاستشارة ( نفسيه ، علاقات زوجيه ، تربية اطفال  ، مذاكرة ودراسة ،  حياتية نجاح في الحياة)" });
        questions.Add(new SessionQuestion { Question = "ما الاعراض النفسية التي تشتكى منها ؟ والدرجة المئوية لكل عرض" });
        questions.Add(new SessionQuestion { Question = "ما الاعراض الجسمية التي تشتكى منها ؟ والدرجة المئوية  لكل عرض" });
        questions.Add(new SessionQuestion { Question = "متى بدأ عرض (  تاريخه  )" });
        questions.Add(new SessionQuestion { Question = "ما هي اسباب ظهوره من وجهة نظرك ؟" });
        questions.Add(new SessionQuestion { Question ="ما هي الحالة النفسية التي تريد ان تكون عليها ؟"});
        questions.Add(new SessionQuestion { Question ="ما الحالة الجسمية التي تريد ان تكون عليها ؟"});
        questions.Add(new SessionQuestion { Question ="هل زرت طبيبا آخر من قبل؟ وهل انت مستمر على علاج دوائي ومتى ؟"});
        questions.Add(new SessionQuestion { Question ="فى حاله زيارة طبيب آخر اذكر الحالة الاولى في البداية التي ذهبت بسببها للطبيب؟"});
        questions.Add(new SessionQuestion { Question ="اذكر بالتفصيل أكثر شيء في الحياة يضايقك ويؤثر عليك سلبياً؟ نقاط الاكثر فالأقل تأثيرا"});
        questions.Add(new SessionQuestion { Question ="اذكر بالتفصيل اكثر شيء في الحياة يشعرك بالسعادة والراحة؟"});
        questions.Add(new SessionQuestion { Question ="ما المدة الزمنية التي تتوقعها لكي تكون متعافي تماما (ما يدور في خيالك بصدق قبل الحضور)"});
        questions.Add(new SessionQuestion { Question ="اذكر أكثر موقف سلبى حدث لك في الماضي"});
        questions.Add(new SessionQuestion { Question ="اذكر أكثر موقف إيجابي حدث لك في المستقبل"});
        questions.Add(new SessionQuestion { Question ="اذكر أكثر حيوان تحبه ومحبب الى قلبك"});
        questions.Add(new SessionQuestion { Question ="اذكر أكثر حيوان تتقزز منه وكريه الى قلبك"});
        questions.Add(new SessionQuestion { Question ="هل سبق ان حضرت كورس؟"});
        questionRepeater.DataSource = questions;
        questionRepeater.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Sessions mysession = new Sessions();
            SessionQuestion sessionQuestions = new SessionQuestion();

            mysession.ClientId = id;
            mysession.DateTime = DateTime.Now;
            mysession.Report = txtReport.Text;
            mysession.Notes = string.Empty;
            mysession.IsActive = IsActive.Active;

            int sessionId = SessionBLL.Insert(mysession);

            foreach (RepeaterItem item in questionRepeater.Items)
            {
                sessionQuestions.SessionId = sessionId;


                TextBox txtQ = (TextBox)item.FindControl("txtQ");
                sessionQuestions.Question = "";
                sessionQuestions.Question = txtQ.Text;

                TextBox txtAns = (TextBox)item.FindControl("txtAns");
                sessionQuestions.Answer = "";
                sessionQuestions.Answer = txtAns.Text;


                Thread.Sleep(150);
                if (txtAns != null && txtQ.Text != null)
                {
                    SessionQuestionBLL.Insert(sessionQuestions);
                }
            }

            Session["Message"] = " Client Has Been Served";
            Response.Redirect("/Sessions/Sessions.aspx",false);

        }
        catch (Exception ex) 
        {
            Session["Message"] = "";
            Session["Message"] = ex.Message;
            Response.Redirect("/Sessions/Sessions.aspx", false);

        }
    }

   
}