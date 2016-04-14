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

namespace ICT4Participation.Forms
{
    public partial class VrijwilligersForm : Form
    {
        private readonly Administration _administration;
        private readonly List<HelpRequest> _helpRequests;

        public VrijwilligersForm()
        {
            InitializeComponent();
            _administration = new Administration();
            _helpRequests = new List<HelpRequest>();

            GetAllHelpRequests();

            UpdateHelpListGui();
            UpdatePersonalRecords();
        }

        private void GetAllHelpRequests()
        {
            
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
                        FormTools.NewHelpRequest(
                            h.NeedyName,
                            h.Titel,
                            h.Description,
                            h.Location,
                            h.StartDate,
                            h.DeadLine,
                            h.Urgent,
                            h.RequestIntroduction,
                            h.Transportation,
                            position
                            )
                        );
                    position++;
                }
            }
        }

        private void UpdatePersonalRecords()
        {
            if (_administration.GetCurrentUser() is Volunteer)
            {
                Volunteer currentUser = (Volunteer)_administration.GetCurrentUser();

                lblPersonalInfo.Text =
                    "Naam: " + currentUser.Name + Environment.NewLine +
                    "Rijbewijs: " + FormTools.ConvertBoolToString(currentUser.HasDrivingLincense) +
                    Environment.NewLine +
                    "Auto beschikbaar: " + FormTools.ConvertBoolToString(currentUser.HasCar) + Environment.NewLine;
                //"Openbaar vervoer: " + FormTools.ConvertBoolToString(currentUser.)
            }
        }
    }
}
