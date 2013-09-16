using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;


namespace Panda.EmaraSystem.DAL
{
   public class PrescriptionSessionDataDAL
    {
       public static PrescriptionSessionData GetItem(int id)
        {
            PrescriptionSessionData prescSessionData = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_PrescSessionDataGetById", out con,
                DataManager.CreateParameter("@sessionDataID", SqlDbType.Int, id)))
            {


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        prescSessionData = FillDataRecord(dr);
                    }
                }


                else
                {
                    throw new Exception("No Data");
                }
                con.Close();
            }
            return prescSessionData;
        }

       public static List<PrescriptionSessionData> GetList()
        {
            List<PrescriptionSessionData> list = new List<PrescriptionSessionData>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_PrescSessionDataGetAll", out con))
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

        public static int Insert(PrescriptionSessionData prescSessionData)
        {
            object o = DataManager.ExecuteScalar("ESystem_PrescSessionDataInsert",
             DataManager.CreateParameter("@sessionDataName", SqlDbType.NVarChar,prescSessionData.SessionDataName ));  

            return Convert.ToInt32(o);
        }

        public static int Update(PrescriptionSessionData prescSessionData)
        {

            object o = DataManager.ExecuteScalar("ESystem_PrescSessionDataUpdate",
             DataManager.CreateParameter("@sessionDataID", SqlDbType.Int, prescSessionData.SessionDataId),
             DataManager.CreateParameter("@sessionDataName", SqlDbType.NVarChar, prescSessionData.SessionDataName));

            return Convert.ToInt32(o);
        }

        public static bool Delete(int id)
        {
            int result = 0;
            result = DataManager.ExecuteNonQuery("ESystem_PrescSessionDataDelete",
                   DataManager.CreateParameter("@sessionDataID", SqlDbType.Int, id));

            return result > 0;
        }


       private static PrescriptionSessionData FillDataRecord(IDataRecord myDataRecord)
       {
           PrescriptionSessionData prescSessionData = new PrescriptionSessionData();

           prescSessionData.SessionDataId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("SessionDataID"));

           prescSessionData.SessionDataName = myDataRecord.GetString(myDataRecord.GetOrdinal("SessionDataName"));



           return prescSessionData;
       }
    }
}
