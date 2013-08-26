using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using System.Data.SqlClient;

namespace Panda.EmaraSystem.DAL 
{
   public class WaitingListDAL
   {

       public static WaitingList GetItem(int id)
       {
           WaitingList waitingList = null;
           SqlConnection con;
           using (SqlDataReader dr = DataManager.GetDataReader("ESystem_WaitingListGetById", out con,
               DataManager.CreateParameter("@id", SqlDbType.Int, id)))
           {
               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       waitingList = FillDataRecord(dr);
                   }
               }
               else
               {
                   throw new Exception("No Data");

               }

               con.Close();
           }
           return waitingList;
       }

       public static List<WaitingList> GetList()
       {
           List<WaitingList> list = new List<WaitingList>();
           SqlConnection con;
           using (SqlDataReader dr =
               DataManager.GetDataReader("ESystem_WaitingListGetAll", out con))
           {
               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       list.Add(FillDataRecord(dr));
                   }
               }
               else
               {
                   throw new Exception("No Data");
               }

               con.Close();
           }
           return list;
       }
       
       public static List<WaitingList> GetUnServedList()
       {
           List<WaitingList> list = new List<WaitingList>();
           SqlConnection con;
           using (SqlDataReader dr =
               DataManager.GetDataReader("ESystem_WaitingListGetByUnReserved", out con))
           {
               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       list.Add(FillDataRecord(dr));
                   }
               }
               else
               {
                   throw new Exception("No Data");
               }

               con.Close();
           }
           return list;
       }

       //
       public static List<WaitingList> GetServedList()
       {
           List<WaitingList> list = new List<WaitingList>();
           SqlConnection con;
           using (SqlDataReader dr =
               DataManager.GetDataReader("ESystem_WaitingListGetServed", out con))
           {
               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       list.Add(FillDataRecord(dr));
                   }
               }
               else
               {
                   throw new Exception("No Data");
               }

               con.Close();
           }
           return list;
       }



       public static int Insert(WaitingList waitingList)
       {
           object o = DataManager.ExecuteScalar("ESystem_WaitingListInsert",
            DataManager.CreateParameter("@clintid", SqlDbType.Int, waitingList.ClientId),
            DataManager.CreateParameter("@datetime", SqlDbType.DateTime, waitingList.DateTime),
            DataManager.CreateParameter("@isreserved", SqlDbType.Int, waitingList.IsReserved),
            DataManager.CreateParameter("@notes", SqlDbType.NVarChar, waitingList.Notes),
            DataManager.CreateParameter("@createdby", SqlDbType.NVarChar, waitingList.CreatedBy));
           return Convert.ToInt32(o);
       }

       public static int Update(WaitingList waitingList)
       {
           object o = DataManager.ExecuteScalar("ESystem_WaitingListUpdate",
            DataManager.CreateParameter("@waitlistid", SqlDbType.Int, waitingList.WaitListId),
            DataManager.CreateParameter("@ClientId", SqlDbType.Int, waitingList.ClientId),
            DataManager.CreateParameter("@datetime", SqlDbType.DateTime, waitingList.DateTime),
            DataManager.CreateParameter("@isreserved", SqlDbType.Int, waitingList.IsReserved),
            DataManager.CreateParameter("@notes", SqlDbType.NVarChar, waitingList.Notes),
            DataManager.CreateParameter("@createdby", SqlDbType.NVarChar, waitingList.CreatedBy));
           return Convert.ToInt32(o);
       }

       public static bool Delete(int id)
       {
           int result = 0;
           result = DataManager.ExecuteNonQuery("ESystem_WaitingListDelete",
                  DataManager.CreateParameter("@waitlistid", SqlDbType.Int, id));

           return result > 0;
       }


       private static WaitingList FillDataRecord(IDataRecord myDataRecord)
       {
           WaitingList waitingList = new WaitingList();

           waitingList.WaitListId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("WaitListId"));
           waitingList.ClientId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("ClientId"));
           waitingList.DateTime = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("DateTime"));


           if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IsReserved")))
           {
               waitingList.IsReserved = (IsServed)myDataRecord.GetInt32(myDataRecord.GetOrdinal("IsReserved"));
           }


           if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Notes")))
           {
               waitingList.Notes = myDataRecord.GetString(myDataRecord.GetOrdinal("Notes"));

           }

           if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CreatedBy")))
           {
               waitingList.CreatedBy = myDataRecord.GetString(myDataRecord.GetOrdinal("CreatedBy"));

           }

           if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FullName")))
           {
               waitingList.FullName = myDataRecord.GetString(myDataRecord.GetOrdinal("FullName"));
           }
           return waitingList;
       }

    }
}
