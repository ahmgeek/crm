using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;

namespace Panda.EmaraSystem.BLL
{
   public class PrescriptionCoursesBLL
    {
        public static PrescriptionCourses GetItem(int id)
        {
            return PrescriptionCoursesDAL.GetItem(id);
        }
        public static PrescriptionCourses GetByPrescId(int id)
        {
            return PrescriptionCoursesDAL.GetByPrescId(id);
        }

        public static List<PrescriptionCourses> GetListByPrescription(int prescriptionId)
        {
            return PrescriptionCoursesDAL.GetListByPrescription(prescriptionId);
        }


        public static int Insert(PrescriptionCourses prescCourse)
        {
            prescCourse.CorsesId = PrescriptionCoursesDAL.Insert(prescCourse);
            return prescCourse.PrescriptionId;
        }
        public static int Update(PrescriptionCourses prescCourse)
        {
            prescCourse.CorsesId = PrescriptionCoursesDAL.Update(prescCourse);
            return prescCourse.PrescriptionId;
        }
        public static int UpdateByPresc(PrescriptionCourses prescCourse)
        {
            prescCourse.PrescriptionId = PrescriptionCoursesDAL.UpdateByPresc(prescCourse);
            return prescCourse.PrescriptionId;
        }


        public static bool Delete(PrescriptionCourses prescCourse)
        {
            return PrescriptionCoursesDAL.Delete(prescCourse.CorsesId);
        }

    }
}
