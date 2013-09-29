using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO
{
   public class PrescriptionCourses
    {

        public int CorsesId { get; set; }
        public int PrescriptionId { get; set; }
        public string CourseName { get; set; }
        public string Notes { get; set; }
    }
}
