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
        private readonly Administration _administration;
        private List<HelpRequest> _helpRequests;

        public HulpbehoevendeForm()
        {
            InitializeComponent();
            _administration = new Administration();

            cbTransportType.DataSource = Enum.GetValues(typeof(TransportationType));

            GetPersonalHelpRequests();

            UpdateHelpListGui();
        }

        private void GetPersonalHelpRequests()
        {
            
            OracleParameter[] parameters =
            {
                new OracleParameter("needyid", _administration.User.ID)
            };
            
            _helpRequests = _administration.GetHelpRequests("GetUserHelpRequests", parameters);
        }

        private void UpdateHelpListGui()
        {
            int position = 0;

            pnlHulpVragen.Controls.Clear();

            foreach (HelpRequest h in _helpRequests)
            {
                    pnlHulpVragen.Controls.Add(FormTools.NewHelpRequest(h, position, true));
                    position++;

            }
        }

        private void btnSendRequest_Click(object sender, System.EventArgs e)
        {
            string title = tbTitle.Text;
            string description = tbDescription.Text;
            bool urgent = cbUrgent.Checked;
            TransportationType tt = TransportationType.NVT;
            DateTime dt = dtpEndDate.Value;
            bool meeting = cbMeeting.Checked;

            if (title == "" || description == "")
            {
                MessageBox.Show("Vul alstublieft een titel of beschrijving in om door te gaan!");
            }

            Needy currentNeedy = (Needy) _administration.User;

            currentNeedy.AddHelpRequest(title, description, urgent, tt, DateTime.Now, dt, meeting);
        }
    }
}
