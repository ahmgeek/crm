using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;


namespace Panda.EmaraSystem.DAL
{
    public class FirstCallDAL
    {

        public static FirstCall GetItem(int id)
        {
            FirstCall firstCall = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_FirstCallGetItem", out con,
                DataManager.CreateParameter("@id", SqlDbType.Int, id)))
            {


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        firstCall = FillDataRecord(dr);
                    }
                }


                else
                {
                    throw new Exception("No Data");
                }
                con.Close();
            }
            return firstCall;
        }
        public static FirstCall GetByCase(int caseId)
        {
            FirstCall firstCall = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_FirstCallGetByCase", out con,
                DataManager.CreateParameter("@caseId", SqlDbType.Int, caseId)))
            {


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        firstCall = FillDataRecord(dr);
                    }
                }


                else
                {
                    throw new Exception("No Data");
                }
                con.Close();
            }
            return firstCall;
        }

        public static List<FirstCall> GetList()
        {
            List<FirstCall> list = new List<FirstCall>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_FirstCallGetAll", out con))
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

        public static int Insert(FirstCall firstCall)
        {
            object o = DataManager.ExecuteScalar("ESystem_FirstCallUpdate",
             DataManager.CreateParameter("@caseId", SqlDbType.Int, firstCall.CaseId),
             DataManager.CreateParameter("@dateTime", SqlDbType.NVarChar, firstCall.dateTime),
             DataManager.CreateParameter("@report", SqlDbType.NVarChar, firstCall.Report),
             DataManager.CreateParameter("@techReport", SqlDbType.NVarChar, firstCall.TechnichalReport),
             DataManager.CreateParameter("@visitDate", SqlDbType.DateTime, firstCall.VisitDate),
             DataManager.CreateParameter("@visitTime", SqlDbType.NVarChar, firstCall.VisitTime),
             DataManager.CreateParameter("@status", SqlDbType.Int, firstCall.Status),
             DataManager.CreateParameter("@notes", SqlDbType.NVarChar, firstCall.Notes),
             DataManager.CreateParameter("@createdBy", SqlDbType.NVarChar, firstCall.CreatedBy)
             );

            return Convert.ToInt32(o);
        }
        
        public static int Update(FirstCall firstCall)
        {

            object o = DataManager.ExecuteScalar("ESystem_ClientUpdate",
                DataManager.CreateParameter("@fCallId", SqlDbType.Int, firstCall.FcallId),
                DataManager.CreateParameter("@caseId", SqlDbType.Int, firstCall.CaseId),
                DataManager.CreateParameter("@dateTime", SqlDbType.NVarChar, firstCall.dateTime),
                DataManager.CreateParameter("@report", SqlDbType.NVarChar, firstCall.Report),
                DataManager.CreateParameter("@techReport", SqlDbType.NVarChar, firstCall.TechnichalReport),
                DataManager.CreateParameter("@visitDate", SqlDbType.DateTime, firstCall.VisitDate),
                DataManager.CreateParameter("@visitTime", SqlDbType.NVarChar, firstCall.VisitTime),
                DataManager.CreateParameter("@status", SqlDbType.Int, firstCall.Status),
                DataManager.CreateParameter("@notes", SqlDbType.NVarChar, firstCall.Notes),
                DataManager.CreateParameter("@createdBy", SqlDbType.NVarChar, firstCall.CreatedBy));
            return Convert.ToInt32(o);
        }
        public static int UpdateByCase(FirstCall firstCall)
        {

            object o = DataManager.ExecuteScalar("ESystem_FirstCallUpdateByCase",
                DataManager.CreateParameter("@caseId", SqlDbType.Int, firstCall.CaseId),
                DataManager.CreateParameter("@dateTime", SqlDbType.NVarChar, firstCall.dateTime),
                DataManager.CreateParameter("@report", SqlDbType.NVarChar, firstCall.Report),
                DataManager.CreateParameter("@techReport", SqlDbType.NVarChar, firstCall.TechnichalReport),
                DataManager.CreateParameter("@visitDate", SqlDbType.DateTime, firstCall.VisitDate),
                DataManager.CreateParameter("@visitTime", SqlDbType.NVarChar, firstCall.VisitTime),
                DataManager.CreateParameter("@status", SqlDbType.Int, firstCall.Status),
                DataManager.CreateParameter("@notes", SqlDbType.NVarChar, firstCall.Notes));
            return Convert.ToInt32(o);
        }

        private static FirstCall FillDataRecord(IDataRecord myDataRecord)
        {
            FirstCall firstCall = new FirstCall();

            firstCall.FcallId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("FcallId"));

            firstCall.CaseId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CaseId"));

            
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("dateTime")))
            {
                firstCall.dateTime = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("dateTime"));

            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Report")))
            {
                firstCall.Report = myDataRecord.GetString(myDataRecord.GetOrdinal("Report"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("TechnichalReport")))
            {
                firstCall.TechnichalReport = myDataRecord.GetString(myDataRecord.GetOrdinal("TechnichalReport"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("VisitDate")))
            {
                firstCall.VisitDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("VisitDate"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("VisitTime")))
            {
                firstCall.VisitTime = myDataRecord.GetString(myDataRecord.GetOrdinal("VisitTime"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Status")))
            {
                firstCall.Status = (FirstCallStatus)myDataRecord.GetInt32(myDataRecord.GetOrdinal("Status"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Notes")))
            {
                firstCall.Notes = myDataRecord.GetString(myDataRecord.GetOrdinal("Notes"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CreatedBy")))
            {
                firstCall.CreatedBy = myDataRecord.GetString(myDataRecord.GetOrdinal("CreatedBy"));
            }


            return firstCall;
        }

    }
}
