using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;


namespace Panda.EmaraSystem.DAL
{
    public class PrescriptionCdDataDAL
    {
        public static PrescriptionCdData GetItem(int id)
        {
            PrescriptionCdData prescriptionCdData = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_PrescCdDataGetById", out con,
                DataManager.CreateParameter("@cdDaiaId", SqlDbType.Int, id)))
            {


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        prescriptionCdData = FillDataRecord(dr);
                    }
                }


                else
                {
                    throw new Exception("No Data");
                }
                con.Close();
            }
            return prescriptionCdData;
        }

        public static List<PrescriptionCdData> GetList()
        {
            List<PrescriptionCdData> list = new List<PrescriptionCdData>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_PrescCdDataGetAll", out con))
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

        public static int Insert(PrescriptionCdData prescriptionCd)
        {
            object o = DataManager.ExecuteScalar("ESystem_PrescCdDataInsert",
             DataManager.CreateParameter("@cdDataName", SqlDbType.NVarChar,prescriptionCd.cdDataName ));             );

            return Convert.ToInt32(o);
        }

        public static int Update(PrescriptionCdData prescriptionCd)
        {

            object o = DataManager.ExecuteScalar("ESystem_PrescCdDataUpdate",
             DataManager.CreateParameter("@cdDaiaId", SqlDbType.Int, prescriptionCd.CdDataId),
             DataManager.CreateParameter("@cdDataName", SqlDbType.NVarChar,prescriptionCd.cdDataName ));             
            
            return Convert.ToInt32(o);
        }

        public static bool Delete(int id)
        {
            int result = 0;
            result = DataManager.ExecuteNonQuery("ESystem_PrescCdDataDelete",
                   DataManager.CreateParameter("@cdDaiaId", SqlDbType.Int, id));

            return result > 0;
        }


        private static PrescriptionCdData FillDataRecord(IDataRecord myDataRecord)
        {
            PrescriptionCdData prescCdData = new PrescriptionCdData();

            prescCdData.CdDataId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CdDataID"));

            prescCdData.cdDataName = myDataRecord.GetString(myDataRecord.GetOrdinal("CdDataName"));



            return prescCdData;
        }


    }
}
