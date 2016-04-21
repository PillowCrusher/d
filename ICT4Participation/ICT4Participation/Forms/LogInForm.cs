using System.Windows.Forms;
using ICT4Participation.Classes.Database;
using Phidgets;
using Phidgets.Events;
using ICT4Participation.Classes.ClassObjects;
using ICT4Participation.Classes.Intelligence;

namespace ICT4Participation.Forms
{
    public partial class LogInForm : Form
    {
        private RFID rfid;
        string rfidTag = null;
        public Administration administration = new Administration();

        public LogInForm()
        {
            InitializeComponent();
        }

        private void LogInForm_Load(object sender, System.EventArgs e)
        {
            rfid = new RFID();
            rfid.Attach += new AttachEventHandler(rfid_Attach);
            rfid.Detach += new DetachEventHandler(rfid_Detach);
            rfid.Error += new ErrorEventHandler(rfid_Error);

            rfid.Tag += new TagEventHandler(rfid_Tag);
            rfid.TagLost += new TagEventHandler(rfid_TagLost);

            rfid.open();
        }

        void rfid_Tag(object sender, TagEventArgs e)
        {
            //scanned rfid ID
            rfidTag = e.Tag;
            User user = administration.LoginWithRfid(rfidTag);
            Form form = null;
            if (user != null)
            {
                if (user.GetType() == typeof(Needy))
                {
                     form = new HulpbehoevendeForm();
                     using (form)
                     {
                         this.Hide();
                     }             
                }
            }
        }

        void rfid_TagLost(object sender, TagEventArgs e)
        {
            // if tag is lost
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
            rfid.Antenna = false;
        }

        void rfid_Error(object sender, ErrorEventArgs e)
        {
            // if the is an error, show
            MessageBox.Show("RFID ERROR " + e.Description);
            rfid.close();
            this.Close();
        }

        private void btLogIn_Click(object sender, System.EventArgs e)
        {
            if (tbUsername.Text != "")
            {
                if (tbPassword.Text != "")
                {
                    if (rfidTag != null)
                    {
                        Admin user = administration.Login(tbUsername.Text, tbPassword.Text, rfidTag);
                        if(user != null)
                        {
                            AdminForm form = new AdminForm();
                            using (form)
                            {
                                this.Hide();
                            } 
                        }
                        else
                        {
                            MessageBox.Show("Er is geen admin account gevonden met deze naam, wachtwoord en rfid combinatie");
                        }
                    }
                    else
                    {
                        User user = administration.Login(tbUsername.Text, tbPassword.Text);
                        if (user != null)
                        {
                            if (user.GetType() == typeof(Needy))
                            {
                                HulpbehoevendeForm form = new HulpbehoevendeForm();
                                using (form)
                                {
                                    this.Hide();
                                } 
                            }
                        }
                        else
                        {
                            MessageBox.Show("Er is geen account met de naam en wachtwoord combinatie gevonden");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vul alsjeblieft een wachtwoord in");
                }
            }
            else
            {
                MessageBox.Show("Vul alsjeblieft een gebruikersnaam in");
            }
        }

        private void llblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm form = new RegisterForm();
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.Visible = true;
            }
        }
    }
}
