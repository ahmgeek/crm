using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Countreis.CountryList;
using Notification.Helper;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;

public partial class Clients_ClientsDetail : System.Web.UI.Page
{
    UsersBLL user = new UsersBLL();
    string userName;
    int clientID = 0;


   
    protected void Page_Load(object sender, EventArgs e)
    {
        userName = user.GetUser().UserName;

        if (!IsPostBack)
        {
            if (Request.QueryString.ToString() != string.Empty)
            {
                clientID =Convert.ToInt32(Request.QueryString["id"]);
                 
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
        try
        {

 
        Client client = ClientBLL.GetItem(Convert.ToInt32(Request.QueryString["id"]));
        int id        = Convert.ToInt32(Request.QueryString["id"]);



            if (client.HasArelation == HasRelations.yes)
            {
                Application["flag"]       = "true";
                rdlst.SelectedIndex       = 0;
                drpClients.DataSource = ClientBLL.GetList();
                drpClients.DataTextField = "FullName";
                drpClients.DataValueField = "ClientId";
                drpClients.DataBind();
                Relatives rel = RelativesBLL.GetItem(id);
                txtRelName.Text = rel.RelationName;
                drpClients.SelectedItem.Text = rel.ClientRelName;
            }
            else
            {
                Application["flag"] = "false";
                pnlRelationData.Visible = false;
                rdlst.SelectedIndex = 1;
            }

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
        txtNotes.Text = client.Notes;
        }
        catch (Exception ex)
        {
            this.ShowHelperMessage("Error",ex.Message, HelperNotify.NotificationType.error );
        }
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
                Application["flag"] = "false";
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
            int id                          = Convert.ToInt32(Request.QueryString["id"]);
            client.CLientId                 = id;
            client.FirstName                = txtFName.Text;
            client.MiddleName               = txtMiddleName.Text;
            client.SurrName                 = txtSurrName.Text;
            client.City                     = txtCity.Text  ;
            client.Country                  = drpCountry.SelectedItem.Text;
            client.Address                  = txtAdress.Text;
            client.Telephone                = txtTelephone.Text;
            client.Mob                      = txtMob.Text;
            client.DateOfBirth              = Convert.ToDateTime(txtDateOf.Text);
            client.Gender                   = drpGender.SelectedItem.Text;
            client.Notes                    = txtNotes.Text;
            client.CreatedBy                = ClientBLL.GetItem(id).CreatedBy;
            client.CreationDate             = ClientBLL.GetItem(id).CreationDate;
            client.IsActive                 = IsActive.Active;


            

            #endregion

            #region Relation Data
            if (Application["flag"] == "true")
            {
                if (rdlst.SelectedIndex == 0)
                {
                    Relatives relative = new Relatives();
                    relative.ClientId = Convert.ToInt32(Request.QueryString["id"]);
                    relative.CLientRelId = Convert.ToInt32(drpClients.SelectedItem.Value);
                    relative.RelationName = txtRelName.Text;
                    RelativesBLL.Update(relative);
                    client.HasArelation = HasRelations.yes;
                    clientID = ClientBLL.Update(client);
                }
            }
            else
            {
                if (rdlst.SelectedIndex == 0)
                {
                    Relatives rel = new Relatives();
                    rel.ClientId = Convert.ToInt32(Request.QueryString["id"]);
                    rel.CLientRelId = Convert.ToInt32(drpClients.SelectedItem.Value);
                    rel.RelationName = txtRelName.Text;
                    RelativesBLL.Insert(rel);
                    client.HasArelation = HasRelations.yes;
                    clientID = ClientBLL.Update(client);
                }
                else
                {
                        List<Relatives> rel = RelativesBLL.GetByClient(Convert.ToInt32(Request.QueryString["id"]));
                        foreach (Relatives item in rel)
                        {
                            RelativesBLL.Delete(item);
                        }
                        client.HasArelation = HasRelations.no;
                        clientID = ClientBLL.Update(client);
                }
            }
            #endregion

            //session fore firing the jquery notify
            string message = "CLient has been Updated";
            Response.Redirect("/Clients/Clients.aspx?message=" + message, false);
        }
        catch (Exception ex)
        {
            string message = ex.Message.Replace("\n"," ");
            Response.Redirect("/Clients/Clients.aspx?message=" + message, false);

        }
    }


    protected void btnCanel_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("/Clients/Clients.aspx");
    }
}