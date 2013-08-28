using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO
{
    public class PrescriptionCD
    {

        public int CdId { get; set; }
        public int PrescriptionId { get; set; }
        public string CdName { get; set; }
        public string Note { get; set; }
    }
}
