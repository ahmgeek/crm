using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO
{
   public class ClientDetail
    {
        public int CLientId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Mob { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PrfrdTimeForCall { get; set; }
        public int HasArelation { get; set; }
    }
}
