using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using System.Data.SqlClient;

namespace Panda.EmaraSystem.DAL
{
    
    public class RelativesDAL
   {
      
       public static List<Relatives> GetList(int id)
       {
           List<Relatives> list = new List<Relatives>();
           SqlConnection con;
           using (SqlDataReader dr =
               DataManager.GetDataReader("ESystem_RelativeGetAll", out con,
               DataManager.CreateParameter("@id", SqlDbType.Int, id)))
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

       public static List<Relatives> GetList()
       {
           List<Relatives> list = new List<Relatives>();
           SqlConnection con;
           using (SqlDataReader dr =
               DataManager.GetDataReader("ESystem_RelativeGetAllGeneral", out con))
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

       public static int Insert(Relatives rel)
       {
           object o =DataManager.ExecuteScalar("ESystem_RelativeInsert",
            DataManager.CreateParameter("@ClientId", SqlDbType.Int, rel.ClientId),
            DataManager.CreateParameter("@CLientRelId", SqlDbType.Int, rel.CLientRelId),
            DataManager.CreateParameter("@RelaionName", SqlDbType.NVarChar, rel.RelationName));
           return Convert.ToInt32(o) ;
       }

       public static int Update(Relatives rel)
       {
           object o = DataManager.ExecuteScalar("ESystem_RelativeUpdate",
            DataManager.CreateParameter("@RelativeId", SqlDbType.Int, rel.RelativeId),
            DataManager.CreateParameter("@ClientId", SqlDbType.Int, rel.ClientId),
            DataManager.CreateParameter("@CLientRelId", SqlDbType.Int, rel.CLientRelId),
            DataManager.CreateParameter("@RelaionName", SqlDbType.NVarChar, rel.RelationName));
           return Convert.ToInt32(o);
       }

       public static bool Delete(int id)
       {
           int result = 0;
           result = DataManager.ExecuteNonQuery("ESystem_RelativeDelete",
                  DataManager.CreateParameter("@RelativeId", SqlDbType.Int, id));

           return result > 0;
       }

       private static Relatives FillDataRecord(IDataRecord myDataRecord)
       {
           Relatives relative = new Relatives();

           relative.RelativeId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("RelativeId"));
           relative.ClientId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("ClientId"));

           if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CLientRelId")))
           {
               relative.CLientRelId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CLientRelId"));

           }

           if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("RelaionName")))
           {
               relative.RelationName = myDataRecord.GetString(myDataRecord.GetOrdinal("RelaionName"));
           }

           return relative;
       }

       

    }
}
