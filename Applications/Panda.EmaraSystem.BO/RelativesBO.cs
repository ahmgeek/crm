using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO {
  public  class RelativesBO {
        public int RelId { get; set; }
        public int ClientId { get; set; }
        public int ClientRelId { get; set; }
        public string ClientName { get; set; }
        public string ClientRelName { get; set; }
        public string RelationName { get; set; }
    }
}
