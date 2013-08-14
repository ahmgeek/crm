using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;


namespace Panda.EmaraSystem.BLL
{
    public class ClientBLL
    {

        ClientDAL cld = new ClientDAL();

        public void ClientInsert(ClientBO c)
        {

            cld.ClientInsert(c);
        }


        public DataSet GetAllClients()
        {
           return cld.GetAllClients();
        }

        public ClientBO GetAllClientsExcept(int id)
        {
            ClientBO clntBO = new ClientBO();


            return clntBO;
        }


        public ClientBO GetClientById(int id)
        {
            ClientBO clntBO = new ClientBO();


            return clntBO;
        }
    }
}
