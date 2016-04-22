using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICT4Participation.Classes.Intelligence;
using ICT4Participation.Classes.ClassObjects;

namespace ICT4Participation.Forms
{
    public partial class Needy_Profile : Form
    {
        public Administration _administration = new Administration();
        public string location { get; private set; }
        public string phonenumber { get; private set; }
        public bool publicTransport { get; private set; }
        public bool drivingLincence { get; private set; }
        public bool hasCar { get; private set; }

        public Needy_Profile()
        {
            InitializeComponent();
        }

        public Needy_Profile(Needy needy)
        {
            InitializeComponent();
            cbxLocation.Text = needy.Location;
            tbPhonenumber.Text = needy.Phonenumber;
            if (needy.PublicTransport)
            {
                rbtTransportYes.Checked = true;
            }
            else
            {
                rbtTransportNo.Checked = true;

            }
            if (needy.HasDrivingLincense)
            {
                rbtDrivingYes.Checked = true;
            }
            else
            {
                rbtDrivingNo.Checked = true;
            }
            if (needy.HasCar)
            {
                rbtCarYes.Checked = true;
            }
            else
            {
                rbtCarNo.Checked = true;
            }
        }

        private void btUpdateProfile_Click(object sender, EventArgs e)
        {
                if (cbxLocation.Text != "")
                {
                    if (tbPhonenumber.Text != "")
                    {
                        if (rbtTransportNo.Checked == true)
                        {
                            publicTransport = true;
                        }
                        else if (rbtTransportNo.Checked == false)
                        {
                            publicTransport = false;
                        }
                        if (rbtCarYes.Checked == true)
                        {
                            hasCar = true;
                        }
                        else if (rbtCarNo.Checked == false)
                        {
                            hasCar = false;
                        }
                        if (rbtDrivingYes.Checked == true)
                        {
                            drivingLincence = true;
                        }
                        else if (rbtDrivingNo.Checked == false)
                        {
                            drivingLincence = false;
                        }
                        location = cbxLocation.Text;
                        phonenumber = tbPhonenumber.Text;
                    }
                    else
                    {
                        MessageBox.Show("Vul alsjeblieft een naam in");
                    }
                }
                else
                {
                    MessageBox.Show("Vul alsjeblieft een lokatie in");
                }
        }
    

    private void btUnsubscribe_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Weet je het zeker?", "Bevestig", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    Volunteer v = _administration.User as Volunteer;
                    v.UnSubscribe();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
