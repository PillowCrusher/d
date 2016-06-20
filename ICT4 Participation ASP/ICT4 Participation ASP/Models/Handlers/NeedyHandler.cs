using System;
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

        public List<object> GetPendingVolunteers(Needy user)
        {
            List<object> acceptedList = new List<object>();
            List<object> parameters = new List<object>();
            parameters.Add(user.ID);

            DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetPendingVolunteers]);

            List<Volunteer> volunteers = new List<Volunteer>();
            List<HelpRequest> helprequests = new List<HelpRequest>();
            foreach (DataRow dr in dt.Rows)
            {
                Volunteer volunteer = new Volunteer(dr);
                volunteers.Add(volunteer);
                HelpRequest helpRequest = new HelpRequest(Convert.ToInt32(dr[23]), dr[25].ToString(), dr[26].ToString(), dr[27].ToString(), Convert.ToInt32(dr[28]), Convert.ToBoolean(dr[29]), (TransportationType)Enum.Parse(typeof(TransportationType), dr[30].ToString()), Convert.ToDateTime(dr[31]), Convert.ToDateTime(dr[32]), Convert.ToInt32(dr[33]), Convert.ToBoolean(dr[34]), new List<Skill>());
                helprequests.Add(helpRequest);
            }
            acceptedList.Add(volunteers);
            acceptedList.Add(helprequests);
            return acceptedList;
        }

        public void AcceptVolunteer(Volunteer volunteer, HelpRequest helpRequest)
        {
            helpRequest.AcceptVolunteer(volunteer);
            List<object> parameters = new List<object>();
            parameters.Add(helpRequest.ID);
            parameters.Add(volunteer.ID);
            Db.ExecuteNonQuery(parameters, DatabaseQueries.Query[QueryId.AcceptedVolunteer]);
        }
        public void DeclineVolunteer(Volunteer volunteer, HelpRequest helpRequest)
        {
            helpRequest.DeclineVolunteer(volunteer);
            List<object> parameters = new List<object>();
            parameters.Add(helpRequest.ID);
            parameters.Add(volunteer.ID);
            Db.ExecuteNonQuery(parameters, DatabaseQueries.Query[QueryId.AcceptedVolunteer]);
        }
    }
}
