using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4Participation.Classes.Database;

namespace ICT4Participation.Classes.ClassObjects
{
    public class HelpRequest
    {
        public List<Volunteer> Accepted = new List<Volunteer>();
        public List<Volunteer> Declined = new List<Volunteer>();
        public List<Volunteer> Pending = new List<Volunteer>();

        public string NeedyName { get; private set; }
        public string Titel { get; private set; }
        public string Description { get; private set; }
        public string Location { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime DeadLine { get; private set; }
        public bool Urgent { get; private set; }
        public bool Interview { get; private set; }
        public TransportationType Transportation { get; private set; }
        public bool Completed { get; private set; }

        public HelpRequest(string needyName, string titel, string description, string location, bool urgent, TransportationType transportation, DateTime startDate, DateTime deadLine,  bool Interview,  bool completed)
        {
            if (titel == null)
            {
                throw new ArgumentNullException("titel", "titel is empty");
            }
            if (description == null)
            {
                throw new ArgumentNullException("descrptions","description is emtpy");
            }
            if (location == null)
            {
                throw new ArgumentNullException("location", "location is empty");
            }
            if (startDate == null)
            {
                throw new ArgumentNullException("startDate", "startDate is empty");
            }
            if (deadLine == null)
            {
                throw new ArgumentNullException("endDate", "endDate is empty");
            }
            this.NeedyName = needyName;
            this.Titel = titel;
            this.Description = description;
            this.Location = location;
            this.StartDate = startDate;
            this.DeadLine = deadLine;
            this.Urgent = urgent;
            this.Interview = Interview;
            this.Transportation = transportation;
            this.Completed = completed;
        }

        public void Decline(Volunteer volunteer)
        {
            Volunteer _volunteer = null;
            foreach(Volunteer volunteerPending in Pending)
            {
                if (volunteerPending.Phonenumber==volunteer.Phonenumber)
                {
                    _volunteer = volunteerPending;
                }
            }
            Pending.Remove(_volunteer);
            Declined.Add(_volunteer);

            
        }

        public void Accept(Volunteer volunteer)
        {
            Volunteer _volunteer = null;
            foreach (Volunteer volunteerPending in Pending)
            {
                if (volunteerPending.Phonenumber == volunteer.Phonenumber)
                {
                    _volunteer = volunteerPending;
                }
            }
            Pending.Remove(_volunteer);
            Accepted.Add(_volunteer);

            //DatabaseManager.ExecuteInsertQuery();
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
