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
    public partial class NavbarMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Handler h = new Handler();
            Account loggedAccount = (Account) Session["LoggedUser"];
            if (loggedAccount == null)
            {
                LinkLogin.Visible = true;
                LinkRegister.Visible = true;

            }
            else
            {
                LinkLogin.Visible = false;
                LinkLogout.Visible = true;
                LinkRegister.Visible = false;
                if (loggedAccount is Admin)
                {
                    LinkNeedyRegister.Visible = true;
                }
                else
                {
                    if (h.GetUserWarned(loggedAccount.Username) == 1)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Je hebt een waarschuwing gekregen. Neem voor verdere informatie contact op met de beheerder.');", true);
                        h.ResetUserWarned(loggedAccount.Username);
                    }
                }
                
            }
        }

        protected void LinkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginStandard.aspx");
        }

        protected void LinkLogout_Click(object sender, EventArgs e)
        {
            Session["LoggedUser"] = null;
            Response.Redirect("LoginStandard.aspx");
        }

        protected void LinkRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterVolunteer.aspx");
        }

        protected void LinkNeedyRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterNeedy.aspx");
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Account loggedAccount = (Account)Session["LoggedUser"];
            if (loggedAccount is Admin)
            {
                Response.Redirect("AdminHome.aspx");
            }
            if (loggedAccount is Needy)
            {
                Response.Redirect("NeedyHome.aspx");
            }
            if (loggedAccount is Volunteer)
            {
                Response.Redirect("VolunteerHome.aspx");
            }
            else
            {
                Response.Redirect("LoginStandard.aspx");
            }
        }
    }
}