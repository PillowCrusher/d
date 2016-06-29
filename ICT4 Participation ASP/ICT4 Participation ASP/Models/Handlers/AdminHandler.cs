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
    public class AdminHandler : Handler

    {
        public List<Volunteer> Volunteers { get; set; }
        public List<User> Users { get; set; }
        public List<HelpRequest> HelpRequests { get; set; }
        public List<Review> Reviews { get; set; }
        public AdminHandler()
        {
            Volunteers = new List<Volunteer>();
            Users = new List<User>();
            HelpRequests=new List<HelpRequest>();
            Reviews = new List<Review>();
        }

        public void AddNeedy(string username, string email, string name, string address, string city, string phonenumber, int ov, int drivinglicense, int car, string barcode, string password)
        {
            List<object> objects = new List<object>();
            objects.Add(username);
            objects.Add(password);
            objects.Add(email);
            objects.Add(name);
            objects.Add(address);
            objects.Add(city);
            objects.Add(phonenumber);
            objects.Add(drivinglicense);
            objects.Add(car);
            objects.Add(ov);
            objects.Add(barcode);
            Db.ExecuteSqlProcedure(objects, DatabaseQueries.Query[QueryId.InsertNeedy]);
        }

        public void DeleteHelprequest(string id)
        {
            List<object> objects = new List<object>();
            objects.Add(id);
            Db.ExecuteNonQuery(objects, DatabaseQueries.Query[QueryId.DeleteHelpRequest]);
        }

        public void DeleteReview(string id)
        {
            List<object> parameters = new List<object>();
            parameters.Add(id.Split(' ')[1]);
            parameters.Add(id.Split(' ')[0]);

            Db.ExecuteNonQuery(parameters, DatabaseQueries.Query[QueryId.DeleteReviews]);
        }

        public void BlockUser(string id)
        {
            User u = null;
            List<User> tempUsers = new List<User>();
            tempUsers.AddRange(FillUsers());
            tempUsers.AddRange(FillAccepted());
            foreach (User user in tempUsers)
            {
                if (user.ID.ToString() == id)
                {
                    u = user;
                }
            }
            if (u != null)
            {
                List<object> objects = new List<object>();
                objects.Add(u.ID);
                Db.ExecuteNonQuery(objects, DatabaseQueries.Query[QueryId.BlockUser]);
            }
          
        }

        public void WarnUser(string id)
        {
            User u = null;
            List<User> tempUsers = new List<User>();
            tempUsers.AddRange(FillUsers());
            tempUsers.AddRange(FillAccepted());
            foreach (User user in tempUsers)
            {
                if (user.ID.ToString() == id)
                {
                    u = user;
                }
            }
            if (u != null)
            {
                List<object> objects = new List<object>();
                objects.Add(u.ID);
                Db.ExecuteNonQuery(objects, DatabaseQueries.Query[QueryId.WarnUser]);
            }  
        }

        public string DescriptionHelprequest(string ID)
        {
            foreach (HelpRequest help in FillHelpRequests())
            {
                if (help.ID.ToString() == ID)
                {
                    return help.Description;
                }
            }
            return "";
        }

        public List<HelpRequest> FillHelpRequests()
        {
            List<object> parameters = new List<object>();


            DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetAllHelpRequestsInc]);

            foreach (DataRow dr in dt.Rows)
            {
                HelpRequests.Add(new HelpRequest(dr));
            }

            return HelpRequests;
        }

        public List<Review> FillReviews(string id)
        {
            List<object> parameters = new List<object>();
            parameters.Add(id);

            DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetReviewsFromHelpRequest]);

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Comments"] == null)
                {
                    Reviews.Add(new Review(new Volunteer(dr),dr["Message"].ToString()));
                }
                else
                {
                    Reviews.Add(new Review(new Volunteer(dr), dr["Message"].ToString(),dr["Comments"].ToString()));
                }
            }

            return Reviews;
        }

        public string MessageReview(string id)
        {
            string message = "";
            List<object> parameters = new List<object>();
            parameters.Add(id.Split(' ')[1]);
            parameters.Add(id.Split(' ')[0]);
            

            DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetReviewFromHelpRequestUser]);
            if (dt.Rows.Count != 0)
            {
                message = dt.Rows[dt.Rows.Count - 1]["MESSAGE"].ToString();
                foreach (DataRow dataRow in dt.Rows)
                {
                    if (dataRow["COMMENTS"].ToString() != "")
                    {
                        message += "           Reactie: " + dataRow["COMMENTS"].ToString();
                    }
                }
            }
            return message;
        }

        public List<Volunteer> ReviewVolunteers(string id)
        {
            List<Volunteer> volunteers = new List<Volunteer>();
            List<object> parameters = new List<object>();
            parameters.Add(id);

            DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetVolunteersHelprequested]);

            foreach (DataRow dr in dt.Rows)
            {
                volunteers.Add(new Volunteer(dr));
            }
            return volunteers;
        }

        public List<User> FillUsers()
        {
            List<object> parameters = new List<object>();
            List<User> needyUsers = new List<User>();

            DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetNeedy]);

            foreach (DataRow dr in dt.Rows)
            {
                needyUsers.Add(new Needy(dr));
            }

            return needyUsers;
        }


        public List<Volunteer> FillAccepted()
        {

            List<object> parameters = new List<object>();


            DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetAcceptedVolunteersNoHulprequest]);


            List<Volunteer> acceptedVolunteers = new List<Volunteer>();

            foreach (DataRow dr in dt.Rows)
            {
                acceptedVolunteers.Add(new Volunteer(dr));
                Volunteers.Add(new Volunteer(dr));
            }

            return acceptedVolunteers;
        }

        public List<Volunteer> FillUnaccepted()
        {

            List<object> parameters = new List<object>();


            DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetVOGVolunteers]);


            List<Volunteer> acceptedVolunteers = new List<Volunteer>();

            foreach (DataRow dr in dt.Rows)
            {
                acceptedVolunteers.Add(new Volunteer(dr));
                Volunteers.Add(new Volunteer(dr));
            }

            return acceptedVolunteers;
        }

        public void ActivateVolunteer(string id)
        {
            Volunteer v = null;
            foreach (Volunteer volunteer in FillUnaccepted())
            {
                if (volunteer.ID.ToString() == id)
                {
                    v = volunteer;
                }
            }
            if (v != null)
            {
                List<object> objects = new List<object>();
                objects.Add(v.ID);
                Db.ExecuteNonQuery(objects, DatabaseQueries.Query[QueryId.AcceptVolunteer]);
            }
        }
    }
}
