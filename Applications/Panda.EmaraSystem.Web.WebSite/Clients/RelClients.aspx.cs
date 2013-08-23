using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;



public partial class Clients_RelClients : System.Web.UI.Page
{


    Client clntBO = new Client();

    protected void Page_Load(object sender, EventArgs e)
    {


        
            if (Request.QueryString.ToString() != string.Empty)
            {
                drpClients.DataBind();
                int id = Convert.ToInt32(Request.QueryString["Acc"].ToString());
                txtAccNum.Text= ClientBLL.GetItem(id).AccountNumber;
                txtClientName.Text = ClientBLL.GetItem(id).FullName;
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
        drpClients.DataSource = ClientBLL.GetList();
        drpClients.DataTextField = "FullName";
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