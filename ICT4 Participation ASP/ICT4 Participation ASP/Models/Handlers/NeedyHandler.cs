﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Database;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.Models.Handlers
{
    public class NeedyHandler : Handler
    {

        public void AddHelprequest(Needy user, string titel, string description, string location, int traveltime,  int urgent, string Transportation, DateTime startTime, DateTime endTime, int ammount, int meeting)//string skills)
        {
            List<object> parameters = new List<object>();
            parameters.Add(user.ID);
            parameters.Add(titel);
            parameters.Add(description);
            parameters.Add(location);
            parameters.Add(traveltime);
            parameters.Add(urgent);
            parameters.Add(Transportation);
            parameters.Add(startTime);
            parameters.Add(endTime);
            parameters.Add(ammount);
            parameters.Add(meeting);
            // parameters.Add(skills);
            Db.ExecuteNonQuery(parameters, DatabaseQueries.Query[QueryId.InsertHelprequest]);

            parameters.Clear();
            parameters.Add(user.ID);
            parameters.Add(titel);
            parameters.Add(startTime);
            parameters.Add(endTime);
            DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetUserHelpRequest]);

            foreach (DataRow dr in dt.Rows)
            {
                HelpRequest request = new HelpRequest(dr);
                user.AddHelpRequest(request);
            }
        }

        public List<HelpRequest> GetHelprequests(Needy user)
        {           
            List<object> parameters = new List<object>();
            parameters.Add(user.ID);

            DataTable dt =  Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetUserHelpRequests]);
            
            List<HelpRequest> requestses = new List<HelpRequest>();
            foreach (DataRow dr in dt.Rows)
            {
                HelpRequest request = new HelpRequest(dr);
                user.AddHelpRequest(request);
            }
            return requestses;
        }

        public void AddReview(HelpRequest helpRequest, Volunteer volunteer, string message)
        {
            helpRequest.AddReview(new Review(volunteer, message));
            List<object> parameters = new List<object>();
            parameters.Add(helpRequest.ID);
            parameters.Add(volunteer.ID);
            parameters.Add(message);
            Db.ExecuteNonQuery(parameters, DatabaseQueries.Query[QueryId.InsertReview]);
        }

        public void CompleteHelpreqeust(HelpRequest helpRequest)
        {
            List<object> parameters = new List<object>();
            parameters.Add(helpRequest.ID);
            Db.ExecuteNonQuery(parameters, DatabaseQueries.Query[QueryId.CompleteHelpRequest]);
        }

        public List<HelpRequest> GetPendingVolunteers(Needy user)
        {
            List<object> parameters = new List<object>();
            parameters.Add(user.ID);
            DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetAllHelpRequests]);

            List<HelpRequest> helpRequests = new List<HelpRequest>();
            HelpRequest hr;
            foreach (DataRow dr in  dt.Rows)
            {
                hr = new HelpRequest(dr);
                List<object> objects = new List<object>();
                parameters.Add(hr.ID);
                DataTable dt2 = Db.ExecuteReadQuery(objects, DatabaseQueries.Query[QueryId.GetPendingVolunteers]);

                foreach (DataRow dr2 in dt2.Rows)
                {
                    hr.Pending.Add(new Volunteer(dr2));
                }
                helpRequests.Add(hr);
            }

            return helpRequests;
        }

        public void AcceptVolunteer(Volunteer volunteer, HelpRequest helpRequest)
        {
            helpRequest.AcceptVolunteer(volunteer);
            List<object> parameters = new List<object>();
            parameters.Add(helpRequest.ID);
            parameters.Add(volunteer.ID);
            Db.ExecuteNonQuery(parameters, DatabaseQueries.Query[QueryId.HelpRequestAccept]);
        }
        public void DeclineVolunteer(Volunteer volunteer, HelpRequest helpRequest)
        {
            helpRequest.DeclineVolunteer(volunteer);
            List<object> parameters = new List<object>();
            parameters.Add(helpRequest.ID);
            parameters.Add(volunteer.ID);
            Db.ExecuteNonQuery(parameters, DatabaseQueries.Query[QueryId.HelpRequestDecline]);
        }
    }
}
