using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO {
    public  class PrsecriptionBO {
        public int PrescId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime DateTime { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
