using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4_Participation_ASP.WebForms
{
    public partial class RegisterVolunteer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_OnClick(object sender, EventArgs e)
        {
            string username = inputUserName.Text;
            string password = inputPassword.Text;
            string email = inputEmail.Text;
            string name = inputName.Text;
            DateTime birthdate = Convert.ToDateTime(inputBirthDate.Text);
            string address = inputAdres.Text;
            string city = inputCity.Text;
            string phonenumber = inputPhonenumber.Text;
            string s = inputPhoto.FileName;
            string d = inputVog.FileName;
            bool haslicense = inputDrivingLincense.Checked;
            bool hascar = inputCar.Checked;

            if (password == inputPasswordConfirm.Text)
            {
                
            }

        }


        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
        }
    }
}