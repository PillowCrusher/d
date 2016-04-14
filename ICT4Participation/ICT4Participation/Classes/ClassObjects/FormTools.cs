using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4Participation.Classes.ClassObjects
{
    public static class FormTools
    {
        private static string _needyName;
        private static string _title;
        private static string _description;
        private static string _location;
        private static DateTime _startDate;
        private static DateTime _deadLine;
        private static bool _urgent;
        private static bool _meeting;
        private static TransportationType _transportation;
        private static int _position;


        public static GroupBox NewHelpRequest(
            string needyName,
            string title,
            string description,
            string location,
            DateTime startDate,
            DateTime deadLine,
            bool urgent,
            bool meeting,
            TransportationType transportation,
            int position)
        {
            _needyName = needyName;
            _title = title;
            _description = description;
            _location = location;
            _startDate = startDate;
            _deadLine = deadLine;
            _urgent = urgent;
            _meeting = meeting;
            _transportation = transportation;
            _position = position;

            var extraInfo =
                "Locatie: " + _location + Environment.NewLine +
                "Urgent: " + ConvertBoolToString(_urgent) + Environment.NewLine +
                "Kennis maken: " + ConvertBoolToString(_meeting) + Environment.NewLine +
                "Transport type: " + _transportation + Environment.NewLine +
                "Datum geplaatst: " + _startDate.ToString("d") + Environment.NewLine +
                "Deadline: " + _deadLine.ToString("d");

            return NewGroupbox(220, 214, extraInfo, 604, 185, 75, 23, "Reageer");
        }

        public static GroupBox NewHelpRequest(
            string needyName,
            string title,
            string description,
            string location,
            DateTime deadLine,
            bool urgent,
            bool meeting,
            TransportationType transportation,
            int position
            )
        {
            _needyName = needyName;
            _title = title;
            _description = description;
            _location = location;
            _deadLine = deadLine;
            _urgent = urgent;
            _meeting = meeting;
            _transportation = transportation;
            _position = position;

            var extraInfo =
                "Locatie: " + location + Environment.NewLine +
                "Urgent: " + ConvertBoolToString(urgent) + Environment.NewLine +
                "Kennis maken: " + ConvertBoolToString(meeting) + Environment.NewLine +
                "Transport type: " + transportation + Environment.NewLine +
                "Deadline: " + deadLine.ToString("d");

            return NewGroupbox(270, 265, extraInfo, 550, 195, 128, 60, "Bekik vrijwilligers");
        }
        
        private static GroupBox NewGroupbox(int locationInt, int gbSize, string lblExtraInfo, int btnX, int btnY, int btnW, int btnH, string btnText)
        {
            locationInt = locationInt * _position;
            locationInt += 5;

            //Nieuwe groupbox voor de hulp vraag
            var newQuestion = new GroupBox
            {
                Text = _needyName + " - " + _title,
                Location = new Point(6, locationInt),
                Size = new Size(685, gbSize)
            };

            //Textbox voor de hulpvraag
            var t = new TextBox
            {
                Multiline = true,
                Location = new Point(6, 19),
                Size = new Size(673, 94),
                Text = _description
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
        
        public static string ConvertBoolToString(bool toConvert)
        {
            string converted;

            converted = toConvert ? "Ja" : "Nee";

            return converted;
        }

        private static void Reageer_Click(object sender, EventArgs e)
        {

        }
    }
}
