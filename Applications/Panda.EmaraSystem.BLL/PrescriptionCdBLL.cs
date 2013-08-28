using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;

namespace Panda.EmaraSystem.BLL
{
   public class PrescriptionCdBLL
    {
       public static PrescriptionCD GetItem(int id)
        {
            return PrescriptionCdDAL.GetItem(id);
        }
       public static PrescriptionCD GetByPrescId(int id)
       {
           return PrescriptionCdDAL.GetByPrescId(id);
       }



       public static List<PrescriptionCD> GetList()
        {
            return PrescriptionCdDAL.GetList();
        }

       public static int Insert(PrescriptionCD prescCd)
        {
            prescCd.CdId = PrescriptionCdDAL.Insert(prescCd);
            return prescCd.PrescriptionId;
        }
       public static int Update(PrescriptionCD prescCd)
       {
           prescCd.CdId = PrescriptionCdDAL.Update(prescCd);
           return prescCd.PrescriptionId;
       }


       public static bool Delete(PrescriptionCD prescCd)
        {
            return PrescriptionCdDAL.Delete(prescCd.CdId);
        }

    }
}
