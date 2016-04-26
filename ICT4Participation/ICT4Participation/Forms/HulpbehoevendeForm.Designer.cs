namespace ICT4Participation.Forms
{
    partial class HulpbehoevendeForm
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.lbChats = new System.Windows.Forms.ListBox();
            this.lbHelpRequests = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbDriverLicense = new System.Windows.Forms.CheckBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cbUrgent = new System.Windows.Forms.CheckBox();
            this.cbMeeting = new System.Windows.Forms.CheckBox();
            this.cbTransportType = new System.Windows.Forms.ComboBox();
            this.gbHulpVragen = new System.Windows.Forms.GroupBox();
            this.pnlHulpVragen = new System.Windows.Forms.Panel();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbHulpVragen.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSend);
            this.groupBox5.Controls.Add(this.tbMessage);
            this.groupBox5.Controls.Add(this.lbChats);
            this.groupBox5.Controls.Add(this.lbHelpRequests);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(748, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(504, 657);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Chats";
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(405, 597);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(93, 46);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Verstuur";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMessage.Location = new System.Drawing.Point(132, 597);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(267, 46);
            this.tbMessage.TabIndex = 2;
            this.tbMessage.Click += new System.EventHandler(this.tbMessage_Click);
            // 
            // lbChats
            // 
            this.lbChats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChats.FormattingEnabled = true;
            this.lbChats.HorizontalScrollbar = true;
            this.lbChats.ItemHeight = 20;
            this.lbChats.Location = new System.Drawing.Point(132, 19);
            this.lbChats.Name = "lbChats";
            this.lbChats.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbChats.Size = new System.Drawing.Size(366, 544);
            this.lbChats.TabIndex = 1;
            // 
            // lbHelpRequests
            // 
            this.lbHelpRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHelpRequests.FormattingEnabled = true;
            this.lbHelpRequests.ItemHeight = 20;
            this.lbHelpRequests.Location = new System.Drawing.Point(6, 19);
            this.lbHelpRequests.Name = "lbHelpRequests";
            this.lbHelpRequests.Size = new System.Drawing.Size(120, 604);
            this.lbHelpRequests.TabIndex = 0;
            this.lbHelpRequests.SelectedIndexChanged += new System.EventHandler(this.lbHelpRequests_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 210);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nieuwe Hulpvraag";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSendRequest, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbDescription, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(718, 179);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Beschrijving:";
            // 
            // tbTitle
            // 
            this.tbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTitle.Location = new System.Drawing.Point(110, 3);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(605, 26);
            this.tbTitle.TabIndex = 3;
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSendRequest.Location = new System.Drawing.Point(3, 145);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(101, 31);
            this.btnSendRequest.TabIndex = 2;
            this.btnSendRequest.Text = "Verstuur";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // tbDescription
            // 
            this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescription.Location = new System.Drawing.Point(110, 38);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(605, 101);
            this.tbDescription.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.cbDriverLicense, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpEndDate, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbUrgent, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbMeeting, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbTransportType, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(110, 145);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(605, 31);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // cbDriverLicense
            // 
            this.cbDriverLicense.AutoSize = true;
            this.cbDriverLicense.Location = new System.Drawing.Point(3, 3);
            this.cbDriverLicense.Name = "cbDriverLicense";
            this.cbDriverLicense.Size = new System.Drawing.Size(89, 24);
            this.cbDriverLicense.TabIndex = 0;
            this.cbDriverLicense.Text = "Rijbewijs";
            this.cbDriverLicense.UseVisualStyleBackColor = true;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpEndDate.Location = new System.Drawing.Point(442, 3);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(310, 26);
            this.dtpEndDate.TabIndex = 3;
            // 
            // cbUrgent
            // 
            this.cbUrgent.AutoSize = true;
            this.cbUrgent.Location = new System.Drawing.Point(225, 3);
            this.cbUrgent.Name = "cbUrgent";
            this.cbUrgent.Size = new System.Drawing.Size(77, 24);
            this.cbUrgent.TabIndex = 4;
            this.cbUrgent.Text = "Urgent";
            this.cbUrgent.UseVisualStyleBackColor = true;
            // 
            // cbMeeting
            // 
            this.cbMeeting.AutoSize = true;
            this.cbMeeting.Location = new System.Drawing.Point(308, 3);
            this.cbMeeting.Name = "cbMeeting";
            this.cbMeeting.Size = new System.Drawing.Size(128, 24);
            this.cbMeeting.TabIndex = 5;
            this.cbMeeting.Text = "Kennis maken";
            this.cbMeeting.UseVisualStyleBackColor = true;
            // 
            // cbTransportType
            // 
            this.cbTransportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransportType.FormattingEnabled = true;
            this.cbTransportType.Location = new System.Drawing.Point(98, 3);
            this.cbTransportType.Name = "cbTransportType";
            this.cbTransportType.Size = new System.Drawing.Size(121, 28);
            this.cbTransportType.TabIndex = 6;
            // 
            // gbHulpVragen
            // 
            this.gbHulpVragen.Controls.Add(this.pnlHulpVragen);
            this.gbHulpVragen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHulpVragen.Location = new System.Drawing.Point(12, 228);
            this.gbHulpVragen.Name = "gbHulpVragen";
            this.gbHulpVragen.Size = new System.Drawing.Size(730, 441);
            this.gbHulpVragen.TabIndex = 6;
            this.gbHulpVragen.TabStop = false;
            this.gbHulpVragen.Text = "Hulp Vragen:";
            // 
            // pnlHulpVragen
            // 
            this.pnlHulpVragen.AutoScroll = true;
            this.pnlHulpVragen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHulpVragen.Location = new System.Drawing.Point(3, 22);
            this.pnlHulpVragen.Name = "pnlHulpVragen";
            this.pnlHulpVragen.Size = new System.Drawing.Size(724, 416);
            this.pnlHulpVragen.TabIndex = 1;
            // 
            // HulpbehoevendeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 548);
            this.Controls.Add(this.gbHulpVragen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.MaximumSize = new System.Drawing.Size(1275, 705);
            this.MinimumSize = new System.Drawing.Size(967, 558);
            this.Name = "HulpbehoevendeForm";
            this.Text = "HulpbehoevendeForm";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gbHulpVragen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.ListBox lbChats;
        private System.Windows.Forms.ListBox lbHelpRequests;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox cbDriverLicense;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.CheckBox cbUrgent;
        private System.Windows.Forms.CheckBox cbMeeting;
        private System.Windows.Forms.GroupBox gbHulpVragen;
        private System.Windows.Forms.Panel pnlHulpVragen;
        private System.Windows.Forms.ComboBox cbTransportType;
    }
}