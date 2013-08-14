using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Panda.EmaraSystem.BO;


namespace Panda.EmaraSystem.DAL
{
    public class ClientDAL
    {

        //All Clients Selection 
        public DataSet GetAllClients()
        {
            return DataManager.GetDataSet("ESystem_CLientGetAllConc", "y");
        }

        public DataSet GetAllExcept(int id)
        {
            DataSet ds = DataManager.GetDataSet("ESystem_CLientGetAllConcExcept", "z",
                DataManager.CreateParameter("@id", SqlDbType.Int, id));
            return ds;
        }

        //Client Insert
        public int ClientInsert(ClientBO clntBO)
        {            

         object o=   DataManager.ExecuteScalar("ESystem_ClientInsert",
                DataManager.CreateParameter("@accountNumber", SqlDbType.NVarChar, clntBO.AccountNumer),
                DataManager.CreateParameter("@firstName", SqlDbType.NVarChar, clntBO.FirstName),
                DataManager.CreateParameter("@middlename", SqlDbType.NVarChar, clntBO.MiddleName),
                DataManager.CreateParameter("@surrName", SqlDbType.NVarChar, clntBO.SurrName),
                DataManager.CreateParameter("@city", SqlDbType.NVarChar, clntBO.City),
                DataManager.CreateParameter("@country", SqlDbType.NVarChar, clntBO.Country),
                DataManager.CreateParameter("@address", SqlDbType.NVarChar, clntBO.Address),
                DataManager.CreateParameter("@telephone", SqlDbType.NVarChar, clntBO.Telephone),
                DataManager.CreateParameter("@mob", SqlDbType.NVarChar, clntBO.Mobile),
                DataManager.CreateParameter("@dateofbirth", SqlDbType.Date, clntBO.DateOfBirth),
                DataManager.CreateParameter("@gender", SqlDbType.NVarChar, clntBO.Gender),
                DataManager.CreateParameter("@preferedTimeForCall", SqlDbType.NVarChar, clntBO.PrfrdTimeForCall),
                DataManager.CreateParameter("@creationDate", SqlDbType.DateTime, clntBO.CreationDate),
                DataManager.CreateParameter("@createdBy", SqlDbType.NVarChar, clntBO.CreatedBy),
                DataManager.CreateParameter("@lastModifiedDate", SqlDbType.DateTime, clntBO.LstModifiedDate),
                DataManager.CreateParameter("@lastModifiedBy", SqlDbType.NVarChar, clntBO.LstModifiedBy),
                DataManager.CreateParameter("@notes", SqlDbType.NVarChar, clntBO.Notes));

            clntBO.CLientId = Convert.ToInt32(o);
             return clntBO.CLientId;
        }

        //Client Update
        public void ClientUpdate(ClientBO clntBO)
        {
            DataManager.ExecuteNonQuery("ESystem_ClientUpdate",
              DataManager.CreateParameter("@clientid", SqlDbType.Int, clntBO.CLientId),
              DataManager.CreateParameter("@accountNumber", SqlDbType.NVarChar, clntBO.AccountNumer),
              DataManager.CreateParameter("@firstName", SqlDbType.NVarChar, clntBO.FirstName),
              DataManager.CreateParameter("@middlename", SqlDbType.NVarChar, clntBO.MiddleName),
              DataManager.CreateParameter("@surrName", SqlDbType.NVarChar, clntBO.SurrName),
              DataManager.CreateParameter("@address", SqlDbType.NVarChar, clntBO.Address),
              DataManager.CreateParameter("@telephone", SqlDbType.NVarChar, clntBO.Telephone),
              DataManager.CreateParameter("@mob", SqlDbType.NVarChar, clntBO.Mobile),
              DataManager.CreateParameter("@dateofbirth", SqlDbType.Date, clntBO.DateOfBirth),
              DataManager.CreateParameter("@gender", SqlDbType.NVarChar, clntBO.Gender),
              DataManager.CreateParameter("@preferedTimeForCall", SqlDbType.NVarChar, clntBO.PrfrdTimeForCall),
              DataManager.CreateParameter("@creationDate", SqlDbType.DateTime, clntBO.CreationDate),
              DataManager.CreateParameter("@createdBy", SqlDbType.NVarChar, clntBO.CreatedBy),
              DataManager.CreateParameter("@lastModifiedDate", SqlDbType.DateTime, clntBO.LstModifiedDate),
              DataManager.CreateParameter("@lastModifiedBy", SqlDbType.NVarChar, clntBO.LstModifiedBy),
              DataManager.CreateParameter("@notes", SqlDbType.NVarChar, clntBO.Notes));
       
 
        }

        //Client Delete
        public void ClientDelete(ClientBO clntBO)
        {
            DataManager.ExecuteNonQuery("ESystem_ClientDelete",
                DataManager.CreateParameter("@clientid", SqlDbType.Int, clntBO.CLientId));
        }

        public  ClientBO GetClientById(int id)
        {
            ClientBO clntBO = new ClientBO();

            DataSet ds= DataManager.GetDataSet("ESystem_CLientGetById", "x",
                DataManager.CreateParameter("@id", SqlDbType.Int,id));

            clntBO.CLientId = id;

            clntBO.FullName = ds.Tables["x"].Rows[0]["Name"].ToString();
            clntBO.FirstName = ds.Tables["x"].Rows[0]["FirstName"].ToString();
            clntBO.MiddleName = ds.Tables["x"].Rows[0]["MiddleName"].ToString();
            clntBO.SurrName = ds.Tables["x"].Rows[0]["SurrName"].ToString();
            clntBO.AccountNumer = ds.Tables["x"].Rows[0]["AccountNumber"].ToString();
            clntBO.City = ds.Tables["x"].Rows[0]["city"].ToString();
            clntBO.Country = ds.Tables["x"].Rows[0]["country"].ToString();
            clntBO.Address = ds.Tables["x"].Rows[0]["address"].ToString();
            clntBO.Telephone = ds.Tables["x"].Rows[0]["Telephone"].ToString();
            clntBO.Mobile = ds.Tables["x"].Rows[0]["Mob"].ToString();
            clntBO.DateOfBirth = Convert.ToDateTime(ds.Tables["x"].Rows[0]["DateOfBirth"].ToString());
            clntBO.Gender = ds.Tables["x"].Rows[0]["Gender"].ToString();
            clntBO.PrfrdTimeForCall = ds.Tables["x"].Rows[0]["PreferedTimeForCall"].ToString();
            clntBO.CreationDate = Convert.ToDateTime(ds.Tables["x"].Rows[0]["CreationDate"].ToString());
            clntBO.CreatedBy = ds.Tables["x"].Rows[0]["CreatedBy"].ToString();
            clntBO.LstModifiedDate = Convert.ToDateTime(ds.Tables["x"].Rows[0]["LastModifiedDate"].ToString());
            clntBO.LstModifiedBy = ds.Tables["x"].Rows[0]["LastModifiedBy"].ToString();

            return clntBO;
        }



    }
}
