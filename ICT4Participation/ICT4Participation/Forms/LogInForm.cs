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
        private RFID rfid;
        private string rfidTag = null;
        private Administration _administration;

        public LogInForm()
        {
            InitializeComponent();
            _administration = new Administration();
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            rfid = new RFID();
            rfid.Attach += new AttachEventHandler(rfid_Attach);
            rfid.Detach += new DetachEventHandler(rfid_Detach);
            rfid.Error += new ErrorEventHandler(rfid_Error);
            rfid.Tag += new TagEventHandler(rfid_Tag);
            rfid.open();
        }

        void rfid_Tag(object sender, TagEventArgs e)
        {
            //scanned rfid ID
            rfidTag = e.Tag;
            Form form = null;
            if (tbUsername.Text != "" && tbPassword.Text != "")
            {
                _administration.Login(tbUsername.Text, tbPassword.Text, rfidTag);
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
                _administration.LoginWithRfid(rfidTag);
                if (_administration.User != null && _administration.User.GetType() == typeof(Needy))
                {
                    using (form = new HulpbehoevendeForm())
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

        private void btLogIn_Click(object sender, EventArgs e)
        {
            Form form = null;
            if (tbUsername.Text != "" && tbPassword.Text != "")
            {
                _administration.Login(tbUsername.Text, tbPassword.Text);
                tbUsername.Text = "";
                tbPassword.Text = "";
                if (_administration.User != null)
                {
                    if (_administration.User.GetType() == typeof(Volunteer))
                    {
                        using (form = new VrijwilligersForm())
                        {
                            Hide();
                            form.ShowDialog();
                        }
                    }
                    if (_administration.User.GetType() == typeof(Needy))
                    {
                        using (form = new HulpbehoevendeForm())
                        {
                            Hide();
                            form.ShowDialog();
                        }
                    }
                    _administration.Logout();
                    Show();
                }
            }
            else
            {
                MessageBox.Show("Vul AUB een gebruikersnaam en wachtwoord in.");
            }
        }

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
