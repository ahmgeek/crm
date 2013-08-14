using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESystem.BLL;
using ESystem.Entities;



public partial class Clients_RelClients : System.Web.UI.Page
{


    ClientBLL clntBLL = new ClientBLL();
    ClientENT clntENT = new ClientENT();

    protected void Page_Load(object sender, EventArgs e)
    {


        
            if (Request.QueryString.ToString() != string.Empty)
            {
                drpClients.DataBind();
                int id = Convert.ToInt32(Request.QueryString["Acc"].ToString());
                txtAccNum.Text= clntBLL.GetClientById(id).AccountNumer;
                txtClientName.Text = clntBLL.GetClientById(id).FullName;
            }
            else
            {
                Response.Redirect("/Clients/Clients.aspx");

            }
        

    }



    protected void rdlst_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (HasArelation())
        {
            pnlRel.Visible = true;
            BindClients();
        }
        else
        {
            pnlRel.Visible = false;

        }
    }




    void BindClients()
    {
        int id = Convert.ToInt32(Request.QueryString["Acc"].ToString());
        drpClients.DataSource = clntBLL.GetAllClientsExcept(id);
        drpClients.DataTextField = "Name";
        drpClients.DataValueField = "ClientId";
        drpClients.DataBind();
    }

    protected void btnWaitList_Click(object sender, EventArgs e)
    {
        if (HasArelation())
        {
            //TODO Save in relatives table & wait List
        }

        else
        {
            //TODO dave in wait List
        }
    }


    protected void btnAppointMent_Click(object sender, EventArgs e)
    {

    }

    public bool HasArelation()
    {
        if (rdlst.SelectedIndex==0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}