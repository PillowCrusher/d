using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICT4Participation.Classes.Database;
using Phidgets;
using Phidgets.Events;
using System.Threading;
using System.Threading.Tasks;
using ICT4Participation.Classes.ClassObjects;
using ICT4Participation.Classes.Intelligence;

namespace ICT4Participation.Forms
{
    public partial class LogInForm : Form
    {
        /// <summary>
        /// Het aanmaken van een RFID object om mee te scannen
        /// </summary>
        private RFID rfid;
        /// <summary>
        /// string waarin het gescande RFID tag wordt opgeslagen
        /// </summary>
        private string rfidTag = null;
        /// <summary>
        /// Administratie klasse wat de logica regelt
        /// </summary>
        private Administration _administration;

        public LogInForm()
        {
            InitializeComponent();
            _administration = new Administration();
        }

        /// <summary>
        /// Bij het aanmaken van het form worden de RFID event aangemaakt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogInForm_Load(object sender, EventArgs e)
        {
            rfid = new RFID();
            rfid.Attach += new AttachEventHandler(rfid_Attach);
            rfid.Detach += new DetachEventHandler(rfid_Detach);
            rfid.Error += new ErrorEventHandler(rfid_Error);
            rfid.Tag += new TagEventHandler(rfid_Tag);
            rfid.open();
        }

        /// <summary>
        /// Event zorgt ervoor dat een hulpbehoevende of admin kan inloggen met behulp van een RFID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rfid_Tag(object sender, TagEventArgs e)
        {
            //scanned rfid ID
            rfidTag = e.Tag;
            Form form = null;
            // als tijdens het scannen de username en password niet leeg zijn word er gekeken of het om een admin account gaat
            if (tbUsername.Text != "" && tbPassword.Text != "")
            {
                _administration.Login(tbUsername.Text, tbPassword.Text, rfidTag);
                //als het gevonden account niet leeg is en van het type admin is wordt deze doorgestuurd naar het admin form
                if (_administration.User != null && _administration.User.GetType() == typeof(Admin))
                {
                    tbUsername.Text = "";
                    tbPassword.Text = "";
                    using (form = new AdminForm())
                    {
                        Hide();
                        form.ShowDialog();
                    }
                    _administration.Logout();
                    Show();
                }
            }
            else
            {
                //als er alleen een rfid wordt gescand wordt er gekeken of er het pasje van een hulpbehoevende is
                _administration.LoginWithRfid(rfidTag);
                //als het gevonden account niet leeg is en van het type needy is wordt deze doorgestuurd naar het hulpbehoevende form
                if (_administration.User != null && _administration.User.GetType() == typeof(Needy))
                {
                    using (form = new HulpbehoevendeForm(_administration))
                    {
                        Hide();
                        form.ShowDialog();
                    }
                    _administration.Logout();
                    Show();
                }
            }
            rfidTag = null;
        }

        void rfid_Attach(object sender, AttachEventArgs e)
        {
            // if the rfid is connected set on and change status
            rfid.Antenna = true;
        }

        void rfid_Detach(object sender, DetachEventArgs e)
        {
            // if the rfid is detachted and change status
            //rfid.Antenna = false;
        }

        void rfid_Error(object sender, ErrorEventArgs e)
        {
            // if the is an error, show
            MessageBox.Show("RFID ERROR " + e.Description);
            rfid.close();
            Close();
        }

        /// <summary>
        /// Event zorgt ervoor dat een needy of volunteer kan inloggen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btLogIn_Click(object sender, EventArgs e)
        {
            Form form = null;
            //Als de username en password niet leeg zijn wordt er in de database gezocht naar een matchend account
            if (tbUsername.Text != "" && tbPassword.Text != "")
            {
                _administration.Login(tbUsername.Text, tbPassword.Text);
                tbUsername.Text = "";
                tbPassword.Text = "";
                //Als het gevonden account niet leeg is en een type van volunteer wordt deze naar het vrijwilligers form gebracht
                if (_administration.User != null)
                {
                    if (_administration.User.GetType() == typeof(Volunteer))
                    {
                        using (form = new VrijwilligersForm(this._administration))
                        {
                            Hide();
                            form.ShowDialog();
                        }
                    }
                    //Als het gevonden account niet leeg is en een type van needy wordt deze naar het hulpbehoevende form gebracht
                    if (_administration.User.GetType() == typeof(Needy))
                    {
                        using (form = new HulpbehoevendeForm(_administration))
                        {
                            Hide();
                            form.ShowDialog();
                        }
                    }
                    Show();
                }
                //als er geen account is gevonden krijgt de gebruiker een waarschuwing
                else
                {
                    MessageBox.Show("Inloggen mislukt, controleer uw gebruikersnaam en wachtwoord.");
                }
                _administration.Logout();
            }
            else
            {
                MessageBox.Show("Vul AUB een gebruikersnaam en wachtwoord in.");
            }
        }

        /// <summary>
        /// dit event stuurt een user naar de pagina om zich te registreren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm form = new RegisterForm();
            Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                Visible = true;
            }
        }
    }
}
