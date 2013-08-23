using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Panda.EmaraSystem.BO;


namespace Panda.EmaraSystem.BO
{
    public class SessionDAL
    {


        public static Session GetItem(int id)
        {
            Session session = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_SessionGetById", out con,
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
        public static Session GetByClient(int id)
        {
            Session session = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_SessionGetByClient", out con,
                DataManager.CreateParameter("@clientid", SqlDbType.Int, id)))
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
        public static Session GetByDate(DateTime date)
        {
            Session session = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_SessionGetByClient", out con,
                DataManager.CreateParameter("@date", SqlDbType.Int, date)))
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

        public static List<Session> GetList()
        {
            List<Session> list = new List<Session>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_SessionGeAll", out con))
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

        public static int Insert(Session Session)
        {
            int result = 0;
            result = (int)DataManager.ExecuteScalar("ESystem_RelativeInsert",
             DataManager.CreateParameter("@ClientId", SqlDbType.Int, Session.ClientId),
             DataManager.CreateParameter("@stuffid", SqlDbType.UniqueIdentifier, Session.StuffId),
             DataManager.CreateParameter("@datetime", SqlDbType.DateTime, Session.DateTime),
             DataManager.CreateParameter("@report", SqlDbType.NVarChar, Session.Report),
             DataManager.CreateParameter("@notes", SqlDbType.NVarChar, Session.Notes),
             DataManager.CreateParameter("@isactive", SqlDbType.Bit, Session.IsActive));

            return result;
        }

        public static int Update(Session Session)
        {
            int result = 0;

            result = (int)DataManager.ExecuteScalar("ESystem_RelativeUpdate",
             DataManager.CreateParameter("@sessionid", SqlDbType.Int,Session.SessionId),
             DataManager.CreateParameter("@ClientId", SqlDbType.Int, Session.ClientId),
             DataManager.CreateParameter("@stuffid", SqlDbType.UniqueIdentifier, Session.StuffId),
             DataManager.CreateParameter("@datetime", SqlDbType.DateTime, Session.DateTime),
             DataManager.CreateParameter("@report", SqlDbType.NVarChar, Session.Report),
             DataManager.CreateParameter("@notes", SqlDbType.NVarChar, Session.Notes),
             DataManager.CreateParameter("@isactive", SqlDbType.Bit, Session.IsActive));


            return result;
        }

        public static bool Delete(int id)
        {
            int result = 0;
            result = DataManager.ExecuteNonQuery("ESystem_SessionDelete",
                   DataManager.CreateParameter("@sessionid", SqlDbType.Int, id));

            return result > 0;
        }

        private static Session FillDataRecord(IDataRecord myDataRecord)
        {
            Session session = new Session();

            session.SessionId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("SessionId"));
            session.ClientId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("ClientId"));
            session.StuffId = myDataRecord.GetGuid(myDataRecord.GetOrdinal("StuffId"));
            session.DateTime = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("DateTime"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Report")))
            {
                session.Report = myDataRecord.GetString(myDataRecord.GetOrdinal("Report"));

            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Notes")))
            {
                session.Notes = myDataRecord.GetString(myDataRecord.GetOrdinal("Notes"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IsActive")))
            {
                session.IsActive = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("IsActive"));
            }
            return session;
        }
    }
}
