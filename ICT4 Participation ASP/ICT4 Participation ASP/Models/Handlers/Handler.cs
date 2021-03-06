﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Database;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.Models.Handlers
{
    public class Handler
    {
        protected Repository Db { get; private set; }

        public Handler()
        {
            OracleDatabase odb = new OracleDatabase();
            if (odb.CheckConnection())
            {
                Db = odb;
            }
            else
            {
                Db = new InMemoryDatabase();
            }
            // User = new Admin(1, "Henk", "@F", "234567890");
        }

        /// <summary>
        /// methode waarmee een gebruiker kan inloggen doormddel van een username en password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Account Login(List<object> parameters)
        {
            DataTable dt = Db.ExecuteReadQuery(null, Db.ExecuteSqlFunction(parameters, DatabaseQueries.Query[QueryId.GetUserLogin]).ToString());

            Account loggedAccount = null;

            foreach (DataRow dr in dt.Rows)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new Exception("Er zijn meer dan 1 Accounts gevonden.. Neem contact op met de beheerder");
                }
                 
                string role = dr["Role"].ToString();

                if (role == "ADMIN")
                {
                    loggedAccount = new Admin(dr);

                }
                else if (role == "NEEDY")
                {
                    loggedAccount = new Needy(dr);

                }
                else if (role == "VOLUNTEER")
                {
                    loggedAccount = new Volunteer(dr);
                }
                else
                {
                    throw new Exception("Kan de gegevens niet ophalen, meld dit aan de beheerder");
                }
            }
            if (dt.Rows.Count == 0)
            {
                throw new Exception("Er is geen account gevonden met deze gebruikersnaam en wachtwoord");
            }

            return loggedAccount;
        }

        /// <summary>
        /// methode waarmee een admin kan inloggen doormddel van een username, password en barcode
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="Barcode"></param>
        public Needy LoginBar(List<object> parameters)
        {
            if (parameters.Count != 1) throw new Exception("Er zijn meer dan 1 accounts gevonden, neem contact op met de systeem beheerder.");

            DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetUserLoginByBarcode]);

            Account loggedAccount = null;

            foreach (DataRow dr in dt.Rows)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new Exception("Er zijn meer dan 1 Accounts gevonden.. Neem contact op met de beheerder");
                }
                try
                {
                    loggedAccount = new Needy(dr);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (dt.Rows.Count == 0)
            {
                throw new Exception("Er is geen account gevonden met deze barcode");
            }
            return (Needy)loggedAccount;
        }

        public void AddVolunteer(string username, string email, string name, DateTime birthdate, string address, string city, string phonenumber, string photo, string vog, int haslicense, int hascar, string password)
        {
            List<object> objects = new List<object>();
            objects.Add(username);
            objects.Add(password);
            objects.Add(email);
            objects.Add(name);
            objects.Add(address);
            objects.Add(city);
            objects.Add(phonenumber);
            objects.Add(haslicense);
            objects.Add(hascar);
            objects.Add(birthdate);
            objects.Add(photo);
            objects.Add(vog);
            Db.ExecuteSqlProcedure(objects, DatabaseQueries.Query[QueryId.InsertVolunteer]);
        }

        public void AddChatMessage(HelpRequest helpRequest, User user, string message, DateTime time)
        {
            helpRequest.AddChatMessages(new ChatMessage(user.ID, user.Name, helpRequest.ID, time, message));

            List<object> objects = new List<object>();

            objects.Add(user.ID);
            objects.Add(user.Name);
            objects.Add(helpRequest.ID);
            objects.Add(time);
            objects.Add(message);

            Db.ExecuteNonQuery(objects, DatabaseQueries.Query[QueryId.InsertChatMessage]);
        }

        public void GetChatMessages(HelpRequest helpRequest)
        {
            List<object> parameters = new List<object>();

            parameters.Add(helpRequest.ID);

            DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetChatMessagesFromHelprequest]);

            List<ChatMessage> chatMessages = new List<ChatMessage>();

            helpRequest.ChatMessages.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                chatMessages.Add(new ChatMessage(dr));
            }

            helpRequest.ChatMessages.AddRange(chatMessages);
        }

        public List<Volunteer> GetUsersFromHelprequest(int helprequestId)
        {
            List<object> parameters = new List<object>();

            parameters.Add(helprequestId);

            DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetVolunteersHelprequest]);


            List<Volunteer> acceptedVolunteers = new List<Volunteer>();

            foreach (DataRow dr in dt.Rows)
            {
                acceptedVolunteers.Add(new Volunteer(dr));
            }

            return acceptedVolunteers;
        }

        public List<Skill> GetSkills()
        {
            List<Skill> skills = new List<Skill>();

            DataTable dt = Db.ExecuteReadQuery(null, DatabaseQueries.Query[QueryId.GetSkills]);

            foreach (DataRow dr in dt.Rows)
            {
                skills.Add(new Skill(dr));
            }
            return skills;
        }

        public int GetUserWarned(string username)
        {
            List<object> objects = new List<object>();
            objects.Add(username);
            DataTable dt = Db.ExecuteReadQuery(objects, DatabaseQueries.Query[QueryId.GetUserWarned]);

            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                return Convert.ToInt32(dr[0]);
            }
            else
            {
                throw new Exception("Error: Geen of meer dan één waarde gevonden.");
            }
        }

        public void ResetUserWarned(string username)
        {
            List<object> objects = new List<object>();
            objects.Add(username);
            Db.ExecuteNonQuery(objects, DatabaseQueries.Query[QueryId.ResetUserWarned]);
        }

        ///// <summary>
        ///// methode waarmee een needy kan inloggen doormddel van een rfid
        ///// </summary>
        ///// <param name="barcode"></param>
        //public void LoginWithBarcode(string barcode)
        //{
        //    try
        //    {
        //        if (barcode != null)
        //        {
        //            User = Database.LoginWithBarcode(barcode);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// Methode waarmee de gebruiker wordt uitgelogt
        ///// </summary>
        //public void Logout()
        //{
        //    User = null;
        //}

        ///// <summary>
        ///// Methode waarm de user zich uitschrijft
        ///// </summary>
        ///// <param name="user"></param>
        //public void Unsubscribe(User user)
        //{
        //    if (user != null)
        //    {
        //        Database.UnSubscribe(user);
        //    }
        //}

        //public bool AddVolunteer(string username, string password, string email, string name, string address,
        //    string city, string phonenumber, bool publicTransport, bool hasdrivinglicence, bool hascar,
        //    DateTime birthdate, string photo, string vog)
        //{
        //    try
        //    {
        //        bool succes  = Database.AddVolunteer(new Volunteer(username, email, name, address, city, phonenumber, hasdrivinglicence, hascar,
        //            birthdate, photo, vog), password);
        //        return succes;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public bool AddNeedy(string username, string password, string email, string name, string adres, string city,
        //    string phonenumber, bool publictransport, bool hasdrivinglicence, bool hascar, string barcode)
        //{
        //    try
        //    {
        //        bool succes = Database.AddNeedy(new Needy(username, email, name, adres, city, phonenumber, publictransport, hasdrivinglicence, hascar, barcode), password);
        //        return succes;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public List<Review> GetAllReviews()
        //{
        //    try
        //    {
        //        return Database.GetAllReviews();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public bool UpdateVolunteer(string username, string password, string email, string name, string address,
        //   string city, string phonenumber, bool publicTransport, bool hasdrivinglicence, bool hascar,
        //   DateTime birthdate, string photo, string vog)
        //{
        //    try
        //    {
        //        bool succes = Database.UpdateVolunteer(new Volunteer(username, email, name, address, city, phonenumber, hasdrivinglicence, hascar,
        //            birthdate, photo, vog), password);
        //        return succes;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void DeleteHelprequest(int id)
        //{
        //    try
        //    {
        //        Database.DeleteHelprequest(id);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void DeleteReview(int HelpRequestID, int VolunteerID, string message)
        //{
        //    try
        //    {
        //        Database.DeleteReview(HelpRequestID, VolunteerID, message);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void AcceptVolunteer(int ID)
        //{
        //    try
        //    {
        //       Database.AcceptVolunteer(ID);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public void DenyVolunteer(int ID)
        //{
        //    try
        //    {
        //        Database.DenyVolunteer(ID);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public List<int> GetAcceptedHelpRequests(OracleParameter[] parameter)
        //{
        //    try
        //    {
        //        return Database.GetAcceptedHelpRequests(parameter);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public List<Volunteer> GetAllVolunteers(string query)
        //{
        //    return Database.GetAllVolunteers(query);
        //}

        //public List<HelpRequest> GetHelpRequests(string query, OracleParameter[] parameters)
        //{
        //    return Database.GetHelpRequests(query, parameters);
        //}

    }
}