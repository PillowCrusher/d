﻿using System;
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

            GetAllVolunteers();

            UpdateVolunteerListGui();
        }

        public void GetAllVolunteers()
        {
            _volunteers = _administration.GetAllVolunteers();
        }

        private void GetPendingVolunteers()
        {
            int position = 0;

            pnlVOGVolunteers.Controls.Clear();
            
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
    }
}
