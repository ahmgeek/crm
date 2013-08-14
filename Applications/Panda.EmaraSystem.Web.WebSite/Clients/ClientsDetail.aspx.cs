using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESystem.BLL;
using ESystem.Entities;

public partial class Clients_ClientsDetail : System.Web.UI.Page
{
    ClientBLL clntBLL = new ClientBLL();
    //ReltaivBLL TODO
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CountryBind();
            if (Request.QueryString.ToString() != string.Empty)
            {
                int id = Convert.ToInt32(Request.QueryString["Acc"]);
                txtAccNum.Text = clntBLL.GetClientById(id).AccountNumer;
                txtFName.Text = clntBLL.GetClientById(id).FirstName;
                txtMiddleName.Text = clntBLL.GetClientById(id).MiddleName;
                txtSurrName.Text = clntBLL.GetClientById(id).SurrName;
                txtCity.Text = clntBLL.GetClientById(id).City;
                drpCountry.SelectedItem.Text = clntBLL.GetClientById(id).Country;
                txtAdress.Text = clntBLL.GetClientById(id).Address;
                txtTelephone.Text = clntBLL.GetClientById(id).Telephone;
                txtMob.Text = clntBLL.GetClientById(id).Mobile;
                txtDateOf.Text = clntBLL.GetClientById(id).DateOfBirth.ToString("dd/MM/yyyy");
                drpGender.SelectedItem.Text = clntBLL.GetClientById(id).Gender;
                drpTime.SelectedItem.Text = clntBLL.GetClientById(id).PrfrdTimeForCall;
                txtNotes.Text = clntBLL.GetClientById(id).Notes;
                //txtRelatedto.Text =   TODO Relation
            }
            else
            {
                Response.Redirect("/Clients/Clients.aspx");
            }
        }
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