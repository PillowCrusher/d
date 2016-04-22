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
    public partial class Volunteer_Profile : Form
    {
        public Administration _administration = new Administration();
        public string adress { get; private set; }
        public string city { get; private set; }
        public string phonenumber { get; private set; }
        public bool publicTransport { get; private set; }
        public bool drivingLincence { get; private set; }
        public bool hasCar { get; private set; }
        public DateTime birhtDay { get; private set; }
        public string photoFile { get; private set; }
        public string VOGFile { get; private set; }


        public Volunteer_Profile()
        {
            InitializeComponent();
        }

        public Volunteer_Profile(Volunteer volunteer)
        {
            InitializeComponent();

            tbAddress.Text = volunteer.Address;
            tbCity.Text = volunteer.City;
            tbPhonenumber.Text = volunteer.Phonenumber;
            if (volunteer.PublicTransport )
            {
                rbtTransportYes.Checked = true;
            }
            else
            {
                rbtTransportNo.Checked = true;

            }
            if (volunteer.HasDrivingLincense)
            {
                rbtDrivingYes.Checked = true;
            }
            else
            {
                rbtDrivingNo.Checked = true;
            }
            if (volunteer.HasCar)
            {
                rbtCarYes.Checked = true;
            }
            else
            {
                rbtCarNo.Checked = true;
            }
            dtpBirthDate.Value = volunteer.BirthDate;
            lbFileVOG.Text = volunteer.VOG;
            lbFilePhoto.Text = volunteer.Photo;
        }

        private void btPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog photoLog = new OpenFileDialog();
            if (photoLog.ShowDialog() == DialogResult.OK)
            {
                photoFile = photoLog.FileName;
                lbFilePhoto.Text = photoFile.Split('\\').Last();
            }
        }

        private void btVOG_Click(object sender, EventArgs e)
        {
            OpenFileDialog VOGLog = new OpenFileDialog();
            if (VOGLog.ShowDialog() == DialogResult.OK)
            {
                VOGFile = VOGLog.FileName;
                lbFileVOG.Text = VOGFile.Split('\\').Last();
            }
        }

        private void btUpdateProfile_Click(object sender, EventArgs e)
        {
            if (tbAddress.Text != "")
            {
                if (tbCity.Text != "")
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
                        if (photoFile != null)
                        {
                            if (VOGFile != null)
                            {
                                adress = tbAddress.Text;
                                city = tbCity.Text;
                                phonenumber = tbPhonenumber.Text;
                                birhtDay = dtpBirthDate.Value.Date;
                            }
                            else
                            {
                                MessageBox.Show("Voeg alsjeblieft een VOG toe");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Voeg alsjeblieft een Foto toe");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vul alsjeblieft een naam in");
                    }
                }
                else
                {
                    MessageBox.Show("Vul alsjeblieft een woonplaats in");
                }
            }
            else
            {
                MessageBox.Show("Vul alsjeblieft een adres in");
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
