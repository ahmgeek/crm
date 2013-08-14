using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;


public partial class Clients_NewClient : System.Web.UI.Page {


    ClientBO clntBO = new ClientBO();
    ClientBLL clntBLL = new ClientBLL();
    UsersBLL usrBLL = new UsersBLL();
    SqlDateTime NullDate;



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txtAccNum.Text = GetUniqueId.GetRandomString();
            CountryBind();
           
        }
    
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clntBO.AccountNumer = txtAccNum.Text;
        clntBO.FirstName = txtFName.Text.Trim();
        clntBO.MiddleName = txtMiddleName.Text.Trim();
        clntBO.SurrName = txtSurrName.Text;
        clntBO.City = txtCity.Text;
        clntBO.Country = drpCountry.SelectedItem.Text;
        clntBO.Address = txtAdress.Text;
        clntBO.Telephone = txtTelephone.Text;
        clntBO.Mobile = txtMob.Text;
        clntBO.DateOfBirth = Convert.ToDateTime(txtDateOf.Text);
        clntBO.Gender = drpGender.SelectedItem.Text;
        clntBO.PrfrdTimeForCall = drpTime.SelectedItem.Text;
        clntBO.CreationDate = DateTime.Now;
        clntBO.CreatedBy = usrBLL.GetUser("Admin").UserName;
        clntBO.LstModifiedDate = (DateTime)(NullDate);
        clntBO.LstModifiedBy = string.Empty;
        clntBO.Notes = txtNotes.Text;

        //asign the entities to the bll
       
            clntBLL.ClientInsert(clntBO);
            Response.Redirect("/Clients/RelClients.aspx?Acc=" + clntBO.CLientId);
        
        //    ClientScript.RegisterStartupScript(this.GetType(), "Enfo", HelperNotify.HelperMessage("Error", "", HelperNotify.NotificationType.info));
        
    }

    void CountryBind()
    {
        List<string> myList = new List<string>();
        myList.Insert(0, "");
        myList.Add("ألبانيا");
        myList.Add("الجزائر");
        myList.Add("أنغولا");
        myList.Add("أنجويلا");
        myList.Add("أذربيجان");
        myList.Add("البحرين");
        myList.Add("بنغلاديش");
        myList.Add("البوسنة والهرسك");
        myList.Add("بوركينا فاسو");
        myList.Add("مصر");
        myList.Add("إيران");
        myList.Add("العراق");
        myList.Add("المنطقة المحايدة بين العراق والسعودية");
        myList.Add("الكويت");
        myList.Add("ليبيا");
        myList.Add("لبنان");
        myList.Add("ليتوانيا");
        myList.Add("مقدونيا");
        myList.Add("مدغشقر");
        myList.Add("ماليزيا");
        myList.Add("مالطا");
        myList.Add("موريتانيا");
        myList.Add("المغرب");
        myList.Add("عمان");
        myList.Add("فلسطين");
        myList.Add("قطر");
        myList.Add("المملكة العربية السعودية");
        myList.Add("جزر سليمان");
        myList.Add("الصومال");
        myList.Add("السودان");
        myList.Add("سوريا");
        myList.Add("تونس");
        myList.Add("تركيا");
        myList.Add("الإمارات العربية المتحدة");
        myList.Add("اليمن");
        myList.Add("الجزائر");
        myList.Add("الأردن");

        drpCountry.DataSource = myList;
        drpCountry.DataBind();
    }
}