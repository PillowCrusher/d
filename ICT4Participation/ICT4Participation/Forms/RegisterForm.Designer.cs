namespace ICT4Participation.Forms
{
    partial class RegisterForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.lblVOG = new System.Windows.Forms.Label();
            this.grpbxCar = new System.Windows.Forms.GroupBox();
            this.rbtCarNo = new System.Windows.Forms.RadioButton();
            this.rbtCarYes = new System.Windows.Forms.RadioButton();
            this.grbxDrivingLincense = new System.Windows.Forms.GroupBox();
            this.rbtDrivingNo = new System.Windows.Forms.RadioButton();
            this.rbtDrivingYes = new System.Windows.Forms.RadioButton();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.tbPhonenumber = new System.Windows.Forms.TextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.btPhoto = new System.Windows.Forms.Button();
            this.btVOG = new System.Windows.Forms.Button();
            this.lbFilePhoto = new System.Windows.Forms.Label();
            this.lbFileVOG = new System.Windows.Forms.Label();
            this.btRegister = new System.Windows.Forms.Button();
            this.lbGebruikersnaam = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbWachtwoord = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.grbxPublicTransport = new System.Windows.Forms.GroupBox();
            this.rbtTransportNo = new System.Windows.Forms.RadioButton();
            this.rbtTransportYes = new System.Windows.Forms.RadioButton();
            this.grpbxCar.SuspendLayout();
            this.grbxDrivingLincense.SuspendLayout();
            this.grbxPublicTransport.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblName.Location = new System.Drawing.Point(21, 129);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(94, 31);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Naam:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblAddress.Location = new System.Drawing.Point(21, 166);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(93, 31);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Adres:";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCity.Location = new System.Drawing.Point(21, 207);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(165, 31);
            this.lblCity.TabIndex = 2;
            this.lblCity.Text = "Woonplaats:";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPhoneNumber.Location = new System.Drawing.Point(21, 244);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(226, 31);
            this.lblPhoneNumber.TabIndex = 3;
            this.lblPhoneNumber.Text = "Telefoonnummer:";
            // 
            // lblBirthdate
            // 
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblBirthdate.Location = new System.Drawing.Point(21, 530);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(154, 31);
            this.lblBirthdate.TabIndex = 6;
            this.lblBirthdate.Text = "Verjaardag:";
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPhoto.Location = new System.Drawing.Point(21, 580);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(77, 31);
            this.lblPhoto.TabIndex = 7;
            this.lblPhoto.Text = "Foto:";
            // 
            // lblVOG
            // 
            this.lblVOG.AutoSize = true;
            this.lblVOG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblVOG.Location = new System.Drawing.Point(21, 627);
            this.lblVOG.Name = "lblVOG";
            this.lblVOG.Size = new System.Drawing.Size(82, 31);
            this.lblVOG.TabIndex = 8;
            this.lblVOG.Text = "VOG:";
            // 
            // grpbxCar
            // 
            this.grpbxCar.Controls.Add(this.rbtCarNo);
            this.grpbxCar.Controls.Add(this.rbtCarYes);
            this.grpbxCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpbxCar.Location = new System.Drawing.Point(15, 440);
            this.grpbxCar.Name = "grpbxCar";
            this.grpbxCar.Size = new System.Drawing.Size(272, 72);
            this.grpbxCar.TabIndex = 9;
            this.grpbxCar.TabStop = false;
            this.grpbxCar.Text = "Auto:";
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
            // grbxDrivingLincense
            // 
            this.grbxDrivingLincense.Controls.Add(this.rbtDrivingNo);
            this.grbxDrivingLincense.Controls.Add(this.rbtDrivingYes);
            this.grbxDrivingLincense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbxDrivingLincense.Location = new System.Drawing.Point(15, 362);
            this.grbxDrivingLincense.Name = "grbxDrivingLincense";
            this.grbxDrivingLincense.Size = new System.Drawing.Size(272, 72);
            this.grbxDrivingLincense.TabIndex = 10;
            this.grbxDrivingLincense.TabStop = false;
            this.grbxDrivingLincense.Text = "Rijbewijs:";
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
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(249, 130);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(300, 31);
            this.tbName.TabIndex = 11;
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(249, 169);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(300, 31);
            this.tbAddress.TabIndex = 12;
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(249, 210);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(300, 31);
            this.tbCity.TabIndex = 13;
            // 
            // tbPhonenumber
            // 
            this.tbPhonenumber.Location = new System.Drawing.Point(249, 247);
            this.tbPhonenumber.Name = "tbPhonenumber";
            this.tbPhonenumber.Size = new System.Drawing.Size(300, 31);
            this.tbPhonenumber.TabIndex = 14;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpBirthDate.Location = new System.Drawing.Point(181, 524);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(366, 38);
            this.dtpBirthDate.TabIndex = 15;
            // 
            // btPhoto
            // 
            this.btPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btPhoto.Location = new System.Drawing.Point(145, 573);
            this.btPhoto.Name = "btPhoto";
            this.btPhoto.Size = new System.Drawing.Size(210, 38);
            this.btPhoto.TabIndex = 16;
            this.btPhoto.Text = "Voeg foto toe";
            this.btPhoto.UseVisualStyleBackColor = true;
            this.btPhoto.Click += new System.EventHandler(this.btPhoto_Click);
            // 
            // btVOG
            // 
            this.btVOG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btVOG.Location = new System.Drawing.Point(145, 627);
            this.btVOG.Name = "btVOG";
            this.btVOG.Size = new System.Drawing.Size(210, 39);
            this.btVOG.TabIndex = 17;
            this.btVOG.Text = "Voeg VOG toe";
            this.btVOG.UseVisualStyleBackColor = true;
            this.btVOG.Click += new System.EventHandler(this.btVOG_Click);
            // 
            // lbFilePhoto
            // 
            this.lbFilePhoto.AutoSize = true;
            this.lbFilePhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbFilePhoto.Location = new System.Drawing.Point(361, 577);
            this.lbFilePhoto.Name = "lbFilePhoto";
            this.lbFilePhoto.Size = new System.Drawing.Size(0, 31);
            this.lbFilePhoto.TabIndex = 18;
            // 
            // lbFileVOG
            // 
            this.lbFileVOG.AutoSize = true;
            this.lbFileVOG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbFileVOG.Location = new System.Drawing.Point(361, 627);
            this.lbFileVOG.Name = "lbFileVOG";
            this.lbFileVOG.Size = new System.Drawing.Size(0, 31);
            this.lbFileVOG.TabIndex = 19;
            // 
            // btRegister
            // 
            this.btRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRegister.Location = new System.Drawing.Point(27, 676);
            this.btRegister.Name = "btRegister";
            this.btRegister.Size = new System.Drawing.Size(520, 90);
            this.btRegister.TabIndex = 20;
            this.btRegister.Text = "Registeer Vrijwilliger";
            this.btRegister.UseVisualStyleBackColor = true;
            this.btRegister.Click += new System.EventHandler(this.btRegister_Click);
            // 
            // lbGebruikersnaam
            // 
            this.lbGebruikersnaam.AutoSize = true;
            this.lbGebruikersnaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbGebruikersnaam.Location = new System.Drawing.Point(21, 14);
            this.lbGebruikersnaam.Name = "lbGebruikersnaam";
            this.lbGebruikersnaam.Size = new System.Drawing.Size(222, 31);
            this.lbGebruikersnaam.TabIndex = 21;
            this.lbGebruikersnaam.Text = "Gebruikersnaam:";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbEmail.Location = new System.Drawing.Point(21, 52);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(89, 31);
            this.lbEmail.TabIndex = 22;
            this.lbEmail.Text = "Email:";
            // 
            // lbWachtwoord
            // 
            this.lbWachtwoord.AutoSize = true;
            this.lbWachtwoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbWachtwoord.Location = new System.Drawing.Point(21, 89);
            this.lbWachtwoord.Name = "lbWachtwoord";
            this.lbWachtwoord.Size = new System.Drawing.Size(173, 31);
            this.lbWachtwoord.TabIndex = 23;
            this.lbWachtwoord.Text = "Wachtwoord:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(249, 89);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(300, 31);
            this.tbPassword.TabIndex = 24;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(249, 53);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(300, 31);
            this.tbEmail.TabIndex = 25;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(249, 17);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(300, 31);
            this.tbUsername.TabIndex = 26;
            // 
            // grbxPublicTransport
            // 
            this.grbxPublicTransport.Controls.Add(this.rbtTransportNo);
            this.grbxPublicTransport.Controls.Add(this.rbtTransportYes);
            this.grbxPublicTransport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbxPublicTransport.Location = new System.Drawing.Point(15, 284);
            this.grbxPublicTransport.Name = "grbxPublicTransport";
            this.grbxPublicTransport.Size = new System.Drawing.Size(372, 72);
            this.grbxPublicTransport.TabIndex = 27;
            this.grbxPublicTransport.TabStop = false;
            this.grbxPublicTransport.Text = "Openbaar vervoer:";
            // 
            // rbtTransportNo
            // 
            this.rbtTransportNo.AutoSize = true;
            this.rbtTransportNo.Location = new System.Drawing.Point(127, 30);
            this.rbtTransportNo.Name = "rbtTransportNo";
            this.rbtTransportNo.Size = new System.Drawing.Size(90, 35);
            this.rbtTransportNo.TabIndex = 1;
            this.rbtTransportNo.TabStop = true;
            this.rbtTransportNo.Text = "nee";
            this.rbtTransportNo.UseVisualStyleBackColor = true;
            // 
            // rbtTransportYes
            // 
            this.rbtTransportYes.AutoSize = true;
            this.rbtTransportYes.Location = new System.Drawing.Point(43, 30);
            this.rbtTransportYes.Name = "rbtTransportYes";
            this.rbtTransportYes.Size = new System.Drawing.Size(66, 35);
            this.rbtTransportYes.TabIndex = 0;
            this.rbtTransportYes.TabStop = true;
            this.rbtTransportYes.Text = "ja";
            this.rbtTransportYes.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 778);
            this.Controls.Add(this.grbxPublicTransport);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lbWachtwoord);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbGebruikersnaam);
            this.Controls.Add(this.btRegister);
            this.Controls.Add(this.lbFileVOG);
            this.Controls.Add(this.lbFilePhoto);
            this.Controls.Add(this.btVOG);
            this.Controls.Add(this.btPhoto);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.tbPhonenumber);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.grbxDrivingLincense);
            this.Controls.Add(this.grpbxCar);
            this.Controls.Add(this.lblVOG);
            this.Controls.Add(this.lblPhoto);
            this.Controls.Add(this.lblBirthdate);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblName);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterForm_FormClosing);
            this.grpbxCar.ResumeLayout(false);
            this.grpbxCar.PerformLayout();
            this.grbxDrivingLincense.ResumeLayout(false);
            this.grbxDrivingLincense.PerformLayout();
            this.grbxPublicTransport.ResumeLayout(false);
            this.grbxPublicTransport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblBirthdate;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.Label lblVOG;
        private System.Windows.Forms.GroupBox grpbxCar;
        private System.Windows.Forms.RadioButton rbtCarNo;
        private System.Windows.Forms.RadioButton rbtCarYes;
        private System.Windows.Forms.GroupBox grbxDrivingLincense;
        private System.Windows.Forms.RadioButton rbtDrivingNo;
        private System.Windows.Forms.RadioButton rbtDrivingYes;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbPhonenumber;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Button btPhoto;
        private System.Windows.Forms.Button btVOG;
        private System.Windows.Forms.Label lbFilePhoto;
        private System.Windows.Forms.Label lbFileVOG;
        private System.Windows.Forms.Button btRegister;
        private System.Windows.Forms.Label lbGebruikersnaam;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbWachtwoord;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.GroupBox grbxPublicTransport;
        private System.Windows.Forms.RadioButton rbtTransportNo;
        private System.Windows.Forms.RadioButton rbtTransportYes;
    }
}