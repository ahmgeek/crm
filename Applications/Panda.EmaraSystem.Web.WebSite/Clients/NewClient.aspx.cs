using System;
using System.Collections.Generic;
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

public partial class Clients_NewClient : System.Web.UI.Page {

    UsersBLL user = new UsersBLL();
    Client client = new Client();
    int clientID = 0;
    string userName;


    protected void Page_Load(object sender, EventArgs e)
    {
        userName = user.GetUser().UserName;

        //pnlClient.Visible = true;
        if (!IsPostBack)
        {
            txtAccNum.Text = GetUniqueId.GetRandomString();
            CountryBind();
            BindRepater();

        }
    
    }


    #region InterFace Methods
    private void CountryBind()
    {
        drpCountry.DataSource = Countries.BindCountries() ;
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
        btnWaitList.Enabled = true;
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
    void BindClients()
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
                this.ShowHelperMessage("Error","There is no clients so far",HelperNotify.NotificationType.error);
        }


    }

    void BindRepater()
    {
        List<SessionQuestion> questions = new List<SessionQuestion>();
        questions.Add(new SessionQuestion { Question = "نوع الاستشارة ( نفسيه ، علاقات زوجيه ، تربية اطفال  ، مذاكرة ودراسة ،  حياتية نجاح في الحياة)" });
        questions.Add(new SessionQuestion { Question = "ما الاعراض النفسية التي تشتكى منها ؟ والدرجة المئوية لكل عرض" });
        questions.Add(new SessionQuestion { Question = "ما الاعراض الجسمية التي تشتكى منها ؟ والدرجة المئوية  لكل عرض" });
        questions.Add(new SessionQuestion { Question = "متى بدأ عرض (  تاريخه  )" });
        questions.Add(new SessionQuestion { Question = "ما هي اسباب ظهوره من وجهة نظرك ؟" });
        questions.Add(new SessionQuestion { Question = "ما هي الحالة النفسية التي تريد ان تكون عليها ؟" });
        questions.Add(new SessionQuestion { Question = "ما الحالة الجسمية التي تريد ان تكون عليها ؟" });
        questions.Add(new SessionQuestion { Question = "هل زرت طبيبا آخر من قبل؟ وهل انت مستمر على علاج دوائي ومتى ؟" });
        questions.Add(new SessionQuestion { Question = "فى حاله زيارة طبيب آخر اذكر الحالة الاولى في البداية التي ذهبت بسببها للطبيب؟" });
        questions.Add(new SessionQuestion { Question = "اذكر بالتفصيل أكثر شيء في الحياة يضايقك ويؤثر عليك سلبياً؟ نقاط الاكثر فالأقل تأثيرا" });
        questions.Add(new SessionQuestion { Question = "اذكر بالتفصيل اكثر شيء في الحياة يشعرك بالسعادة والراحة؟" });
        questions.Add(new SessionQuestion { Question = "ما المدة الزمنية التي تتوقعها لكي تكون متعافي تماما (ما يدور في خيالك بصدق قبل الحضور)" });
        questions.Add(new SessionQuestion { Question = "اذكر أكثر موقف سلبى حدث لك في الماضي" });
        questions.Add(new SessionQuestion { Question = "اذكر أكثر موقف إيجابي حدث لك في المستقبل" });
        questions.Add(new SessionQuestion { Question = "اذكر أكثر حيوان تحبه ومحبب الى قلبك" });
        questions.Add(new SessionQuestion { Question = "اذكر أكثر حيوان تتقزز منه وكريه الى قلبك" });
        questions.Add(new SessionQuestion { Question = "هل سبق ان حضرت كورس؟" });
        questionRepeater.DataSource = questions;
        questionRepeater.DataBind();
    }
    #endregion




    //Saving The Data TODO{ CommitTransAction() }
    protected void btnWaitList_Click(object sender, EventArgs e)
    {
        try
        {

            using (TransactionScope trans = new TransactionScope())
            {


                #region CLient Data
                //Load the data into the object

                //Re Initialize
                client.AccountNumber = string.Empty;
                client.AccountNumber = txtAccNum.Text;


                client.FirstName = string.Empty;
                client.FirstName = txtFName.Text;


                client.MiddleName = string.Empty;
                client.MiddleName = txtMiddleName.Text;


                client.SurrName = string.Empty;
                client.SurrName = txtSurrName.Text;


                client.City = txtCity.Text;
                client.Country = drpCountry.SelectedItem.Text;
                client.Address = txtAdress.Text;
                client.Telephone = txtTelephone.Text;
                client.Mob = txtMob.Text;
                client.DateOfBirth = Convert.ToDateTime(txtDateOf.Text);
                client.Gender = drpGender.SelectedItem.Text;
                client.PrfrdTimeForCall = drpTime.SelectedItem.Text;
                client.Notes = txtNotes.Text;
                client.CreationDate = DateTime.Now;
                client.CreatedBy = userName;
                client.IsActive = IsActive.Active;
                client.HasArelation = Convert.ToInt16(HasArelation());
                clientID = ClientBLL.Insert(client);

                #endregion

                Thread.Sleep(1000);
                #region Relation Data

                if (HasArelation())
                {


                    Relatives relative = new Relatives();
                    relative.ClientId = clientID;
                    relative.CLientRelId = Convert.ToInt32(drpClients.SelectedItem.Value);
                    relative.RelationName = txtRelName.Text;
                    RelativesBLL.Insert(relative);
                }

                #endregion
                Thread.Sleep(1000);
                #region WaitList Data
                WaitingList waitList = new WaitingList();
                waitList.ClientId = clientID;
                waitList.DateTime = DateTime.Now;
                waitList.IsReserved = IsServed.UnServed;
                waitList.Notes = string.Empty;
                waitList.CreatedBy = userName;
                WaitingListBLL.Insert(waitList);
                #endregion
                trans.Complete();
                //session fore firing the jquery notify
                string message = "CLient has been sent to the WaitingList";
                Response.Redirect("/Clients/Clients.aspx?message=" + message, false);
            }
        }
        catch (Exception ex)
        {
            string message = ex.Message;
            Response.Redirect("/Clients/Clients.aspx?message=" + message);
        }
    }


}