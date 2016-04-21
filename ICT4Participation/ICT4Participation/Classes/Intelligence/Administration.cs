using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using ICT4Participation.Classes.ClassObjects;
using ICT4Participation.Classes.Database;

namespace ICT4Participation.Classes.Intelligence
{
    public class Administration
    {
        private static User _currentUser;

        public List<User> Users { get; private set; }

        public Administration()
        {
            Users = new List<User>();
        }

        public User Login(string username, string password)
        {
            return null;
        }

        public Admin Login(string username, string password, string RFID)
        {
            return null;
        }

        public User GetCurrentUser()
        {
            return _currentUser;
        }

        public User LoginWithRfid(string rfid)
        {
            return null;
        }

        public void Logout(string username)
        {

        }

        public void Unsubscribe(User user)
        {
            user.UnSubscribe();
        }

        public void AddVolunteer(string username, string password, string email, string name, string address, 
            string city, string phonenumber, bool publicTransport, bool hasdrivinglicence, bool hascar, 
            DateTime birthdate, string photo, string vog)
        {
            Users.Add(new Volunteer(new Account(username,password, email), name, address, city, phonenumber,publicTransport, hasdrivinglicence, hascar, birthdate, photo, vog));
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
                Needy needy = new Needy(new Account(username, password, email), name, address, city, phonenumber, publictransport, hasdrivinglicence, hascar, rfid);

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
