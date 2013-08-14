using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ESystem.BLL;

public partial class SystemSetting_Users : System.Web.UI.Page {

    private int rankUser = 0;
    private int currentPageUser = 0;

    UsersBLL userBLL = new UsersBLL();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindGrid();
            btnDeleteUser.Enabled = false;

            if (Request.QueryString["suc"]=="true")
            {
                string script = HelperNotify.HelperMessage("Succeded", "Role Inserted ! ", HelperNotify.NotificationType.success);
                ClientScript.RegisterStartupScript(this.GetType(), "pnotify", script);                

            }
            else if(Request.QueryString["suc"]=="false")
            {
                string script = HelperNotify.HelperMessage("Error", "Role Exist ! ", HelperNotify.NotificationType.error);
                ClientScript.RegisterStartupScript(this.GetType(), "pnotify", script);                
            }



        }
    }

    void BindGrid()
    {

        grdUsers.DataSource = userBLL.GetAllUsers();
        grdUsers.DataBind();
    }



    protected void grdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        currentPageUser = e.NewPageIndex;
        grdUsers.PageIndex = e.NewPageIndex;
    }




   
    protected void btnDeleteUser_Click(object sender, EventArgs e)
    {
        CheckBox chkUser;
        string username;
        Literal litName;
        foreach (GridViewRow row in grdUsers.Rows)
        {
            chkUser = (CheckBox)row.Cells[0].FindControl("chkUser");
            if (chkUser.Checked)
            {
                litName = (Literal)row.Cells[0].FindControl("LitUserName");
                username = litName.Text;
                userBLL.DeleteUser(username);
            }
        }
        Response.Redirect("/SystemSettings/Users.aspx");
        BindGrid();
    }


    protected void grdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblRank = (Label)e.Row.FindControl("lblRank");
        // On page reload, rank is reset to 0
        if (rankUser == 0)
        {
            // Only run this on subsequent pages
            if (currentPageUser > 0)
            {
                // Set rank to current index of page * the number of records to display on GridView page
                rankUser = currentPageUser * grdUsers.PageSize;
            }
        }
        // Make sure we actually found our label
        if (lblRank != null)
        {
            // Increment rank by 1
            rankUser += 1;
            // Set rank label to our new rank value
            lblRank.Text = rankUser.ToString();
        }

    }



    protected void chkUser_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkUser;
        CheckBox chkAllUser;
        foreach (GridViewRow row in grdUsers.Rows)
        {
            chkUser = (CheckBox)row.Cells[0].FindControl("chkUser");
            chkAllUser = (CheckBox)grdUsers.HeaderRow.Cells[0].FindControl("chkAllUser");
            if (chkUser.Checked)
            {
                chkAllUser.Checked = false;
                btnDeleteUser.Enabled = true;
                return;
            }
        }
        btnDeleteUser.Enabled = false;
    }
    protected void chkAllUser_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkallUser = (CheckBox)sender;
        btnDeleteUser.Enabled = chkallUser.Checked;
        CheckBox chkUSer;
        foreach (GridViewRow row in grdUsers.Rows)
        {
            chkUSer = (CheckBox)row.Cells[0].FindControl("chkUser");
            chkUSer.Checked = chkallUser.Checked;
        }
    }



}