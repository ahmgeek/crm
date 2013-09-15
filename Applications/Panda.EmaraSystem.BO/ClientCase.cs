using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO
{
    public class ClientCase
    {

        #region PrivateProp


        private List<Relatives> _relatives = new List<Relatives>();
        private List<Prescription> _prescriptions = new List<Prescription>();
        private List<Sessions> _sessionse = new List<Sessions>();
        private List<FirstCall> _firstCall = new List<FirstCall>();
        #endregion
        public int CaseId { get; set; }
        public int ClientId { get; set; }
        public string CaseNumber { get; set; }
        public ClientCase CaseStatus { get; set; }
        public DateTime dateTime { get; set; }

        //FirstCallData
        public List<FirstCall> FirstCall
        {
            get
            {
                return _firstCall;
            }
            set
            {
                _firstCall = value;
            }
        }

        #region ClientData
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurrName { get; set; }
        public string FullName
        {
            get
            {
                string tempValue = FirstName;
                if (!String.IsNullOrEmpty(MiddleName))
                {
                    tempValue += " " + MiddleName;
                }
                tempValue += " " + SurrName;
                return tempValue;
            }

        }
        public string Mob { get; set; }
        #endregion

        #region ClientReltions

        public List<Relatives> Reltives
        {
            get
            {
                return _relatives;
            }
            set
            {
                _relatives = value;
            }
        }

        public List<Prescription> Prescription
        {
            get
            {
                return _prescriptions;
            }
            set
            {
                _prescriptions = value;
            }
        }


        public List<Sessions> Sessions
        {
            get
            {
                return _sessionse;
            }
            set
            {
                _sessionse = value;
            }
        }

        #endregion
    }
}
