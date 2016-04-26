using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4Participation.Classes.Database;
using ICT4Participation.Classes.Intelligence;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using System.Drawing;
using ICT4Participation.Forms;
using ICT4Participation.Forms.SubForms;

namespace ICT4Participation.Classes.ClassObjects
{
    public class HelpRequest
    {
        private int _position;
        public List<ChatMessage> ChatMessages;
        public List<Volunteer> Pending;
        public List<Volunteer> Accepted;
        public List<Volunteer> Declined;
        public int ID { get; private set; }
        public string NeedyName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Location { get; private set; }
        public bool Urgent { get; private set; }
        public TransportationType Transportation { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime DeadLine { get; private set; }
        public bool Interview { get; private set; }

        public HelpRequest(int id, string needyName, string titel, string description, string location, bool urgent, TransportationType transportation, DateTime startDate, DateTime deadLine, bool interview)
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
            Title = titel;
            Description = description;
            Location = location;
            StartDate = startDate;
            DeadLine = deadLine;
            Urgent = urgent;
            Interview = interview;
            Transportation = transportation;
            Pending = new List<Volunteer>();
            Accepted = new List<Volunteer>();
            Declined = new List<Volunteer>();
        }

        public void Decline(Volunteer volunteer)
        {
            OracleParameter[] Parameter =
            {
                new OracleParameter("HelprequestID", ID),
                new OracleParameter("UserID", volunteer.ID)
            };

            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["HelpRequestDecline"], Parameter);
        }

        public void Accept(Volunteer volunteer)
        {
            OracleParameter[] Parameter =
            {
                new OracleParameter("HelprequestID", ID),
                new OracleParameter("UserID", volunteer.ID)
            };

            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["HelpRequestAccept"], Parameter);
        }

        public void AddChatMessage(ChatMessage chatmessage)
        {
            OracleParameter[] parameters =
            {
                new OracleParameter("userid", chatmessage.Sender.ID),
                new OracleParameter("helprequestid", ID),
                new OracleParameter("time", chatmessage.Time),
                new OracleParameter("message", chatmessage.Message),
            };
            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertChatMessage"], parameters);
        }

        public void GetChatMessages()
        {
            ChatMessages = new List<ChatMessage>();
            OracleParameter[] parameters =
            {
                new OracleParameter("helprequest_id", ID)
            };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetChatMessagesFromHelprequest"], parameters);
            foreach (DataRow dr in dt.Rows)
            {
                ChatMessages.Add(new ChatMessage(new User(
                            Convert.ToInt32(dr["ID"]),
                            Convert.ToString(dr["username"]),
                            Convert.ToString(dr["email"]),
                            Convert.ToString(dr["name"]),
                            Convert.ToString(dr["phonenumber"]),
                            Convert.ToBoolean(dr["ovpossible"]),
                            Convert.ToBoolean(dr["hasdrivinglicence"]),
                            Convert.ToBoolean(dr["hascar"]),
                            Convert.ToBoolean(dr["iswarned"])),
                            Convert.ToString(dr["message"]),
                            Convert.ToDateTime(dr["time"])));
            }
        }

        public void GetVolunteers()
        {
            OracleParameter[] parameters =
            {
                new OracleParameter("id", ID)
            };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetVolunteersHelprequest"], parameters);
            foreach (DataRow dr in dt.Rows)
            {
                Volunteer v = new Volunteer(
                    Convert.ToInt32(dr["ID"]),
                    dr["Username"].ToString(),
                    dr["Email"].ToString(),
                    dr["Name"].ToString(),
                    dr["Adress"].ToString(),
                    dr["City"].ToString(),
                    dr["Phonenumber"].ToString(),
                    Convert.ToBoolean(dr["OVpossible"]),
                    Convert.ToBoolean(dr["HasDrivingLicence"]),
                    Convert.ToBoolean(dr["HasCar"]),
                    Convert.ToDateTime(dr["DateOfBirth"]),
                    dr["Photo"].ToString(),
                    dr["VOG"].ToString(),
                    Convert.ToBoolean(dr["ISWARNED"]),
                    Convert.ToBoolean(dr["ISBLOCKED"]), null);
                string status = dr["Status"].ToString();
                if (status == "Pending")
                {
                    Pending.Add(v);
                }
                else if (status == "Accepted")
                {
                    Accepted.Add(v);
                }
                else if (status == "Declined")
                {
                    Declined.Add(v);
                }
            }
        }

        public GroupBox NewHelpRequest(int position, bool personal)
        {
            _position = position;

            if (personal)
            {
                var extraInfo =
                    "Locatie: " + Location + Environment.NewLine +
                    "Urgent: " + FormTools.ConvertBoolToString(Urgent) + Environment.NewLine +
                    "Kennis maken: " + FormTools.ConvertBoolToString(Interview) + Environment.NewLine +
                    "Transport type: " + Transportation + Environment.NewLine +
                    "Deadline: " + DeadLine.ToString("d");

                return NewHelpRequestGroupbox(270, 265, extraInfo, 550, 195, 128, 60, "Bekijk vrijwilligers");
            }
            else
            {
                var extraInfo =
                    "Locatie: " + Location + Environment.NewLine +
                    "Urgent: " + FormTools.ConvertBoolToString(Urgent) + Environment.NewLine +
                    "Kennis maken: " + FormTools.ConvertBoolToString(Interview) + Environment.NewLine +
                    "Transport type: " + Transportation + Environment.NewLine +
                    "Datum geplaatst: " + StartDate.ToString("d") + Environment.NewLine +
                    "Deadline: " + DeadLine.ToString("d");

                return NewHelpRequestGroupbox(220, 214, extraInfo, 604, 185, 75, 23, "Reageer");
            }
        }

        private GroupBox NewHelpRequestGroupbox(int locationInt, int gbSize, string lblExtraInfo, int btnX, int btnY, int btnW, int btnH, string btnText)
        {
            locationInt = locationInt * _position;
            locationInt += 5;

            //Nieuwe groupbox voor de hulp vraag
            var newQuestion = new GroupBox
            {
                Text = NeedyName + " - " + Title,
                Location = new Point(6, locationInt),
                Size = new Size(685, gbSize)
            };

            //Textbox voor de hulpvraag
            var t = new TextBox
            {
                Multiline = true,
                Location = new Point(6, 19),
                Size = new Size(673, 94),
                Text = Description,
                ReadOnly = true
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

        private void Reageer_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Parent.Parent.Parent.Parent is HulpbehoevendeForm)
            {
                using (Form form = new BekijkVrijwilligersForm(this))
                {
                    form.ShowDialog();
                }
            }

            if (b.Parent.Parent.Parent.Parent is VrijwilligersForm)
            {
                OracleParameter[] parameters =
                {
                    new OracleParameter("userid", ((VrijwilligersForm)b.Parent.Parent.Parent.Parent).GetCurrentVolunteer().ID),
                    new OracleParameter("helprequestid", ID),
                };

                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["CheckifUserHelprequestExists"],
                    parameters);

                if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("Je hebt al gereageerd op deze hulpvraag!");
                    return;
                }

                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertUserHelprequest"], parameters);
                MessageBox.Show("Je hebt succesvol gereageerd op deze hulpvraag!");
            }
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
