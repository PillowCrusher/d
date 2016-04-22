namespace ICT4Participation.Forms
{
    partial class VrijwilligersForm
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
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.tlpProperties = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.cbDriverLicense = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.gbHelpRequest = new System.Windows.Forms.GroupBox();
            this.pnlHulpVragen = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnChangeInfo = new System.Windows.Forms.Button();
            this.btnShowReviews = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPersonalInfo = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.lbChats = new System.Windows.Forms.ListBox();
            this.lbHelpRequests = new System.Windows.Forms.ListBox();
            this.gbFilter.SuspendLayout();
            this.tlpProperties.SuspendLayout();
            this.gbHelpRequest.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.tlpProperties);
            this.gbFilter.Enabled = false;
            this.gbFilter.Location = new System.Drawing.Point(2236, 23);
            this.gbFilter.Margin = new System.Windows.Forms.Padding(6);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Padding = new System.Windows.Forms.Padding(6);
            this.gbFilter.Size = new System.Drawing.Size(268, 390);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // tlpProperties
            // 
            this.tlpProperties.ColumnCount = 1;
            this.tlpProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpProperties.Controls.Add(this.checkBox4, 0, 3);
            this.tlpProperties.Controls.Add(this.checkBox3, 0, 2);
            this.tlpProperties.Controls.Add(this.checkBox2, 0, 1);
            this.tlpProperties.Controls.Add(this.cbDriverLicense, 0, 0);
            this.tlpProperties.Controls.Add(this.dateTimePicker1, 0, 5);
            this.tlpProperties.Controls.Add(this.checkBox5, 0, 4);
            this.tlpProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpProperties.Location = new System.Drawing.Point(6, 30);
            this.tlpProperties.Margin = new System.Windows.Forms.Padding(6);
            this.tlpProperties.Name = "tlpProperties";
            this.tlpProperties.RowCount = 6;
            this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpProperties.Size = new System.Drawing.Size(256, 354);
            this.tlpProperties.TabIndex = 0;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(6, 129);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(108, 29);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Urgent";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 88);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(220, 29);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Openbaar Vervoer";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 47);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(88, 29);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Auto";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // cbDriverLicense
            // 
            this.cbDriverLicense.AutoSize = true;
            this.cbDriverLicense.Location = new System.Drawing.Point(6, 6);
            this.cbDriverLicense.Margin = new System.Windows.Forms.Padding(6);
            this.cbDriverLicense.Name = "cbDriverLicense";
            this.cbDriverLicense.Size = new System.Drawing.Size(129, 29);
            this.cbDriverLicense.TabIndex = 0;
            this.cbDriverLicense.Text = "Rijbewijs";
            this.cbDriverLicense.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 211);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(244, 31);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(6, 170);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(180, 29);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Text = "Kennis maken";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // gbHelpRequest
            // 
            this.gbHelpRequest.Controls.Add(this.pnlHulpVragen);
            this.gbHelpRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHelpRequest.Location = new System.Drawing.Point(24, 23);
            this.gbHelpRequest.Margin = new System.Windows.Forms.Padding(6);
            this.gbHelpRequest.Name = "gbHelpRequest";
            this.gbHelpRequest.Padding = new System.Windows.Forms.Padding(6);
            this.gbHelpRequest.Size = new System.Drawing.Size(1460, 1263);
            this.gbHelpRequest.TabIndex = 1;
            this.gbHelpRequest.TabStop = false;
            this.gbHelpRequest.Text = "Hulp Vragen:";
            // 
            // pnlHulpVragen
            // 
            this.pnlHulpVragen.AutoScroll = true;
            this.pnlHulpVragen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHulpVragen.Location = new System.Drawing.Point(6, 31);
            this.pnlHulpVragen.Margin = new System.Windows.Forms.Padding(6);
            this.pnlHulpVragen.Name = "pnlHulpVragen";
            this.pnlHulpVragen.Size = new System.Drawing.Size(1448, 1226);
            this.pnlHulpVragen.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel1);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Controls.Add(this.lblPersonalInfo);
            this.groupBox4.Location = new System.Drawing.Point(1496, 23);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox4.Size = new System.Drawing.Size(728, 390);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Profiel gegevens";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnRefresh, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnChangeInfo, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnShowReviews, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 287);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 92);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.Location = new System.Drawing.Point(6, 6);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(221, 80);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh Hulp Vragen";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnChangeInfo
            // 
            this.btnChangeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChangeInfo.Location = new System.Drawing.Point(472, 6);
            this.btnChangeInfo.Margin = new System.Windows.Forms.Padding(6);
            this.btnChangeInfo.Name = "btnChangeInfo";
            this.btnChangeInfo.Size = new System.Drawing.Size(222, 80);
            this.btnChangeInfo.TabIndex = 2;
            this.btnChangeInfo.Text = "Informatie aanpassen";
            this.btnChangeInfo.UseVisualStyleBackColor = true;
            this.btnChangeInfo.Click += new System.EventHandler(this.btnChangeInfo_Click);
            // 
            // btnShowReviews
            // 
            this.btnShowReviews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowReviews.Location = new System.Drawing.Point(239, 6);
            this.btnShowReviews.Margin = new System.Windows.Forms.Padding(6);
            this.btnShowReviews.Name = "btnShowReviews";
            this.btnShowReviews.Size = new System.Drawing.Size(221, 80);
            this.btnShowReviews.TabIndex = 3;
            this.btnShowReviews.Text = "Bekijk Reviews";
            this.btnShowReviews.UseVisualStyleBackColor = true;
            this.btnShowReviews.Click += new System.EventHandler(this.btnShowReviews_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ICT4Participation.Properties.Resources.user_male_silhouette_318_55563;
            this.pictureBox1.Location = new System.Drawing.Point(12, 37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblPersonalInfo
            // 
            this.lblPersonalInfo.AutoSize = true;
            this.lblPersonalInfo.Location = new System.Drawing.Point(222, 31);
            this.lblPersonalInfo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPersonalInfo.Name = "lblPersonalInfo";
            this.lblPersonalInfo.Size = new System.Drawing.Size(315, 25);
            this.lblPersonalInfo.TabIndex = 0;
            this.lblPersonalInfo.Text = "Error while getting personal info";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSend);
            this.groupBox5.Controls.Add(this.tbMessage);
            this.groupBox5.Controls.Add(this.lbChats);
            this.groupBox5.Controls.Add(this.lbHelpRequests);
            this.groupBox5.Location = new System.Drawing.Point(1496, 425);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox5.Size = new System.Drawing.Size(1008, 856);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Chats";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(810, 756);
            this.btnSend.Margin = new System.Windows.Forms.Padding(6);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(186, 88);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Verstuur";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(264, 756);
            this.tbMessage.Margin = new System.Windows.Forms.Padding(6);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(530, 85);
            this.tbMessage.TabIndex = 2;
            this.tbMessage.Text = "tekst om te verzenden";
            // 
            // lbChats
            // 
            this.lbChats.FormattingEnabled = true;
            this.lbChats.ItemHeight = 25;
            this.lbChats.Location = new System.Drawing.Point(264, 37);
            this.lbChats.Margin = new System.Windows.Forms.Padding(6);
            this.lbChats.Name = "lbChats";
            this.lbChats.Size = new System.Drawing.Size(728, 704);
            this.lbChats.TabIndex = 1;
            // 
            // lbHelpRequests
            // 
            this.lbHelpRequests.FormattingEnabled = true;
            this.lbHelpRequests.ItemHeight = 25;
            this.lbHelpRequests.Location = new System.Drawing.Point(12, 37);
            this.lbHelpRequests.Margin = new System.Windows.Forms.Padding(6);
            this.lbHelpRequests.Name = "lbHelpRequests";
            this.lbHelpRequests.Size = new System.Drawing.Size(236, 804);
            this.lbHelpRequests.TabIndex = 0;
            // 
            // VrijwilligersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2498, 1219);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gbHelpRequest);
            this.Controls.Add(this.gbFilter);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximumSize = new System.Drawing.Size(2524, 1290);
            this.MinimumSize = new System.Drawing.Size(2524, 1290);
            this.Name = "VrijwilligersForm";
            this.Text = "VrijwilligersForm";
            this.gbFilter.ResumeLayout(false);
            this.tlpProperties.ResumeLayout(false);
            this.tlpProperties.PerformLayout();
            this.gbHelpRequest.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.TableLayoutPanel tlpProperties;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox cbDriverLicense;
        private System.Windows.Forms.GroupBox gbHelpRequest;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPersonalInfo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.ListBox lbChats;
        private System.Windows.Forms.ListBox lbHelpRequests;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Panel pnlHulpVragen;
        private System.Windows.Forms.Button btnChangeInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnShowReviews;
    }
}