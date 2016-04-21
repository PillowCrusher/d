using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4Participation.Classes.ClassObjects;
using ICT4Participation.Classes.Database;
using Oracle.ManagedDataAccess.Client;
using System.Data;

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
            Users.Add(new Needy(new Account(username, password, email), name, address, city, phonenumber, publictransport, hasdrivinglicence, hascar, rfid));
        }

        public List<HelpRequest> GetAllHelpRequests(OracleParameter[] parameters)
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
