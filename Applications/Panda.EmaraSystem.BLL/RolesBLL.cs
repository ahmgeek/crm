using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;


namespace Panda.EmaraSystem.BLL
{
    public class RolesBLL {
        public void CreatRole(string Rolename)
        {

            if (!Roles.RoleExists(Rolename))
            {
                Roles.CreateRole(Rolename);
            }
            else
                throw new Exception("The role alredy exisits");
        }

        public string[] AllRoles()
        {
            return Roles.GetAllRoles();
        }
        public void DeleteRole(string RoleName)
        {
            Roles.DeleteRole(RoleName);
        }


        public void AddUserToRole(string name, string[] role)
        {
            Roles.AddUserToRoles(name, role);
        }

    }
}
