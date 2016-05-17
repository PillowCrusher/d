using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4Participation.Classes.ClassObjects;
using Oracle.ManagedDataAccess.Client;

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
    }
}
