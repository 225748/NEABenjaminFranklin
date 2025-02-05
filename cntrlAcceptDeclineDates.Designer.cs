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
            this.lblTime = new System.Windows.Forms.Label();
            this.lblRotaName = new System.Windows.Forms.Label();
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
            this.lblRole.Location = new System.Drawing.Point(3, 30);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(32, 13);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "{role}";
            // 
            // btnAcceptDate
            // 
            this.btnAcceptDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAcceptDate.Location = new System.Drawing.Point(6, 48);
            this.btnAcceptDate.Name = "btnAcceptDate";
            this.btnAcceptDate.Size = new System.Drawing.Size(75, 23);
            this.btnAcceptDate.TabIndex = 2;
            this.btnAcceptDate.Text = "Accept";
            this.btnAcceptDate.UseVisualStyleBackColor = false;
            this.btnAcceptDate.Click += new System.EventHandler(this.btnAcceptDate_Click);
            // 
            // btnDeclineDate
            // 
            this.btnDeclineDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnDeclineDate.Location = new System.Drawing.Point(108, 48);
            this.btnDeclineDate.Name = "btnDeclineDate";
            this.btnDeclineDate.Size = new System.Drawing.Size(75, 23);
            this.btnDeclineDate.TabIndex = 3;
            this.btnDeclineDate.Text = "Decline";
            this.btnDeclineDate.UseVisualStyleBackColor = false;
            this.btnDeclineDate.Click += new System.EventHandler(this.btnDeclineDate_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(105, 11);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(34, 13);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "{time}";
            // 
            // lblRotaName
            // 
            this.lblRotaName.AutoSize = true;
            this.lblRotaName.Location = new System.Drawing.Point(105, 30);
            this.lblRotaName.Name = "lblRotaName";
            this.lblRotaName.Size = new System.Drawing.Size(33, 13);
            this.lblRotaName.TabIndex = 5;
            this.lblRotaName.Text = "{rota}";
            // 
            // cntrlAcceptDeclineDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblRotaName);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnDeclineDate);
            this.Controls.Add(this.btnAcceptDate);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblDate);
            this.Name = "cntrlAcceptDeclineDates";
            this.Size = new System.Drawing.Size(190, 75);
            this.Load += new System.EventHandler(this.cntrlAcceptDeclineDates_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnAcceptDate;
        private System.Windows.Forms.Button btnDeclineDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblRotaName;
    }
}
