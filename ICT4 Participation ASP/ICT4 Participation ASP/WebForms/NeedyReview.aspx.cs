using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Handlers;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.WebForms
{
    public partial class NeedyReview : System.Web.UI.Page
    {
        private HelpRequest _currentHelpRequest;
        private Needy _currentNeedy;
        private NeedyHandler _needyHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _currentHelpRequest = (HelpRequest)Session["_currentHelpRequest"];
            }
            if (Session["LoggedUser"] is Needy)
            {
                _currentNeedy = (Needy)Session["LoggedUser"];
                _needyHandler = new NeedyHandler();                
            }
            else
            {
                Response.Redirect("NeedyHome.aspx");
            }
            if (!IsPostBack)
            {
                _currentHelpRequest = (HelpRequest)Session["_currentHelpRequest"];
                if (_currentHelpRequest != null)
                {
                    foreach (Volunteer v in _currentHelpRequest.Accepted)
                    {
                        ListItem dataItem = new ListItem();
                        dataItem.Text = v.Name;
                        dataItem.Value = v.ID.ToString();
                        VrijwilligerListBox.Items.Add(dataItem);
                    }
                }
                else
                {
                    Response.Redirect("NeedyHome.aspx");
                }
            }
        }

        protected void btnPlaats_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(VrijwilligerListBox.SelectedValue);
            Volunteer volunteer = null;
            foreach (Volunteer v in _currentHelpRequest.Accepted)
            {
                if (v.ID == ID)
                {
                    volunteer = v;   
                }
            }
            if (_currentHelpRequest.Reviews.Find(x => x.Volunteer == volunteer) == null)
            {
                _needyHandler.AddReview(_currentHelpRequest, volunteer, inputReview.Text);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('U heeft deze vrijwilliger al beoordeelt');</script>");
            }
        }

        protected void btnAfsluiten_Click(object sender, EventArgs e)
        {
            if (_currentHelpRequest != null)
            {
                _needyHandler.CompleteHelpreqeust(_currentHelpRequest);

                Response.Redirect("NeedyHome.aspx");
            }
        }

        protected void VrijwilligerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}