using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;


namespace Panda.EmaraSystem.BLL
{
  public class StuffBLL
    {
        public static Stuff GetItem(string name)
        {
            MembershipUser u = Membership.GetUser(name);
            Guid id =(Guid) u.ProviderUserKey;
            return StuffDAL.GetItem(id);
        }

        public static List<Stuff> GetList()
        {
            return StuffDAL.GetList();
        }

       
        public static Guid Insert(Stuff stuff)
        {
            stuff.StuffId = StuffDAL.Insert(stuff);
            return stuff.StuffId;
        }
        public static Guid Update(Stuff stuff)
        {
            stuff.StuffId = StuffDAL.Update(stuff);
            return stuff.StuffId;
        }
        public static bool Delete(Stuff stuff)
        {
            return StuffDAL.Delete(stuff.StuffId);
        }
    }
}
