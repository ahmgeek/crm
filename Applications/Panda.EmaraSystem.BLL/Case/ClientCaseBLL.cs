using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;
using Panda.EmaraSystem.DAL;

namespace Panda.EmaraSystem.BLL
{
    public class ClientCaseBLL
    {

        public static ClientCase GetItem(int id)
        {
            ClientCase clientCase = ClientCaseDAL.GetItem(id);
            Client client = ClientBLL.GetItem(clientCase.ClientId);
            Prescription presc = PrescriptionBLL.GetByCase(clientCase.CaseId);
            try
            {
                Relatives rel = RelativesBLL.GetItem(clientCase.ClientId);
                clientCase.ClientRelName = rel.ClientRelName;

            }
            catch (Exception)
            {                
            }
            clientCase.FullName = client.FullName;
            clientCase.Mob = client.Mob;
            clientCase.Gender = client.Gender;
            clientCase.PrescriptionStatus = presc.Status;

            //Prescription
            
            return clientCase;
        }

        public static List<ClientCase> GetList()
        {
            return ClientCaseDAL.GetList();
        }

        public static List<ClientCase> GetListView()
        {
            List<ClientCase> clientCases = ClientCaseDAL.GetList();
            for (int i = 0; i < clientCases.Count; i++)
            {
                Client client = ClientBLL.GetItem(clientCases[i].ClientId);
                Prescription prescription = PrescriptionBLL.GetByCase(clientCases[i].CaseId);
                clientCases[i].FullName = client.FullName;
                clientCases[i].Mob = client.Mob;
                clientCases[i].Gender = client.Gender;
                //Prescription
                clientCases[i].PrescriptionId = prescription.PrescriptionId;
                clientCases[i].PrescriptionStatus = prescription.Status;
                clientCases[i].ConfermedComment = prescription.ConfermedComment;
            }


            return clientCases;
        }

        public static int Insert(ClientCase clientCase)
        {
            clientCase.CaseId = ClientCaseDAL.Insert(clientCase);
            return clientCase.CaseId;
        }

        public static int UpdateByCase(ClientCase clientCase)
        {
            clientCase.CaseId = ClientCaseDAL.Update(clientCase);
            return clientCase.CaseId;
        }

        //Close the case. -> Deactivate all assoicated data.
        //Delete the case. -> Delte all assoicated data.

    }
}
