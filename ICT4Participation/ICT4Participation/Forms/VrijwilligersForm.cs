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
using ICT4Participation.Forms.SubForms;

namespace ICT4Participation.Forms
{
    public partial class VrijwilligersForm : Form
    {
        private readonly Administration _administration;
        private List<HelpRequest> _helpRequests;

        public VrijwilligersForm(Administration administration)
        {
            InitializeComponent();
            _administration = administration;

            Size size = new Size(1280, 720);
            Size = size;
            MinimumSize = size;
            MaximumSize = size;

            GetAllHelpRequests();

            UpdateHelpListGui();
            UpdatePersonalRecords();
            GetAcceptedHelpRequest();
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
                    pnlHulpVragen.Controls.Add(h.NewHelpRequest(position, false));
                    position++;
            }
        }

        private void GetAcceptedHelpRequest()
        {
            lbHelpRequests.Items.Clear();

            OracleParameter[] parameter =
            {
                new OracleParameter("userid", _administration.User.ID),
            };

            foreach (HelpRequest h in _helpRequests)
            {
                if (_administration.GetAcceptedHelpRequests(parameter).Contains(h.ID))
                {
                    lbHelpRequests.Items.Add(h);
                }
            }
        }

        private void UpdatePersonalRecords()
        {
            if (_administration.User.GetType() == typeof(Volunteer))
            {
                Volunteer currentUser = (Volunteer)_administration.User;

                lblPersonalInfo.Text =
                    "Naam: " + currentUser.Name + Environment.NewLine +
                    "Gebruikersnaam: " + currentUser.Username + Environment.NewLine +
                    "Rijbewijs: " + FormTools.ConvertBoolToString(currentUser.HasDrivingLincense) + Environment.NewLine +
                    "Auto beschikbaar: " + FormTools.ConvertBoolToString(currentUser.HasCar) + Environment.NewLine +
                    "Openbaar vervoer: " + FormTools.ConvertBoolToString(currentUser.PublicTransport) + Environment.NewLine +
                    "Gewaarschuwd: " + FormTools.ConvertBoolToString(currentUser.Warned);
            }
        }

        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            if (_administration.User is Volunteer)
            {
                Volunteer currentUser = (Volunteer) _administration.User;

                Volunteer_Profile vpForm = new Volunteer_Profile(currentUser);

                vpForm.ShowDialog();
                if (vpForm.password != null)
                {
                    _administration.UpdateVolunteer(vpForm.password, vpForm.adress, vpForm.city, vpForm.phonenumber,
                        vpForm.publicTransport,
                        vpForm.drivingLincence, vpForm.hasCar, vpForm.birhtDay, vpForm.photoFile, vpForm.VOGFile);
                }
                vpForm.Close();
                UpdatePersonalRecords();
            }
            else
            {
                MessageBox.Show("Het is niet mogelijk om de gegevens aan te passen!");
            }
        }

        private void btnShowReviews_Click(object sender, EventArgs e)
        {
            Form form = new ReviewVolunteerForm(_administration.User);
            using (form)
            {
                form.ShowDialog();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }


        private void RefreshAll()
        {
            GetAllHelpRequests();
            UpdateHelpListGui();
            lbHelpRequests.DataSource = _helpRequests;
            lbHelpRequests.DisplayMember = "Title";
            lbChats.DataSource = null;
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            HelpRequest h = (HelpRequest)lbHelpRequests.SelectedItem;
            foreach (HelpRequest hr in _helpRequests)
            {
                if (h == hr)
                {
                    hr.AddChatMessage(new ChatMessage((User)_administration.User, tbMessage.Text, DateTime.Now));
                    tbMessage.Text = "";
                    hr.GetChatMessages();
                    lbChats.DataSource = hr.ChatMessages;
                    lbChats.DisplayMember = "TotalString";
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
            HelpRequest h = (HelpRequest) lbHelpRequests.SelectedItem;
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

        public Volunteer GetCurrentVolunteer()
        {
            var user = _administration.User as Volunteer;
            return user;
        }

        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(this, e);
            }
        }
    }
}
