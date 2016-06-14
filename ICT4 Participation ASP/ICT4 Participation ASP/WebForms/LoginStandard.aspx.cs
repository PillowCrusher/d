using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Handlers;
using System.Data;

namespace ICT4_Participation_ASP.WebForms
{
    public partial class LoginStandard : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            Handler handler = new Handler();

            List<object> parameters = new List<object>();
            parameters.Add(inputUsername.Text); //TextBox Username
            parameters.Add(inputPassword.Text); //TextBox Password
            parameters.Add(inputBarcode.Text);  //TextBox Barcode

            DataTable dt = handler.ExecuteReadQuery(null, handler.ExecuteSqlFunction(parameters, "LogIn").ToString());

            Account loggedUser = null;

            foreach (DataRow dr in dt.Rows)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new Exception("Er zijn meer dan 1 Accounts gevonden.. Neem contact op met de beheerder");
                }

                string roll = dr["Roll"].ToString();

                if (roll == "ADMIN")
                {
                    loggedUser = new Admin(dr);
                    Response.Redirect("AdminHome.aspx");
                }
                else if (roll == "NEEDY")
                {
                    loggedUser = new Needy(dr);
                    Response.Redirect("NeedyHome.aspx");
                }
                else if(roll == "VOLUNTEER")
                {
                    loggedUser = new Volunteer(dr);
                    Response.Redirect("VolunteerHome.aspx");
                }
                else
                {
                    throw new Exception("Kan de gegevens niet ophalen, meld dit aan de beheerder");
                }
            }

            Session["LoggedUser"] = loggedUser;
        }
    }
}