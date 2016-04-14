﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Participation.Classes.ClassObjects
{
    public class HelpRequest
    {
        public List<Volunteer> Accepted = new List<Volunteer>();
        public List<Volunteer> Declined = new List<Volunteer>();
        public List<Volunteer> Pending = new List<Volunteer>();

        public string Titel { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime TravelTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Urgent { get; set; }
        public bool RequestIntroduction { get; set; }
        public bool Completed { get; set; }

        public HelpRequest(string titel, string description, string location, DateTime travelTime, DateTime startDate, DateTime endDate, bool urgent, bool requestintroduction, bool completed)
        {
            if (titel == null)
            {
                throw new ArgumentNullException("titel", "titel is empty");
            }
            if (description == null)
            {
                throw new ArgumentNullException("descrption","description is emtpy");
            }
            if (location == null)
            {
                throw new ArgumentNullException("location", "location is empty");
            }
            if(travelTime == null)
            {
                throw new ArgumentNullException("traveltime","traveltime is empty");
            }
            if (startDate == null)
            {
                throw new ArgumentNullException("startDate", "startDate is empty");
            }
            if (endDate == null)
            {
                throw new ArgumentNullException("endDate", "endDate is empty");
            }
            this.Titel = titel;
            this.Description = description;
            this.Location = location;
            this.TravelTime = travelTime;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Urgent = urgent;
            this.RequestIntroduction = requestintroduction;
            this.Completed = completed;
        }

        public void Decline(Volunteer volunteer)
        {

        }

        public void Accept(Volunteer volunteer)
        {

        }

        public void AddReview(Review review)
        {

        }

        public void AddChatMessage(ChatMessage chatmessage)
        {

        }

        public void DeleteReview(Review review)
        {

        }
    }
}
