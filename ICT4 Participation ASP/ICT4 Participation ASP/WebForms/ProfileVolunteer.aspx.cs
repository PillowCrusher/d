using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

            List<object> parameters = new List<object>();

            parameters.Add(_currentVolunteer.ID);
            parameters.Add(inputAdres.Text);
            parameters.Add(inputCity.Text);
            parameters.Add(inputPhonenumber.Text);
            parameters.Add(Convert.ToInt32(inputDrivingLincense.Checked));
            parameters.Add(Convert.ToInt32(inputCar.Checked));

            parameters.Add(inputPhoto.HasFile ? inputPhoto.FileName : _currentVolunteer.Photo);

            parameters.Add(inputVog.HasFile ? inputVog.FileName : _currentVolunteer.VOG);

            _volunteerHandler.UpdateProfileData(parameters);

            parameters.Clear();

            parameters.Add(_currentVolunteer.Username);
            parameters.Add(inputPassword.Text);
            parameters.Add(string.Empty);

            Session["LoggedUser"] = _volunteerHandler.Login(parameters);

            Response.Redirect("VolunteerHome.aspx");
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
            //foto
            //vog
            //vaardigheden

        }
    }
}