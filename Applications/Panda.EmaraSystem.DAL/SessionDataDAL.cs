using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Panda.EmaraSystem.BO;


namespace Panda.EmaraSystem.DAL
{
    public class SessionDataDAL
    {
        public static SessionData GetItem(int id)
        {
            SessionData sessionData = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_SessionDataGetById", out con,
                DataManager.CreateParameter("@sessionDataId", SqlDbType.Int, id)))
            {


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        sessionData = FillDataRecord(dr);
                    }
                }


                else
                {
                    throw new Exception("No Data");
                }
                con.Close();
            }
            return sessionData;
        }

        public static List<SessionData> GetList()
        {
            List<SessionData> list = new List<SessionData>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_SessionDataGetAll", out con))
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

        public static int Insert(SessionData sessionData)
        {
            object o = DataManager.ExecuteScalar("ESystem_SessionDataInsert",
             DataManager.CreateParameter("@questionName", SqlDbType.NVarChar,sessionData.SessionQuestion ));             );

            return Convert.ToInt32(o);
        }

        public static int Update(SessionData sessionData)
        {

            object o = DataManager.ExecuteScalar("ESystem_SessionDataUpdate",
             DataManager.CreateParameter("@sessionDataId", SqlDbType.Int, sessionData.SessionDataId),
             DataManager.CreateParameter("@questionName", SqlDbType.NVarChar,sessionData.SessionQuestion));
            return Convert.ToInt32(o);
        }

        public static bool Delete(int id)
        {
            int result = 0;
            result = DataManager.ExecuteNonQuery("ESystem_SessionDataDelete",
                   DataManager.CreateParameter("@sessionDataId", SqlDbType.Int, id));

            return result > 0;
        }


        private static SessionData FillDataRecord(IDataRecord myDataRecord)
        {
            SessionData sessionData = new SessionData();

            sessionData.SessionDataId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("SessionDataID"));

            sessionData.SessionQuestion = myDataRecord.GetString(myDataRecord.GetOrdinal("SessionQuestion"));



            return sessionData;
        }

    }
}
