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
using ICT4Participation.Forms;

namespace ICT4Participation
{
    public partial class AdminForm : Form
    {
        private readonly Administration _administration;
        private List<Volunteer> _volunteers;
        private List<Volunteer> _pendingVolunteers; 

        public AdminForm()
        {
            InitializeComponent();
            _administration = new Administration();

            Size size = new Size(1280, 720);
            this.Size = size;
            this.MinimumSize = size;
            this.MaximumSize = size;

            GetVolunteers();
            GetPendingVolunteers();

            UpdateVolunteerListGui();

            UpdateAllHelpRequests();
        }

        private void UpdateAllHelpRequests()
        {
            lbHelpRequest.Items.Clear();

            foreach (HelpRequest hr in _administration.GetHelpRequests("GetAllHelpRequests", null))
            {
                lbHelpRequest.Items.Add(hr);
            }
        }

        public void GetVolunteers()
        {
            _volunteers = _administration.GetAllVolunteers("GetAcceptedVolunteers");
            _pendingVolunteers = _administration.GetAllVolunteers("GetVOGVolunteers");
        }

        private void GetPendingVolunteers()
        {
            int position = 0;

            pnlVOGVolunteers.Controls.Clear();

            foreach (Volunteer v in _pendingVolunteers)
            {
                pnlVOGVolunteers.Controls.Add(v.NewVolunteer(position, true));
                position++;
            }
            
        }

        public void UpdateVolunteerListGui()
        {
            int position = 0;
            
            pnlVolunteers.Controls.Clear();

            foreach (Volunteer v in _volunteers)
            {
                pnlVolunteers.Controls.Add(v.NewVolunteer(position, false));
                position++;
            }
        }

        private void btAddNeedy_Click_1(object sender, EventArgs e)
        {
            Form form = null;
            using (form = new Needy_RegisterForm())
            {
                Hide();
                form.ShowDialog();
            }
            Show();
        }

        private void lbHelpRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            HelpRequest hr = (HelpRequest) lbHelpRequest.SelectedItem;

            tbDescription.Text = hr.Description;

            btnDeleteHR.Enabled = true;
        }

        private void btnDeleteHR_Click(object sender, EventArgs e)
        {
            try
            {
                HelpRequest hr = (HelpRequest)lbHelpRequest.SelectedItem;


                _administration.DeleteHelprequest(hr.ID);

                UpdateAllHelpRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
