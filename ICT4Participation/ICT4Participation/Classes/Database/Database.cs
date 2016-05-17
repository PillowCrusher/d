using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4Participation.Classes.ClassObjects;
using ICT4Participation.Classes.Intelligence;
using Oracle.ManagedDataAccess.Client;
using Phidgets;

namespace ICT4Participation.Classes.Database
{
    public class Database
    {
        private Administration _administration;

        public Database(Administration administration)
        {
            _administration = administration;
        }

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

        public List<HelpRequest> GetHelpRequests(string querie, OracleParameter[] parameters)
        {
            List<HelpRequest> helpRequests = new List<HelpRequest>();
            
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query[querie], parameters);

            foreach (DataRow dr in dt.Rows)
            {

                helpRequests.Add(
                    new HelpRequest(
                        Convert.ToInt32(dr["ID"]),
                        dr["Name"].ToString(),
                        dr["Title"].ToString(),
                        dr["Description"].ToString(),
                        dr["Location"].ToString(),
                        Convert.ToBoolean(dr["Urgent"]),
                        (TransportationType)Enum.Parse(typeof(TransportationType), dr["TransportType"].ToString()),
                        Convert.ToDateTime(dr["StartDate"]),
                        Convert.ToDateTime(dr["EndDate"]),
                        Convert.ToBoolean(dr["Interview"])
                        )
                    );
            }

            return helpRequests;
        }


        public List<Volunteer> GetAllVolunteers(string queryName)
        {
            List<Volunteer> volunteers = new List<Volunteer>();

            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query[queryName], null);
            foreach (DataRow dr in dt.Rows)
            {
                volunteers.Add(
                    new Volunteer(
                        Convert.ToInt32(dr["ID"]),
                        dr["Username"].ToString(),
                        dr["Email"].ToString(),
                        dr["Name"].ToString(),
                        dr["Adress"].ToString(),
                        dr["City"].ToString(),
                        dr["Phonenumber"].ToString(),
                        Convert.ToBoolean(dr["OVpossible"]),
                        Convert.ToBoolean(dr["HasDrivingLicence"]),
                        Convert.ToBoolean(dr["HasCar"]),
                        Convert.ToDateTime(dr["DateOfBirth"]),
                        dr["Photo"].ToString(),
                        dr["VOG"].ToString(),
                        Convert.ToBoolean(dr["ISWARNED"]),
                        Convert.ToBoolean(dr["ISBLOCKED"]), _administration)
                    );

            }
            return volunteers;
        }
    }
}
