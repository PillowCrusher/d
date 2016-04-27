namespace ICT4Participation.Forms.SubForms
{
    partial class ReviewVolunteerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblReview = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lbReviews = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblReview
            // 
            this.lblReview.AutoSize = true;
            this.lblReview.Location = new System.Drawing.Point(11, 8);
            this.lblReview.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReview.Name = "lblReview";
            this.lblReview.Size = new System.Drawing.Size(51, 13);
            this.lblReview.TabIndex = 2;
            this.lblReview.Text = "Reviews:";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(11, 179);
            this.lblComment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(47, 13);
            this.lblComment.TabIndex = 3;
            this.lblComment.Text = "Reactie:";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(11, 194);
            this.txtComment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(357, 64);
            this.txtComment.TabIndex = 4;
            this.txtComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtComment_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(78, 262);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(213, 33);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Plaats reactie";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lbReviews
            // 
            this.lbReviews.FormattingEnabled = true;
            this.lbReviews.Location = new System.Drawing.Point(11, 23);
            this.lbReviews.Margin = new System.Windows.Forms.Padding(2);
            this.lbReviews.Name = "lbReviews";
            this.lbReviews.Size = new System.Drawing.Size(357, 147);
            this.lbReviews.TabIndex = 0;
            // 
            // ReviewVolunteerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 302);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblReview);
            this.Controls.Add(this.lbReviews);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReviewVolunteerForm";
            this.Text = "ReviewVolunteerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblReview;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox lbReviews;
    }
}