using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using Panda.EmaraSystem.BO;

namespace Panda.EmaraSystem.BLL
{

    public class UsersBLL
    {
        RolesBLL rol = new RolesBLL();

        public string Name { get; set; }
        public string Email { get; set; }




        public string CreatUser(string UserName,string Email,String Password,string[] UserRoles)
        {
             
            MembershipCreateStatus createStatus;
            MembershipUser newUser = Membership.CreateUser(UserName, Password, Email, null, null, true, out createStatus);
            switch (createStatus)
            {
                case MembershipCreateStatus.Success:
                    Roles.AddUserToRoles(UserName, UserRoles);
                   throw new Exception("The user account was successfully created!");
                   break;
                case MembershipCreateStatus.DuplicateUserName:
                    throw new Exception("There already exists a user with this username.");
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    throw new Exception("There already exists a user with this email address.");
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    throw new Exception("There email address you provided in invalid.");
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    throw new Exception("There security answer was invalid.");
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    throw new Exception("The password you provided is invalid. It must be seven characters long and have at least one non-alphanumeric character.");
                    break;
                default:
                    throw new Exception("There was an unknown error; the user account was NOT created.");
                    break;
            }

        }


        public MembershipUserCollection GetAllUsers()
        {
           return Membership.GetAllUsers();
        }


        public bool DeleteUser(string username)
        {
           return  Membership.DeleteUser(username);
        }


        public MembershipUser GetUser(string name)
        {
            MembershipUser u = Membership.GetUser(name);
            Name = u.UserName;
            Email = u.Email;
            return u;
        }
        public string[] UserRoles(string username)
        {
            MembershipUser mu = Membership.GetUser(username);
            string user = mu.UserName;

            string[] roles = Roles.GetRolesForUser(user);
            return roles;
        }

    }
}
