using System;
using ICT4Participation.Classes.ClassObjects;
using System.Collections.Generic;
using System.Windows.Forms;
using ICT4Participation.Classes.Intelligence;
using Oracle.ManagedDataAccess.Client;
using System.Drawing;

namespace ICT4Participation.Forms
{
    public partial class HulpbehoevendeForm : Form
    {
        private readonly Administration _administration;
        private List<HelpRequest> _helpRequests;

        public HulpbehoevendeForm(Administration ad)
        {
            InitializeComponent();
            _administration = ad;

            Size size = new Size(1280, 720);
            this.Size = size;
            this.MinimumSize = size;
            this.MaximumSize = size;


            cbTransportType.DataSource = Enum.GetValues(typeof(TransportationType));
            RefreshAll();

        }

        private void RefreshAll()
        {
            GetPersonalHelpRequests();
            UpdateHelpListGui();
            HelpRequest h = (HelpRequest)lbHelpRequests.SelectedItem;
            lbHelpRequests.DataSource = _helpRequests;
            lbHelpRequests.DisplayMember = "Title";
            lbHelpRequests.SelectedItem = h;
        }

        private void GetPersonalHelpRequests()
        {
            OracleParameter[] parameters =
            {
                new OracleParameter("needyid", _administration.User.ID)
            };
            
            _helpRequests = _administration.GetHelpRequests("GetUserHelpRequests", parameters);
            lbHelpRequests.DataSource = _helpRequests;
        }

        private void UpdateHelpListGui()
        {
            int position = 0;

            pnlHulpVragen.Controls.Clear();

            foreach (HelpRequest h in _helpRequests)
            {
                    pnlHulpVragen.Controls.Add(h.NewHelpRequest(h, position, true));
                    position++;

            }
        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text;
            string description = tbDescription.Text;
            bool urgent = cbUrgent.Checked;
            TransportationType tt = ((TransportationType) cbTransportType.SelectedIndex);
            DateTime dt = dtpEndDate.Value;
            bool meeting = cbMeeting.Checked;

            if (title == string.Empty || description == string.Empty)
            {
                MessageBox.Show("Vul alstublieft een titel en beschrijving in om door te gaan!");
                return;
            }

            Needy currentNeedy = (Needy)_administration.User;

            currentNeedy.AddHelpRequest(title, description, urgent, tt, DateTime.Now, dt, meeting);
            RefreshAll();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            HelpRequest h = lbHelpRequests.SelectedItem as HelpRequest;
            foreach (HelpRequest hr in _helpRequests)
            {
                if (h == hr)
                {
                    hr.AddChatMessage(new ChatMessage((User)_administration.User, tbMessage.Text, DateTime.Now));
                    tbMessage.Text = "";
                    hr.GetChatMessages();
                    RefreshAll();
                    break;
                }
            }
        }

        private void tbMessage_Click(object sender, EventArgs e)
        {
            tbMessage.Text = "";
        }

        private void lbHelpRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            HelpRequest h = lbHelpRequests.SelectedItem as HelpRequest;
            foreach (HelpRequest hr in _helpRequests)
            {
                if (h == hr)
                {
                    hr.GetChatMessages();
                    lbChats.DataSource = hr.ChatMessages;
                    lbChats.DisplayMember = "TotalString";
                }
            }
        }
    }
}
