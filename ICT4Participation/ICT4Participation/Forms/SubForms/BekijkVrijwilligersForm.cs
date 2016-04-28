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
        private List<string> _recensies; 

        public BekijkVrijwilligersForm(HelpRequest helpRequest)
        {
            InitializeComponent();
            _helpRequest = helpRequest;
            RefreshListBoxes();
        }

        private void RefreshListBoxes()
        {
            _helpRequest.GetVolunteers();
            lbVrijwilligers.DataSource = _helpRequest.Pending;
            lbVrijwilligers.DisplayMember = "Name";
            lbRecensies.DataSource = _recensies;
        }

        private void btnAccepteer_Click(object sender, EventArgs e)
        {
            if (lbVrijwilligers.SelectedItem != null)
            {
                Volunteer v = (Volunteer) lbVrijwilligers.SelectedItem;
                _helpRequest.Accept(v);
                _recensies.Clear();
                lbRecensies.DataSource = null;
                RefreshListBoxes();
            }
            else
            {
                MessageBox.Show("Selecteer een vrijwilliger.");
            }
        }

        private void btnWijsAf_Click(object sender, EventArgs e)
        {
            if (lbVrijwilligers.SelectedItem != null)
            {
                Volunteer v = (Volunteer)lbVrijwilligers.SelectedItem;
                _helpRequest.Decline(v);
                _recensies.Clear();
                lbRecensies.Items.Clear();
                RefreshListBoxes();
            }
            else
            {
                MessageBox.Show("Selecteer een vrijwilliger.");
            }
        }

        private void lbVrijwilligers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Volunteer v = (Volunteer) lbVrijwilligers.SelectedItem;
            _recensies = new List<string>();
            OracleParameter[] parameters =
            {
                new OracleParameter("id", v.ID), 
            };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllReviewsVolunteer"], parameters);
            foreach (DataRow dr in dt.Rows)
            {
                _recensies.Add(Convert.ToString(dr["MESSAGE"]));
            }
        }
    }
}
