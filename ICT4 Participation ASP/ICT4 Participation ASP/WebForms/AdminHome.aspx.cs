using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Handlers;

namespace ICT4_Participation_ASP
{
    public partial class AdminPage : System.Web.UI.Page
    {
        private Admin _currentAdmin;
        private AdminHandler _currentAdminHandler;
        protected void Page_Load(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            ListBox2.Items.Clear();
            if (Session["LoggedUser"] is Admin)
            {
                _currentAdmin = (Admin)Session["LoggedUser"];
                _currentAdminHandler = new AdminHandler();
            }
            else
            {
                Response.Redirect("~/WebForms/LoginStandard.aspx");
            }


            foreach (User user in _currentAdminHandler.FillAccepted())
            {
                ListBox1.Items.Add(new ListItem(user.Name, user.ID.ToString()));
            }
            foreach (Volunteer volunteer in _currentAdminHandler.FillUnaccepted())
            {
                ListBox2.Items.Add(new ListItem(volunteer.Name, volunteer.ID.ToString()));
            }
        }


        protected void Button1_OnClick(object sender, EventArgs e)
        {
            _currentAdminHandler.BlockUser(ListBox1.SelectedValue);
        }

        protected void Button2_OnClick(object sender, EventArgs e)
        {
            _currentAdminHandler.WarnUser(ListBox1.SelectedValue);
        }

        protected void Button4_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void Button3_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void ListBox4_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}