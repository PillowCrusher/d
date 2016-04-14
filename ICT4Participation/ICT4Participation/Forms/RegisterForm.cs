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

namespace ICT4Participation.Forms
{
    public partial class RegisterForm : Form
    {
        public Administration administration = new Administration();
        private string photoFile = null;
        private string VOGFile = null;

        public RegisterForm()
        {
            InitializeComponent();
            rbtCarNo.Checked = true;
            rbtDrivingNo.Checked = true;
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
        private void btRegister_Click(object sender, EventArgs e)
        {
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
                                        administration.AddVolunteer(tbName.Text, tbAddress.Text, tbCity.Text, tbPhonenumber.Text, driving, car, birthday, photoFile, VOGFile);
                                        this.DialogResult = DialogResult.OK;
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

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


    }
}
