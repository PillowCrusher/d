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
using ICT4Participation.Classes.Intelligence;
using Oracle.ManagedDataAccess.Client;
using ICT4Participation.Classes.Database;

namespace ICT4Participation.Forms
{
    public partial class VrijwilligersForm : Form
    {
        private readonly Administration _administration;
        private List<HelpRequest> _helpRequests;

        public VrijwilligersForm()
        {
            InitializeComponent();
            _administration = new Administration();

            GetAllHelpRequests();

            UpdateHelpListGui();
            UpdatePersonalRecords();
        }

        private void GetAllHelpRequests()
        {
            _helpRequests = _administration.GetHelpRequests("GetAllHelpRequests", null);
        }

        private void UpdateHelpListGui()
        {
            int position = 0;

            pnlHulpVragen.Controls.Clear();

            foreach (HelpRequest h in _helpRequests)
            {
                    pnlHulpVragen.Controls.Add(
                        FormTools.NewHelpRequest(
                            h.NeedyName,
                            h.Titel,
                            h.Description,
                            h.Location,
                            h.StartDate,
                            h.DeadLine,
                            h.Urgent,
                            h.Interview,
                            h.Transportation,
                            position
                            )
                        );
                    position++;

            }
        }

        private void UpdatePersonalRecords()
        {
            if (_administration.GetCurrentUser() is Volunteer)
            {
                Volunteer currentUser = (Volunteer)_administration.GetCurrentUser();

                lblPersonalInfo.Text =
                    "Naam: " + currentUser.Name + Environment.NewLine +
                    "Gebruikersnaam: " + currentUser.Username + Environment.NewLine +
                    "Rijbewijs: " + FormTools.ConvertBoolToString(currentUser.HasDrivingLincense) + Environment.NewLine +
                    "Auto beschikbaar: " + FormTools.ConvertBoolToString(currentUser.HasCar) + Environment.NewLine +
                    "Openbaar vervoer: " + FormTools.ConvertBoolToString(currentUser.PublicTransport);
            }
        }

        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            if (_administration.GetCurrentUser() is Volunteer)
            {
                Volunteer currentUser = (Volunteer) _administration.GetCurrentUser();

                Volunteer_Profile vpForm = new Volunteer_Profile(currentUser);

                vpForm.ShowDialog();



                UpdatePersonalRecords();
            }
            else
            {
                MessageBox.Show("Het is niet mogelijk om de gegevens aan te passen!");
            }
        }

        private void btnShowReviews_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateHelpListGui();
        }
    }
}
