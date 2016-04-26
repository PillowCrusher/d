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

        public VrijwilligersForm(Administration administration)
        {
            InitializeComponent();
            _administration = administration;

            Size size = new Size(1280, 720);
            this.Size = size;
            this.MinimumSize = size;
            this.MaximumSize = size;

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
                    pnlHulpVragen.Controls.Add(h.NewHelpRequest(position, false));
                    position++;
            }
        }

        private void GetHelpRequest()
        {
            
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

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateHelpListGui();
        }


        private void RefreshAll()
        {
            UpdateHelpListGui();
            lbHelpRequests.DataSource = _helpRequests;
            lbHelpRequests.DisplayMember = "Title";
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            HelpRequest h = lbHelpRequests.SelectedItem as HelpRequest;
            foreach (HelpRequest hr in _helpRequests)
            {
                if (h == hr)
                {
                    hr.AddChatMessage(new ChatMessage((User)_administration.User, tbMessage.Text, DateTime.Now));
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
                    SelectionMode selectionMode = lbHelpRequests.SelectionMode;
                    lbHelpRequests.SelectionMode = SelectionMode.None;
                    lbChats.DataSource = hr.ChatMessages;
                    lbChats.DisplayMember = "TotalString";
                    lbHelpRequests.SelectionMode = selectionMode;
                }
            }
        }

        public Volunteer GetCurrentVolunteer()
        {
            var user = _administration.User as Volunteer;
            return user;
        }
    }
}
