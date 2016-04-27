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
    public partial class ReviewVolunteerForm : Form
    {
        private Account _user;
        private List<string> _reviews; 

        public ReviewVolunteerForm(Account user)
        {
            InitializeComponent();
            _user = user;
            RefreshAll();
        }

        private void RefreshAll()
        {
            _reviews = new List<string>();
            OracleParameter[] parameters =
            {
                new OracleParameter("id", _user.ID) 
            };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllReviewsVolunteer"], parameters);

            foreach (DataRow dr in dt.Rows)
            {
                _reviews.Add(dr["Message"].ToString());
            }
            lbReviews.DataSource = _reviews;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = lbReviews.SelectedItem.ToString();
            OracleParameter[] parameters =
            {
                new OracleParameter("comment", txtComment.Text),
                new OracleParameter("review", message)
            };
            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["UpdateCommentReview"], parameters);
        }

        private void txtComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(this, e);
            }
        }
    }
}
