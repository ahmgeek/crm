using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;


namespace Panda.EmaraSystem.DAL 
{
   public class WaitingListDAL {

       public DataSet WaitListGetAll()
       {
           return DataManager.GetDataSet("ESystem_WaitingListGetAll", "x");
       }

       public int WaitListInsert(WaitinListBO waitBO)
       {
           object o = DataManager.ExecuteScalar("ESystem_WaitingListInsert",
               DataManager.CreateParameter("@clintid", System.Data.SqlDbType.Int, waitBO.ClientId),
               DataManager.CreateParameter("@datetime", System.Data.SqlDbType.DateTime, waitBO.DateTime),
               DataManager.CreateParameter("@clientnumber", System.Data.SqlDbType.Int, waitBO.ClientNumber),
               DataManager.CreateParameter("@isreserved", System.Data.SqlDbType.Bit, waitBO.IsReserved),
               DataManager.CreateParameter("@notes", System.Data.SqlDbType.NVarChar, waitBO.Notes),
               DataManager.CreateParameter("@createdby", System.Data.SqlDbType.NVarChar, waitBO.CreatedBy));

           waitBO.WaitListId = (int)o;
           return waitBO.WaitListId;
       }

       public int WaitListUpdate(WaitinListBO waitBO)
       {
         object o=  DataManager.ExecuteScalar("ESystem_WaitingListUpdate",
               DataManager.CreateParameter("@waitlistid", System.Data.SqlDbType.Int,waitBO.WaitListId),
               DataManager.CreateParameter("@clintid", System.Data.SqlDbType.Int,waitBO.ClientId),
               DataManager.CreateParameter("@datetime", System.Data.SqlDbType.DateTime,waitBO.DateTime),
               DataManager.CreateParameter("@clientnumber", System.Data.SqlDbType.Int,waitBO.ClientNumber),
               DataManager.CreateParameter("@isreserved", System.Data.SqlDbType.Bit,waitBO.IsReserved),
               DataManager.CreateParameter("@notes", System.Data.SqlDbType.NVarChar,waitBO.Notes),
               DataManager.CreateParameter("@createdby", System.Data.SqlDbType.NVarChar,waitBO.CreatedBy));

         waitBO.WaitListId = (int)o;


         return waitBO.WaitListId;
               
       }

       public void WaitListDelete(WaitinListBO waitBO)
       {
           DataManager.ExecuteNonQuery("ESystem_WaitingListDelete",
               DataManager.CreateParameter("@waitlistid", System.Data.SqlDbType.Int, waitBO.WaitListId));
       }

       public static WaitinListBO GetWaitList()
       {
           WaitinListBO waitBO = new WaitinListBO();
           ClientDAL clientDAL = new ClientDAL();

           DataSet ds= DataManager.GetDataSet("ESystem_WaitingListGetAll", "x");

           waitBO.WaitListId = (int)ds.Tables["x"].Rows[0]["WaitListId"];
           waitBO.ClientId = (int)ds.Tables["x"].Rows[0]["ClientId"];
           waitBO.DateTime = (DateTime)ds.Tables["x"].Rows[0]["DateTime"];
           waitBO.ClientNumber = (int)ds.Tables["x"].Rows[0]["ClientNumber"];
           waitBO.ClientName = clientDAL.GetClientById(waitBO.ClientId).FullName;
           waitBO.IsReserved =(bool) ds.Tables["x"].Rows[0]["IsReserved"];
           waitBO.Notes = ds.Tables["x"].Rows[0]["Notes"].ToString();
           waitBO.CreatedBy = ds.Tables["x"].Rows[0]["CreatedBy"].ToString();

           return waitBO;
       }

    }
}
