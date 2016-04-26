namespace ICT4Participation.Forms.SubForms
{
    partial class ReviewForm
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
            this.tbRecensie = new System.Windows.Forms.TextBox();
            this.btnSluitAf = new System.Windows.Forms.Button();
            this.btnPlaatsRecensie = new System.Windows.Forms.Button();
            this.lblRecensietb = new System.Windows.Forms.Label();
            this.lblVrijwilligerlst = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbVrijwilligers
            // 
            this.lbVrijwilligers.FormattingEnabled = true;
            this.lbVrijwilligers.Location = new System.Drawing.Point(13, 26);
            this.lbVrijwilligers.Name = "lbVrijwilligers";
            this.lbVrijwilligers.Size = new System.Drawing.Size(259, 95);
            this.lbVrijwilligers.TabIndex = 0;
            // 
            // tbRecensie
            // 
            this.tbRecensie.Location = new System.Drawing.Point(13, 140);
            this.tbRecensie.Multiline = true;
            this.tbRecensie.Name = "tbRecensie";
            this.tbRecensie.Size = new System.Drawing.Size(259, 46);
            this.tbRecensie.TabIndex = 1;
            // 
            // btnSluitAf
            // 
            this.btnSluitAf.Location = new System.Drawing.Point(149, 192);
            this.btnSluitAf.Name = "btnSluitAf";
            this.btnSluitAf.Size = new System.Drawing.Size(123, 28);
            this.btnSluitAf.TabIndex = 2;
            this.btnSluitAf.Text = "Sluit hulpvraag af";
            this.btnSluitAf.UseVisualStyleBackColor = true;
            this.btnSluitAf.Click += new System.EventHandler(this.btnSluitAf_Click);
            // 
            // btnPlaatsRecensie
            // 
            this.btnPlaatsRecensie.Location = new System.Drawing.Point(12, 192);
            this.btnPlaatsRecensie.Name = "btnPlaatsRecensie";
            this.btnPlaatsRecensie.Size = new System.Drawing.Size(123, 28);
            this.btnPlaatsRecensie.TabIndex = 2;
            this.btnPlaatsRecensie.Text = "Plaats recensie";
            this.btnPlaatsRecensie.UseVisualStyleBackColor = true;
            this.btnPlaatsRecensie.Click += new System.EventHandler(this.btnPlaatsRecensie_Click);
            // 
            // lblRecensietb
            // 
            this.lblRecensietb.AutoSize = true;
            this.lblRecensietb.Location = new System.Drawing.Point(12, 124);
            this.lblRecensietb.Name = "lblRecensietb";
            this.lblRecensietb.Size = new System.Drawing.Size(141, 13);
            this.lblRecensietb.TabIndex = 3;
            this.lblRecensietb.Text = "Type hieronder uw recensie:";
            // 
            // lblVrijwilligerlst
            // 
            this.lblVrijwilligerlst.AutoSize = true;
            this.lblVrijwilligerlst.Location = new System.Drawing.Point(12, 9);
            this.lblVrijwilligerlst.Name = "lblVrijwilligerlst";
            this.lblVrijwilligerlst.Size = new System.Drawing.Size(135, 13);
            this.lblVrijwilligerlst.TabIndex = 3;
            this.lblVrijwilligerlst.Text = "Slecteer hier een vrijwiliger:";
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 231);
            this.Controls.Add(this.lblVrijwilligerlst);
            this.Controls.Add(this.lblRecensietb);
            this.Controls.Add(this.btnPlaatsRecensie);
            this.Controls.Add(this.btnSluitAf);
            this.Controls.Add(this.tbRecensie);
            this.Controls.Add(this.lbVrijwilligers);
            this.Name = "ReviewForm";
            this.Text = "ReviewForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbVrijwilligers;
        private System.Windows.Forms.TextBox tbRecensie;
        private System.Windows.Forms.Button btnSluitAf;
        private System.Windows.Forms.Button btnPlaatsRecensie;
        private System.Windows.Forms.Label lblRecensietb;
        private System.Windows.Forms.Label lblVrijwilligerlst;
    }
}