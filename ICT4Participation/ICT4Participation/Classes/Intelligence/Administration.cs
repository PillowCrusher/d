using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;
using ICT4Participation.Classes.ClassObjects;
using ICT4Participation.Classes.Database;

namespace ICT4Participation.Classes.Intelligence
{
    public class Administration
    {

        public Account User { get; private set; }
        //  public List<User> Users { get; private set; }

        public Administration()
        {
        }

        public void Login(string username, string password)
        {
            try
            {
                OracleParameter[] loginParameter =
                {
                    new OracleParameter("username", username),
                    new OracleParameter("password", password)
                };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetUserLogin"],
                    loginParameter);
                Account account = null;

                foreach (DataRow dr in dt.Rows)
                {

                    int id = Convert.ToInt32(dr["ID"]);
                    string userName = dr["USERNAME"].ToString();
                    string email = dr["EMAIL"].ToString();
                    string name = dr["NAME"].ToString();
                    string phonenumber = dr["PHONENUMBER"].ToString();
                    bool drivingLicence = Convert.ToBoolean(dr["HASDRIVINGLICENCE"]);
                    bool car = Convert.ToBoolean(dr["HASCAR"]);
                    bool ovPossible = Convert.ToBoolean(dr["OVPOSSIBLE"]);

                    if (dr["DATEOFBIRTH"] != DBNull.Value && dr["PHOTO"] != DBNull.Value && dr["VOG"] != DBNull.Value && dr["ADRESS"] != DBNull.Value && dr["CITY"] != DBNull.Value)
                    {
                        DateTime birthdate = Convert.ToDateTime(dr["DATEOFBIRTH"]);
                        string photo = dr["PHOTO"].ToString();
                        string vog = dr["VOG"].ToString();
                        string adres = dr["ADRESS"].ToString();
                        string city = dr["CITY"].ToString();
                        account = new Volunteer(id, userName, email, name, adres, city, phonenumber,
                            ovPossible, drivingLicence, car, birthdate, photo, vog);
                    }
                    else if (dr["RFID"] != DBNull.Value && dr["LOCATION"] != DBNull.Value)
                    {
                        string rfid = dr["RFID"].ToString();
                        string location = dr["LOCATION"].ToString();

                        account = new Needy(id, userName, email, name, location, phonenumber,
                            ovPossible, drivingLicence, car, rfid);
                    }
                }
                User = account;
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
            return new Needy(1, "henk", "email@email.com", "Henk", "Oes Hoes", "+316 12345678", true, false, false, "1234");
            //return _currentUser;
        }

        public void LoginWithRfid(string rfid)
        {
            try
            {
                OracleParameter[] loginParameter =
                {
                    new OracleParameter("rfid", rfid),
                };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetUserLoginByRFID"],
                    loginParameter);
                Account account = null;

                foreach (DataRow dr in dt.Rows)
                {

                    int id = Convert.ToInt32(dr["ID"]);
                    string userName = dr["USERNAME"].ToString();
                    string email = dr["EMAIL"].ToString();
                    string name = dr["NAME"].ToString();
                    string phonenumber = dr["PHONENUMBER"].ToString();
                    bool drivingLicence = Convert.ToBoolean(dr["HASDRIVINGLICENCE"]);
                    bool car = Convert.ToBoolean(dr["HASCAR"]);
                    bool ovPossible = Convert.ToBoolean(dr["OVPOSSIBLE"]);

                    if (dr["DATEOFBIRTH"] != DBNull.Value && dr["PHOTO"] != DBNull.Value && dr["VOG"] != DBNull.Value && dr["ADRESS"] != DBNull.Value && dr["CITY"] != DBNull.Value)
                    {
                        DateTime birthdate = Convert.ToDateTime(dr["DATEOFBIRTH"]);
                        string photo = dr["PHOTO"].ToString();
                        string vog = dr["VOG"].ToString();
                        string adres = dr["ADRESS"].ToString();
                        string city = dr["CITY"].ToString();
                        account = new Volunteer(id, userName, email, name, adres, city, phonenumber,
                            ovPossible, drivingLicence, car, birthdate, photo, vog);
                    }
                    else if (dr["RFID"] != DBNull.Value && dr["LOCATION"] != DBNull.Value)
                    {
                        string RFID = dr["RFID"].ToString();
                        string location = dr["LOCATION"].ToString();

                        account = new Needy(id, userName, email, name, location, phonenumber,
                            ovPossible, drivingLicence, car, RFID);
                    }
                }
                User = account;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Logout(string username)
        {
            User = null;
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

                InsertAccount(username, password, email);

                int volunteerId = GetAccountId(username);
                
                InsertUser(volunteerId, name, phonenumber, hasdrivinglicence, hascar, publicTransport);

                OracleParameter[] volunteerParameter =
            {
                new OracleParameter("id", volunteerId), 
                new OracleParameter("dateofbirth", birthdate), 
                new OracleParameter("photo", photo), 
                new OracleParameter("vog", vog),
                new OracleParameter("adress", address),
                new OracleParameter("city", city)  
            };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertVolunteer"], volunteerParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddNeedy(string username, string password, string email, string name, string location, 
            string phonenumber, bool publictransport, bool hasdrivinglicence, bool hascar, string rfid)
        {
            try
            {
                InsertAccount(username, password, email);

                int needyId = GetAccountId(username);

                InsertUser(needyId, name, phonenumber, hasdrivinglicence, hascar, publictransport);

                OracleParameter[] needyParameter =
            {
                new OracleParameter("id", needyId),
                new OracleParameter("rfid", rfid),
                new OracleParameter("location", location) 
            };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertNeedy"], needyParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetAccountId(string username)
        {
            int id = 0;
            OracleParameter[] idParameter =
                {
                    new OracleParameter("username", username)
                };
            DataTable d = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAccountID"], idParameter);
            foreach (DataRow dr in d.Rows)
            {
                id = Convert.ToInt32(dr["ID"]);
            }
            return id;
        }

        public void InsertAccount(string username, string password, string email)
        {
            try
            {
                OracleParameter[] accountParameter =
                {
                new OracleParameter("username", username),
                new OracleParameter("password", password),
                new OracleParameter("email", email)
            };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertAccount"], accountParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertUser(int id, string name, string phonenumber, bool hasdrivinglicence, bool hascar, bool publictransport)
        {
            try
            { 
            OracleParameter[] userParameter =
            {
                new OracleParameter("id", id),
                new OracleParameter("name", name),
                new OracleParameter("phonenumber", phonenumber),
                new OracleParameter("hasdrivinglicence", Convert.ToInt32(hasdrivinglicence)),
                new OracleParameter("hascar", Convert.ToInt32(hascar)),
                new OracleParameter("ovpossible", Convert.ToInt32(publictransport))
            };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertUser"], userParameter);
            }
            catch (Exception ex)
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
                        Convert.ToBoolean(dr["Interview"])
                        )
                    );
            }

            return helpRequests;
        }
    }
}
