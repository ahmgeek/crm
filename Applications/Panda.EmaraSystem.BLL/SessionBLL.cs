using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;

namespace Panda.EmaraSystem.BLL
{
   public class SessionBLL
    {
        public static Sessions GetItem(int id)
        {
            return SessionDAL.GetItem(id);
        }
        //

        public static Sessions GetByClient(int id)
        {
            return SessionDAL.GetByClient(id);
        }

        public static List<Sessions> GetList()
        {
            return SessionDAL.GetList();
        }

        public static List<Sessions> GetUnServed()
        {
            return SessionDAL.GetUnServedList();
        }

        public static List<Sessions> GetServed()
        {
            return SessionDAL.GetServedList();
        }


        public static int Insert(Sessions session)
        {
            session.SessionId = SessionDAL.Insert(session);
            return session.SessionId;
        }




        public static bool Delete(Sessions session)
        {
            return SessionDAL.Delete(session.SessionId);
        }


    }
}
