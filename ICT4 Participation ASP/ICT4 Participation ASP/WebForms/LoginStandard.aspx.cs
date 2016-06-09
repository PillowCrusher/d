using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Handlers;

namespace ICT4_Participation_ASP.WebForms
{
    public partial class LoginStandard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            Handler a = new Handler();/*
            a.Login(inputUsername.Text, inputPassword.Text);
            if (a.User is Volunteer)
            {
                Response.Redirect("VolunteerHome.aspx");
            }
            if (a.User is Needy)
            {
                Response.Redirect("NeedyHome.aspx");
            }
            if (a.User is Admin)
            {
                Response.Redirect("AdminHome.aspx");
            }*/
        }
    }
}