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
using Countreis.CountryList;
using System.Data.SqlClient;
using System.Threading;

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
            pnlClient.Visible = true;
            pnlFinal.Visible = false;
            

        }
    
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        client.AccountNumber = txtAccNum.Text;
        client.FirstName = txtFName.Text;
        client.MiddleName = txtMiddleName.Text;
        client.SurrName = txtSurrName.Text;

        pnlRelTxtAccNum.Text = client.AccountNumber;
        pnlRelTxtClientName.Text = client.FullName;

        pnlClient.Visible = false;
        pnlRelation.Visible = true;
        pnlFinal.Visible = true;
    }
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
            pnlClient.Visible = false;
            pnlRel.Visible = true;
            BindClients();
        }
        else
        {
            pnlClient.Visible = false;
            pnlRel.Visible = false;

        }
    }



    void BindClients()
    {
        drpClients.DataSource = ClientBLL.GetList();
        drpClients.DataTextField = "FullName";
        drpClients.DataValueField = "ClientId";
        drpClients.DataBind();

    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        pnlClient.Visible = true;
        pnlRelation.Visible = false;
        pnlFinal.Visible = false;
    }

    //Saving The Data TODO{ CommitTransAction() }
    protected void btnWaitList_Click(object sender, EventArgs e)
    {
        try
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

                //session fore firing the jquery notify
                string message = "CLient has been sent to the WaitingList";
                Response.Redirect("/Clients/Clients.aspx?message="+message,false);

        }
        catch (Exception ex)
        {
            string message = ex.Message;
            Response.Redirect("/Clients/Clients.aspx?message=" + message);
        }
    }
    protected void btnAppointMent_Click(object sender, EventArgs e)
    {
        //TODO
    }


}