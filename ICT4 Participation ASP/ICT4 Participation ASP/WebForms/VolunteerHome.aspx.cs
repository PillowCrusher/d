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
    public partial class VolunteerHome : System.Web.UI.Page
    {
        private VolunteerHandler _volunteerHandler;
        private Volunteer _currentVolunteer;

        private List<HelpRequest> _theList = new List<HelpRequest>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedUser"] is Volunteer)
            {
                _currentVolunteer = (Volunteer)Session["LoggedUser"];
                _volunteerHandler = new VolunteerHandler();
            }
            else
            {
                Response.Redirect("LoginStandard.aspx");
            }

            //populate members of list
            lvList.DataSource = _theList;
            lvList.DataBind();
        }
    }
}