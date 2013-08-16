using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Panda.EmaraSystem.BO
{
    public class ClientBO
    {
        public int CLientId { get; set; }
        public string AccountNumer { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurrName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PrfrdTimeForCall { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public SqlDateTime LstModifiedDate { get; set; }
        public string LstModifiedBy { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public string FullName { get; set; }
        public RelativesBO Relatives { get; set; }
        public SessionBO Session { get; set; }
        public PrescriptionBO Prescription { get; set; }

    }
}
