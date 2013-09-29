using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;

namespace Panda.EmaraSystem.DAL
{
    public class SessionQuestionDAL
    {


        public static SessionQuestion GetItem(int id)
        {
            SessionQuestion session = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_SessionQuestionGetById", out con,
                DataManager.CreateParameter("@sessionQuestionid", SqlDbType.Int, id)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        session = FillDataRecord(dr);
                    }
                }
                else
                {
                    throw new Exception("No Data");

                }

                con.Close();
            }
            return session;
        }


        public static List<SessionQuestion> GetByCase(int caseId)
        {
            List<SessionQuestion> list = new List<SessionQuestion>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_SessionQuestionByCase", out con,
                DataManager.CreateParameter("@id", SqlDbType.Int, caseId)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(FillDataRecord(dr));
                    }
                }
                else
                {
                    throw new Exception("No Data");
                }

                con.Close();
            }
            return list;
        }

        public static List<SessionQuestion> GetBySession(int sessionId)
        {
            List<SessionQuestion> list = new List<SessionQuestion>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_SessionQuestionGetBySession", out con,
                DataManager.CreateParameter("@sessionid", SqlDbType.Int, sessionId)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(FillDataRecord(dr));
                    }
                }
                else
                {
                    throw new Exception("No Data");
                }

                con.Close();
            }
            return list;

        }

        public static int Insert(SessionQuestion sessionQuestion)
        {
             Object o = DataManager.ExecuteScalar("ESystem_SessionQuestionInsert",
             DataManager.CreateParameter("@sessionid", SqlDbType.Int, sessionQuestion.SessionId),
             DataManager.CreateParameter("@question", SqlDbType.NVarChar, sessionQuestion.Question),
             DataManager.CreateParameter("@answer", SqlDbType.NVarChar, sessionQuestion.Answer));

            return Convert.ToInt32(o);
        }

        public static int Update(SessionQuestion sessionQuestion)
        {

            Object o = DataManager.ExecuteScalar("ESystem_SessionQuestionUpdate",
             DataManager.CreateParameter("@sessionquestionid", SqlDbType.Int, sessionQuestion.SessionQuestionId),
             DataManager.CreateParameter("@sessionid", SqlDbType.Int, sessionQuestion.SessionId),
             DataManager.CreateParameter("@question", SqlDbType.NVarChar, sessionQuestion.Question),
             DataManager.CreateParameter("@answer", SqlDbType.NVarChar, sessionQuestion.Answer));

            return Convert.ToInt32(o);
        }
        //TODO Update By SessionId
        private static SessionQuestion FillDataRecord(IDataRecord myDataRecord)
        {
            SessionQuestion sessionQuestion = new SessionQuestion();

            sessionQuestion.SessionQuestionId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("SessionQuestionId"));

            sessionQuestion.SessionId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("SessionId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Question")))
            {
                sessionQuestion.Question = myDataRecord.GetString(myDataRecord.GetOrdinal("Question"));

            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Answer")))
            {
                sessionQuestion.Answer = myDataRecord.GetString(myDataRecord.GetOrdinal("Answer"));
            }

            return sessionQuestion;
        }




    }
}
