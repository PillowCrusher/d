using System;
using System.Web;
using System.Web.UI.WebControls;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Handlers;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.WebForms
{
    public partial class AdminPage : System.Web.UI.Page
    {
        private Admin _currentAdmin;
        private AdminHandler _currentAdminHandler;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["LoggedUser"] is Admin)
            {
                _currentAdmin = (Admin)Session["LoggedUser"];
                _currentAdminHandler = new AdminHandler();
            }
            else
            {
                Response.Redirect("~/WebForms/LoginStandard.aspx");
            }

            if (!IsPostBack)
            {
                HttpCookie cookie = new HttpCookie("AdminList");

                cookie.Values.Add("VOG","");
                cookie.Values.Add("User","");
                cookie.Values.Add("Helprequest", "");
                cookie.Values.Add("Review", "");
                cookie.Values.Add("Textbox","");
                cookie.Values.Add("Switch","Helprequest");
                //Helprequest

                RefreshLists();
            }

            //Hulprequest.SelectedIndex = 0;
            //Review.SelectedIndex = 0;
            //_currentAdminHandler.SelectedValue1(Actors.SelectedValue);
            //_currentAdminHandler.SelectedValue2(VOG.SelectedValue);
            //_currentAdminHandler.SelectedValue3(Hulprequest.SelectedValue,"helprequest");

        }

        private void RefreshLists()
        {
            Actors.Items.Clear();
            VOG.Items.Clear();
            Hulprequest.Items.Clear();
            Review.Items.Clear();

            foreach (User user in _currentAdminHandler.FillUsers())
            {
                Actors.Items.Add(new ListItem("Needy: " + user.Name, user.ID.ToString()));
            }
            foreach (Volunteer volunteer in _currentAdminHandler.FillAccepted())
            {
                Actors.Items.Add(new ListItem("Volunteer: " + volunteer.Name, volunteer.ID.ToString()));
            }
            foreach (Volunteer volunteer in _currentAdminHandler.FillUnaccepted())
            {
                VOG.Items.Add(new ListItem("Volunteer: " + volunteer.Name, volunteer.ID.ToString()));
            }
            foreach (HelpRequest helpRequest in _currentAdminHandler.FillHelpRequests())
            {
                Hulprequest.Items.Add(new ListItem(helpRequest.Titel, helpRequest.ID.ToString()));
            }
        }


        protected void Button1_OnClick(object sender, EventArgs e)
        {
            _currentAdminHandler.BlockUser(Request.Cookies["AdminList"]["User"]);
            //foreach (User user in _currentAdminHandler.FillUsers())
            //{
            //    Actors.Items.Add(new ListItem("Needy: " + user.Name, user.ID.ToString()));
            //}
            //foreach (Volunteer volunteer in _currentAdminHandler.FillAccepted())
            //{
            //    Actors.Items.Add(new ListItem("Volunteer: " + volunteer.Name, volunteer.ID.ToString()));
            //}
            RefreshLists();
        }

        protected void Button2_OnClick(object sender, EventArgs e)
        {
            _currentAdminHandler.WarnUser(Request.Cookies["AdminList"]["User"]);
        }

        protected void Button4_OnClick(object sender, EventArgs e)
        {

            _currentAdminHandler.ActivateVolunteer(Request.Cookies["AdminList"]["VOG"]);
            Actors.Items.Clear();
            VOG.Items.Clear();
            RefreshLists();
        }

        protected void Button3_OnClick(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            string abc = Request.Cookies["AdminList"]["Switch"];
            if (Request.Cookies["AdminList"]["Switch"] == "Helprequest")
            {
                _currentAdminHandler.DeleteHelprequest(Request.Cookies["AdminList"]["Helprequest"]);
                Hulprequest.Items.Clear();
                Review.Items.Clear();
                foreach (HelpRequest helpRequest in _currentAdminHandler.FillHelpRequests())
                {
                    Hulprequest.Items.Add(new ListItem(helpRequest.Titel, helpRequest.ID.ToString()));
                }
            }
            else
            {
                string ac = Request.Cookies["AdminList"]["Helprequest"];
                string ab = Request.Cookies["AdminList"]["Review"].ToString();
                _currentAdminHandler.DeleteReview(Request.Cookies["AdminList"]["Review"].ToString());
                Review.Items.Clear();
                foreach (Volunteer volunteer in _currentAdminHandler.ReviewVolunteers(Request.Cookies["AdminList"]["Helprequest"]))
                {
                    Review.Items.Add(new ListItem(volunteer.Name, volunteer.ID.ToString() + " " + Response.Cookies["AdminList"]["Helprequest"]));
                }
            }
        }


        protected void Actors_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (Actors.SelectedValue != null)
            {
                Response.Cookies["AdminList"]["User"] = Actors.SelectedValue;
            }
            else
            {
                Response.Cookies["AdminList"]["User"] ="";
            }
          
        }

        protected void VOG_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (VOG.SelectedValue != null)
            {
                Response.Cookies["AdminList"]["VOG"] = VOG.SelectedValue;
            }
            else
            {
                Response.Cookies["AdminList"]["VOG"] = "";
            }
        }

        protected void Hulprequest_OnSelectedIndexChanged(object sender, EventArgs e)
        {            
            if (Hulprequest.SelectedValue != null)
            {
                Review.Items.Clear();
                Response.Cookies["AdminList"]["Helprequest"] = Hulprequest.SelectedValue;
                string abcde = Hulprequest.SelectedValue;
                string asdf = Request.Cookies["AdminList"]["Helprequest"];
                Response.Cookies["AdminList"]["Switch"] = "Helprequest";
                string abc = Response.Cookies["AdminList"]["Switch"];
                Response.Cookies["AdminList"]["Textbox"] =
                    _currentAdminHandler.DescriptionHelprequest(Hulprequest.SelectedValue);
                foreach (Volunteer volunteer in _currentAdminHandler.ReviewVolunteers(Hulprequest.SelectedValue))
                {
                    Review.Items.Add(new ListItem(volunteer.Name,volunteer.ID.ToString()+" "+Hulprequest.SelectedValue));
                }
            }
            else
            {
                Response.Cookies["AdminList"]["Helprequest"] = "";
            }
            string abcd = Response.Cookies["AdminList"]["Switch"];
            TextBox1.Text = Response.Cookies["AdminList"]["Textbox"];
        }

        protected void Review_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (Review.SelectedValue != null)
            {
                Response.Cookies["AdminList"]["Review"] = Review.SelectedValue;
                Response.Cookies["AdminList"]["Switch"] = "Review";
                Response.Cookies["AdminList"]["Textbox"] =
    _currentAdminHandler.MessageReview(Review.SelectedValue);
               

            }
            else
            {
                Response.Cookies["AdminList"]["Review"] = "";
            }
            TextBox1.Text = Response.Cookies["AdminList"]["Textbox"];
        }

        protected void VOGBtn_Click(object sender, EventArgs e)
        {
            Response.Write(string.Format("<script>window.open('{0}','_blank');</script>", "Default.aspx"));
        }
    }
}