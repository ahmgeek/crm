using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;
using System.Data;

namespace Panda.EmaraSystem.BLL
{
   public class RelativesBLL
    {

        public static Relatives GetItem(int id)
        {
            return RelativesDAL.GetItem(id);
        }

        public static List<Relatives> GetList()
        {
            return RelativesDAL.GetList();
        }

        public static int Insert(Relatives relative)
        {
            relative.RelativeId = RelativesDAL.Insert(relative);
            return relative.RelativeId;
        }
        public static int Update(Relatives relative)
        {
            relative.RelativeId = RelativesDAL.Update(relative);
            return relative.RelativeId;

        }

        public static bool Delete(Relatives relative)
        {
            return RelativesDAL.Delete(relative.RelativeId);
        }

       
    }
}
