using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;


namespace Panda.EmaraSystem.DAL
{
    public class PrescriptionCourseDataDAL
    {

        public static PrescriptionCourseData GetItem(int id)
        {
            PrescriptionCourseData prescriptionCourse = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_PrescCourseDataGetById", out con,
                DataManager.CreateParameter("@courseDataID", SqlDbType.Int, id)))
            {


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        prescriptionCourse = FillDataRecord(dr);
                    }
                }


                else
                {
                    throw new Exception("No Data");
                }
                con.Close();
            }
            return prescriptionCourse;
        }

        public static List<PrescriptionCourseData> GetList()
        {
            List<PrescriptionCourseData> list = new List<PrescriptionCourseData>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_PrescCourseDataGetAll", out con))
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

        public static int Insert(PrescriptionCourseData prescriptionCourse)
        {
            object o = DataManager.ExecuteScalar("ESystem_PrescCourseDataInsert",
             DataManager.CreateParameter("@courseDataName", SqlDbType.NVarChar,prescriptionCourse.CourseDataName ));             );

            return Convert.ToInt32(o);
        }

        public static int Update(PrescriptionCourseData prescriptionCourse)
        {

            object o = DataManager.ExecuteScalar("ESystem_PrescCourseDataUpdate",
             DataManager.CreateParameter("@courseDataID", SqlDbType.Int, prescriptionCourse.CourseDataId),
             DataManager.CreateParameter("@courseDataName", SqlDbType.NVarChar,prescriptionCourse.CourseDataName ));             );
            return Convert.ToInt32(o);
        }

        public static bool Delete(int id)
        {
            int result = 0;
            result = DataManager.ExecuteNonQuery("ESystem_PrescCourseDataDelete",
                   DataManager.CreateParameter("@courseDataID", SqlDbType.Int, id));

            return result > 0;
        }


        private static PrescriptionCourseData FillDataRecord(IDataRecord myDataRecord)
        {
            PrescriptionCourseData prescCourseData = new PrescriptionCourseData();

            prescCourseData.CourseDataId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CourseDataID"));


            prescCourseData.CourseDataName = myDataRecord.GetString(myDataRecord.GetOrdinal("CourseDataName"));



            return prescCourseData;
        }

    }
}
