using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO {
   public class PrescriptionDetail {
       public int PrescriptionDetailId { get; set; }
       public int PrescriptionId { get; set; }
       public int CourseId { get; set; }
       public string CourseName { get; set; }
       public int Counter { get; set; }
       public string Note { get; set; }
       public List<Courses> Courses { get; set; }
       
    }
}
