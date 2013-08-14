using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;


namespace Panda.EmaraSystem.DAL
{
    
    
   public class RelativesDAL {

       public static RelativesBO GetRelations(int id)
       {
           RelativesBO relBO = new RelativesBO();
           ClientDAL clntDAL = new ClientDAL();

           DataSet ds = DataManager.GetDataSet("ESystem_RelativeGetByClientId", "x",
                DataManager.CreateParameter("@id", SqlDbType.Int, id));


           relBO.ClientId = id;
           relBO.ClientRelId = (int)ds.Tables["x"].Rows[0]["CLientRelId"];
           relBO.ClientRelName = ds.Tables["x"].Rows[0]["RelaionName"].ToString();
           int clntrelID = (int)ds.Tables["x"].Rows[0]["CLientRelId"];


           relBO.ClientName = clntDAL.GetClientById(id).FullName;
           relBO.ClientRelName = clntDAL.GetClientById(clntrelID).FullName;

           return relBO;

       }



       public int RelativeInert(RelativesBO relBO)
       {
           object o = DataManager.ExecuteScalar("ESystem_RelativeInsert",
               DataManager.CreateParameter("@ClientId", System.Data.SqlDbType.Int, relBO.ClientId),
               DataManager.CreateParameter("@ClientRelId", System.Data.SqlDbType.Int, relBO.ClientRelId),
               DataManager.CreateParameter("@RelaionName", System.Data.SqlDbType.NVarChar, relBO.RelationName));
           relBO.RelId = (int)o;
           return relBO.RelId;

       }


       public void RelativeUpdate(RelativesBO relBO)
       {
           DataManager.ExecuteNonQuery("ESystem_RelativeUpdate",
               DataManager.CreateParameter("@RelativeId", System.Data.SqlDbType.Int,relBO.RelId),
               DataManager.CreateParameter("@ClientId", System.Data.SqlDbType.Int,relBO.ClientId),
               DataManager.CreateParameter("@CLientRelId", System.Data.SqlDbType.Int,relBO.ClientRelId),
               DataManager.CreateParameter("@RelaionName", System.Data.SqlDbType.NVarChar,relBO.RelationName));
               
               
               
               
               
               }


       public void RelativeDelete(RelativesBO relBO)
       {
           DataManager.ExecuteNonQuery("ESystem_RelativeDelete",
    DataManager.CreateParameter("@RelativeId", SqlDbType.Int,relBO.RelId ));

       }

    }
}
