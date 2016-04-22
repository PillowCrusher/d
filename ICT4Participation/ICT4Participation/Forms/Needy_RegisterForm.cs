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
    public partial class Needy_RegisterForm : Form
    {
        public Administration administration = new Administration();
        public Needy_RegisterForm()
        {
            InitializeComponent();
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            bool publicTransport = false;
            bool car = false;
            bool driving = false;
            if (tbUsername.Text != "")
            {
                if (tbName.Text != "")
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
                                if (txtRFID.Text != "")
                                {
                                    try
                                    {
                                        if (administration.GetAccountId(tbUsername.Text) == 0)
                                        {
                                            administration.AddNeedy(tbUsername.Text, tbPassword.Text, tbEmail.Text,
                                                tbName.Text, cbxLocation.Text, tbPhonenumber.Text, publicTransport,
                                                driving, car, txtRFID.Text);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Username is al bezet");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Vul alsjeblieft een RFID code in");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Vul alsjeblieft een naam in");
                            }
                        }
                    else
                    {
                        MessageBox.Show("Vul alsjeblieft een locatie in");
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

        private void Needy_RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
