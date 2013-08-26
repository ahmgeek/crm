using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO {
    public  class Prescription {

        #region Private Variables
        private IsServed service = IsServed.UnServed;
        #endregion


        public int PrescriptionId { get; set; }
        public int ClientId { get; set; }
        public DateTime DateTime { get; set; }
        public string Report { get; set; }
        public IsServed IsServed
        {
            get
            {
                return service;
            }
            set
            {
                service = value;
            }

        }
        public string FullName { get; set; }
    }
}
