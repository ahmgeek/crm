using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;
using Notification.Helper;
using System.Threading;

public partial class Prescriptions_NewPrescriptions : System.Web.UI.Page
{
    int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.ToString() != string.Empty)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                BindGrid();
                BindRepeater();
                string[] cd = { "التعامل مع الناس", "مفجرات الثقة بالنفس" };
                for (int i = 0; i < cd.Length; i++)
                {
                    txtCD.Items.Add(cd[i]);
                }
            }

        }
        else
        {
            Response.Redirect("/Prescriptions/Prescriptions.aspx");
        }
    }

    private void BindGrid()
    {

        Client _client = ClientBLL.GetItem(id);
        List<Client> list = new List<Client>();
        list.Add(_client);
        grdUser.DataSource = list;
        grdUser.DataBind();
        BindDate();
    }
    private void BindDate()
    {
        lblDate.Text = DateTime.Now.ToShortDateString();
        lblTime.Text = DateTime.Now.ToShortTimeString();

        Sessions mySession = SessionBLL.GetByClient(id);
        txtReport.Text = mySession.Report;
    }
    private void BindRepeater()
    {
        List<SessionQuestion> list = SessionQuestionBLL.GetClientList(id);
        questionRepeater.DataSource = list;
        questionRepeater.DataBind();
    }


    protected void grdUser_PreRender(object sender, EventArgs e)
    {

        foreach (GridViewRow item in grdUser.Rows)
        {

            Label lblFullName = (Label)item.FindControl("lblFullName");
            lblFullName.CssClass = "label label-important";

            Label lblAccountNumber = (Label)item.FindControl("lblAccountNumber");
            lblAccountNumber.CssClass = "label label-info";

            Label lblcity = (Label)item.FindControl("lblcity");
            lblcity.CssClass = "label label-inverse";


            Label lblMob = (Label)item.FindControl("lblMob");
            lblMob.CssClass = "label label-success";

            Label lblBirth = (Label)item.FindControl("lblBirth");
            lblBirth.CssClass = "label label-inverse";


            Label lblgender = (Label)item.FindControl("lblgender");
            lblgender.CssClass = "label label-info";

            //
        }
    }
    protected void grdUser_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.CssClass = "success";

    }
}