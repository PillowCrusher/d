namespace ICT4Participation.Forms
{
    partial class LogInForm
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
            this.lblICT4P = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btLogIn = new System.Windows.Forms.Button();
            this.llblRegister = new System.Windows.Forms.LinkLabel();
            this.tlpRegister = new System.Windows.Forms.TableLayoutPanel();
            this.tlpRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblICT4P
            // 
            this.lblICT4P.AutoSize = true;
            this.lblICT4P.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lblICT4P.Location = new System.Drawing.Point(12, 9);
            this.lblICT4P.Name = "lblICT4P";
            this.lblICT4P.Size = new System.Drawing.Size(280, 39);
            this.lblICT4P.TabIndex = 0;
            this.lblICT4P.Text = "ICT4Participation";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUsername.Location = new System.Drawing.Point(19, 62);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(117, 17);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Gebruikersnaam:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPassword.Location = new System.Drawing.Point(19, 91);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(90, 17);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Wachtwoord:";
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbUsername.Location = new System.Drawing.Point(142, 59);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(138, 23);
            this.tbUsername.TabIndex = 3;
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbPassword.Location = new System.Drawing.Point(142, 88);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(138, 23);
            this.tbPassword.TabIndex = 3;
            // 
            // btLogIn
            // 
            this.btLogIn.Location = new System.Drawing.Point(65, 128);
            this.btLogIn.Name = "btLogIn";
            this.btLogIn.Size = new System.Drawing.Size(167, 43);
            this.btLogIn.TabIndex = 4;
            this.btLogIn.Text = "Log In";
            this.btLogIn.UseVisualStyleBackColor = true;
            // 
            // llblRegister
            // 
            this.llblRegister.AutoSize = true;
            this.llblRegister.Location = new System.Drawing.Point(3, 0);
            this.llblRegister.Name = "llblRegister";
            this.llblRegister.Size = new System.Drawing.Size(141, 26);
            this.llblRegister.TabIndex = 5;
            this.llblRegister.TabStop = true;
            this.llblRegister.Text = "Heeft u nog geen account? Registreer u hier.";
            // 
            // tlpRegister
            // 
            this.tlpRegister.ColumnCount = 1;
            this.tlpRegister.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRegister.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpRegister.Controls.Add(this.llblRegister, 0, 0);
            this.tlpRegister.Location = new System.Drawing.Point(65, 178);
            this.tlpRegister.Name = "tlpRegister";
            this.tlpRegister.RowCount = 1;
            this.tlpRegister.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRegister.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpRegister.Size = new System.Drawing.Size(167, 39);
            this.tlpRegister.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 229);
            this.Controls.Add(this.tlpRegister);
            this.Controls.Add(this.btLogIn);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblICT4P);
            this.Name = "Form1";
            this.Text = "Log In";
            this.tlpRegister.ResumeLayout(false);
            this.tlpRegister.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblICT4P;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btLogIn;
        private System.Windows.Forms.LinkLabel llblRegister;
        private System.Windows.Forms.TableLayoutPanel tlpRegister;
    }
}

