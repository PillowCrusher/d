using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4_Participation_ASP.Models.Objects
{
    public class HelpRequest
    {
        public List<Review> Reviews { get; protected set; }
        public List<ChatMessage> ChatMessages { get; protected set; }
        public List<Volunteer> Volunteers { get; protected set; }

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
        public bool Completed { get; protected set; }
        public List<Skill> Skills { get; protected set; }

        public HelpRequest(int id, string titel, string description, string location, int travelTime, bool urgent, TransportationType transportationType, DateTime startDate, DateTime endDate, int volunteersNumbers, bool interview, bool completed, List<Skill> skills )
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
            Completed = completed;
            Skills = skills;

            Reviews = new List<Review>();
            ChatMessages = new List<ChatMessage>();
            Volunteers = new List<Volunteer>();
        }
    }
}