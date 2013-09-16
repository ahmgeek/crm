using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Panda.EmaraSystem.BO;

namespace Panda.EmaraSystem.DAL
{
   public class PrescriptionSessionDAL
    {
       public static PrescriptionSession GetItem(int id)
        {
            PrescriptionSession prescriptionSession= null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_PrescriptionSessionSellectById", out con,
                DataManager.CreateParameter("@prescSessionId", SqlDbType.Int, id)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        prescriptionSession = FillDataRecord(dr);
                    }
                }
                else
                {
                    throw new Exception("No Data");

                }

                con.Close();
            }
            return prescriptionSession;
        }
       public static PrescriptionSession GetByPrescId(int id)
        {
            PrescriptionSession prescriptionSession = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_PrescriptionSessionSellectByPresc", out con,
                DataManager.CreateParameter("@prescId", SqlDbType.Int, id)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        prescriptionSession = FillDataRecord(dr);
                    }
                }
                else
                {
                    throw new Exception("No Data");

                }

                con.Close();
            }
            return prescriptionSession;
        }
       public static List<PrescriptionSession> GetList()
        {
            List<PrescriptionSession> list = new List<PrescriptionSession>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_PrescriptionSessionSellectALL", out con))
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
       public static int Insert(PrescriptionSession prescriptionSession)
        {
            object o = DataManager.ExecuteScalar("ESystem_PrescriptionSessionInsert",
             DataManager.CreateParameter("@prescId", SqlDbType.Int, prescriptionSession.PrescriptionId),
             DataManager.CreateParameter("@sessionName", SqlDbType.NVarChar, prescriptionSession.SessionName),
             DataManager.CreateParameter("@number", SqlDbType.Int, prescriptionSession.Number),
             DataManager.CreateParameter("@comment", SqlDbType.NVarChar, prescriptionSession.Comment));
            return Convert.ToInt32(o);
        }


       public static int Update(PrescriptionSession prescriptionSession)
        {
            object o = DataManager.ExecuteScalar("ESystem_PrescriptionSessionUpdate",
             DataManager.CreateParameter("@prescSessionid", SqlDbType.Int, prescriptionSession.PrescSessionId),
             DataManager.CreateParameter("@prescId", SqlDbType.Int, prescriptionSession.PrescriptionId),
             DataManager.CreateParameter("@sessionName", SqlDbType.NVarChar, prescriptionSession.SessionName),
             DataManager.CreateParameter("@number", SqlDbType.Int, prescriptionSession.Number),
             DataManager.CreateParameter("@comment", SqlDbType.NVarChar, prescriptionSession.Comment));

            return Convert.ToInt32(o);
        }

        public static bool Delete(int id)
        {
            int result = 0;
            result = DataManager.ExecuteNonQuery("ESystem_PrescriptionSessionDelete",
                   DataManager.CreateParameter("@sesiionId", SqlDbType.Int, id));

            return result > 0;
        }

        private static PrescriptionSession FillDataRecord(IDataRecord myDataRecord)
        {
            PrescriptionSession prescriptionSession= new PrescriptionSession();

            prescriptionSession.PrescSessionId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PrescSessionId"));
            prescriptionSession.PrescriptionId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PrescriptionId"));
            prescriptionSession.SessionName = myDataRecord.GetString(myDataRecord.GetOrdinal("SessionName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
            {
                prescriptionSession.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Comment")))
            {
                prescriptionSession.Comment = myDataRecord.GetString(myDataRecord.GetOrdinal("Comment"));
            }


            return prescriptionSession;
        }

    }
}
