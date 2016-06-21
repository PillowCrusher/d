using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Handlers;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP
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

                ListBox1.Items.Clear();
                ListBox2.Items.Clear();
                ListBox3.Items.Clear();
                ListBox4.Items.Clear();


                foreach (User user in _currentAdminHandler.FillUsers())
                {
                    ListBox1.Items.Add(new ListItem("Needy :" + user.Name, user.ID.ToString()));
                }
                foreach (Volunteer volunteer in _currentAdminHandler.FillAccepted())
                {
                    ListBox1.Items.Add(new ListItem("Volunteer :" + volunteer.Name, volunteer.ID.ToString()));
                }
                foreach (Volunteer volunteer in _currentAdminHandler.FillUnaccepted())
                {
                    ListBox2.Items.Add(new ListItem("Volunteer :" + volunteer.Name, volunteer.ID.ToString()));
                }
                foreach (HelpRequest helpRequest in _currentAdminHandler.FillHelpRequests())
                {
                    ListBox3.Items.Add(new ListItem(helpRequest.Titel,helpRequest.ID.ToString()));
                }
            }
           
            //ListBox3.SelectedIndex = 0;
            //ListBox4.SelectedIndex = 0;
            //_currentAdminHandler.SelectedValue1(ListBox1.SelectedValue);
            //_currentAdminHandler.SelectedValue2(ListBox2.SelectedValue);
            //_currentAdminHandler.SelectedValue3(ListBox3.SelectedValue,"helprequest");
        }


        protected void Button1_OnClick(object sender, EventArgs e)
        {
            _currentAdminHandler.BlockUser(Request.Cookies["AdminList"]["User"]);
        }

        protected void Button2_OnClick(object sender, EventArgs e)
        {
            _currentAdminHandler.WarnUser(Request.Cookies["AdminList"]["User"]);
        }

        protected void Button4_OnClick(object sender, EventArgs e)
        {   
            _currentAdminHandler.ActivateVolunteer(Request.Cookies["AdminList"]["VOG"]);
        }

        protected void Button3_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        protected void ListBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox1.SelectedValue != null)
            {
                Response.Cookies["AdminList"]["User"] = ListBox1.SelectedValue;
            }
            else
            {
                Response.Cookies["AdminList"]["User"] ="";
            }
          
        }

        protected void ListBox2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox2.SelectedValue != null)
            {
                Response.Cookies["AdminList"]["VOG"] = ListBox2.SelectedValue;
            }
            else
            {
                Response.Cookies["AdminList"]["VOG"] = "";
            }
        }

        protected void ListBox3_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ListBox3.SelectedValue != null)
            {
                ListBox4.Items.Clear();
                Response.Cookies["AdminList"]["Helprequest"] = ListBox3.SelectedValue;
                Response.Cookies["AdminList"]["Switch"] = "Helprequest";
                Response.Cookies["AdminList"]["Textbox"] =
                    _currentAdminHandler.DescriptionHelprequest(ListBox3.SelectedValue);
                foreach (Volunteer volunteer in _currentAdminHandler.ReviewVolunteers(ListBox3.SelectedValue))
                {
                    ListBox4.Items.Add(new ListItem(volunteer.Name,volunteer.ID.ToString()+" "+ListBox3.SelectedValue));
                }
            }
            else
            {
                Response.Cookies["AdminList"]["Helprequest"] = "";
            }
            TextBox1.Text = Response.Cookies["AdminList"]["Textbox"];
        }

        protected void ListBox4_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox4.SelectedValue != null)
            {
                Response.Cookies["AdminList"]["Review"] = ListBox3.SelectedValue;
                Response.Cookies["AdminList"]["Switch"] = "Review";
                Response.Cookies["AdminList"]["Textbox"] =
    _currentAdminHandler.MessageReview(ListBox4.SelectedValue);
               

            }
            else
            {
                Response.Cookies["AdminList"]["Review"] = "";
            }
            TextBox1.Text = Response.Cookies["AdminList"]["Textbox"];
        }
    }
}