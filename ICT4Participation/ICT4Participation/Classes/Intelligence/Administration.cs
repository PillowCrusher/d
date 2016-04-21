using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4Participation.Classes.ClassObjects;
using ICT4Participation.Classes.Database;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Types;

namespace ICT4Participation.Classes.Intelligence
{
    public class Administration
    {
        private static User _currentUser;

        public User user = null;
      //  public List<User> Users { get; private set; }

        public Administration()
        {
        }

        public User Login(string username, string password)
        {
            try
            {
                User user = null;
                OracleParameter[] loginParameter = 
            {
                new OracleParameter(":username", username),
                new OracleParameter(":password", password)
            };

                DataTable id = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetUserLogin"], null);
                foreach (DataRow dr in id.Rows)
                {
                  // user = new User(new Account())
                }
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Admin Login(string username, string password, string RFID)
        {
            return null;
        }

        public User GetCurrentUser()
        {
            return new Needy(new Account(1, "henk", "password", "email@email.com"), "Henk", "address", "city", "+316 12345678", true, false, false, "1234");
            return _currentUser;
        }

        public User LoginWithRfid(string rfid)
        {
            return null;
        }

        public void Logout(string username)
        {
            user = null;
        }

        public void Unsubscribe(User user)
        {
            user.UnSubscribe();
        }

        public void AddVolunteer(string username, string password, string email, string name, string address, 
            string city, string phonenumber, bool publicTransport, bool hasdrivinglicence, bool hascar, 
            DateTime birthdate, string photo, string vog)
        {
            try
            {
                int volunteerID = 0;
                DataTable id = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAccountID"], null);
                foreach (DataRow dr in id.Rows)
                {
                    volunteerID = Convert.ToInt32(dr["ACCOUNT_SEQ.nextval"]);
                }
                Volunteer volunteer = new Volunteer(new Account(volunteerID, username, password, email), name, address, city, phonenumber, publicTransport, hasdrivinglicence, hascar, birthdate, photo, vog);

                OracleParameter[] accountParameter = 
            {
                new OracleParameter(":id", volunteerID),
                new OracleParameter(":username", username),
                new OracleParameter(":password", password),
                new OracleParameter(":email", email)
            };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertAccount"], accountParameter);

                OracleParameter[] userParameter = 
            {
                new OracleParameter(":id", volunteerID),
                new OracleParameter(":name", name),
                new OracleParameter(":adress", address),
                new OracleParameter(":city", city),
                new OracleParameter(":phonenumber", phonenumber),
                new OracleParameter(":hasdrivinglicence", Convert.ToInt32(hasdrivinglicence)),
                new OracleParameter(":hascar", Convert.ToInt32(hascar)),
                new OracleParameter(":deregistrationdate", null),
                new OracleParameter(":ovpossible", Convert.ToInt32(publicTransport))

            };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertUser"], userParameter);

                OracleParameter[] volunteerParameter = 
            {
                new OracleParameter(":id", volunteerID), 
                new OracleParameter(":dateofbirth", birthdate), 
                new OracleParameter(":photo", photo), 
                new OracleParameter(":vog", vog)
            };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertVolunteer"], volunteerParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddNeedy(string username, string password, string email, string name, string address,
            string city, string phonenumber, bool publictransport, bool hasdrivinglicence,
            bool hascar, string rfid)
        {
            try
            {
                int needyID = 0;
                DataTable id = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAccountID"], null);
                foreach (DataRow dr in id.Rows)
                {
                    needyID = Convert.ToInt32(dr["ACCOUNT_SEQ.nextval"]);
                }
                Needy needy = new Needy(new Account(needyID, username, password, email), name, address, city, phonenumber, publictransport, hasdrivinglicence, hascar, rfid);

                OracleParameter[] accountParameter = 
            {
                new OracleParameter(":id", needyID),
                new OracleParameter(":username", username),
                new OracleParameter(":password", password),
                new OracleParameter(":email", email)
            };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertAccount"], accountParameter);

                OracleParameter[] userParameter = 
            {
                new OracleParameter(":id", needyID),
                new OracleParameter(":name", name),
                new OracleParameter(":adress", address),
                new OracleParameter(":city", city),
                new OracleParameter(":phonenumber", phonenumber),
                new OracleParameter(":hasdrivinglicence", Convert.ToInt32(hasdrivinglicence)),
                new OracleParameter(":hascar", Convert.ToInt32(hascar)),
                new OracleParameter(":deregistrationdate", null),
                new OracleParameter(":ovpossible", Convert.ToInt32(publictransport))
            };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertUser"], userParameter);

                OracleParameter[] needyParameter = 
            {
                new OracleParameter(":id", needyID),
                new OracleParameter(":rfid", rfid)
            };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertNeedy"], needyParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HelpRequest> GetHelpRequests(OracleParameter[] parameters)
        {
            List<HelpRequest> helpRequests = new List<HelpRequest>();

            /*
            OracleParameter[] parameter =
            {
                new OracleParameter("USERID", Convert.ToInt32(row[3]))
            };
            */

            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllHelpRequests"], parameters);

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
                        DateTime.Now, //Convert.ToDateTime(dr["StartDate"]),
                        DateTime.Now, //Convert.ToDateTime(dr["EndDate"]),
                        Convert.ToBoolean(dr["Interview"]),
                        Convert.ToBoolean(dr["Completed"])
                        )
                    );
            }

            return helpRequests;
        } 
    }
}
