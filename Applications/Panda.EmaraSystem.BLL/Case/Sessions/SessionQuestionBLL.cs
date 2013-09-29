using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;


namespace Panda.EmaraSystem.BLL
{
   public class SessionQuestionBLL
    {
        public static SessionQuestion GetItem(int id)
        {
            return SessionQuestionDAL.GetItem(id);
        }

        public static List<SessionQuestion> GetByCase(int id)
        {
            return SessionQuestionDAL.GetByCase(id);
        }
        
        public static List<SessionQuestion> GetBySession(int sessionId)
        {
            return SessionQuestionDAL.GetBySession(sessionId);
        }

        public static int Insert(SessionQuestion sessionQuestion)
        {
            sessionQuestion.SessionQuestionId = SessionQuestionDAL.Insert(sessionQuestion);
            return sessionQuestion.SessionQuestionId;
        }



        public static int Update(SessionQuestion sessionQuestion)
        {
            sessionQuestion.SessionQuestionId = SessionQuestionDAL.Update(sessionQuestion);
            return sessionQuestion.SessionQuestionId;

        }

        //public static bool Delete(SessionQuestion sessionQuestion)
        //{
        //    return SessionQuestionDAL.Delete(sessionQuestion.SessionQuestionId);
        //}


    }
}
