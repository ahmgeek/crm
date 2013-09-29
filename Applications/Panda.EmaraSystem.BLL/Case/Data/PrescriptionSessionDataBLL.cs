using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;


namespace Panda.EmaraSystem.BLL
{
    public class PrescriptionSessionDataBLL
    {
        public static PrescriptionSessionData GetItem(int id)
        {
            return PrescriptionSessionDataDAL.GetItem(id);
        }

        public static List<PrescriptionSessionData> GetList()
        {
            return PrescriptionSessionDataDAL.GetList();
        }

        public static int Insert(PrescriptionSessionData prescriptionSessionData)
        {
            prescriptionSessionData.SessionDataId = PrescriptionSessionDataDAL.Insert(prescriptionSessionData);
            return prescriptionSessionData.SessionDataId;
        }

        public static int update(PrescriptionSessionData prescriptionSessionData)
        {
            prescriptionSessionData.SessionDataId = PrescriptionSessionDataDAL.Update(prescriptionSessionData);
            return prescriptionSessionData.SessionDataId;
        }

        public static bool Delete(PrescriptionSessionData prescriptionSessionData)
        {
            return PrescriptionSessionDataDAL.Delete(prescriptionSessionData.SessionDataId);
        }

    }
}
