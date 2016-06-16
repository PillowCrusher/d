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
    public partial class RegisterNeedy : System.Web.UI.Page
    {
        private AdminHandler ah;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedUser"] is Admin)
            {
                ah = new AdminHandler();
            }
            else
            {
                Response.Redirect("LoginStandard.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = inputUserName.Text;
            string email = inputEmail.Text;
            string name = inputName.Text;
            string address = inputAdres.Text;
            string city = inputCity.Text;
            string phonenumber = inputPhonenumber.Text;
            bool ov = inputOpenbaarVervoer.Checked;
            bool drivinglicense = inputDrivingLincense.Checked;
            bool car = inputCar.Checked;
            string barcode = inputBarcode.Text;
            string password = inputPassword.Text;
            string passwordconfirm = inputPasswordConfirm.Text;

            if (password == passwordconfirm)
            {
                ah.AddNeedy(username, email, name, address, city, phonenumber, Convert.ToInt32(ov), Convert.ToInt32(drivinglicense), Convert.ToInt32(car), barcode, password);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Hulpbehoevende is toegevoegd');</script>");
                Response.Redirect("AdminHome.aspx");
            }
        }
    }
}