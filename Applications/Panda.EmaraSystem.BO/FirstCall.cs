using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO
{
    public class FirstCall
    {
        public int FcallId { get; set; }
        public int CaseId { get; set; }
        public DateTime dateTime { get; set; }
        public string Report { get; set; }
        public string TechnichalReport { get; set; }
        public DateTime VisitDate { get; set; }
        public string VisitTime { get; set; }
        public FirstCallStatus Status { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
    }
}
