using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO
{
   public class Appointments
   {
       public int AppID { get; set; }
       public int ClientId { get; set; }
       public string ClientName { get; set; }
       public DateTime AppDate { get; set; }
       public string AppStartTime { get; set; }
       public DateTime CreationDate { get; set; }
       public DateTime ModifedDate { get; set; }
       public string CreatedBy { get; set; }
       public string ModifiedBy { get; set; }
       public bool IsActive { get; set; }
       public List<Client> Clients { get; set; }
   
   
   
   }
}
