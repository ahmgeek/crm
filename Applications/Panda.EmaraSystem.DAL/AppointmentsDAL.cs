using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.EmaraSystem.BO;

namespace Panda.EmaraSystem.DAL
{
   public class AppointmentsDAL 
   {


       //public int AppointmentInsert(AppointmentsBO appBO)
       //{
       //    object o = DataManager.ExecuteScalar("ESystem_AppointmentInsert",
       //        DataManager.CreateParameter("@Clintid", System.Data.SqlDbType.Int, appBO.ClientId),
       //        DataManager.CreateParameter("@appdate", System.Data.SqlDbType.DateTime, appBO.AppointmentDate),
       //        DataManager.CreateParameter("@appstarttime", System.Data.SqlDbType.NVarChar, appBO.StartTime),
       //        DataManager.CreateParameter("@creationdate", System.Data.SqlDbType.DateTime, appBO.CreationDate),
       //        DataManager.CreateParameter("@modifieddate", System.Data.SqlDbType.DateTime, appBO.ModifiedDate),
       //        DataManager.CreateParameter("@createdby", System.Data.SqlDbType.NVarChar, appBO.CreatedBy),
       //        DataManager.CreateParameter("@modifiedby", System.Data.SqlDbType.NVarChar, appBO.ModifiedBy),
       //        DataManager.CreateParameter("@isactive", System.Data.SqlDbType.Bit, appBO.IsActive));
       //    appBO.AppointmentId = (int)o;
       //    return appBO.AppointmentId;
       //}

       //public int AppointmentUpdate(AppointmentsBO appBO)
       //{
       //    object o = DataManager.ExecuteScalar("ESystem_AppointmentUpdate",
       //        DataManager.CreateParameter("@Appid", System.Data.SqlDbType.Int, appBO.AppointmentId),
       //        DataManager.CreateParameter("@Clintid", System.Data.SqlDbType.Int, appBO.ClientId),
       //        DataManager.CreateParameter("@appdate", System.Data.SqlDbType.DateTime, appBO.AppointmentDate),
       //        DataManager.CreateParameter("@appstarttime", System.Data.SqlDbType.NVarChar, appBO.StartTime),
       //        DataManager.CreateParameter("@creationdate", System.Data.SqlDbType.DateTime, appBO.CreationDate),
       //        DataManager.CreateParameter("@modifieddate", System.Data.SqlDbType.DateTime, appBO.ModifiedDate),
       //        DataManager.CreateParameter("@createdby", System.Data.SqlDbType.NVarChar, appBO.CreatedBy),
       //        DataManager.CreateParameter("@modifiedby", System.Data.SqlDbType.NVarChar, appBO.ModifiedBy),
       //        DataManager.CreateParameter("@isactive", System.Data.SqlDbType.Bit, appBO.IsActive));
       //    appBO.AppointmentId = (int)o;
       //    return appBO.AppointmentId;
       //}



    }
}
