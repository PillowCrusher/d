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
                    bool isWarned = Convert.ToBoolean(dr["ISWARNED"]);


                    if (dr["DATEOFBIRTH"] != DBNull.Value && dr["PHOTO"] != DBNull.Value && dr["VOG"] != DBNull.Value && dr["ADRESS"] != DBNull.Value && dr["CITY"] != DBNull.Value)
                    {
                        DateTime birthdate = Convert.ToDateTime(dr["DATEOFBIRTH"]);
                        string photo = dr["PHOTO"].ToString();
                        string vog = dr["VOG"].ToString();
                        string adres = dr["ADRESS"].ToString();
                        string city = dr["CITY"].ToString();
                        bool blocked = Convert.ToBoolean(dr["ISBLOCKED"]);
                        bool accpeted = Convert.ToBoolean(dr["ACCEPTED"]);
                        if (accpeted)
                        {
                           // throw new NotImplementedException(
                             //   "IsWarned moet worden opgehaald voor het toevoegen van volunteer");
                            account = new Volunteer(id, userName, email, name, adres, city, phonenumber,
                            ovPossible, drivingLicence, car, birthdate, photo, vog, isWarned, blocked);
                        }
                    }
                    else if (dr["RFID"] != DBNull.Value && dr["LOCATION"] != DBNull.Value)
                    {
                        string rfid = dr["RFID"].ToString();
                        string location = dr["LOCATION"].ToString();

                        account = new Needy(id, userName, email, name, location, phonenumber,
                            ovPossible, drivingLicence, car, rfid, isWarned);
                    }
                }
                User = account;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Login(string username, string password, string RFID)
        {
            OracleParameter[] parameters =
            {
                new OracleParameter("username", username),
                new OracleParameter("password", password),
                new OracleParameter("rfid", RFID)
            };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAdminLogin"], parameters);
            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["ID"]);
                string userName = Convert.ToString(dr["USERNAME"]);
                string email = Convert.ToString(dr["EMAIL"]);
                string rfid = Convert.ToString(dr["RFID"]);
                User = new Admin(id, userName, email, rfid);
            }
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
                    bool isWarned = Convert.ToBoolean(dr["ISWARNED"]);

                    if (dr["DATEOFBIRTH"] != DBNull.Value && dr["PHOTO"] != DBNull.Value && dr["VOG"] != DBNull.Value && dr["ADRESS"] != DBNull.Value && dr["CITY"] != DBNull.Value)
                    {
                        DateTime birthdate = Convert.ToDateTime(dr["DATEOFBIRTH"]);
                        string photo = dr["PHOTO"].ToString();
                        string vog = dr["VOG"].ToString();
                        string adres = dr["ADRESS"].ToString();
                        string city = dr["CITY"].ToString();
                        bool blocked = Convert.ToBoolean(dr["ISBLOCKED"]);

                        //throw new NotImplementedException("IsWarned moet worden opgehaald voor het toevoegen van volunteer");
                        account = new Volunteer(id, userName, email, name, adres, city, phonenumber,
                            ovPossible, drivingLicence, car, birthdate, photo, vog, isWarned, blocked);
                    }
                    else if (dr["RFID"] != DBNull.Value && dr["LOCATION"] != DBNull.Value)
                    {
                        string RFID = dr["RFID"].ToString();
                        string location = dr["LOCATION"].ToString();

                        account = new Needy(id, userName, email, name, location, phonenumber,
                            ovPossible, drivingLicence, car, RFID, isWarned);
                    }
                }
                User = account;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Logout()
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
                throw new Exception(ex.Message);
            }
        }

        public List<HelpRequest> GetHelpRequests(string querie, OracleParameter[] parameters)
        {
            List<HelpRequest> helpRequests = new List<HelpRequest>();

            /*
            OracleParameter[] parameter =
            {
                new OracleParameter("USERID", Convert.ToInt32(row[3]))
            };
            */

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
                        DateTime.Now, //Convert.ToDateTime(dr["StartDate"]),
                        DateTime.Now, //Convert.ToDateTime(dr["EndDate"]),
                        Convert.ToBoolean(dr["Interview"]),
                        User
                        )
                    );
            }

            return helpRequests;
        }

        public List<Volunteer> GetAllVolunteers()
        {
            List<Volunteer> volunteers = new List<Volunteer>();

            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllVolunteers"], null);

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
                        DateTime.Now,// Convert.ToDateTime(dr["DateOfBirth"]),
                        dr["Photo"].ToString(),
                        dr["VOG"].ToString(),
                        Convert.ToBoolean(dr["ISWARNED"]),
                        Convert.ToBoolean(dr["ISBLOCKED"]))
                    );
            }

            return volunteers;
        }

        public void BlockAccount(User user)
        {
            Admin admin = ((Admin)User);
            admin.BlockAccount(user);
        }

        public void SendWarning(string message, User user)
        {
            Admin admin = ((Admin)User);
            admin.SendWarning(message, user);
        }

        public void AddRfidToUser(Needy needy, string rfid)
        {
            Admin admin = ((Admin)User);
            admin.AddRfidToUser(needy, rfid);
        }

        public void UpdateVolunteer(string password, string adress, string city, string phonenumber, bool publicTransport, bool drivingLincence, bool hasCar, DateTime birhtDay, string photoFile, string VOGFile)
        {
            try
            {
                OracleParameter[] userParameter =
                {
                new OracleParameter("phonenumber", phonenumber),
                new OracleParameter("hasdrivinglicence", Convert.ToInt32(drivingLincence)),
                new OracleParameter("hascar", Convert.ToInt32(hasCar)),
                new OracleParameter("ovpossible", Convert.ToInt32(publicTransport)),
                new OracleParameter("id", User.ID)
            };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["UpdateUser"], userParameter);

                OracleParameter[] volunteerParameter =
                {
                new OracleParameter("dateofbirth", birhtDay),
                new OracleParameter("photo", photoFile),
                new OracleParameter("vog", VOGFile),
                new OracleParameter("adress", adress),
                new OracleParameter("city", city),
                new OracleParameter("id", User.ID)
            };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["UpdateVolunteer"], volunteerParameter);

                Login(User.Username, password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
