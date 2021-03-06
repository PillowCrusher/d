﻿using System;
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
            Session["LoggedUser"] = null;
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            Handler handler = new Handler();

            List<object> parameters = new List<object>();

            if (inputUsername.Text != string.Empty) parameters.Add(inputUsername.Text); //TextBox Username
            if (inputPassword.Text != string.Empty) parameters.Add(inputPassword.Text); //TextBox Password
            parameters.Add(inputBarcode.Text);  //TextBox Barcode

            Account loggedAccount = null;
            try
            {
                if (parameters.Count == 1)
                {
                    loggedAccount = handler.LoginBar(parameters);
                }
                else
                {
                    loggedAccount = handler.Login(parameters);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("20001"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Er is geen gebruiker met deze naam en wachtwoord gevonden" + "');", true);
                }
                else
                {
                    string test = ex.Message;

                    string[] lines = test.Split(new string[] {"\n"}, StringSplitOptions.None);

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lines[0] + "');", true);
                }
            }


            if (loggedAccount is Admin)
            {
                Session["LoggedUser"] = loggedAccount;
                Response.Redirect("AdminHome.aspx");
            }

            if (loggedAccount is Needy)
            {
                Session["LoggedUser"] = loggedAccount;
                Response.Redirect("NeedyHome.aspx");
            }

            if (loggedAccount is Volunteer)
            {
                Session["LoggedUser"] = loggedAccount;
                Response.Redirect("VolunteerHome.aspx");
            }
        }
    }
}