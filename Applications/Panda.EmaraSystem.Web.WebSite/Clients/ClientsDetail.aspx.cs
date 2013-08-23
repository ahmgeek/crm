using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Countreis.CountryList;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;

public partial class Clients_ClientsDetail : System.Web.UI.Page
{
    //ReltaivBLL TODO
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.ToString() != string.Empty)
            {
                BindCountries();
                BindData();
            }
            else
            {
                Response.Redirect("/Clients/Clients.aspx");
            }
        }
    }

    private void BindCountries()
    {
        drpCountry.DataSource = Countries.BindCountries();
        drpCountry.DataBind();
    }



    private void BindData()
    {
        Client client = ClientBLL.GetItem(Convert.ToInt32(Request.QueryString["Acc"]));
        int id = Convert.ToInt32(Request.QueryString["Acc"]);
        txtAccNum.Text = client.AccountNumber;
        txtFName.Text = client.FirstName;
        txtMiddleName.Text = client.MiddleName;
        txtSurrName.Text = client.SurrName;
        txtCity.Text = client.City;
        drpCountry.SelectedItem.Text = client.Country;
        txtAdress.Text = client.Address;
        txtTelephone.Text = client.Telephone;
        txtMob.Text = client.Mob;
        txtDateOf.Text = client.DateOfBirth.ToString("dd/MM/yyyy");
        drpGender.SelectedItem.Text = client.Gender;
        drpTime.SelectedItem.Text = client.PrfrdTimeForCall;
        txtNotes.Text = client.Notes;
    }

}