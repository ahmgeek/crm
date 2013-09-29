using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;

namespace Panda.EmaraSystem.BLL
{
   public class PrescriptionCourseDataBLL
    {
        public static PrescriptionCourseData GetItem(int id)
        {
            return PrescriptionCourseDataDAL.GetItem(id);
        }

        public static List<PrescriptionCourseData> GetList()
        {
            return PrescriptionCourseDataDAL.GetList();
        }

        public static int Insert(PrescriptionCourseData prescriptionCourseData)
        {
            prescriptionCourseData.CourseDataId = PrescriptionCourseDataDAL.Insert(prescriptionCourseData);
            return prescriptionCourseData.CourseDataId;
        }

        public static int update(PrescriptionCourseData prescriptionCourseData)
        {
            prescriptionCourseData.CourseDataId = PrescriptionCourseDataDAL.Update(prescriptionCourseData);
            return prescriptionCourseData.CourseDataId;
        }

        public static bool Delete(PrescriptionCourseData prescriptionCourseData)
        {
            return PrescriptionCourseDataDAL.Delete(prescriptionCourseData.CourseDataId);
        }

    }
}
