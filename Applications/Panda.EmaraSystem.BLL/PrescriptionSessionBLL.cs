using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;

namespace Panda.EmaraSystem.BLL
{
   public class PrescriptionSessionBLL
    {
        public static PrescriptionSession GetItem(int id)
        {
            return PrescriptionSessionDAL.GetItem(id);
        }
        public static PrescriptionSession GetByPrescId(int id)
        {
            return PrescriptionSessionDAL.GetByPrescId(id);
        }



        public static List<PrescriptionSession> GetList()
        {
            return PrescriptionSessionDAL.GetList();
        }

        public static int Insert(PrescriptionSession prescSession)
        {
            prescSession.PrescSessionId = PrescriptionSessionDAL.Insert(prescSession);
            return prescSession.PrescriptionId;
        }
        public static int Update(PrescriptionSession prescSession)
        {
            prescSession.PrescSessionId = PrescriptionSessionDAL.Update(prescSession);
            return prescSession.PrescriptionId;
        }


        public static bool Delete(PrescriptionSession prescSession)
        {
            return PrescriptionSessionDAL.Delete(prescSession.PrescSessionId);
        }

    }
}
