using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Panda.EmaraSystem.BO;
using System.Data;


namespace Panda.EmaraSystem.BO
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
       //
       public static Prescription GetByClient(int id)
       {
           Prescription prescription = null;
           SqlConnection con;
           using (SqlDataReader dr = DataManager.GetDataReader("ESystem_PrescriptionGetByClientId", out con,
               DataManager.CreateParameter("@clientId", SqlDbType.Int, id)))
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
             DataManager.CreateParameter("@sessionId", SqlDbType.Int, prescription.SessionId),
             DataManager.CreateParameter("@ClientId", SqlDbType.Int, prescription.ClientId),
             DataManager.CreateParameter("@datetime", SqlDbType.DateTime, prescription.DateTime),
             DataManager.CreateParameter("@report", SqlDbType.NVarChar, prescription.Report),
             DataManager.CreateParameter("@isServed", SqlDbType.Int, prescription.IsServed));

            return Convert.ToInt32(o);
        }
       public static int Update(Prescription prescription)
       {
           object o = DataManager.ExecuteScalar("ESystem_PrescriptionInsert",
            DataManager.CreateParameter("@prescid", SqlDbType.Int, prescription.PrescriptionId),
            DataManager.CreateParameter("@sessionId", SqlDbType.Int, prescription.SessionId),
            DataManager.CreateParameter("@ClientId", SqlDbType.Int, prescription.ClientId),
            DataManager.CreateParameter("@datetime", SqlDbType.DateTime, prescription.DateTime),
            DataManager.CreateParameter("@report", SqlDbType.NVarChar, prescription.Report),
            DataManager.CreateParameter("@isServed", SqlDbType.Int, prescription.IsServed));

           return Convert.ToInt32(o);
       }

        public static bool Delete(int id)
        {
            int result = 0;
            result = DataManager.ExecuteNonQuery("ESystem_PrescriptionDelete",
                   DataManager.CreateParameter("@prescid", SqlDbType.Int, id));

            return result > 0;
        }

        private static Prescription FillDataRecord(IDataRecord myDataRecord)
        {
            Prescription prescription = new Prescription();

            prescription.PrescriptionId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PrescriptionId"));
            prescription.SessionId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("SessionId"));
            prescription.ClientId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("ClientId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DateTime")))
            {
                prescription.DateTime = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("DateTime"));

            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Report")))
            {
                prescription.Report = myDataRecord.GetString(myDataRecord.GetOrdinal("Report"));
            }
            
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IsServed")))
            {
                prescription.IsServed = (IsServed)myDataRecord.GetInt32(myDataRecord.GetOrdinal("IsServed"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FullName")))
            {
                prescription.FullName = myDataRecord.GetString(myDataRecord.GetOrdinal("FullName"));
            }

            return prescription;
        }

    }
}
