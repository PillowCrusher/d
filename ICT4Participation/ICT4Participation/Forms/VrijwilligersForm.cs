using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICT4Participation.Classes.ClassObjects;

namespace ICT4Participation.Forms
{
    public partial class VrijwilligersForm : Form
    {
        private Admin _admin;
        private readonly List<HelpRequest> _helpRequests;

        public VrijwilligersForm()
        {
            InitializeComponent();
            _admin = new Admin();
            _helpRequests = new List<HelpRequest>();
            
            GetAllHelpRequests();

            UpdateHelpListGui(); 
        }

        private void GetAllHelpRequests()
        {
            //testdata
            _helpRequests.Add(new HelpRequest("naam", "titel", "question", "location", DateTime.Now, DateTime.Now, true, true, TransportationType.Benenwagen, false));
            _helpRequests.Add(new HelpRequest("kees", "titel", "question", "location", DateTime.Now, DateTime.Now, true, true, TransportationType.Benenwagen, false));
            _helpRequests.Add(new HelpRequest("henk", "titel", "question", "location", DateTime.Now, DateTime.Now, true, true, TransportationType.Benenwagen, false));
            _helpRequests.Add(new HelpRequest("hoer", "titel", "question", "location", DateTime.Now, DateTime.Now, true, true, TransportationType.Benenwagen, false));
        }

        private void UpdateHelpListGui()
        {
            int position = 0;

            pnlHulpVragen.Controls.Clear();

            foreach (HelpRequest h in _helpRequests)
            {
                if (!h.Completed)
                {
                    pnlHulpVragen.Controls.Add(
                        NewHelpQuestion(h.NeedyName, h.Titel, h.Description, h.Location, h.Urgent, h.RequestIntroduction,
                            h.Transportation, h.StartDate, h.DeadLine, position)
                        );
                    position++;
                }
            }
        }

        private GroupBox NewHelpQuestion(
            string needyName,
            string title,
            string question,
            string location,
            bool urgent,
            bool meeting,
            TransportationType transportation,
            DateTime startDate,
            DateTime deadLine,
            int position)
        {
            int locationInt = (220 * position) + 5;
            //Nieuwe groupbox voor de hulp vraag
            var newQuestion = new GroupBox
            {
                Text = needyName + " - " + title,
                Location = new Point(6, locationInt),
                Size = new Size(685, 214)
            };

            //Textbox voor de hulpvraag
            var t = new TextBox
            {
                Multiline = true,
                Location = new Point(6, 19),
                Size = new Size(673, 94),
                Text = question
            };
            newQuestion.Controls.Add(t);

            //Label voor extra informatie
            var l = new Label
            {
                Location = new Point(6, 116),
                Text =
                    "Locatie: " + location + Environment.NewLine +
                    "Urgent: " + ConvertBoolToString(urgent) + Environment.NewLine +
                    "Kennis maken: " + ConvertBoolToString(meeting) + Environment.NewLine +
                    "Transport type: " + transportation + Environment.NewLine +
                    "Datum geplaatst: " + startDate.ToString("d") + Environment.NewLine +
                    "Deadline: " + deadLine.ToString("d"),
                AutoSize = true,
                Size = new Size(138, 78)
            };
            newQuestion.Controls.Add(l);

            //Button voor reageren
            var btn = new Button
            {
                Location = new Point(604, 185),
                Size = new Size(75, 23),
                Text = "Reageer"
            };
            btn.Click += new EventHandler(Reageer_Click);
            newQuestion.Controls.Add(btn);

            return newQuestion;
        }

        private static string ConvertBoolToString(bool toConvert)
        {
            string converted;

            converted = toConvert ? "Ja" : "Nee";

            return converted;
        }

        private void Reageer_Click(object sender, EventArgs e)
        {

        }
    }
}
