using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Panda.EmaraSystem.BO;
using System.Data;

namespace Panda.EmaraSystem.DAL
{
   public class PrescriptionDAL
    {


       public static Prescription GetItem(int id)
       {
           Prescription prescription = null;
           SqlConnection con;
           using (SqlDataReader dr = DataManager.GetDataReader("ESystem_PrescriptionGetByid", out con,
               DataManager.CreateParameter("@prescid", SqlDbType.Int, id)))
           {
               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       prescription = FillDataRecord(dr);
                   }
               }
               else
               {
                   throw new Exception("No Data");

               }

               con.Close();
           }
           return prescription;
       }
       
       public static Prescription GetByCase(int caseId)
       {
           Prescription prescription = null;
           SqlConnection con;
           using (SqlDataReader dr = DataManager.GetDataReader("ESystem_PrescriptionGetByCase", out con,
               DataManager.CreateParameter("@caseId", SqlDbType.Int, caseId)))
           {
               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       prescription = FillDataRecord(dr);
                   }
               }
               else
               {
                   throw new Exception("No Data");

               }

               con.Close();
           }
           return prescription;
       }

       public static List<Prescription> GetList()
       {
           List<Prescription> list = new List<Prescription>();
           SqlConnection con;
           using (SqlDataReader dr =
               DataManager.GetDataReader("ESystem_PrescriptionGetAll", out con))
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


       public static int Insert(Prescription prescription)
        {
            object o = DataManager.ExecuteScalar("ESystem_PrescriptionInsert",
             DataManager.CreateParameter("@caseId", SqlDbType.Int, prescription.CaseId),
             DataManager.CreateParameter("@report", SqlDbType.NVarChar, prescription.Report),
             DataManager.CreateParameter("@status", SqlDbType.Int, prescription.Status),
             DataManager.CreateParameter("@confermedComment", SqlDbType.NVarChar, prescription.ConfermedComment));

            return Convert.ToInt32(o);
        }
       public static int Update(Prescription prescription)
       {
           object o = DataManager.ExecuteScalar("ESystem_PrescriptionUpdate",
             DataManager.CreateParameter("@prescid", SqlDbType.Int, prescription.PrescriptionId),
             DataManager.CreateParameter("@caseId", SqlDbType.Int, prescription.CaseId),
             DataManager.CreateParameter("@report", SqlDbType.NVarChar, prescription.Report),
             DataManager.CreateParameter("@status", SqlDbType.Int, prescription.Status),
             DataManager.CreateParameter("@confermedComment", SqlDbType.NVarChar, prescription.ConfermedComment));

           return Convert.ToInt32(o);
       }
       //Update By CaseId
       public static int UpdateByCase(Prescription prescription)
       {
           object o = DataManager.ExecuteScalar("ESystem_PrescriptionUpdateByCaseId",
             DataManager.CreateParameter("@caseId", SqlDbType.Int, prescription.CaseId),
             DataManager.CreateParameter("@report", SqlDbType.NVarChar, prescription.Report),
             DataManager.CreateParameter("@status", SqlDbType.Int, prescription.Status),
             DataManager.CreateParameter("@confermedComment", SqlDbType.NVarChar, prescription.ConfermedComment));

           return Convert.ToInt32(o);
       }
       // Update the status only (Confirm)
       public static int Confirm(Prescription prescription)
       {
           object o = DataManager.ExecuteScalar("ESystem_PrescriptionConfirm",
             DataManager.CreateParameter("@caseId", SqlDbType.Int, prescription.CaseId),
             DataManager.CreateParameter("@status", SqlDbType.Int, prescription.Status));

           return Convert.ToInt32(o);
       }



        private static Prescription FillDataRecord(IDataRecord myDataRecord)
        {
            Prescription prescription = new Prescription();

            prescription.PrescriptionId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PrescriptionId"));
            prescription.CaseId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CaseId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Report")))
            {
                prescription.Report = myDataRecord.GetString(myDataRecord.GetOrdinal("Report"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Status")))
            {
                prescription.Status = (PrescriptionStatus)myDataRecord.GetInt32(myDataRecord.GetOrdinal("Status"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ConfermedComment")))
            {
                prescription.ConfermedComment = myDataRecord.GetString(myDataRecord.GetOrdinal("ConfermedComment"));
            }

            return prescription;
        }
    }
}
