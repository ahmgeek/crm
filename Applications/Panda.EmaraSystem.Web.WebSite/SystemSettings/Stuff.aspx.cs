using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Panda.EmaraSystem.BLL;
using Panda.EmaraSystem.BO;
using Notification.Helper;

public partial class SystemSettings_Stuff : System.Web.UI.Page
{


    private Guid stuffId = Guid.Empty;
    private string stuffName;
    UsersBLL u = new UsersBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.ToString() != string.Empty)
        {
            // getting the Id of the user
            stuffId = (Guid)u.GetUser(Request.QueryString["name"].ToString()).ProviderUserKey;
            stuffName = Request.QueryString["name"].ToString();
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (!IsPostBack)
        {
            if (stuffId != Guid.Empty)
            {
                try
                {
                    Data();
                    btnSave.Visible = true;
                    btnInsert.Visible = false;
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    ClientScript.RegisterStartupScript(this.GetType(), "Info", HelperNotify.HelperMessage("Warning", message, HelperNotify.NotificationType.info));
                    btnInsert.Visible = true;
                    btnSave.Visible = false;

                }

            }





        }
    }


    private void Data()
    {
        Stuff myStuff = StuffBLL.GetItem(stuffName);
        txtFName.Text = myStuff.FirstName;
        txtSurrName.Text = myStuff.SurrName;
        txtDateOf.Text = myStuff.DateOfBirth.ToShortDateString();
        txtMob.Text = myStuff.Mob;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Stuff stuff = new Stuff();
        stuff.StuffId = stuffId;
        stuff.FirstName = txtFName.Text;
        stuff.SurrName = txtSurrName.Text;
        stuff.DateOfBirth = Convert.ToDateTime(txtDateOf.Text);
        stuff.Mob = txtMob.Text;
        StuffBLL.Update(stuff);
        this.ShowHelperMessage("Updated","Data Has Been Updated", HelperNotify.NotificationType.success);
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Stuff stuff = new Stuff();
        stuff.StuffId = stuffId;
        stuff.FirstName = txtFName.Text;
        stuff.SurrName = txtSurrName.Text;
        stuff.DateOfBirth = Convert.ToDateTime(txtDateOf.Text);
        stuff.Mob = txtMob.Text;
        StuffBLL.Insert(stuff);
        this.ShowHelperMessage("Saved", "Data Has Been Saved", HelperNotify.NotificationType.success);
    }
}