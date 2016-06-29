using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Handlers;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.WebForms
{
    public partial class ProfileVolunteer : System.Web.UI.Page
    {
        private Volunteer _currentVolunteer;
        private VolunteerHandler _volunteerHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedUser"] is Volunteer)
            {
                _currentVolunteer = (Volunteer)Session["LoggedUser"];
                _volunteerHandler = new VolunteerHandler();

                if (!IsPostBack)
                {
                    UpdateGui();
                }
            }
            else
            {
                Response.Redirect("LoginStandard.aspx");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (inputPassword.Text == string.Empty)
            {
                throw new Exception("Vul je wachtwoord in om door te gaan!");
            }

            List<Skill> skills = _volunteerHandler.GetSkills();
            List<Skill> mySkills = new List<Skill>();
            foreach (ListItem item in SkillCheckBoxList.Items)
            {
                if (item.Selected)
                {
                    foreach (Skill s in skills)
                    {
                        if (item.ToString() == s.ToString())
                        {
                            mySkills.Add(s);
                        }
                    }
                }
            }
            string photo = null;
            if (inputPhoto.HasFile == false)
            {
                photo = _currentVolunteer.Photo;
            }
            else
            {
                photo = inputPhoto.FileName;
            }
            string vog = null;
            if (inputVog.HasFile == false)
            {
                vog = _currentVolunteer.VOG;
            }
            else
            {
                vog = inputVog.FileName;
            }
            _volunteerHandler.UpdateProfileData(_currentVolunteer.ID, inputAdres.Text, inputCity.Text, inputPhonenumber.Text, inputDrivingLincense.Checked, inputCar.Checked, photo, vog, mySkills);

            List<object> parameters = new List<object>();

            parameters.Add(_currentVolunteer.Username);
            parameters.Add(inputPassword.Text);
            parameters.Add(string.Empty);

            Session["LoggedUser"] = _volunteerHandler.Login(parameters);
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Je profiel is geupdate');window.open('VolunteerHome.aspx','_self');", true);
        }

        private void UpdateGui()
        {
            UserNameLabel.Text = _currentVolunteer.Username;
            EmailLabel.Text = _currentVolunteer.Email;
            NameLabel.Text = _currentVolunteer.Name;
            inputAdres.Text = _currentVolunteer.Adres;
            inputCity.Text = _currentVolunteer.City;
            inputPhonenumber.Text = _currentVolunteer.Phonenumber;
            inputDrivingLincense.Checked = _currentVolunteer.HasDrivingLincense;
            inputCar.Checked = _currentVolunteer.HasCar;
            birthdDateLabel.Text = _currentVolunteer.BirthDate.ToString("d");
            List<Skill> skills = _volunteerHandler.GetSkills();
            _currentVolunteer.AddSkill(_volunteerHandler.GetVolunteerSkills(_currentVolunteer));
            foreach (Skill s in skills)
            {
                foreach (Skill m in _currentVolunteer.Skills)
                {
                    ListItem item = new ListItem();
                    item.Text = s.ToString();
                    if(s.Naam == m.Naam)
                    {
                        item.Selected = true;
                        item.Enabled = false;
                    }
                    else
                    {
                        item.Selected = false;
                    }
                    SkillCheckBoxList.Items.Add(item);
                }
            }
        }

        protected void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            _volunteerHandler.Unsubscribe(DateTime.Now, _currentVolunteer);
            Session["LoggedUser"] = null;
            Response.Redirect("LoginStandard.aspx");
        }
    }
}