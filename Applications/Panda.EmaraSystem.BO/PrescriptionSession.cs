using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO
{
   public class PrescriptionSession
    {
        public int PrescSessionId { get; set; }
        public int PrescriptionId { get; set; }
        public string SessionName { get; set; }
        public int Number { get; set; }
        public string Comment { get; set; }
    }
}
