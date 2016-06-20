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
    public partial class VolunteerReviews1 : System.Web.UI.Page
    {
        private HelpRequest _currentHelpRequest;
        private Volunteer _currentVolunteer;
        private VolunteerHandler _volunteerHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _currentHelpRequest = (HelpRequest)Session["_currentHelpRequest"];
            }
            if (Session["LoggedUser"] is Volunteer)
            {
                _currentVolunteer = (Volunteer) Session["LoggedUser"];
                _volunteerHandler = new VolunteerHandler();
                _volunteerHandler.GetReviews(_currentVolunteer);
                DdlReview.Items.Clear();
                foreach (Review r in _currentVolunteer.Reviews)
                {
                    DdlReview.Items.Add(r.Message);
                }
            }
            else
            {
                Response.Redirect("LoginStandard.aspx");
            }
        }



        protected void postComment_Click(object sender, EventArgs e)
        {
            foreach (Review r in _currentVolunteer.Reviews)
            {
                if (r.Message == DdlReview.Text)
                {
                    if (r.Comment != "" || r.Comment != null)
                    {
                        var comment = inputComment.Text;
                        _volunteerHandler.PlaceComment(r, _currentVolunteer, comment);
                        inputComment.Text = String.Empty;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('U hebt gereageerd op deze beoordeling');</script>");
                        Page_Load(null, null);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('U heeft al gereageerd op deze beoordeling');</script>");
                    }
                }               
            }
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
        }
    }
}