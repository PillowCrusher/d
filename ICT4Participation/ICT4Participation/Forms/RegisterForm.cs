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
        /// <summary>
        /// Administratie klasse wat de logica regelt
        /// </summary>
        public Administration administration = new Administration();
        /// <summary>
        /// private field om het path van de foto in op te slaan na het selecteren
        /// </summary>
        private string photoFile = null;
        /// <summary>
        /// private field om het path van de VOG in op te slaan na het selecteren
        /// </summary>
        private string VOGFile = null;

        public RegisterForm()
        {
            InitializeComponent();
            rbtTransportNo.Checked = true;
            rbtCarNo.Checked = true;
            rbtDrivingNo.Checked = true;
        }

        /// <summary>
        /// Event zorgt ervoor dat een gebruiker een photo uit zijn bestanden kan kiezen
        /// en slaat het file path oop in het field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog photoLog = new OpenFileDialog();
            if (photoLog.ShowDialog() == DialogResult.OK)
            {
                photoFile = photoLog.FileName;
                lbFilePhoto.Text = photoFile.Split('\\').Last();
            }
        }

        /// <summary>
        /// Event zorgt ervoor dat een gebruiker een VOG uit zijn bestanden kan kiezen
        /// en slaat het file path oop in het field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btVOG_Click(object sender, EventArgs e)
        {
            OpenFileDialog VOGLog = new OpenFileDialog();
            if (VOGLog.ShowDialog() == DialogResult.OK)
            {
                VOGFile = VOGLog.FileName;
                lbFileVOG.Text = VOGFile.Split('\\').Last();
            }
        }

        /// <summary>
        /// Event controleert de ingevulde waardes en voegt een nieuw Volunteer toe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btRegister_Click(object sender, EventArgs e)
        {
            //tijdelijk bools om de waarde in op te slaan
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
                                //Kijkt welk van de radiobuttons is geselecteerd en geeft een waarde mee
                                //aan de tijdelijke bool
                                if (rbtTransportYes.Checked == true)
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
                                            //Controleert of het username nog niet bezet is door andere gebruikers
                                            if (administration.GetAccountId(tbUsername.Text) == 0)
                                            {
                                                //Voegt de volunteer toe in de database
                                                administration.AddVolunteer(tbUsername.Text, tbPassword.Text,
                                                    tbEmail.Text, tbName.Text, tbAddress.Text, tbCity.Text,
                                                    tbPhonenumber.Text, publicTransport, driving, car, birthday,
                                                    photoFile, VOGFile);
                                                this.DialogResult = DialogResult.OK;
                                            }
                                            else
                                            {
                                                MessageBox.Show("username is al bezet");
                                            }
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

        /// <summary>
        /// Event om het form te sluiten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


    }
}
