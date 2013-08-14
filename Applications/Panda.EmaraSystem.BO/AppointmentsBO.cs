using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO
{
   public class AppointmentsBO
   {
       public int AppointmentId { get; set; }
       public int ClientId { get; set; }
       public string ClientName { get; set; }
       public DateTime AppointmentDate { get; set; }
       public string StartTime { get; set; }
       public DateTime CreationDate { get; set; }
       public DateTime ModifiedDate { get; set; }
       public string CreatedBy { get; set; }
       public string ModifiedBy { get; set; }
       public bool IsActive { get; set; }

   
   
   
   }
}
