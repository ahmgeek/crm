using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO {
    public  class Prescription {

        #region Private Variables
        private List<PrescriptionSession> _prescriptionSessions = new List<PrescriptionSession>();
        private List<PrescriptionCD>  _prescriptionCds = new List<PrescriptionCD>();
        private List<PrescriptionCourses> _prescriptionCourseses = new List<PrescriptionCourses>(); 

        private PrescriptionStatus _status = PrescriptionStatus.onhold;
        #endregion


        public int PrescriptionId { get; set; }
        public int CaseId { get; set; }
        public string Report { get; set; }
        public PrescriptionStatus  Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }

        }
        public string ConfermedComment { get; set; }


        public List<PrescriptionSession> PrescriptionSessions
        {
            get
            {
                return _prescriptionSessions;
            }
            set
            {
                _prescriptionSessions = value;
            }
        }

        public List<PrescriptionCD> PrescriptionCds
        {
            get
            {
                return _prescriptionCds;
            }
            set
            {
                _prescriptionCds = value;
            }
        }

        public List<PrescriptionCourses> PrescriptionCourseses
        {
            get
            {
                return _prescriptionCourseses;
            }
            set
            {
                _prescriptionCourseses = value;
            }
        }

    }
}
