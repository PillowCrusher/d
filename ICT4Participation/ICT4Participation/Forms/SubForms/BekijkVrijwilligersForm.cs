using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICT4Participation.Classes.ClassObjects;
using ICT4Participation.Classes.Database;
using Oracle.ManagedDataAccess.Client;

namespace ICT4Participation.Forms.SubForms
{
    public partial class BekijkVrijwilligersForm : Form
    {
        private HelpRequest _helpRequest;
        private List<string> recensies; 

        public BekijkVrijwilligersForm(HelpRequest helpRequest)
        {
            InitializeComponent();
            _helpRequest = helpRequest;
            RefreshListBoxes();
        }

        private void RefreshListBoxes()
        {
            lbVrijwilligers.DataSource = _helpRequest.Pending;
            lbVrijwilligers.DisplayMember = "Name";
        }

        private void btnAccepteer_Click(object sender, EventArgs e)
        {
            Volunteer v = (Volunteer) lbVrijwilligers.SelectedItem;
            _helpRequest.Accept(v);
        }

        private void btnWijsAf_Click(object sender, EventArgs e)
        {
            Volunteer v = (Volunteer)lbVrijwilligers.SelectedItem;
            _helpRequest.Decline(v);
        }

        private void lbRecensies_SelectedIndexChanged(object sender, EventArgs e)
        {
            Volunteer v = (Volunteer) lbVrijwilligers.SelectedItem;
            recensies = new List<string>();
            OracleParameter[] parameters =
            {
                new OracleParameter("id", v.ID), 
            };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllReviewsVolunteer"], parameters);
            foreach (DataRow dr in dt.Rows)
            {
                recensies.Add(Convert.ToString(dr["MESSAGE"]));
            }
        }
    }
}
