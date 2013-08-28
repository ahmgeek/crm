using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;

namespace Panda.EmaraSystem.BLL
{
   public class PrescriptionBLL
    {
       public static Prescription GetItem(int id)
       {
           return PrescriptionDAL.GetItem(id);
       }


       public static Prescription GetByClient(int id)
       {
           return PrescriptionDAL.GetByClient(id);
       }


       public static List<Prescription> GetList()
       {
           return PrescriptionDAL.GetList();
       }

       public static int Insert(Prescription presc)
       {
           presc.PrescriptionId = PrescriptionDAL.Insert(presc);
           return presc.PrescriptionId;
       }


       public static bool Delete(Prescription presc)
       {
           return PrescriptionDAL.Delete(presc.PrescriptionId);
       }


    }
}
