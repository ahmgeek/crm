using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Panda.EmaraSystem.BO;


namespace Panda.EmaraSystem.DAL
{
    public class ClientDAL
    {


        public static Client GetItem(int id)
        {
            Client clnt = null;
            SqlConnection con;
            using (SqlDataReader dr = DataManager.GetDataReader("ESystem_CLientGetById", out con,
                DataManager.CreateParameter("@id", SqlDbType.Int, id)))
            {


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        clnt = FillDataRecord(dr);
                    }
                }


                else
                {
                    throw new Exception("No Data");
                }
                con.Close();
            }
            return clnt;
        }

        public static List<Client> GetList()
        {
            List<Client> list = new List<Client>();
            SqlConnection con;
            using (SqlDataReader dr =
                DataManager.GetDataReader("ESystem_CLientGetAll", out con))
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

        public static int Insert(Client client)
        {
            object o = DataManager.ExecuteScalar("ESystem_ClientInsert",
             DataManager.CreateParameter("@accountNumber", SqlDbType.NVarChar, client.AccountNumber),
             DataManager.CreateParameter("@firstName", SqlDbType.NVarChar, client.FirstName),
             DataManager.CreateParameter("@middleName", SqlDbType.NVarChar, client.MiddleName),
             DataManager.CreateParameter("@surrName", SqlDbType.NVarChar, client.SurrName),
             DataManager.CreateParameter("@city", SqlDbType.NVarChar, client.City),
             DataManager.CreateParameter("@country", SqlDbType.NVarChar, client.Country),
             DataManager.CreateParameter("@address", SqlDbType.NVarChar, client.Address),
             DataManager.CreateParameter("@telephone", SqlDbType.NVarChar, client.Telephone),
             DataManager.CreateParameter("@mob", SqlDbType.NVarChar, client.Mob),
             DataManager.CreateParameter("@dateofbirth", SqlDbType.DateTime, client.DateOfBirth),
             DataManager.CreateParameter("@gender", SqlDbType.NVarChar, client.Gender),
             DataManager.CreateParameter("@preferedTimeForCall", SqlDbType.NVarChar, client.PrfrdTimeForCall),
             DataManager.CreateParameter("@creationdate", SqlDbType.DateTime, client.CreationDate),
             DataManager.CreateParameter("@createdBy", SqlDbType.NVarChar, client.CreatedBy),
             DataManager.CreateParameter("@IsActive", SqlDbType.Int, client.IsActive),
             DataManager.CreateParameter("@notes", SqlDbType.NVarChar, client.Notes));
            
            return Convert.ToInt32(o);
        }

        public static int Update(Client client)
        {
            int result = 0;

            result = (int)DataManager.ExecuteScalar("ESystem_ClientUpdate",
             DataManager.CreateParameter("@clientId", SqlDbType.Int,client.CLientId),
             DataManager.CreateParameter("@accountNumber", SqlDbType.NVarChar, client.AccountNumber),
             DataManager.CreateParameter("@firstName", SqlDbType.NVarChar, client.FirstName),
             DataManager.CreateParameter("@middleName", SqlDbType.NVarChar, client.MiddleName),
             DataManager.CreateParameter("@surrName", SqlDbType.NVarChar, client.SurrName),
             DataManager.CreateParameter("@city", SqlDbType.NVarChar, client.City),
             DataManager.CreateParameter("@country", SqlDbType.NVarChar, client.Country),
             DataManager.CreateParameter("@address", SqlDbType.NVarChar, client.Address),
             DataManager.CreateParameter("@telephone", SqlDbType.NVarChar, client.Telephone),
             DataManager.CreateParameter("@mob", SqlDbType.NVarChar, client.Mob),
             DataManager.CreateParameter("@dateofbirth", SqlDbType.Date, client.DateOfBirth),
             DataManager.CreateParameter("@gender", SqlDbType.NVarChar, client.Gender),
             DataManager.CreateParameter("@preferedTimeForCall", SqlDbType.NVarChar, client.PrfrdTimeForCall),
             DataManager.CreateParameter("@creationDate", SqlDbType.DateTime, client.CreationDate),
             DataManager.CreateParameter("@createdBy", SqlDbType.NVarChar, client.CreatedBy),
             DataManager.CreateParameter("@IsActive", SqlDbType.NVarChar, client.IsActive),
             DataManager.CreateParameter("@notes", SqlDbType.NVarChar, client.Notes));


            return result;
        }

        public static bool Delete(int id)
        {
            int result = 0;
            result = DataManager.ExecuteNonQuery("ESystem_ClientDelete",
                DataManager.CreateParameter("@clientid", SqlDbType.Int, id));
            return result > 0;
        }

        private static Client FillDataRecord(IDataRecord myDataRecord)
        {
            Client client = new Client();

            client.CLientId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CLientId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("AccountNumber")))
            {
                client.AccountNumber = myDataRecord.GetString(myDataRecord.GetOrdinal("AccountNumber"));
            }

            client.FirstName = myDataRecord.GetString(myDataRecord.GetOrdinal("FirstName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("MiddleName")))
            {
                client.MiddleName = myDataRecord.GetString(myDataRecord.GetOrdinal("MiddleName"));
            }

            client.SurrName = myDataRecord.GetString(myDataRecord.GetOrdinal("SurrName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("city")))
            {
             client.City = myDataRecord.GetString(myDataRecord.GetOrdinal("city"));

            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("country")))
            {
                client.Country = myDataRecord.GetString(myDataRecord.GetOrdinal("country"));

            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("address")))
            {
                client.Address = myDataRecord.GetString(myDataRecord.GetOrdinal("address"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Telephone")))
            {
                client.Telephone = myDataRecord.GetString(myDataRecord.GetOrdinal("Telephone"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Mob")))
            {
                client.Mob = myDataRecord.GetString(myDataRecord.GetOrdinal("Mob"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DateOfBirth")))
            {
                client.DateOfBirth = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("DateOfBirth"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Gender")))
            {
                client.Gender = myDataRecord.GetString(myDataRecord.GetOrdinal("Gender"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("PreferedTimeForCall")))
            {
                client.PrfrdTimeForCall = myDataRecord.GetString(myDataRecord.GetOrdinal("PreferedTimeForCall"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CreationDate")))
            {
                client.CreationDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("CreationDate"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CreatedBy")))
            {
                client.CreatedBy = myDataRecord.GetString(myDataRecord.GetOrdinal("CreatedBy"));
            }
          

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IsActive")))
            {
                client.IsActive =  (IsActive) myDataRecord.GetInt32(myDataRecord.GetOrdinal("IsActive"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("notes")))
            {
                client.Notes = myDataRecord.GetString(myDataRecord.GetOrdinal("notes"));
            }
            return client;
        }

        
    }
}
