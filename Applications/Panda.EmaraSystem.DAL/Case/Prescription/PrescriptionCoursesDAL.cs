using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;

namespace Panda.EmaraSystem.DAL
{
    public class PrescriptionCoursesDAL
    {


        public static PrescriptionCourses GetItem(int id)
        {
            PrescriptionCourses prescriptionCourses = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_PrescriptionCoursesGetById", out con,
                DataManager.CreateParameter("@CorsesId", SqlDbType.Int, id)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        prescriptionCourses = FillDataRecord(dr);
                    }
                }
                else
                {
                    throw new Exception("No Data");

                }

                con.Close();
            }
            return prescriptionCourses;
        }
        public static PrescriptionCourses GetByPrescId(int id)
        {
            PrescriptionCourses prescriptionCourses = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_PrescriptionCoursesSelectByPresc", out con,
                DataManager.CreateParameter("@prescId", SqlDbType.Int, id)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        prescriptionCourses = FillDataRecord(dr);
                    }
                }
                else
                {
                    throw new Exception("No Data");

                }

                con.Close();
            }
            return prescriptionCourses;
        }

        public static List<PrescriptionCourses> GetListByPrescription(int prescriptionId)
        {
            List<PrescriptionCourses> list = new List<PrescriptionCourses>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_PrescriptionCoursesSelectByPresc", out con,
                DataManager.CreateParameter("@prescId", SqlDbType.Int, prescriptionId)))
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


        public static int Insert(PrescriptionCourses prescriptionCourses)
        {
            object o = DataManager.ExecuteScalar("ESystem_PrescriptionCoursesInsert",
             DataManager.CreateParameter("@prescId", SqlDbType.Int, prescriptionCourses.PrescriptionId),
             DataManager.CreateParameter("@courseNam", SqlDbType.NVarChar, prescriptionCourses.CourseName),
             DataManager.CreateParameter("@notes", SqlDbType.NVarChar, prescriptionCourses.Notes));
            return Convert.ToInt32(o);
        }
        public static int Update(PrescriptionCourses prescriptionCourses)
        {
            object o = DataManager.ExecuteScalar("ESystem_PrescriptionCoursesUpdate",
             DataManager.CreateParameter("@CorsesId", SqlDbType.Int, prescriptionCourses.CorsesId),
             DataManager.CreateParameter("@prescId", SqlDbType.Int, prescriptionCourses.PrescriptionId),
             DataManager.CreateParameter("@courseNam", SqlDbType.NVarChar, prescriptionCourses.CourseName),
             DataManager.CreateParameter("@notes", SqlDbType.NVarChar, prescriptionCourses.Notes));

            return Convert.ToInt32(o);
        }
        public static int UpdateByPresc(PrescriptionCourses prescriptionCourses)
        {
            object o = DataManager.ExecuteScalar("ESystem_PrescriptionCoursesUpdateByPresc",
             DataManager.CreateParameter("@prescId", SqlDbType.Int, prescriptionCourses.PrescriptionId),
             DataManager.CreateParameter("@courseName", SqlDbType.NVarChar, prescriptionCourses.CourseName),
             DataManager.CreateParameter("@notes", SqlDbType.NVarChar, prescriptionCourses.Notes));

            return Convert.ToInt32(o);
        }


        public static bool Delete(int id)
        {
            int result = 0;
            result = DataManager.ExecuteNonQuery("ESystem_PrescriptionCoursesDelete",
                   DataManager.CreateParameter("@CorsesId", SqlDbType.Int, id));

            return result > 0;
        }


        private static PrescriptionCourses FillDataRecord(IDataRecord myDataRecord)
        {
            PrescriptionCourses prescriptionCourses = new PrescriptionCourses();
            prescriptionCourses.CorsesId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CorsesId"));
            prescriptionCourses.PrescriptionId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PrescriptionId"));
            prescriptionCourses.CourseName = myDataRecord.GetString(myDataRecord.GetOrdinal("CourseName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Notes")))
            {
                prescriptionCourses.Notes = myDataRecord.GetString(myDataRecord.GetOrdinal("Notes"));
            }

            return prescriptionCourses;
        }

    }
}
