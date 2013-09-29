using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.DAL;
using Panda.EmaraSystem.BO;

namespace Panda.EmaraSystem.BLL
{
    public class FirstCallBLL
    {
        public static FirstCall GetItem(int id)
        {

            return FirstCallDAL.GetItem(id);
        }

        public static List<FirstCall> GetList()
        {
            return FirstCallDAL.GetList();
        }


        public static int Insert(FirstCall firstCall)
        {
            firstCall.FcallId = FirstCallDAL.Insert(firstCall);
            return firstCall.FcallId;
        }

        public static int Update(FirstCall firstCall)
        {
            firstCall.FcallId = FirstCallDAL.Update(firstCall);
            return firstCall.FcallId;
        }

        public static int UpdateByCase(FirstCall firstCall)
        {
            firstCall.CaseId = FirstCallDAL.UpdateByCase(firstCall);
            return firstCall.CaseId;
        }



    }
}
