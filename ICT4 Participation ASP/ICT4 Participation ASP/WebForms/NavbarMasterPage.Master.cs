using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4_Participation_ASP.Models.Accounts;

namespace ICT4_Participation_ASP.WebForms
{
    public partial class NavbarMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}