using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESystem.Entities;
using ESystem.BLL;
using System.Data.SqlTypes;


public partial class Clients_NewClient : System.Web.UI.Page {
    ClientENT clntENT = new ClientENT();
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
        clntENT.AccountNumer = txtAccNum.Text;
        clntENT.FirstName = txtFName.Text.Trim();
        clntENT.MiddleName = txtMiddleName.Text.Trim();
        clntENT.SurrName = txtSurrName.Text;
        clntENT.City = txtCity.Text;
        clntENT.Country = drpCountry.SelectedItem.Text;
        clntENT.Address = txtAdress.Text;
        clntENT.Telephone = txtTelephone.Text;
        clntENT.Mobile = txtMob.Text;
        clntENT.DateOfBirth = Convert.ToDateTime(txtDateOf.Text);
        clntENT.Gender = drpGender.SelectedItem.Text;
        clntENT.PrfrdTimeForCall = drpTime.SelectedItem.Text;
        clntENT.CreationDate = DateTime.Now;
        clntENT.CreatedBy = usrBLL.GetUser("Admin").UserName;
        clntENT.LstModifiedDate = (DateTime)(NullDate);
        clntENT.LstModifiedBy = string.Empty;
        clntENT.Notes = txtNotes.Text;

        //asign the entities to the bll
       
            clntBLL.ClientInsert(clntENT);
            Response.Redirect("/Clients/RelClients.aspx?Acc=" + clntENT.CLientId);
        
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