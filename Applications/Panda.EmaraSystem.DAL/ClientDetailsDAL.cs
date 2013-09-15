using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Panda.EmaraSystem.BO;


namespace Panda.EmaraSystem.DAL
{
    public  class ClientDetailsDAL
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
                DataManager.GetDataReader("ESystem_ClientView", out con))
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

        public static int Insert(ClientDetail client)
        {
            object o = DataManager.ExecuteScalar("ESystem_ClientInsert",
             DataManager.CreateParameter("@city", SqlDbType.NVarChar, client.City),
             DataManager.CreateParameter("@country", SqlDbType.NVarChar, client.Country),
             DataManager.CreateParameter("@address", SqlDbType.NVarChar, client.Address),
             DataManager.CreateParameter("@telephone", SqlDbType.NVarChar, client.Telephone),
             DataManager.CreateParameter("@mob", SqlDbType.NVarChar, client.Mob),
             DataManager.CreateParameter("@dateofbirth", SqlDbType.DateTime, client.DateOfBirth),
             DataManager.CreateParameter("@gender", SqlDbType.NVarChar, client.Gender),
             DataManager.CreateParameter("@preferedTimeForCall", SqlDbType.NVarChar, client.PrfrdTimeForCall),
             DataManager.CreateParameter("@hasArelation", SqlDbType.Int, client.HasArelation)
             );

            return Convert.ToInt32(o);
        }

        public static int Update(ClientDetail client)
        {

            object o = DataManager.ExecuteScalar("ESystem_ClientUpdate",
                DataManager.CreateParameter("@clientId", SqlDbType.Int, client.CLientId),
                DataManager.CreateParameter("@city", SqlDbType.NVarChar, client.City),
                DataManager.CreateParameter("@country", SqlDbType.NVarChar, client.Country),
                DataManager.CreateParameter("@address", SqlDbType.NVarChar, client.Address),
                DataManager.CreateParameter("@telephone", SqlDbType.NVarChar, client.Telephone),
                DataManager.CreateParameter("@mob", SqlDbType.NVarChar, client.Mob),
                DataManager.CreateParameter("@dateofbirth", SqlDbType.DateTime, client.DateOfBirth),
                DataManager.CreateParameter("@gender", SqlDbType.NVarChar, client.Gender),
                DataManager.CreateParameter("@preferedTimeForCall", SqlDbType.NVarChar, client.PrfrdTimeForCall),
                DataManager.CreateParameter("@hasArelation", SqlDbType.Int, client.HasArelation));
            return Convert.ToInt32(o);
        }

        private static ClientDetail FillDataRecord(IDataRecord myDataRecord)
        {
            ClientDetail client = new ClientDetail();

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

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("HasArelation")))
            {
                client.HasArelation = myDataRecord.GetInt32(myDataRecord.GetOrdinal("HasArelation"));
            }


            return ClientDetail;
        }

    }
}
