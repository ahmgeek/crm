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

        public static List<SessionQuestion> GetList()
        {
            return SessionQuestionDAL.GetList();
        }
        //
        public static List<SessionQuestion> GetClientList(int clientId)
        {
            return SessionQuestionDAL.GetClientList(clientId);
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

        public static bool Delete(SessionQuestion sessionQuestion)
        {
            return SessionQuestionDAL.Delete(sessionQuestion.SessionQuestionId);
        }


    }
}
