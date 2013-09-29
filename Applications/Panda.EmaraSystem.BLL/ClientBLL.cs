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


        public static Client GetItem(int id)
        {
            Client client = ClientDAL.GetItem(id);
            return client;
        }

        public static List<Client> GetList()
        {
            List<Client> clients = ClientDAL.GetList();
            return clients;
        }
        public static int Insert(Client client)
        {
            client.CLientId = ClientDAL.Insert(client);
            return client.CLientId;
        }
                    
        public static int Update(Client client)
        {
            client.CLientId = ClientDAL.Update(client);
            return client.CLientId;

        }
               

        // Deleteing the client. -> only from the admin area.
        //Delete all the assoicated data.

        public static bool Delete(Client client)
        {
            return ClientDAL.Delete(client.CLientId);
        }

    }
}
