using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4Participation.Classes.Database;
using ICT4Participation.Classes.Intelligence;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using System.Drawing;

namespace ICT4Participation.Classes.ClassObjects
{
    public class HelpRequest
    {
        private int _position;

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

        public GroupBox NewHelpRequest(HelpRequest hr, int position, bool personal)
        {
            _position = position;

            if (personal)
            {
                var extraInfo =
                    "Locatie: " + hr.Location + Environment.NewLine +
                    "Urgent: " + FormTools.ConvertBoolToString(hr.Urgent) + Environment.NewLine +
                    "Kennis maken: " + FormTools.ConvertBoolToString(hr.Interview) + Environment.NewLine +
                    "Transport type: " + hr.Transportation + Environment.NewLine +
                    "Deadline: " + hr.DeadLine.ToString("d");

                return NewHelpRequestGroupbox(hr, 270, 265, extraInfo, 550, 195, 128, 60, "Bekijk vrijwilligers");
            }
            else
            {
                var extraInfo =
                    "Locatie: " + hr.Location + Environment.NewLine +
                    "Urgent: " + FormTools.ConvertBoolToString(hr.Urgent) + Environment.NewLine +
                    "Kennis maken: " + FormTools.ConvertBoolToString(hr.Interview) + Environment.NewLine +
                    "Transport type: " + hr.Transportation + Environment.NewLine +
                    "Datum geplaatst: " + hr.StartDate.ToString("d") + Environment.NewLine +
                    "Deadline: " + hr.DeadLine.ToString("d");

                return NewHelpRequestGroupbox(hr, 220, 214, extraInfo, 604, 185, 75, 23, "Reageer");
            }
        }

        private GroupBox NewHelpRequestGroupbox(HelpRequest hr, int locationInt, int gbSize, string lblExtraInfo, int btnX, int btnY, int btnW, int btnH, string btnText)
        {
            locationInt = locationInt * _position;
            locationInt += 5;

            //Nieuwe groupbox voor de hulp vraag
            var newQuestion = new GroupBox
            {
                Text = hr.NeedyName + " - " + hr.Titel,
                Location = new Point(6, locationInt),
                Size = new Size(685, gbSize)
            };

            //Textbox voor de hulpvraag
            var t = new TextBox
            {
                Multiline = true,
                Location = new Point(6, 19),
                Size = new Size(673, 94),
                Text = hr.Description
            };
            newQuestion.Controls.Add(t);

            //Label voor extra informatie
            var l = new Label
            {
                Location = new Point(6, 116),
                Text = lblExtraInfo,
                AutoSize = true,
                Size = new Size(138, 78)
            };
            newQuestion.Controls.Add(l);

            //Button voor reageren
            var btn = new Button
            {
                Location = new Point(btnX, btnY),
                Size = new Size(btnW, btnH),
                Text = btnText
            };
            btn.Click += new EventHandler(Reageer_Click);
            newQuestion.Controls.Add(btn);

            return newQuestion;
        }

        private static void Reageer_Click(object sender, EventArgs e)
        {

        }
    }
}
