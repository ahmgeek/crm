using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;


namespace Panda.EmaraSystem.DAL
{
    public class ClientCaseDAL
    {
        public static ClientCase GetItem(int caseId)
        {
            ClientCase clntCase = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_ClientCaseGetById", out con,
                DataManager.CreateParameter("@id", SqlDbType.Int, caseId)))
            {


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        clntCase = FillDataRecord(dr);
                    }
                }


                else
                {
                    throw new Exception("No Data");
                }
                con.Close();
            }
            return clntCase;
        }

        public static List<ClientCase> GetList()
        {
            List<ClientCase> list = new List<ClientCase>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_ClientCaseGetAll", out con))
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

        public static int Insert(ClientCase clntCase)
        {
            object o = DataManager.ExecuteScalar("ESystem_ClientCaseInsert",
             DataManager.CreateParameter("@ClientId", SqlDbType.Int, clntCase.ClientId),
             DataManager.CreateParameter("@CaseNumber", SqlDbType.NVarChar, clntCase.CaseNumber),
             DataManager.CreateParameter("@CaseStatus", SqlDbType.Int, clntCase.CaseStatus),
             DataManager.CreateParameter("@dateTime", SqlDbType.DateTime, clntCase.dateTime)
             );

            return Convert.ToInt32(o);
        }

        public static int Update(ClientCase clntCase)
        {

            object o = DataManager.ExecuteScalar("ESystem_ClientCaseUpdate",
             DataManager.CreateParameter("@caseId", SqlDbType.Int, clntCase.CaseId),
             DataManager.CreateParameter("@ClientId", SqlDbType.Int, clntCase.ClientId),
             DataManager.CreateParameter("@CaseNumber", SqlDbType.NVarChar, clntCase.CaseNumber),
             DataManager.CreateParameter("@CaseStatus", SqlDbType.Int, clntCase.CaseStatus),
             DataManager.CreateParameter("@dateTime", SqlDbType.DateTime, clntCase.dateTime));
            return Convert.ToInt32(o);
        }

        private static ClientCase FillDataRecord(IDataRecord myDataRecord)
        {
            ClientCase clientCase = new ClientCase();

            clientCase.CaseId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CaseId"));
            clientCase.ClientId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("ClientId"));

            
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CaseNumber")))
            {
                clientCase.CaseNumber = myDataRecord.GetString(myDataRecord.GetOrdinal("CaseNumber"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CaseStatus")))
            {
                clientCase.CaseStatus = (CaseStatus)myDataRecord.GetInt32(myDataRecord.GetOrdinal("CaseStatus"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("dateTime")))
            {
                clientCase.dateTime = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("dateTime"));
            }


            return clientCase;
        }

    }
}
