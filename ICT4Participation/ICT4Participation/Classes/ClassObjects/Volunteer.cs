using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4Participation.Classes.ClassObjects
{
    //een Volunteer erft van User
    public class Volunteer : User
    {
        private int _position;

        /// <summary>
        /// De verjaardag van de volunteer
        /// </summary>
        public DateTime BirthDate { get; private set; }
        /// <summary>
        /// het file path van de foto van de volunteer
        /// </summary>
        public string Photo { get; private set; }
        /// <summary>
        /// het file path van de VOG van de volunteer
        /// </summary>
        public string VOG { get; private set; }
        /// <summary>
        /// het adress van de volunteer
        /// </summary>
        public string Address { get; private set; }
        /// <summary>
        /// de woonplaats van de volunteer
        /// </summary>
        public string City { get; private set; }
        /// <summary>
        /// een bool of de volunteer is gewaarschuwd door de admin of niet
        /// </summary>
        public bool Warned { get; private set; }
        /// <summary>
        /// een bool of de volunteer is geblokkeerd door de admin of niet
        /// </summary>
        public bool Blocked { get; private set; }

        /// <summary>
        /// een instancie van een Volunteer wat de id,username, email, name, address, city, phonenumber
        /// publictransport, hasdrivinglincense, en hasCar overneemt uit User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="phonenumber"></param>
        /// <param name="publicTransport"></param>
        /// <param name="hasDrivingLincense"></param>
        /// <param name="hasCar"></param>
        /// <param name="birthDate"></param>
        /// <param name="photo"></param>
        /// <param name="vog"></param>
        /// <param name="warned"></param>
        /// <param name="blocked"></param>
        public Volunteer(int id, string username, string email, string name, string address, string city, string phonenumber, bool publicTransport, bool hasDrivingLincense, bool hasCar, DateTime birthDate, string photo, string vog, bool warned, bool blocked)
            : base(id, username, email, name, phonenumber, publicTransport,  hasDrivingLincense, hasCar, warned)
        {
            VOG = vog;
            Photo = photo;
            BirthDate = birthDate;
            Address = address;
            City = city;
            Warned = warned;
            Blocked = blocked;
        }

        public GroupBox NewVolunteer(Volunteer volunteer, int position, bool VOG)
        {
            _position = position;

            if (VOG)
            {
                var extraInfo =
                    "Naam: " + volunteer.Name + Environment.NewLine +
                    "Rijbewijs: " + FormTools.ConvertBoolToString(volunteer.HasDrivingLincense) + Environment.NewLine +
                    "Auto beschikbaar: " + FormTools.ConvertBoolToString(volunteer.HasCar) + Environment.NewLine +
                    "Openbaar Vervoer: " + FormTools.ConvertBoolToString(volunteer.PublicTransport);

                return NewVolunteerGroupbox(volunteer, position, extraInfo, "Bevestigen", "Afwijzen", true);
            }
            else
            {
                var extraInfo =
                    "Naam: " + volunteer.Name + Environment.NewLine +
                    "Rijbewijs: " + FormTools.ConvertBoolToString(volunteer.HasDrivingLincense) + Environment.NewLine +
                    "Auto beschikbaar: " + FormTools.ConvertBoolToString(volunteer.HasCar) + Environment.NewLine +
                    "Openbaar Vervoer: " + FormTools.ConvertBoolToString(volunteer.PublicTransport) + Environment.NewLine +
                    "Gewaarschuwd: " + FormTools.ConvertBoolToString(volunteer.Warned) + Environment.NewLine +
                    "Geblokkeerd: " + FormTools.ConvertBoolToString(volunteer.Blocked);

                return NewVolunteerGroupbox(volunteer, position, extraInfo, "Blokkeer", "Waarschuwen", false);
            }
        }

        private GroupBox NewVolunteerGroupbox(Volunteer volunteer, int locationInt, string lblExtraInfo, string btn1Text, string btn2Text, bool VOG)
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

        private static void btnVOG_Openen(object sender, EventArgs e)
        {
           
        }

        private static void btnBevestigen(object sender, EventArgs e)
        {

        }

        private static void btnAfwijzen(object sender, EventArgs e)
        {

        }

        private static void btnBlokkeer(object sender, EventArgs e)
        {
            
        }

        private static void btnWaarschuwen(object sender, EventArgs e)
        {

        }
    }
}
