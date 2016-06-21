using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Handlers;

namespace ICT4_Participation_ASP.Models.Objects
{
    public class HelpRequest
    {
        private readonly Handler _handler;

        public List<Review> Reviews { get; protected set; }
        public List<ChatMessage> ChatMessages { get; protected set; }
        public List<Volunteer> Pending { get; protected set; }
        public List<Volunteer> Accepted { get; protected set; }
        public List<Volunteer> Declined { get; protected set; }

        public int ID { get; protected set; }
        public string Titel { get; protected set; }
        public string Description { get; protected set; }
        public string Location { get; protected set; }
        public int TravelTime { get; protected set; }
        public bool Urgent { get; protected set; }
        public TransportationType TransportationType { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public int VolunteersNumber { get; protected set; }
        public bool Interview { get; protected set; }
        public List<Skill> Skills { get; protected set; }

        public HelpRequest(int id, string titel, string description, string location, int travelTime, bool urgent, TransportationType transportationType, DateTime startDate, DateTime endDate, int volunteersNumbers, bool interview, List<Skill> skills)
        {
            ID = id;
            Titel = titel;
            Description = description;
            Location = location;
            TravelTime = travelTime;
            Urgent = urgent;
            TransportationType = transportationType;
            StartDate = startDate;
            EndDate = endDate;
            VolunteersNumber = volunteersNumbers;
            Interview = interview;
            Skills = skills;

            Reviews = new List<Review>();
            ChatMessages = new List<ChatMessage>();
            Pending = new List<Volunteer>();
            Accepted = new List<Volunteer>();
            Declined = new List<Volunteer>();

            _handler = new Handler();
        }

        public HelpRequest(DataRow dr): 
            this(Convert.ToInt32(dr["ID"]), dr["Title"].ToString(), dr["Description"].ToString(), dr["Location"].ToString(),
                Convert.ToInt32(dr["TravelTime"]), Convert.ToBoolean(dr["Urgent"]), (TransportationType)Enum.Parse(typeof(TransportationType),dr["TransportType"].ToString()), 
                Convert.ToDateTime(dr["StartDate"]), Convert.ToDateTime(dr["EndDate"]), Convert.ToInt32(dr["VolunteersNumber"]),
                Convert.ToBoolean(dr["Interview"]), new List<Skill>())
        {
            Reviews = new List<Review>();
            ChatMessages = new List<ChatMessage>();
            Pending = new List<Volunteer>();
            Accepted = new List<Volunteer>();
            Declined = new List<Volunteer>();
        }

        public void AddReview(Review review)
        {
            if (Reviews.Contains(review) == false)
            {
                Reviews.Add(review);
            }
            else
            {
                throw new ArgumentException("Deze review bestaat al");
            }
        }

        public void AddChatMessages(ChatMessage chatMessage)
        {
            ChatMessages.Add(chatMessage);
        }

        public void AcceptVolunteer(Volunteer volunteer)
        {
            if (Accepted.Contains(volunteer) == false)
            {
                Accepted.Add(volunteer);
            }
        }

        public void DeclineVolunteer(Volunteer volunteer)
        {
            Volunteer v = Pending.Find(x => x.ID == volunteer.ID);
            Declined.Add(v);
            Pending.Remove(v);
        }
        public override bool Equals(object obj)
        {
            if (obj is HelpRequest)
            {
                HelpRequest other = ((HelpRequest)obj);
                return this.ID == other.ID;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}