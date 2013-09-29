using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Panda.EmaraSystem.BO;


namespace Panda.EmaraSystem.DAL
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
        public static Sessions GetByCase(int caseId)
        {
            Sessions session = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_SessionGetByCase", out con,
                DataManager.CreateParameter("@caseId", SqlDbType.Int, caseId)))
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
        

        public static int Insert(Sessions Session)
        {
            object o = DataManager.ExecuteScalar("ESystem_SessionInsert",
             DataManager.CreateParameter("@caseId", SqlDbType.Int, Session.CaseId),
             DataManager.CreateParameter("@report", SqlDbType.NVarChar, Session.Report),
             DataManager.CreateParameter("@notes", SqlDbType.NVarChar, Session.Notes));

             return Convert.ToInt32(o);
        }

        public static int Update(Sessions Session)
        {
            object o = DataManager.ExecuteScalar("ESystem_SessionUpdate",
             DataManager.CreateParameter("@sessionid", SqlDbType.Int, Session.SessionId),
             DataManager.CreateParameter("@caseId", SqlDbType.Int, Session.CaseId),
             DataManager.CreateParameter("@report", SqlDbType.NVarChar, Session.Report),
             DataManager.CreateParameter("@notes", SqlDbType.NVarChar, Session.Notes));

            return Convert.ToInt32(o);
        }

        //Update By Case
        public static int UpdateByCase(Sessions Session)
        {
            object o = DataManager.ExecuteScalar("ESystem_SessionUpdateByCase",
             DataManager.CreateParameter("@caseId", SqlDbType.Int, Session.CaseId),
             DataManager.CreateParameter("@report", SqlDbType.NVarChar, Session.Report),
             DataManager.CreateParameter("@notes", SqlDbType.NVarChar, Session.Notes));

            return Convert.ToInt32(o);
        }


        private static Sessions FillDataRecord(IDataRecord myDataRecord)
        {
            Sessions session = new Sessions();

            session.SessionId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("SessionId"));
            session.CaseId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CaseId"));


            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Report")))
            {
                session.Report = myDataRecord.GetString(myDataRecord.GetOrdinal("Report"));

            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Notes")))
            {
                session.Notes = myDataRecord.GetString(myDataRecord.GetOrdinal("Notes"));
            }

            return session;
        }
    }
}
