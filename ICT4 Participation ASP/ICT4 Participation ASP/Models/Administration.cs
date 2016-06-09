using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace ICT4_Participation_ASP.Models
{
    public class Administration
    {
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
                if (username != null && password != null)
                {
                    User = Database.Login(username, password);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// methode waarmee een admin kan inloggen doormddel van een username, password en barcode
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="Barcode"></param>
        public void Login(string username, string password, string barcode)
        {
            try
            {
                if (username != null && password != null && barcode != null)
                {
                    User = Database.Login(username, password, barcode);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// methode waarmee een needy kan inloggen doormddel van een rfid
        /// </summary>
        /// <param name="barcode"></param>
        public void LoginWithBarcode(string barcode)
        {
            try
            {
                if (barcode != null)
                {
                    User = Database.LoginWithBarcode(barcode);
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
            if (user != null)
            {
                Database.UnSubscribe(user);
            }
        }

        public bool AddVolunteer(string username, string password, string email, string name, string address,
            string city, string phonenumber, bool publicTransport, bool hasdrivinglicence, bool hascar,
            DateTime birthdate, string photo, string vog)
        {
            try
            {
                bool succes  = Database.AddVolunteer(new Volunteer(username, email, name, address, city, phonenumber, hasdrivinglicence, hascar,
                    birthdate, photo, vog), password);
                return succes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddNeedy(string username, string password, string email, string name, string adres, string city,
            string phonenumber, bool publictransport, bool hasdrivinglicence, bool hascar, string barcode)
        {
            try
            {
                bool succes = Database.AddNeedy(new Needy(username, email, name, adres, city, phonenumber, publictransport, hasdrivinglicence, hascar, barcode), password);
                return succes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Review> GetAllReviews()
        {
            try
            {
                return Database.GetAllReviews();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateVolunteer(string username, string password, string email, string name, string address,
           string city, string phonenumber, bool publicTransport, bool hasdrivinglicence, bool hascar,
           DateTime birthdate, string photo, string vog)
        {
            try
            {
                bool succes = Database.UpdateVolunteer(new Volunteer(username, email, name, address, city, phonenumber, hasdrivinglicence, hascar,
                    birthdate, photo, vog), password);
                return succes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteHelprequest(int id)
        {
            try
            {
                Database.DeleteHelprequest(id);
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
                Database.DeleteReview(HelpRequestID, VolunteerID, message);
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
               Database.AcceptedVolunteer(ID);
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
                Database.DenyVolunteer(ID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<int> GetAcceptedHelpRequests(OracleParameter[] parameter)
        {
            try
            {
                return Database.GetAcceptedHelpRequests(parameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Volunteer> GetAllVolunteers(string query)
        {
            return Database.GetAllVolunteers(query);
        }

        public List<HelpRequest> GetHelpRequests(string query, OracleParameter[] parameters)
        {
            return Database.GetHelpRequests(query, parameters);
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

    }
}