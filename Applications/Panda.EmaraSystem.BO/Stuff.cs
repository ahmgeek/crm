using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO
{
    public class Stuff
    {
        public Guid StuffId { get; set; }
        public string FirstName { get; set; }
        public string SurrName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Mob { get; set; }
        public string FullName
        {
            get
            {
                string Name = FirstName + " " + SurrName;
                return Name;
            }
        }
    }
}
