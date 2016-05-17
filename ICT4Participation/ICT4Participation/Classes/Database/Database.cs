using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4Participation.Classes.ClassObjects;
using Oracle.ManagedDataAccess.Client;
using Phidgets;

namespace ICT4Participation.Classes.Database
{
    public class Database
    {
        public void UnSubscribe(User user)
        {
            try
            {
                DateTime deRegistrationDate = DateTime.Now;
                OracleParameter[] userParameter =
                {
                new OracleParameter("deregistrationdate", deRegistrationDate),
                new OracleParameter("id", user.ID)
                };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["UnsubscribeUser"], userParameter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void BlockAccount(User user)
        {
            try
            {
                OracleParameter[] userParameter =
                {
                new OracleParameter("id", user.ID)
                };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["BlockUser"], userParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SendWarning(string message, User user)
        {
            try
            {
                OracleParameter[] userParameter =
                {
                new OracleParameter("id", user.ID)
                };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["WarnUser"], userParameter);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void AddRfidToUser(Needy needy, string rfid)
        {
            OracleParameter[] userParameter =
                {
                new OracleParameter("rfid", rfid),
                new OracleParameter("id", needy.ID)
                };
            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["AddRFIDToNeedy"], userParameter);
        }
    }
}
