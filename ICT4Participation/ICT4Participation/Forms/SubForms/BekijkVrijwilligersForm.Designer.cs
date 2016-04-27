namespace ICT4Participation.Forms.SubForms
{
    partial class BekijkVrijwilligersForm
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
            this.lbVrijwilligers = new System.Windows.Forms.ListBox();
            this.lbRecensies = new System.Windows.Forms.ListBox();
            this.btnAccepteer = new System.Windows.Forms.Button();
            this.btnWijsAf = new System.Windows.Forms.Button();
            this.lblVrijwilligers = new System.Windows.Forms.Label();
            this.lblRecensies = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbVrijwilligers
            // 
            this.lbVrijwilligers.FormattingEnabled = true;
            this.lbVrijwilligers.Location = new System.Drawing.Point(13, 26);
            this.lbVrijwilligers.Name = "lbVrijwilligers";
            this.lbVrijwilligers.Size = new System.Drawing.Size(126, 225);
            this.lbVrijwilligers.TabIndex = 0;
            this.lbVrijwilligers.SelectedIndexChanged += new System.EventHandler(this.lbVrijwilligers_SelectedIndexChanged);
            // 
            // lbRecensies
            // 
            this.lbRecensies.FormattingEnabled = true;
            this.lbRecensies.Location = new System.Drawing.Point(145, 26);
            this.lbRecensies.Name = "lbRecensies";
            this.lbRecensies.Size = new System.Drawing.Size(357, 186);
            this.lbRecensies.TabIndex = 0;
            // 
            // btnAccepteer
            // 
            this.btnAccepteer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAccepteer.Location = new System.Drawing.Point(145, 219);
            this.btnAccepteer.Name = "btnAccepteer";
            this.btnAccepteer.Size = new System.Drawing.Size(169, 32);
            this.btnAccepteer.TabIndex = 1;
            this.btnAccepteer.Text = "Accepteer vrijwilliger";
            this.btnAccepteer.UseVisualStyleBackColor = true;
            this.btnAccepteer.Click += new System.EventHandler(this.btnAccepteer_Click);
            // 
            // btnWijsAf
            // 
            this.btnWijsAf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnWijsAf.Location = new System.Drawing.Point(320, 219);
            this.btnWijsAf.Name = "btnWijsAf";
            this.btnWijsAf.Size = new System.Drawing.Size(182, 32);
            this.btnWijsAf.TabIndex = 1;
            this.btnWijsAf.Text = "Wijs vrijwilliger af";
            this.btnWijsAf.UseVisualStyleBackColor = true;
            this.btnWijsAf.Click += new System.EventHandler(this.btnWijsAf_Click);
            // 
            // lblVrijwilligers
            // 
            this.lblVrijwilligers.AutoSize = true;
            this.lblVrijwilligers.Location = new System.Drawing.Point(13, 7);
            this.lblVrijwilligers.Name = "lblVrijwilligers";
            this.lblVrijwilligers.Size = new System.Drawing.Size(60, 13);
            this.lblVrijwilligers.TabIndex = 2;
            this.lblVrijwilligers.Text = "Vrijwilligers:";
            // 
            // lblRecensies
            // 
            this.lblRecensies.AutoSize = true;
            this.lblRecensies.Location = new System.Drawing.Point(142, 7);
            this.lblRecensies.Name = "lblRecensies";
            this.lblRecensies.Size = new System.Drawing.Size(60, 13);
            this.lblRecensies.TabIndex = 2;
            this.lblRecensies.Text = "Recensies:";
            // 
            // BekijkVrijwilligersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 261);
            this.Controls.Add(this.lblRecensies);
            this.Controls.Add(this.lblVrijwilligers);
            this.Controls.Add(this.btnWijsAf);
            this.Controls.Add(this.btnAccepteer);
            this.Controls.Add(this.lbRecensies);
            this.Controls.Add(this.lbVrijwilligers);
            this.Name = "BekijkVrijwilligersForm";
            this.Text = "BekijkVrijwilligersForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbVrijwilligers;
        private System.Windows.Forms.ListBox lbRecensies;
        private System.Windows.Forms.Button btnAccepteer;
        private System.Windows.Forms.Button btnWijsAf;
        private System.Windows.Forms.Label lblVrijwilligers;
        private System.Windows.Forms.Label lblRecensies;
    }
}