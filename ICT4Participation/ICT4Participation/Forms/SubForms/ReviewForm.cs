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
    public partial class ReviewForm : Form
    {
        private HelpRequest _helpRequest;

        public ReviewForm(HelpRequest helpRequest)
        {
            InitializeComponent();
            _helpRequest = helpRequest;
            _helpRequest.GetVolunteers();
            lbVrijwilligers.DataSource = _helpRequest.Accepted;
            lbVrijwilligers.DisplayMember = "name";
        }

        private void btnPlaatsRecensie_Click(object sender, EventArgs e)
        {
            if (lbVrijwilligers.SelectedItem != null)
            {
                Volunteer v = (Volunteer) lbVrijwilligers.SelectedItem;
                OracleParameter[] parameters =
                {
                    new OracleParameter("helprequestid", _helpRequest.ID),
                    new OracleParameter("volunteerid", v.ID),
                    new OracleParameter("message", tbRecensie.Text)
                };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertReview"], parameters);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Selecteer AUB een vrijwilliger");
            }
        }

        private void btnSluitAf_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Weet je het zeker?", "Bevestig", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                OracleParameter[] parameters =
                {
                    new OracleParameter("id", _helpRequest.ID)
                };
                DatabaseManager.ExecuteDeleteQuery(DatabaseQuerys.Query["DeleteHelpRequest"], parameters);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
