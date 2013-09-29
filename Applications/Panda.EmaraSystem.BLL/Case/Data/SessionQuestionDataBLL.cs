using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;

namespace Panda.EmaraSystem.BLL
{
   public class SessionQuestionDataBLL
    {
       public static SessionQuestionData GetItem(int id)
       {
           return SessionQuestionDataDAL.GetItem(id);
       }

       public static List<SessionQuestionData> GetList()
       {
           return SessionQuestionDataDAL.GetList();
       }

       public static int Insert(SessionQuestionData sessionData)
       {
           sessionData.SessionDataId = SessionQuestionDataDAL.Insert(sessionData);
           return sessionData.SessionDataId;
       }

       public static int update(SessionQuestionData sessionData)
       {
           sessionData.SessionDataId = SessionQuestionDataDAL.Update(sessionData);
           return sessionData.SessionDataId;
       }

       public static bool Delete(SessionQuestionData sessionData)
       {
           return SessionQuestionDataDAL.Delete(sessionData.SessionDataId);
       }
    }
}
