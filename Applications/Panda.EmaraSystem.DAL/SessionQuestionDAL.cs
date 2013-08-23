using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO
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

        public static SessionQuestion GetBySession(int id)
        {
            SessionQuestion session = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("SessionQuestion", out con,
                DataManager.CreateParameter("@sessionid", SqlDbType.Int, id)))
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


        public static List<SessionQuestion> GetList()
        {
            List<SessionQuestion> list = new List<SessionQuestion>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_SessionQuestionGetAll", out con))
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
            int result = 0;
            result = (int)DataManager.ExecuteScalar("ESystem_SessionQuestionInsert",
             DataManager.CreateParameter("@sessionid", SqlDbType.Int, sessionQuestion.SessionId),
             DataManager.CreateParameter("@question", SqlDbType.NVarChar, sessionQuestion.Question),
             DataManager.CreateParameter("@answer", SqlDbType.NVarChar, sessionQuestion.Answer));

            return result;
        }

        public static int Update(SessionQuestion sessionQuestion)
        {
            int result = 0;

            result = (int)DataManager.ExecuteScalar("ESystem_RelativeUpdate",
             DataManager.CreateParameter("@sessionquestionid", SqlDbType.Int, sessionQuestion.SessionQuestionId),
             DataManager.CreateParameter("@sessionid", SqlDbType.Int, sessionQuestion.SessionId),
             DataManager.CreateParameter("@question", SqlDbType.NVarChar, sessionQuestion.Question),
             DataManager.CreateParameter("@answer", SqlDbType.NVarChar, sessionQuestion.Answer));


            return result;
        }

        public static bool Delete(int id)
        {
            int result = 0;
            result = DataManager.ExecuteNonQuery("ESystem_SessionQuestionDelete",
                   DataManager.CreateParameter("@sessionQuestionid", SqlDbType.Int, id));

            return result > 0;
        }

        private static SessionQuestion FillDataRecord(IDataRecord myDataRecord)
        {
            SessionQuestion sessionQuestion = new SessionQuestion();

            sessionQuestion.SessionQuestionId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("SessionQuestionId"));
            sessionQuestion.SessionId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("SessionId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Question")))
            {
                sessionQuestion.Question = myDataRecord.GetString(myDataRecord.GetOrdinal("Question"));

            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Question")))
            {
                sessionQuestion.Question = myDataRecord.GetString(myDataRecord.GetOrdinal("Question"));
            }
            return sessionQuestion;
        }




    }
}
