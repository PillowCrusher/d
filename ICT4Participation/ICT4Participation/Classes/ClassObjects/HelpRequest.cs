using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4Participation.Classes.Database;
using ICT4Participation.Classes.Intelligence;
using Oracle.ManagedDataAccess.Client;

namespace ICT4Participation.Classes.ClassObjects
{
    public class HelpRequest
    {
        public List<Volunteer> Accepted = new List<Volunteer>();
        public List<Volunteer> Declined = new List<Volunteer>();
        public List<Volunteer> Pending = new List<Volunteer>();
        public List<Review> Reviews = new List<Review>();
        public List<ChatMessage> ChatMessages = new List<ChatMessage>();

        public Account Account { get; private set; }
        public int ID { get; private set; }
        public string NeedyName { get; private set; }
        public string Titel { get; private set; }
        public string Description { get; private set; }
        public string Location { get; private set; }
        public bool Urgent { get; private set; }
        public TransportationType Transportation { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime DeadLine { get; private set; }
        public bool Interview { get; private set; }

        public HelpRequest(int id, string needyName, string titel, string description, string location, bool urgent, TransportationType transportation, DateTime startDate, DateTime deadLine, bool interview, Account account)
        {
            if (titel == null)
            {
                throw new ArgumentNullException("titel", "titel is empty");
            }
            if (description == null)
            {
                throw new ArgumentNullException("descrptions", "description is emtpy");
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
            ID = id;
            NeedyName = needyName;
            Titel = titel;
            Description = description;
            Location = location;
            StartDate = startDate;
            DeadLine = deadLine;
            Urgent = urgent;
            Interview = interview;
            Transportation = transportation;
            Account = account;
        }

        public void Decline(Volunteer volunteer)
        {
            Volunteer _volunteer = null;
            foreach (Volunteer volunteerPending in Pending)
            {
                if (volunteerPending.Phonenumber == volunteer.Phonenumber)
                {
                    _volunteer = volunteerPending;
                }
            }
            if (_volunteer != null)
            {
                Pending.Remove(_volunteer);
                Declined.Add(_volunteer);

                OracleParameter[] Parameter =
                {
                    new OracleParameter("HelprequestID", ID),
                    new OracleParameter("UserID", volunteer.ID)
                };

                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["HelpRequestDecline"], Parameter);
            }
            else
            {
                throw new Exception("Volunteer zit niet in Pending.");
            }
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
            if (_volunteer != null)
            {
                Pending.Remove(_volunteer);
                Accepted.Add(_volunteer);

                OracleParameter[] Parameter =
                {
                    new OracleParameter("HelprequestID", ID),
                    new OracleParameter("UserID", volunteer.ID)
                };

                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["HelpRequestAccept"], Parameter);
            }
            else
            {
                throw new Exception("Volunteer zit niet in Pending.");
            }
        }

        public void AddReview(Review review)
        {
            Reviews.Add(review);
            OracleParameter[] Parameter =
            {
                new OracleParameter("helprequestid",ID),
                new OracleParameter("volunteerid",review.Volunteer.ID),
                new OracleParameter("message",review.Comment),
            };
            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertReview"], Parameter);
        }

        public void AddChatMessage(ChatMessage chatmessage)
        {
            ChatMessages.Add(chatmessage);

            OracleParameter[] Parameter =
            {
                new OracleParameter("userid",Account.ID),
                new OracleParameter("helprequestid",ID),
                new OracleParameter("time",DateTime.Now.ToString("yyyy MMMM dd HH:mm:ss")),
                new OracleParameter("message",chatmessage.Message),
            };
            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertChatMessage"], Parameter);
        }

        public void DeleteReview(Review review)
        {
            Review _review = null;
            foreach (Review tempReview in Reviews)
            {
                if (tempReview.Volunteer.ID == review.Volunteer.ID && tempReview.Comment == review.Comment)
                {
                    _review = tempReview;
                }
            }
            Reviews.Remove(_review);
            OracleParameter[] Parameter =
            {
                new OracleParameter("helprequestid",ID),
                new OracleParameter("volunteerid",_review.Volunteer.ID),
                new OracleParameter("message",_review.Comment),
            };
            DatabaseManager.ExecuteDeleteQuery(DatabaseQuerys.Query["DeleteReview"], Parameter);
        }

        public void AddVolunteer(Volunteer volunteer)
        {
            Pending.Add(volunteer);

            OracleParameter[] Parameter =
               {
                    new OracleParameter("HelprequestID", ID),
                    new OracleParameter("UserID", volunteer.ID)
                };
            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertUserHelprequest"], Parameter);
        }

        public override string ToString()
        {
            return Titel;
        }
    }
}
