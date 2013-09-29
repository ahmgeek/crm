using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;

namespace Panda.EmaraSystem.BLL
{
   public class PrescriptionCdDataBLL
    {
        public static PrescriptionCdData GetItem(int id)
        {
            return PrescriptionCdDataDAL.GetItem(id);
        }

        public static List<PrescriptionCdData> GetList()
        {
            return PrescriptionCdDataDAL.GetList();
        }

        public static int Insert(PrescriptionCdData prescriptionCdData)
        {
            prescriptionCdData.CdDataId  = PrescriptionCdDataDAL.Insert(prescriptionCdData);
            return prescriptionCdData.CdDataId;
        }

        public static int update(PrescriptionCdData prescriptionCdData)
        {
            prescriptionCdData.CdDataId = PrescriptionCdDataDAL.Update(prescriptionCdData);
            return prescriptionCdData.CdDataId;
        }

        public static bool Delete(PrescriptionCdData prescriptionCdData)
        {
            return PrescriptionCdDataDAL.Delete(prescriptionCdData.CdDataId);
        }

    }
}
