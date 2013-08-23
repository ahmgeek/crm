using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO {
    public  class Prescription {
        public int PrescriptionId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime DateTime { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModfiedDate { get; set; }

    }
}
