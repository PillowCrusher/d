using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4Participation.Classes.Database;
using Oracle.ManagedDataAccess.Client;

namespace ICT4Participation.Classes.ClassObjects
{
    public class Admin : Account
    {
        public string RFID { get; set; }

        public Admin(int id, string username, string email,string rfid)
            :base(id, username, email)
        {
            RFID = rfid;
        }

        public void BlockAccount(User user)
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

        public void SendWarning(string message, Volunteer volunteer)
        {
            try
            {
                OracleParameter[] userParameter =
                {
                new OracleParameter("id", volunteer.ID)
                };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["BlockVolunteer"], userParameter);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public void AddRfidToUser(Needy needy, string RFID)
        {
            OracleParameter[] userParameter =
                {
                new OracleParameter("rfid", RFID),
                new OracleParameter("id", needy.ID)
                };
            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["AddRFIDToNeedy"], userParameter);
        }
    }
}
