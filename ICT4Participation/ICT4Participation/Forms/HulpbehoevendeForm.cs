using System;
using ICT4Participation.Classes.ClassObjects;
using System.Collections.Generic;
using System.Windows.Forms;
using ICT4Participation.Classes.Intelligence;
using Oracle.ManagedDataAccess.Client;

namespace ICT4Participation.Forms
{
    public partial class HulpbehoevendeForm : Form
    {
        private Administration _administration;
        private List<HelpRequest> _helpRequests;

        public HulpbehoevendeForm()
        {
            InitializeComponent();
            _administration = new Administration();

            GetPersonalHelpRequests();

            UpdateHelpListGui();
        }

        private void GetPersonalHelpRequests()
        {
            
            OracleParameter[] parameters =
            {
                new OracleParameter("needyid", _administration.GetCurrentUser().Account.ID)
            };
            
            _helpRequests = _administration.GetHelpRequests(parameters);
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
                            h.Urgent,
                            h.Transportation,
                            h.DeadLine,
                            h.Interview,
                            position
                            )
                        );
                    position++;

            }
        }

        private void btnSendRequest_Click(object sender, System.EventArgs e)
        {
            string title = tbTitle.Text;
            string description = tbDescription.Text;
            bool driverLicense = cbDriverLicense.Checked;
            bool hasCar = cbHasCar.Checked;
            bool ov = cbOV.Checked;
            bool urgent = cbUrgent.Checked;
            bool meeting = cbMeeting.Checked;
            DateTime dt = dtpEndDate.Value;

            if (title == "" || description == "")
            {
                MessageBox.Show("Vul alstublieft een titel of beschrijving in om door te gaan!");
            }

            Needy currentNeedy = (Needy) _administration.GetCurrentUser();

            currentNeedy.AddHelpRequest(title, description, urgent, TransportationType.Auto, DateTime.Now, dt, meeting);
        }
    }
}
