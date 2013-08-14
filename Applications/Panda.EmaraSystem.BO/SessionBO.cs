using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO {
  public class SessionBO {
      public int SessionId { get; set; }
      public int ClientId { get; set; }
      public string ClientName { get; set; }
      public Guid StuffId { get; set; }
      public DateTime Datetime { get; set; }
      public string Report { get; set; }
      public string Notes { get; set; }
      public bool IsActive { get; set; }
    }
}
