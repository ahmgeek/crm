using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;
using System.Data;


namespace Panda.EmaraSystem.BLL
{
   public class WaitingListBLL
    {

        public static WaitingList GetItem(int id)
        {
            return WaitingListDAL.GetItem(id);
        }

        public static List<WaitingList> GetList()
        {
            return WaitingListDAL.GetList();
        }
        public static List<WaitingList> GetUnServedList()
        {
            return WaitingListDAL.GetUnServedList();
        }
        public static List<WaitingList> GetServedList()
        {
            return WaitingListDAL.GetServedList();
        }


       


        public static int Insert(WaitingList waitlist)
        {
            waitlist.WaitListId = WaitingListDAL.Insert(waitlist);
            return waitlist.WaitListId;
        }
        public static int Update(WaitingList waitlist)
        {
            waitlist.WaitListId = WaitingListDAL.Update(waitlist);
            return waitlist.WaitListId;

        }



        public static bool Delete(WaitingList waitlist)
        {
            return WaitingListDAL.Delete(waitlist.WaitListId);
        }




    }
}
