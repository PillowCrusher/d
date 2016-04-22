﻿namespace ICT4Participation.Forms
{
    partial class Volunteer_Profile
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
            this.rbtTransportYes = new System.Windows.Forms.RadioButton();
            this.grbxPublicTransport = new System.Windows.Forms.GroupBox();
            this.rbtTransportNo = new System.Windows.Forms.RadioButton();
            this.btUpdateProfile = new System.Windows.Forms.Button();
            this.lbFileVOG = new System.Windows.Forms.Label();
            this.lbFilePhoto = new System.Windows.Forms.Label();
            this.btVOG = new System.Windows.Forms.Button();
            this.btPhoto = new System.Windows.Forms.Button();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.tbPhonenumber = new System.Windows.Forms.TextBox();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.rbtDrivingNo = new System.Windows.Forms.RadioButton();
            this.rbtDrivingYes = new System.Windows.Forms.RadioButton();
            this.grbxDrivingLincense = new System.Windows.Forms.GroupBox();
            this.rbtCarNo = new System.Windows.Forms.RadioButton();
            this.rbtCarYes = new System.Windows.Forms.RadioButton();
            this.grpbxCar = new System.Windows.Forms.GroupBox();
            this.lblVOG = new System.Windows.Forms.Label();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.btUnsubscribe = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbPassword1 = new System.Windows.Forms.Label();
            this.lbPassword2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.grbxPublicTransport.SuspendLayout();
            this.grbxDrivingLincense.SuspendLayout();
            this.grpbxCar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtTransportYes
            // 
            this.rbtTransportYes.AutoSize = true;
            this.rbtTransportYes.Location = new System.Drawing.Point(16, 37);
            this.rbtTransportYes.Name = "rbtTransportYes";
            this.rbtTransportYes.Size = new System.Drawing.Size(66, 35);
            this.rbtTransportYes.TabIndex = 0;
            this.rbtTransportYes.TabStop = true;
            this.rbtTransportYes.Text = "ja";
            this.rbtTransportYes.UseVisualStyleBackColor = true;
            // 
            // grbxPublicTransport
            // 
            this.grbxPublicTransport.Controls.Add(this.rbtTransportYes);
            this.grbxPublicTransport.Controls.Add(this.rbtTransportNo);
            this.grbxPublicTransport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbxPublicTransport.Location = new System.Drawing.Point(12, 136);
            this.grbxPublicTransport.Name = "grbxPublicTransport";
            this.grbxPublicTransport.Size = new System.Drawing.Size(526, 72);
            this.grbxPublicTransport.TabIndex = 53;
            this.grbxPublicTransport.TabStop = false;
            this.grbxPublicTransport.Text = "Openbaar vervoer:";
            // 
            // rbtTransportNo
            // 
            this.rbtTransportNo.AutoSize = true;
            this.rbtTransportNo.Location = new System.Drawing.Point(104, 37);
            this.rbtTransportNo.Name = "rbtTransportNo";
            this.rbtTransportNo.Size = new System.Drawing.Size(90, 35);
            this.rbtTransportNo.TabIndex = 1;
            this.rbtTransportNo.TabStop = true;
            this.rbtTransportNo.Text = "nee";
            this.rbtTransportNo.UseVisualStyleBackColor = true;
            // 
            // btUpdateProfile
            // 
            this.btUpdateProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUpdateProfile.Location = new System.Drawing.Point(12, 698);
            this.btUpdateProfile.Name = "btUpdateProfile";
            this.btUpdateProfile.Size = new System.Drawing.Size(526, 90);
            this.btUpdateProfile.TabIndex = 46;
            this.btUpdateProfile.Text = "Update Profiel";
            this.btUpdateProfile.UseVisualStyleBackColor = true;
            this.btUpdateProfile.Click += new System.EventHandler(this.btUpdateProfile_Click);
            // 
            // lbFileVOG
            // 
            this.lbFileVOG.AutoSize = true;
            this.lbFileVOG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbFileVOG.Location = new System.Drawing.Point(353, 65);
            this.lbFileVOG.Name = "lbFileVOG";
            this.lbFileVOG.Size = new System.Drawing.Size(58, 31);
            this.lbFileVOG.TabIndex = 45;
            this.lbFileVOG.Text = "vog";
            // 
            // lbFilePhoto
            // 
            this.lbFilePhoto.AutoSize = true;
            this.lbFilePhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbFilePhoto.Location = new System.Drawing.Point(353, 0);
            this.lbFilePhoto.Name = "lbFilePhoto";
            this.lbFilePhoto.Size = new System.Drawing.Size(60, 31);
            this.lbFilePhoto.TabIndex = 44;
            this.lbFilePhoto.Text = "foto";
            // 
            // btVOG
            // 
            this.btVOG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btVOG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btVOG.Location = new System.Drawing.Point(178, 68);
            this.btVOG.Name = "btVOG";
            this.btVOG.Size = new System.Drawing.Size(169, 59);
            this.btVOG.TabIndex = 43;
            this.btVOG.Text = "Voeg VOG toe";
            this.btVOG.UseVisualStyleBackColor = true;
            this.btVOG.Click += new System.EventHandler(this.btVOG_Click);
            // 
            // btPhoto
            // 
            this.btPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btPhoto.Location = new System.Drawing.Point(178, 3);
            this.btPhoto.Name = "btPhoto";
            this.btPhoto.Size = new System.Drawing.Size(169, 59);
            this.btPhoto.TabIndex = 42;
            this.btPhoto.Text = "Voeg foto toe";
            this.btPhoto.UseVisualStyleBackColor = true;
            this.btPhoto.Click += new System.EventHandler(this.btPhoto_Click);
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpBirthDate.Location = new System.Drawing.Point(172, 367);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(366, 38);
            this.dtpBirthDate.TabIndex = 41;
            // 
            // tbPhonenumber
            // 
            this.tbPhonenumber.Location = new System.Drawing.Point(266, 81);
            this.tbPhonenumber.Name = "tbPhonenumber";
            this.tbPhonenumber.Size = new System.Drawing.Size(257, 31);
            this.tbPhonenumber.TabIndex = 40;
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(266, 42);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(257, 31);
            this.tbCity.TabIndex = 39;
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(266, 3);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(257, 31);
            this.tbAddress.TabIndex = 38;
            // 
            // rbtDrivingNo
            // 
            this.rbtDrivingNo.AutoSize = true;
            this.rbtDrivingNo.Location = new System.Drawing.Point(127, 30);
            this.rbtDrivingNo.Name = "rbtDrivingNo";
            this.rbtDrivingNo.Size = new System.Drawing.Size(90, 35);
            this.rbtDrivingNo.TabIndex = 1;
            this.rbtDrivingNo.TabStop = true;
            this.rbtDrivingNo.Text = "nee";
            this.rbtDrivingNo.UseVisualStyleBackColor = true;
            // 
            // rbtDrivingYes
            // 
            this.rbtDrivingYes.AutoSize = true;
            this.rbtDrivingYes.Location = new System.Drawing.Point(43, 30);
            this.rbtDrivingYes.Name = "rbtDrivingYes";
            this.rbtDrivingYes.Size = new System.Drawing.Size(66, 35);
            this.rbtDrivingYes.TabIndex = 0;
            this.rbtDrivingYes.TabStop = true;
            this.rbtDrivingYes.Text = "ja";
            this.rbtDrivingYes.UseVisualStyleBackColor = true;
            // 
            // grbxDrivingLincense
            // 
            this.grbxDrivingLincense.Controls.Add(this.rbtDrivingNo);
            this.grbxDrivingLincense.Controls.Add(this.rbtDrivingYes);
            this.grbxDrivingLincense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbxDrivingLincense.Location = new System.Drawing.Point(12, 214);
            this.grbxDrivingLincense.Name = "grbxDrivingLincense";
            this.grbxDrivingLincense.Size = new System.Drawing.Size(526, 72);
            this.grbxDrivingLincense.TabIndex = 36;
            this.grbxDrivingLincense.TabStop = false;
            this.grbxDrivingLincense.Text = "Rijbewijs:";
            // 
            // rbtCarNo
            // 
            this.rbtCarNo.AutoSize = true;
            this.rbtCarNo.Location = new System.Drawing.Point(127, 30);
            this.rbtCarNo.Name = "rbtCarNo";
            this.rbtCarNo.Size = new System.Drawing.Size(90, 35);
            this.rbtCarNo.TabIndex = 1;
            this.rbtCarNo.TabStop = true;
            this.rbtCarNo.Text = "nee";
            this.rbtCarNo.UseVisualStyleBackColor = true;
            // 
            // rbtCarYes
            // 
            this.rbtCarYes.AutoSize = true;
            this.rbtCarYes.Location = new System.Drawing.Point(43, 30);
            this.rbtCarYes.Name = "rbtCarYes";
            this.rbtCarYes.Size = new System.Drawing.Size(66, 35);
            this.rbtCarYes.TabIndex = 0;
            this.rbtCarYes.TabStop = true;
            this.rbtCarYes.Text = "ja";
            this.rbtCarYes.UseVisualStyleBackColor = true;
            // 
            // grpbxCar
            // 
            this.grpbxCar.Controls.Add(this.rbtCarNo);
            this.grpbxCar.Controls.Add(this.rbtCarYes);
            this.grpbxCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpbxCar.Location = new System.Drawing.Point(6, 283);
            this.grpbxCar.Name = "grpbxCar";
            this.grpbxCar.Size = new System.Drawing.Size(532, 72);
            this.grpbxCar.TabIndex = 35;
            this.grpbxCar.TabStop = false;
            this.grpbxCar.Text = "Auto:";
            // 
            // lblVOG
            // 
            this.lblVOG.AutoSize = true;
            this.lblVOG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblVOG.Location = new System.Drawing.Point(3, 65);
            this.lblVOG.Name = "lblVOG";
            this.lblVOG.Size = new System.Drawing.Size(82, 31);
            this.lblVOG.TabIndex = 34;
            this.lblVOG.Text = "VOG:";
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPhoto.Location = new System.Drawing.Point(3, 0);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(77, 31);
            this.lblPhoto.TabIndex = 33;
            this.lblPhoto.Text = "Foto:";
            // 
            // lblBirthdate
            // 
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblBirthdate.Location = new System.Drawing.Point(12, 373);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(154, 31);
            this.lblBirthdate.TabIndex = 32;
            this.lblBirthdate.Text = "Verjaardag:";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPhoneNumber.Location = new System.Drawing.Point(3, 78);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(226, 31);
            this.lblPhoneNumber.TabIndex = 31;
            this.lblPhoneNumber.Text = "Telefoonnummer:";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCity.Location = new System.Drawing.Point(3, 39);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(165, 31);
            this.lblCity.TabIndex = 30;
            this.lblCity.Text = "Woonplaats:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblAddress.Location = new System.Drawing.Point(3, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(93, 31);
            this.lblAddress.TabIndex = 29;
            this.lblAddress.Text = "Adres:";
            // 
            // btUnsubscribe
            // 
            this.btUnsubscribe.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUnsubscribe.Location = new System.Drawing.Point(12, 794);
            this.btUnsubscribe.Name = "btUnsubscribe";
            this.btUnsubscribe.Size = new System.Drawing.Size(526, 90);
            this.btUnsubscribe.TabIndex = 54;
            this.btUnsubscribe.Text = "Uitschrijven";
            this.btUnsubscribe.UseVisualStyleBackColor = true;
            this.btUnsubscribe.Click += new System.EventHandler(this.btUnsubscribe_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tbAddress, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbCity, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbPhonenumber, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAddress, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCity, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPhoneNumber, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(526, 118);
            this.tableLayoutPanel1.TabIndex = 55;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btPhoto, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btVOG, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPhoto, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblVOG, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbFilePhoto, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbFileVOG, 2, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 432);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(526, 130);
            this.tableLayoutPanel2.TabIndex = 56;
            // 
            // lbPassword1
            // 
            this.lbPassword1.AutoSize = true;
            this.lbPassword1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword1.Location = new System.Drawing.Point(5, 581);
            this.lbPassword1.Name = "lbPassword1";
            this.lbPassword1.Size = new System.Drawing.Size(537, 37);
            this.lbPassword1.TabIndex = 57;
            this.lbPassword1.Text = "Om je gegevens aan te passen moet";
            // 
            // lbPassword2
            // 
            this.lbPassword2.AutoSize = true;
            this.lbPassword2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword2.Location = new System.Drawing.Point(9, 618);
            this.lbPassword2.Name = "lbPassword2";
            this.lbPassword2.Size = new System.Drawing.Size(371, 37);
            this.lbPassword2.TabIndex = 58;
            this.lbPassword2.Text = "je je wachtwoord invullen";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(12, 662);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(523, 31);
            this.tbPassword.TabIndex = 59;
            // 
            // Volunteer_Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 896);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lbPassword2);
            this.Controls.Add(this.lbPassword1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btUnsubscribe);
            this.Controls.Add(this.grbxPublicTransport);
            this.Controls.Add(this.btUpdateProfile);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.grbxDrivingLincense);
            this.Controls.Add(this.grpbxCar);
            this.Controls.Add(this.lblBirthdate);
            this.Name = "Volunteer_Profile";
            this.Text = "Volunteer_Profile";
            this.grbxPublicTransport.ResumeLayout(false);
            this.grbxPublicTransport.PerformLayout();
            this.grbxDrivingLincense.ResumeLayout(false);
            this.grbxDrivingLincense.PerformLayout();
            this.grpbxCar.ResumeLayout(false);
            this.grpbxCar.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtTransportYes;
        private System.Windows.Forms.GroupBox grbxPublicTransport;
        private System.Windows.Forms.RadioButton rbtTransportNo;
        private System.Windows.Forms.Button btUpdateProfile;
        private System.Windows.Forms.Label lbFileVOG;
        private System.Windows.Forms.Label lbFilePhoto;
        private System.Windows.Forms.Button btVOG;
        private System.Windows.Forms.Button btPhoto;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.TextBox tbPhonenumber;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.RadioButton rbtDrivingNo;
        private System.Windows.Forms.RadioButton rbtDrivingYes;
        private System.Windows.Forms.GroupBox grbxDrivingLincense;
        private System.Windows.Forms.RadioButton rbtCarNo;
        private System.Windows.Forms.RadioButton rbtCarYes;
        private System.Windows.Forms.GroupBox grpbxCar;
        private System.Windows.Forms.Label lblVOG;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.Label lblBirthdate;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Button btUnsubscribe;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbPassword1;
        private System.Windows.Forms.Label lbPassword2;
        private System.Windows.Forms.TextBox tbPassword;
    }
}