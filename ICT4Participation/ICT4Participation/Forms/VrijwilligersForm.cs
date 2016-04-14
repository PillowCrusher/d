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
        private List<HelpRequest> _helpRequests;

        public VrijwilligersForm()
        {
            InitializeComponent();
            _helpRequests = new List<HelpRequest>();
        }

        private void GetAllHelpRequests()
        {

        }

        private void UpdateHelpListGui()
        {

        }

        private GroupBox NewHelpQuestion(
            string needyName,
            string title,
            string question,
            string location,
            bool urgent,
            bool meeting,
            string transportation,
            DateTime datePlaced,
            DateTime deadLine)
        {
            //Nieuwe groupbox voor de hulp vraag
            var newQuestion = new GroupBox
            {
                Text = needyName + " - " + title,
                Location = new Point(6, 19),
                Size = new Size(673, 94)
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
                    "Datum geplaatst: " + datePlaced.ToString("d") + Environment.NewLine +
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


            return newQuestion;
        }

        private static string ConvertBoolToString(bool toConvert)
        {
            string converted;

            converted = toConvert ? "Ja" : "Nee";

            return converted;
        }
    }
}
