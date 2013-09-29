using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Panda.EmaraSystem.BO;
namespace Panda.EmaraSystem.DAL
{
    public class PrescriptionCdDAL
    {


        public static PrescriptionCD GetItem(int id)
        {
            PrescriptionCD prescriptionCD = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_PrescriptionCdSelectById", out con,
                DataManager.CreateParameter("@cdId", SqlDbType.Int, id)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        prescriptionCD = FillDataRecord(dr);
                    }
                }
                else
                {
                    throw new Exception("No Data");

                }

                con.Close();
            }
            return prescriptionCD;
        }
        public static PrescriptionCD GetItemByPrescId(int id)
        {
            PrescriptionCD prescriptionCD = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_PrescriptionCdSelectByPrescription", out con,
                DataManager.CreateParameter("@prescId", SqlDbType.Int, id)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        prescriptionCD = FillDataRecord(dr);
                    }
                }
                else
                {
                    throw new Exception("No Data");

                }

                con.Close();
            }
            return prescriptionCD;
        }

        public static List<PrescriptionCD> GetListByPrescription(int prescriptionId)
        {
            List<PrescriptionCD> list = new List<PrescriptionCD>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_PrescriptionCdSelectByPrescription", out con,
                DataManager.CreateParameter("@prescId",SqlDbType.Int,prescriptionId)))
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


        public static int Insert(PrescriptionCD prescriptionCD)
        {
            object o = DataManager.ExecuteScalar("ESystem_PrescriptionCdInsert",
             DataManager.CreateParameter("@prescId", SqlDbType.Int, prescriptionCD.PrescriptionId),
             DataManager.CreateParameter("@CdName", SqlDbType.NVarChar, prescriptionCD.CdName),
             DataManager.CreateParameter("@note", SqlDbType.NVarChar, prescriptionCD.Note));
            return Convert.ToInt32(o);
        }
        public static int Update(PrescriptionCD prescriptionCD)
        {
            object o = DataManager.ExecuteScalar("ESystem_PrescriptionCdUpdate",
             DataManager.CreateParameter("@CdId", SqlDbType.Int, prescriptionCD.CdId),
             DataManager.CreateParameter("@prescId", SqlDbType.Int, prescriptionCD.PrescriptionId),
             DataManager.CreateParameter("@CdName", SqlDbType.NVarChar, prescriptionCD.CdName),
             DataManager.CreateParameter("@note", SqlDbType.NVarChar, prescriptionCD.Note));

            return Convert.ToInt32(o);
        }
        public static int UpdateByPresc(PrescriptionCD prescriptionCD)
        {
            object o = DataManager.ExecuteScalar("ESystem_PrescriptionCdUpdateByPresc",
             DataManager.CreateParameter("@prescId", SqlDbType.Int, prescriptionCD.PrescriptionId),
             DataManager.CreateParameter("@CdName", SqlDbType.NVarChar, prescriptionCD.CdName),
             DataManager.CreateParameter("@note", SqlDbType.NVarChar, prescriptionCD.Note));

            return Convert.ToInt32(o);
        }

        
        public static bool Delete(int id)
        {
            int result = 0;
            result = DataManager.ExecuteNonQuery("ESystem_PrescriptionCdDelete",
                   DataManager.CreateParameter("@id", SqlDbType.Int, id));

            return result > 0;
        }




        private static PrescriptionCD FillDataRecord(IDataRecord myDataRecord)
        {
            PrescriptionCD prescriptionCd= new PrescriptionCD();

            prescriptionCd.CdId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CdId"));
            prescriptionCd.PrescriptionId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PrescriptionId"));
            prescriptionCd.CdName = myDataRecord.GetString(myDataRecord.GetOrdinal("CdName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Note")))
            {
                prescriptionCd.Note = myDataRecord.GetString(myDataRecord.GetOrdinal("Note"));
            }

            return prescriptionCd;
        }


    }
}
