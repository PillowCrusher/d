﻿using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;
using ICT4Participation.Classes.ClassObjects;
using ICT4Participation.Classes.Database;

namespace ICT4Participation.Classes.Intelligence
{
    public class Administration
    {
        //een field waar het ingelogde account in staat
        public Account User { get; private set; }
        private Database.Database Database { get; set; }

        public Administration()
        {
            Database = new Database.Database(this);
            // User = new Admin(1, "Henk", "@F", "234567890");
        }

        /// <summary>
        /// methode waarmee een gebruiker kan inloggen doormddel van een username en password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void Login(string username, string password)
        {
            try
            {
                //de parameters voor de query
                OracleParameter[] loginParameter =
                {
                    new OracleParameter("username", username),
                    new OracleParameter("password", password)
                };
                //Voer de query uit
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetUserLogin"],
                    loginParameter);
                Account account = null;
                //lees de gevonden data uit
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

                    //als de verjaardag, foto, vog, adress en woonplaats niet leeg zijn wordt een volunteer aangemaakt 
                    if (dr["DATEOFBIRTH"] != DBNull.Value && dr["PHOTO"] != DBNull.Value && dr["VOG"] != DBNull.Value &&
                        dr["ADRESS"] != DBNull.Value && dr["CITY"] != DBNull.Value)
                    {
                        DateTime birthdate = Convert.ToDateTime(dr["DATEOFBIRTH"]);
                        string photo = dr["PHOTO"].ToString();
                        string vog = dr["VOG"].ToString();
                        string adres = dr["ADRESS"].ToString();
                        string city = dr["CITY"].ToString();
                        bool blocked = Convert.ToBoolean(dr["ISBLOCKED"]);
                        bool accpeted = Convert.ToBoolean(dr["ACCEPTED"]);
                        if (blocked == false)
                        {
                            if (accpeted)
                            {

                                account = new Volunteer(id, userName, email, name, adres, city, phonenumber,
                                    ovPossible, drivingLicence, car, birthdate, photo, vog, isWarned, blocked, this);
                            }
                            else
                            {
                                throw new WarningException(
                                    "Je kunt nog niet inloggen, de administrator moet eerst je aanvraag goedkeuren");
                            }
                        }
                        else
                        {
                            throw new WarningException("Sorry, je account is geblokkeerd je kunt niet meer inloggen");
                        }
                    }
                    else if (dr["RFID"] != DBNull.Value && dr["LOCATION"] != DBNull.Value)
                    {
                        //als de rfid en locatie niet leeg zijn wordt een needy aangemaakt 
                        string rfid = dr["RFID"].ToString();
                        string location = dr["LOCATION"].ToString();

                        account = new Needy(id, userName, email, name, location, phonenumber,
                            ovPossible, drivingLicence, car, rfid, isWarned);
                    }
                }
                // zet de gevonden user in het Field user
                User = account;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// methode waarmee een admin kan inloggen doormddel van een username, password en rfid
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="RFID"></param>
        public void Login(string username, string password, string RFID)
        {
            //de parameters voor de query
            OracleParameter[] parameters =
            {
                new OracleParameter("username", username),
                new OracleParameter("password", password),
                new OracleParameter("rfid", RFID)
            };
            //Voer de query uit
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAdminLogin"], parameters);

            //lees de gevonden data uit
            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["ID"]);
                string userName = Convert.ToString(dr["USERNAME"]);
                string email = Convert.ToString(dr["EMAIL"]);
                string rfid = Convert.ToString(dr["RFID"]);
                //zet de gevonden user in het Field user
                User = new Admin(id, userName, email, rfid);
            }
        }

        /// <summary>
        /// methode waarmee een needy kan inloggen doormddel van een rfid
        /// </summary>
        /// <param name="rfid"></param>
        public void LoginWithRfid(string rfid)
        {
            try
            {
                //de parameters voor de query
                OracleParameter[] loginParameter =
                {
                    new OracleParameter("rfid", rfid),
                };

                //Voer de query uit
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetUserLoginByRFID"],
                    loginParameter);


                //lees de gevonden data uit
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
                    string RFID = dr["RFID"].ToString();
                    string location = dr["LOCATION"].ToString();

                    //zet de gevonden user in het Field user
                    User = new Needy(id, userName, email, name, location, phonenumber,
                        ovPossible, drivingLicence, car, RFID, isWarned);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Methode waarmee de gebruiker wordt uitgelogt
        /// </summary>
        public void Logout()
        {
            User = null;
        }

        /// <summary>
        /// Methode waarm de user zich uitschrijft
        /// </summary>
        /// <param name="user"></param>
        public void Unsubscribe(User user)
        {
            Database.UnSubscribe(user);
        }

        /// <summary>
        /// Methode waarmee een nieuwe vrijwilliger toegevoegd in de database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="phonenumber"></param>
        /// <param name="publicTransport"></param>
        /// <param name="hasdrivinglicence"></param>
        /// <param name="hascar"></param>
        /// <param name="birthdate"></param>
        /// <param name="photo"></param>
        /// <param name="vog"></param>
        public bool AddVolunteer(string username, string password, string email, string name, string address,
            string city, string phonenumber, bool publicTransport, bool hasdrivinglicence, bool hascar,
            DateTime birthdate, string photo, string vog)
        {
            try
            {
                //voeg een acount toe
                InsertAccount(username, password, email);

                //haal het id op van het account wat net is toegevoegd
                int volunteerId = GetAccountId(username);

                //voeg een user toe gekoppeld aan het account doormiddel van het ID
                InsertUser(volunteerId, name, phonenumber, hasdrivinglicence, hascar, publicTransport);

                //de parameters voor de query
                OracleParameter[] volunteerParameter =
                {
                    new OracleParameter("id", volunteerId),
                    new OracleParameter("dateofbirth", birthdate),
                    new OracleParameter("photo", photo),
                    new OracleParameter("vog", vog),
                    new OracleParameter("adress", address),
                    new OracleParameter("city", city)
                };
                //Voer de query uit om een vrijwilleger toe te voegen
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertVolunteer"], volunteerParameter);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddNeedy(string username, string password, string email, string name, string location,
            string phonenumber, bool publictransport, bool hasdrivinglicence, bool hascar, string rfid)
        {
            try
            {
                //voeg een acount toe
                InsertAccount(username, password, email);

                //haal het id op van het account wat net is toegevoegd
                int needyId = GetAccountId(username);

                //voeg een user toe gekoppeld aan het account doormiddel van het ID
                InsertUser(needyId, name, phonenumber, hasdrivinglicence, hascar, publictransport);

                //de parameters voor de query
                OracleParameter[] needyParameter =
                {
                    new OracleParameter("id", needyId),
                    new OracleParameter("rfid", rfid),
                    new OracleParameter("location", location)
                };
                //Voer de query uit om een hulpbehoevende toe te voegen
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertNeedy"], needyParameter);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Een methode om het account id op te halen door de zoeken naar de username van de account
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int GetAccountId(string username)
        {
            int id = 0;

            //de parameters voor de query
            OracleParameter[] idParameter =
            {
                new OracleParameter("username", username)
            };
            //Voer de query uit om het id op te halen
            DataTable d = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAccountID"], idParameter);

            //lees de gevonden data uit
            foreach (DataRow dr in d.Rows)
            {
                id = Convert.ToInt32(dr["ID"]);
            }
            //geef het gevonden ID terug
            return id;
        }

        /// <summary>
        /// methode om een user in de database toe te voegen
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public void InsertAccount(string username, string password, string email)
        {
            try
            {
                //de parameters voor de query
                OracleParameter[] accountParameter =
                {
                    new OracleParameter("username", username),
                    new OracleParameter("password", password),
                    new OracleParameter("email", email)
                };
                //Voer de query uit om een account toe te voegen
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertAccount"], accountParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertUser(int id, string name, string phonenumber, bool hasdrivinglicence, bool hascar,
            bool publictransport)
        {
            try
            {
                //de parameters voor de query
                OracleParameter[] userParameter =
                {
                    new OracleParameter("id", id),
                    new OracleParameter("name", name),
                    new OracleParameter("phonenumber", phonenumber),
                    new OracleParameter("hasdrivinglicence", Convert.ToInt32(hasdrivinglicence)),
                    new OracleParameter("hascar", Convert.ToInt32(hascar)),
                    new OracleParameter("ovpossible", Convert.ToInt32(publictransport))
                };
                //Voer de query uit om een user toe te voegen
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertUser"], userParameter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        public List<Review> GetAllReviews()
        {
            List<Review> riviews = new List<Review>();

            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllReviews"], null);
            foreach (DataRow dr in dt.Rows)
            {
                riviews.Add(
                    new Review(
                        Convert.ToInt32(dr["HELPREQUESTID"]),
                        Convert.ToInt32(dr["VOLUNTEERID"]),
                        dr["MESSAGE"].ToString()
                        ));
            }

            return riviews;
        } 

        public void BlockAccount(User user)
        {
            if (User is Admin)
            {
                Database.BlockAccount(user);
                GetAllVolunteers("GetAcceptedVolunteers");
            }
        }

        public void SendWarning(string message, User user)
        {
            if (User is Admin)
            {
                Database.SendWarning(message, user);
            }
        }

        public void AddRfidToUser(Needy needy, string rfid)
        {
            if (User is Admin)
            {
                Database.AddRfidToUser(needy, rfid);
            }
        }

        public void UpdateVolunteer(string password, string adress, string city, string phonenumber,
            bool publicTransport, bool drivingLincence, bool hasCar, DateTime birhtDay, string photoFile, string VOGFile)
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

        public void DeleteHelprequest(int id)
        {
            try
            {
                OracleParameter[] deleteParameter =
                {
                    new OracleParameter("id", id)
                };
                DatabaseManager.ExecuteDeleteQuery(DatabaseQuerys.Query["DeleteHelpRequest"], deleteParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteReview(int HelpRequestID, int VolunteerID, string message)
        {
            try
            {
                OracleParameter[] deleteParameter =
                {
                    new OracleParameter("helprequestid", HelpRequestID),
                    new OracleParameter("volunteerid", VolunteerID),
                    new OracleParameter("message", message)
                };
                DatabaseManager.ExecuteDeleteQuery(DatabaseQuerys.Query["DeleteReview"], deleteParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AcceptedVolunteer(int ID)
        {
            try
            {
                OracleParameter[] updateParameter =
                {
                    new OracleParameter("id", ID)
                };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["AcceptedVolunteer"], updateParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DenyVolunteer(int ID)
        {
            try
            {
                OracleParameter[] deleteParameter =
                {
                    new OracleParameter("id", ID)
                };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["DenyVolunteer"], deleteParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<int> GetAcceptedHelpRequests(OracleParameter[] parameter)
        {
            List<int> helprequestIdList = new List<int>();

            try
            {
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAcceptedHelpRequests"],
                    parameter);

                foreach (DataRow dr in dt.Rows)
                {
                    helprequestIdList.Add(Convert.ToInt32(dr["HELPREQUESTID"]));
                }
            }
            catch (Exception)
            {

                throw;
            }
            return helprequestIdList;
        }

        public List<Volunteer> GetAllVolunteers(string query)
        {
            return Database.GetAllVolunteers(query);
        }

        public List<HelpRequest> GetHelpRequests(string query,OracleParameter[] parameters)
        {
            return Database.GetHelpRequests(query, parameters);
        }
    }
}
