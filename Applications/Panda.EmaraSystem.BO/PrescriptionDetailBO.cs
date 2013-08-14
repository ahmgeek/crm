using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO {
   public class PrescriptionDetailBO {
       public int PrescDetId { get; set; }
       public int PrescriptionId { get; set; }
       public int CourseId { get; set; }
       public string CourseName { get; set; }
       public int CourseCounter { get; set; }
       public string Note { get; set; }
    }
}
