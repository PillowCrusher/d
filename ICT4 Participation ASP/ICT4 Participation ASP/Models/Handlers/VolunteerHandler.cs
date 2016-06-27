﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Database;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.Models.Handlers
{
    public class VolunteerHandler : Handler
    {
        public string Message { get; set; }

        public VolunteerHandler()
        {

        }

        public void UpdateProfileData(List<object> parameters)
        {
            try
            {
                Db.ExecuteSqlProcedure(parameters, DatabaseQueries.Query[QueryId.UpdateVolunteer]);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void GetAcceptedHelprequests(Volunteer user)
        {
            List<object> parameters = new List<object>();
            parameters.Add(user.ID);

            DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetAcceptedHelpRequests]);
            
            foreach (DataRow dr in dt.Rows)
            {
                HelpRequest request = new HelpRequest(dr);
                user.AddHelpRequest(request);
            }
        }

        public List<HelpRequest> GetHelpRequests()
        {
            DataTable dt = Db.ExecuteReadQuery(null, DatabaseQueries.Query[QueryId.GetAllHelpRequests]);

            List<HelpRequest> requestses = new List<HelpRequest>();

            foreach (DataRow dr in dt.Rows)
            {
                requestses.Add(new HelpRequest(dr));
            }
            return requestses;
        }

        public void AcceptHelpRequest(int userId, int helprequestId)
        {
            try
            {
                List<object> parameters = new List<object>();

                parameters.Add(userId);
                parameters.Add(helprequestId);

                Db.ExecuteNonQuery(parameters, DatabaseQueries.Query[QueryId.InsertUserHelprequest]);
            }
            catch (Exception ex)
            {
                throw new Exception("Je hebt al geaccepteerd op deze Helprequest. " + Environment.NewLine + 
                    "Original exception: " + ex.Message);
            }
        }

        public void Unsubscribe(DateTime time, Volunteer volunteer)
        {
            try
            {
                List<object> parameters = new List<object>();
                parameters.Add(time);
                parameters.Add(volunteer.ID);
                Db.ExecuteNonQuery(parameters, DatabaseQueries.Query[QueryId.UnsubscribeUser]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PlaceComment(Review review, Volunteer volunteer, string comment)
        {
            try
            {
                review.AddComment(volunteer, comment);
                List<object> parameters = new List<object>();
                parameters.Add(comment);
                parameters.Add(review.Message);
                parameters.Add(volunteer.ID);
                Db.ExecuteNonQuery(parameters, DatabaseQueries.Query[QueryId.UpdateCommentReview]);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void GetHelprequestReviews(Volunteer volunteer)
        {
            try
            {
                List<object> parameters = new List<object>();
                parameters.Add(volunteer.ID);
                DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetAllVolunteerHelpRequests]);

                List<HelpRequest> helpRequests = new List<HelpRequest>();
                foreach (DataRow dr in dt.Rows)
                {
                    HelpRequest hr = new HelpRequest(dr);
                    parameters.Clear();
                    parameters.Add(hr.ID);
                    parameters.Add(volunteer.ID);
                    DataTable dt2 = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetReviewFromHelpRequestUser]);

                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        hr.AddReview(new Review(volunteer, dr2["Message"].ToString(), dr2["Comments"].ToString()));
                    }
                    helpRequests.Add(hr);
                }
                volunteer.AddHelprequest(helpRequests);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SetMessag(string message)
        {
            Message = message;
        }
    }
}
