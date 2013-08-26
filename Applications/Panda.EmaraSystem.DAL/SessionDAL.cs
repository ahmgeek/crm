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


        public static Sessions GetItem(int id)
        {
            Sessions session = null;
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
        public static Sessions GetByClient(int id)
        {
            Sessions session = null;
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
        public static Sessions GetByDate(DateTime date)
        {
            Sessions session = null;
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

        public static List<Sessions> GetList()
        {
            List<Sessions> list = new List<Sessions>();
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
        public static List<Sessions> GetUnServedList()
        {
            List<Sessions> list = new List<Sessions>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_SessionGetUnServed", out con))
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
        public static List<Sessions> GetServedList()
        {
            List<Sessions> list = new List<Sessions>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_SessionGetServed", out con))
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

        public static int Insert(Sessions Session)
        {
            object o = DataManager.ExecuteScalar("ESystem_SessionInsert",
             DataManager.CreateParameter("@ClientId", SqlDbType.Int, Session.ClientId),
             DataManager.CreateParameter("@datetime", SqlDbType.DateTime, Session.DateTime),
             DataManager.CreateParameter("@report", SqlDbType.NVarChar, Session.Report),
             DataManager.CreateParameter("@notes", SqlDbType.NVarChar, Session.Notes),
             DataManager.CreateParameter("@isactive", SqlDbType.Bit, Session.IsActive));

             return Convert.ToInt32(o);
        }


        public static bool Delete(int id)
        {
            int result = 0;
            result = DataManager.ExecuteNonQuery("ESystem_SessionDelete",
                   DataManager.CreateParameter("@sessionid", SqlDbType.Int, id));

            return result > 0;
        }

        private static Sessions FillDataRecord(IDataRecord myDataRecord)
        {
            Sessions session = new Sessions();

            session.SessionId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("SessionId"));
            session.ClientId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("ClientId"));
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
                session.IsActive = (IsActive)myDataRecord.GetInt32(myDataRecord.GetOrdinal("IsActive"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IsServed")))
            {
                session.IsServed = (IsServed)myDataRecord.GetInt32(myDataRecord.GetOrdinal("IsServed"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FullName")))
            {
                session.FullName = myDataRecord.GetString(myDataRecord.GetOrdinal("FullName"));
            }

            return session;
        }
    }
}
