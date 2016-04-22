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
        /// <summary>
        /// Administratie klasse wat de logica regelt
        /// </summary>
        public Administration administration = new Administration();

        public Needy_RegisterForm()
        {
            InitializeComponent();          
        }

        /// <summary>
        /// Event controleert de ingevulde waardes en voegt een nieuw needy toe
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
                    if (cbxLocation.Text != "")
                    {
                            if (tbPhonenumber.Text != "")
                            {
                            //Kijkt welk van de radiobuttons is geselecteerd en geeft een waarde mee
                            //aan de tijdelijke bool
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
                                    //Controleert of het username nog niet bezet is door andere gebruikers
                                    if (administration.GetAccountId(tbUsername.Text) == 0)
                                        {
                                        //Voegt de volunteer toe in de database
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
    }
}
