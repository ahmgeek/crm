using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Countreis.CountryList;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;

public partial class Clients_ClientsDetail : System.Web.UI.Page
{
    UsersBLL user = new UsersBLL();
    string userName;
    int clientID = 0;

    bool flag = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        userName = user.GetUser().UserName;

        if (!IsPostBack)
        {
            if (Request.QueryString.ToString() != string.Empty)
            {
                clientID =Convert.ToInt32(Request.QueryString["Acc"]);
                 
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



            if (client.HasArelation == 1)
            {
                flag = true;
                rdlst.SelectedIndex = 0;
                drpClients.DataSource = ClientBLL.GetList();
                drpClients.DataTextField = "FullName";
                drpClients.DataValueField = "ClientId";
                drpClients.DataBind();
                Relatives rel = RelativesBLL.GetByClient(id);
                drpClients.SelectedItem.Text = rel.ClientRelName;
                txtRelName.Text = rel.RelationName;

            }
            else
            {
                pnlRelationData.Visible = false;
            }

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

    protected void rdlst_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            if (rdlst.SelectedIndex == 0)
            {

                pnlRelationData.Visible = true;
                drpClients.DataSource = ClientBLL.GetList();
                drpClients.DataTextField = "FullName";
                drpClients.DataValueField = "ClientId";
                drpClients.DataBind();

            }
            else
            {
                pnlRelationData.Visible = false;

            }

       
    }
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


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Client client = new Client();
            #region CLient Data
            //Load the data into the object

            //Re Initialize
            int id = Convert.ToInt32(Request.QueryString["Acc"]);
            client.CLientId = id;
            client.FirstName = txtFName.Text;
            client.MiddleName = txtMiddleName.Text;
            client.SurrName = txtSurrName.Text;
            client.AccountNumber = txtAccNum.Text;
            client.City = txtCity.Text;
            client.Country = drpCountry.SelectedItem.Text;
            client.Address = txtAdress.Text;
            client.Telephone = txtTelephone.Text;
            client.Mob = txtMob.Text;
            client.DateOfBirth = Convert.ToDateTime(txtDateOf.Text);
            client.Gender = drpGender.SelectedItem.Text;
            client.PrfrdTimeForCall = drpTime.SelectedItem.Text;
            client.Notes = txtNotes.Text;
            client.CreatedBy = userName;
            client.CreationDate = ClientBLL.GetItem(id).CreationDate;
            client.IsActive = IsActive.Active;
            client.HasArelation = Convert.ToInt16(HasArelation());


            clientID = ClientBLL.Update(client);

            #endregion

            Thread.Sleep(1000);
            #region Relation Data
            if (flag)
            {
                if (rdlst.SelectedIndex == 0)
                {
                    Relatives relative = new Relatives();
                    relative.ClientId = clientID;
                    relative.CLientRelId = Convert.ToInt32(drpClients.SelectedItem.Value);
                    relative.RelationName = txtRelName.Text;
                    RelativesBLL.Update(relative);
                }
            }
            else
            {
                if (rdlst.SelectedIndex == 0)
                {
                    Relatives relative = new Relatives();
                    relative.ClientId = clientID;
                    relative.CLientRelId = Convert.ToInt32(drpClients.SelectedItem.Value);
                    relative.RelationName = txtRelName.Text;
                    RelativesBLL.Insert(relative);
                }
            }

            if (rdlst.SelectedIndex == 1)
            {

                 Relatives rel = RelativesBLL.GetByClient(client.CLientId);
                  RelativesBLL.Delete(rel);
            }

            #endregion

            //session fore firing the jquery notify
            string message = "CLient has been Updated";
            Response.Redirect("/Clients/Clients.aspx?message=" + message, false);
        }
        catch (Exception ex)
        {
            string message = ex.Message;
            Response.Redirect("/Clients/Clients.aspx?message=" + message);

        }
    }





}