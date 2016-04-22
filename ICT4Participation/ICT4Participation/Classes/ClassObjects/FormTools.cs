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
        private static int _position;

        /// <summary>
        /// Voor het aanmaken van een hulpRequest voor de Volunteer
        /// </summary>
        /// <param name="needyName"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="location"></param>
        /// <param name="startDate"></param>
        /// <param name="deadLine"></param>
        /// <param name="urgent"></param>
        /// <param name="meeting"></param>
        /// <param name="transportation"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static GroupBox NewHelpRequest(HelpRequest hr, int position, bool personal)
        {
            _position = position;

            if (personal)
            {
                var extraInfo =
                "Locatie: " + hr.Location + Environment.NewLine +
                "Urgent: " + ConvertBoolToString(hr.Urgent) + Environment.NewLine +
                "Kennis maken: " + ConvertBoolToString(hr.Interview) + Environment.NewLine +
                "Transport type: " + hr.Transportation + Environment.NewLine +
                "Deadline: " + hr.DeadLine.ToString("d");

                return NewHelpRequestGroupbox(hr, 270, 265, extraInfo, 550, 195, 128, 60, "Bekijk vrijwilligers");
            }
            else
            {
                var extraInfo =
                    "Locatie: " + hr.Location + Environment.NewLine +
                    "Urgent: " + ConvertBoolToString(hr.Urgent) + Environment.NewLine +
                    "Kennis maken: " + ConvertBoolToString(hr.Interview) + Environment.NewLine +
                    "Transport type: " + hr.Transportation + Environment.NewLine +
                    "Datum geplaatst: " + hr.StartDate.ToString("d") + Environment.NewLine +
                    "Deadline: " + hr.DeadLine.ToString("d");

                return NewHelpRequestGroupbox(hr, 220, 214, extraInfo, 604, 185, 75, 23, "Reageer");
            }
        }

        public static GroupBox NewVolunteer(Volunteer volunteer, int position, bool VOG)
        {
            _position = position;

            if (VOG)
            {
                var extraInfo =
                    "Naam: " + volunteer.Name + Environment.NewLine +
                    "Rijbewijs: " + ConvertBoolToString(volunteer.HasDrivingLincense) + Environment.NewLine +
                    "Auto beschikbaar: " + ConvertBoolToString(volunteer.HasCar) + Environment.NewLine +
                    "Openbaar Vervoer: " + ConvertBoolToString(volunteer.PublicTransport);

                return NewVolunteerGroupbox(volunteer, position, extraInfo, "Bevestigen", "Afwijzen", true);
            }
            else
            {
                var extraInfo =
                    "Naam: " + volunteer.Name + Environment.NewLine +
                    "Rijbewijs: " + ConvertBoolToString(volunteer.HasDrivingLincense) + Environment.NewLine +
                    "Auto beschikbaar: " + ConvertBoolToString(volunteer.HasCar) + Environment.NewLine +
                    "Openbaar Vervoer: " + ConvertBoolToString(volunteer.PublicTransport) + Environment.NewLine +
                    "Gewaarschuwd: " + ConvertBoolToString(volunteer.Warned) + Environment.NewLine +
                    "Geblokkeerd: " + ConvertBoolToString(volunteer.Blocked);

                return NewVolunteerGroupbox(volunteer, position, extraInfo, "Blokkeer", "Waarschuwen", false);
            }
        }

        private static GroupBox NewHelpRequestGroupbox(HelpRequest hr, int locationInt, int gbSize, string lblExtraInfo, int btnX, int btnY, int btnW, int btnH, string btnText)
        {
            locationInt = locationInt * _position;
            locationInt += 5;
            
            //Nieuwe groupbox voor de hulp vraag
            var newQuestion = new GroupBox
            {
                Text = hr.NeedyName + " - " + hr.Title,
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

        private static GroupBox NewVolunteerGroupbox(Volunteer volunteer, int locationInt, string lblExtraInfo, string btn1Text, string btn2Text, bool VOG)
        {
            locationInt = locationInt * _position;
            locationInt += 5;

            //Nieuwe groupbox voor de hulp vraag
            var newQuestion = new GroupBox
            {
                Text = volunteer.ID.ToString(),
                Location = new Point(6, locationInt),
                Size = new Size(461, 131)
            };

            //Textbox voor de hulpvraag
            var pb = new PictureBox
            {
                ImageLocation = volunteer.Photo,
                Size = new Size(108, 106)
            };
            newQuestion.Controls.Add(pb);

            //Label voor extra informatie
            var l = new Label
            {
                Location = new Point(120, 19),
                Text = lblExtraInfo,
                AutoSize = true,
                Size = new Size(135, 78)
            };
            newQuestion.Controls.Add(l);

            //Button voor reageren
            var btnVOG = new Button
            {
                Location = new Point(381, 19),
                Size = new Size(85, 23),
                Text = "VOG Openen"
            };
            newQuestion.Controls.Add(btnVOG);
            btnVOG.Click += new EventHandler(btnVOG_Openen);

            //Button voor reageren
            var btn1 = new Button
            {
                Location = new Point(370, 74),
                Size = new Size(85, 23),
                Text = btn1Text
            };
            newQuestion.Controls.Add(btn1);

            //Button voor reageren
            var btn2 = new Button
            {
                Location = new Point(370, 102),
                Size = new Size(85, 23),
                Text = btn2Text
            };
            newQuestion.Controls.Add(btn2);

            //eventhandlers voor verschillende buttons
            if (VOG)
            {
                btn1.Click += new EventHandler(btnBevestigen);
                btn2.Click += new EventHandler(btnAfwijzen);
            }
            else
            {
                btn1.Click += new EventHandler(btnBlokkeer);
                btn2.Click += new EventHandler(btnWaarschuwen);
            }

            return newQuestion;
        }

        public static string ConvertBoolToString(bool toConvert)
        {
            string converted;

            converted = toConvert ? "Ja" : "Nee";

            return converted;
        }
    }
}
