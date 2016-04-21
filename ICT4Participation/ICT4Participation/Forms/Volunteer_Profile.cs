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
        public Administration administration = new Administration();
        private string photoFile = null;
        private string VOGFile = null;

        public Volunteer_Profile()
        {
            InitializeComponent();
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
            bool publicTransport = false;
            bool car = false;
            bool driving = false;
            if (tbUsername.Text != "")
            {
                if (tbName.Text != "")
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
                                    car = true;
                                }
                                else if (rbtCarNo.Checked == false)
                                {
                                    car = false;
                                }
                                if (rbtDrivingYes.Checked == true)
                                {
                                    driving = true;
                                }
                                else if (rbtDrivingNo.Checked == false)
                                {
                                    driving = false;
                                }
                                if (photoFile != null)
                                {
                                    if (VOGFile != null)
                                    {
                                        DateTime birthday = dtpBirthDate.Value.Date;
                                        try
                                        {
                                            administration.user.UpdateProfiel(new Volunteer(new Account(tbUsername.Text, tbPassword.Text, tbEmail.Text), tbName.Text, tbAddress.Text, tbCity.Text, tbPhonenumber.Text, publicTransport, driving, car, birthday, photoFile, VOGFile));
                                            this.DialogResult = DialogResult.OK;
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
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
                else
                {
                    MessageBox.Show("Vul alsjeblieft een naam in");
                }
            }
            else
            {
                MessageBox.Show("Vul alsjeblieft een gebruikersnaam in");
            }
        }

        private void btUnsubscribe_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Weet je het zeker?", "Bevestig", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                administration.user.UnSubscribe();
            }
        }

        
    }
}
