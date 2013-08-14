using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESystem.BLL;
using ESystem.Entities;
using System.Collections;


public partial class SystemSettings_User : System.Web.UI.Page
{
    RolesBLL rolesBLL = new RolesBLL();
    UsersBLL userBll = new UsersBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindChk();
            if (Request.QueryString.Count > 0)
            {
                btnUpdate.Visible = true;
                btnSave.Visible = false;

                userBll.GetUser(Request.QueryString["name"].ToString());
                txtUserName.Text = userBll.Name;
                txtEmail.Text = userBll.Email;

            }
            else
            {

                btnUpdate.Visible = false;
                btnSave.Visible = true;

            }
            

        }
       
      
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        string[] arr;
        ArrayList roleList = new ArrayList();
        foreach (ListItem item in chkList.Items)
        {
            if (item.Selected)
            {
                roleList.Add(item.Text);
            }
        }

        arr = (string[])roleList.ToArray(typeof(string));

        userBll.CreatUser(txtUserName.Text, txtEmail.Text, txtPassword.Text, arr);

    }


    void bindChk()
    {
       chkList.DataSource= rolesBLL.AllRoles();
       chkList.DataBind();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

    }
}