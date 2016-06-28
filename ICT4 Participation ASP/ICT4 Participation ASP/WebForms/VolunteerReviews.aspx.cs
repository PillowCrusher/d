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
            _currentHelpRequest = (HelpRequest) Session["_currentHelpRequest"];
            _currentVolunteer = (Volunteer) Session["LoggedUser"];
            _volunteerHandler = new VolunteerHandler();

            if (!IsPostBack)
            {
                if (IsPostBack)
                {
                }
                if (Session["LoggedUser"] is Volunteer)
                {
                    _volunteerHandler.GetHelprequestReviews(_currentVolunteer);
                    DdlReview.Items.Clear();
                    foreach (HelpRequest h in _currentVolunteer.HelpRequesten)
                    {
                        foreach (Review r in h.Reviews)
                        {
                            ListItem dataItem = new ListItem();
                            dataItem.Value = r.Message;
                            dataItem.Text = h.Titel + ": " + r.Message;
                            DdlReview.Items.Add(dataItem);
                        }
                    }
                    DdlReview_SelectedIndexChanged(DdlReview, e);
                }
                else
                {
                    Response.Redirect("LoginStandard.aspx");
                }
                if (!IsPostBack)
                {
                    DdlReview.Text = _volunteerHandler.Message;
                }
            }
        }



        protected void postComment_Click(object sender, EventArgs e)
        {
            foreach (HelpRequest h in _currentVolunteer.HelpRequesten)
            {
                foreach (Review r in h.Reviews)
                {
                    if (r.Message == DdlReview.SelectedValue)
                    {
                        if (r.Comment != "" || r.Comment != null)
                        {
                            var comment = inputComment.Text;
                            _volunteerHandler.PlaceComment(r, _currentVolunteer, comment);
                            inputComment.Text = String.Empty;
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script",
                                "<script>alert('U hebt gereageerd op deze beoordeling');</script>");
                            DdlReview_SelectedIndexChanged(DdlReview, e);
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script",
                                "<script>alert('U heeft al gereageerd op deze beoordeling');</script>");
                        }
                    }
                }
            }
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
        }

        protected void DdlReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (HelpRequest h in _currentVolunteer.HelpRequesten)
            {
                foreach (Review r in h.Reviews)
                {
                    if (r.Message == DdlReview.SelectedValue)
                    {
                        if (r.Comment == string.Empty)
                        {
                            inputComment.Text = string.Empty;
                            inputComment.Enabled = true;
                            postComment.Enabled = true;
                        }
                        else
                        {
                            inputComment.Enabled = false;
                            inputComment.Text = r.Comment;
                            postComment.Enabled = false;
                        }
                    }
                }
            }

        }
    }
}