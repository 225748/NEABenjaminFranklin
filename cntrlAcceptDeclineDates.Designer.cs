namespace NEABenjaminFranklin
{
    partial class cntrlAcceptDeclineDates
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDate = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnAcceptDate = new System.Windows.Forms.Button();
            this.btnDeclineDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(3, 11);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "{date}";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(85, 11);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(32, 13);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "{role}";
            // 
            // btnAcceptDate
            // 
            this.btnAcceptDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(190)))));
            this.btnAcceptDate.Location = new System.Drawing.Point(3, 37);
            this.btnAcceptDate.Name = "btnAcceptDate";
            this.btnAcceptDate.Size = new System.Drawing.Size(75, 23);
            this.btnAcceptDate.TabIndex = 2;
            this.btnAcceptDate.Text = "Accept";
            this.btnAcceptDate.UseVisualStyleBackColor = false;
            this.btnAcceptDate.Click += new System.EventHandler(this.btnAcceptDate_Click);
            // 
            // btnDeclineDate
            // 
            this.btnDeclineDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeclineDate.Location = new System.Drawing.Point(88, 37);
            this.btnDeclineDate.Name = "btnDeclineDate";
            this.btnDeclineDate.Size = new System.Drawing.Size(75, 23);
            this.btnDeclineDate.TabIndex = 3;
            this.btnDeclineDate.Text = "Decline";
            this.btnDeclineDate.UseVisualStyleBackColor = false;
            this.btnDeclineDate.Click += new System.EventHandler(this.btnDeclineDate_Click);
            // 
            // cntrlAcceptDeclineDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnDeclineDate);
            this.Controls.Add(this.btnAcceptDate);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblDate);
            this.Name = "cntrlAcceptDeclineDates";
            this.Size = new System.Drawing.Size(164, 61);
            this.Load += new System.EventHandler(this.cntrlAcceptDeclineDates_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnAcceptDate;
        private System.Windows.Forms.Button btnDeclineDate;
    }
}
