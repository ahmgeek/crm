using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using System.Data.SqlClient;

namespace Panda.EmaraSystem.DAL 
{
   public class StuffDAL
    {

       public static Stuff GetItem(Guid id)
       {
           Stuff stuff = null;
           SqlConnection con;
           using (SqlDataReader dr = DataManager.GetDataReader("ESystem_StuffGetById", out con,
               DataManager.CreateParameter("@id", SqlDbType.UniqueIdentifier, id)))
           {
               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       stuff = FillDataRecord(dr);
                   }
               }
               else
               {
                   throw new Exception("No Data");

               }

               con.Close();
           }
           return stuff;
       }

       public static List<Stuff> GetList()
       {
           List<Stuff> list = new List<Stuff>();
           SqlConnection con;
           using (SqlDataReader dr =
               DataManager.GetDataReader("ESystem_StuffGeAll", out con))
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

       public static Guid Insert(Stuff stuff)
       {
           Guid result = Guid.Empty;
           result = (Guid)DataManager.ExecuteScalar("ESystem_StuffInsert",
            DataManager.CreateParameter("@stuffId", SqlDbType.UniqueIdentifier, stuff.StuffId),
            DataManager.CreateParameter("@firstname", SqlDbType.NVarChar, stuff.FirstName),
            DataManager.CreateParameter("@surrname", SqlDbType.NVarChar, stuff.SurrName),
            DataManager.CreateParameter("@dateofbirth", SqlDbType.Date, stuff.DateOfBirth),
            DataManager.CreateParameter("@mob", SqlDbType.NVarChar, stuff.Mob));
           return result;
       }

       public static Guid Update(Stuff stuff)
       {
           Guid result = Guid.Empty;

           result = (Guid)DataManager.ExecuteScalar("ESystem_StuffUpdate",
            DataManager.CreateParameter("@stuffId", SqlDbType.UniqueIdentifier, stuff.StuffId),
            DataManager.CreateParameter("@firstname", SqlDbType.NVarChar, stuff.FirstName),
            DataManager.CreateParameter("@surrname", SqlDbType.NVarChar, stuff.SurrName),
            DataManager.CreateParameter("@dateofbirth", SqlDbType.Date, stuff.DateOfBirth),
            DataManager.CreateParameter("@mob", SqlDbType.NVarChar, stuff.Mob));
           return result;
       }

       public static bool Delete(Guid id)
       {
           int result = 0;
        result = DataManager.ExecuteNonQuery("ESystem_StuffDelete",
               DataManager.CreateParameter("@id", SqlDbType.UniqueIdentifier, id));
          
        return result > 0;
       }

       private static Stuff FillDataRecord(IDataRecord myDataRecord)
       {
           Stuff stuff = new Stuff();

           stuff.StuffId = myDataRecord.GetGuid(myDataRecord.GetOrdinal("StuffId"));
           if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FirstName")))
           {
               stuff.FirstName = myDataRecord.GetString(myDataRecord.GetOrdinal("FirstName"));

           }

           if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("SurrName")))
           {
               stuff.SurrName = myDataRecord.GetString(myDataRecord.GetOrdinal("SurrName"));
           }

           if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DateOfBirth")))
           {
               stuff.DateOfBirth = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("DateOfBirth"));
           }
           if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Mob")))
           {
               stuff.Mob = myDataRecord.GetString(myDataRecord.GetOrdinal("Mob"));
           }


           return stuff;
       }



    }
}
