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
            Sessions session = SessionDAL.GetItem(id);
            if (session != null)
            {
                session.SessionQuestions = SessionQuestionDAL.GetBySession(id);
            }
            return session;
        }
        
        public static Sessions GetByCase(int id)
        {
            Sessions session = SessionDAL.GetByCase(id);
            if (session != null)
            {
                session.SessionQuestions = SessionQuestionDAL.GetBySession(session.SessionId);
            }
            return session;
        }


        public static int Insert(Sessions session)
        {
            session.SessionId = SessionDAL.Insert(session);
            return session.SessionId;
        }

        public static int Update(Sessions session)
        {
            session.SessionId = SessionDAL.Update(session);
            return session.SessionId;
        }


        public static int UpdateByCase(Sessions session)
      {
          session.CaseId = SessionDAL.UpdateByCase(session);
          return session.CaseId;
      }


        //public static bool Delete(Sessions session)
        //{
        //    return SessionDAL.Delete(session.SessionId);
        //}


    }
}
