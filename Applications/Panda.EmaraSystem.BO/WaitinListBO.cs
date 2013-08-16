using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO
{
    public class WaitinListBO 
    {
        public int WaitListId { get; set; }
        public int ClientId { get; set; }
        public DateTime DateTime { get; set; }
        public int ClientNumber { get; set; }
        public bool IsReserved { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public string ClientName { get; set; }
        public ClientBO Clients { get; set; }

    }
}
