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
            return ClientDAL.GetItem(id);
        }

        public static Client GetItemMenimal(int id)
        {
            return ClientDAL.GetItemMenimal(id);
        }


        public static List<Client> GetList()
        {
            return ClientDAL.GetList();
        }
       

        public static int Insert(Client client)
        {
          client.CLientId=  ClientDAL.Insert(client);  
            return client.CLientId;
        }



        public static int Update(Client client)
        {
            client.CLientId = ClientDAL.Update(client);
            return client.CLientId;

        }

        public static bool Delete(Client client)
        {
            return ClientDAL.Delete(client.CLientId);
        }

    }
}
