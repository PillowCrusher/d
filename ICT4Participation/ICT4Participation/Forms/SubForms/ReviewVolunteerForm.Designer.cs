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
            this.lsReviews = new System.Windows.Forms.ListBox();
            this.txtReview = new System.Windows.Forms.TextBox();
            this.lblReview = new System.Windows.Forms.Label();
            this.lbComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsReviews
            // 
            this.lsReviews.FormattingEnabled = true;
            this.lsReviews.ItemHeight = 25;
            this.lsReviews.Location = new System.Drawing.Point(13, 12);
            this.lsReviews.Name = "lsReviews";
            this.lsReviews.Size = new System.Drawing.Size(268, 554);
            this.lsReviews.TabIndex = 0;
            // 
            // txtReview
            // 
            this.txtReview.Location = new System.Drawing.Point(287, 41);
            this.txtReview.Multiline = true;
            this.txtReview.Name = "txtReview";
            this.txtReview.Size = new System.Drawing.Size(426, 257);
            this.txtReview.TabIndex = 1;
            // 
            // lblReview
            // 
            this.lblReview.AutoSize = true;
            this.lblReview.Location = new System.Drawing.Point(288, 13);
            this.lblReview.Name = "lblReview";
            this.lblReview.Size = new System.Drawing.Size(82, 25);
            this.lblReview.TabIndex = 2;
            this.lblReview.Text = "Review";
            // 
            // lbComment
            // 
            this.lbComment.AutoSize = true;
            this.lbComment.Location = new System.Drawing.Point(288, 305);
            this.lbComment.Name = "lbComment";
            this.lbComment.Size = new System.Drawing.Size(103, 25);
            this.lbComment.TabIndex = 3;
            this.lbComment.Text = "Comment";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(287, 334);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(426, 158);
            this.txtComment.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 498);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(426, 63);
            this.button1.TabIndex = 5;
            this.button1.Text = "btComment";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ReviewVolunteerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 573);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lbComment);
            this.Controls.Add(this.lblReview);
            this.Controls.Add(this.txtReview);
            this.Controls.Add(this.lsReviews);
            this.Name = "ReviewVolunteerForm";
            this.Text = "ReviewVolunteerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsReviews;
        private System.Windows.Forms.TextBox txtReview;
        private System.Windows.Forms.Label lblReview;
        private System.Windows.Forms.Label lbComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button button1;
    }
}