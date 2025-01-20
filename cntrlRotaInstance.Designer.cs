namespace NEABenjaminFranklin
{
    partial class cntrlRotaInstance
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
            System.Windows.Forms.Button horizontalLine;
            this.lblDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditAssignments = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.flpAssignedRoles = new System.Windows.Forms.FlowLayoutPanel();
            horizontalLine = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // horizontalLine
            // 
            horizontalLine.BackColor = System.Drawing.Color.Black;
            horizontalLine.Enabled = false;
            horizontalLine.Location = new System.Drawing.Point(11, 40);
            horizontalLine.Margin = new System.Windows.Forms.Padding(0);
            horizontalLine.Name = "horizontalLine";
            horizontalLine.Size = new System.Drawing.Size(207, 10);
            horizontalLine.TabIndex = 0;
            horizontalLine.TabStop = false;
            horizontalLine.UseVisualStyleBackColor = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(8, 5);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(53, 16);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "{Date}";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(horizontalLine);
            this.panel1.Controls.Add(this.btnEditAssignments);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.flpAssignedRoles);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 270);
            this.panel1.TabIndex = 3;
            // 
            // btnEditAssignments
            // 
            this.btnEditAssignments.Location = new System.Drawing.Point(113, 5);
            this.btnEditAssignments.Name = "btnEditAssignments";
            this.btnEditAssignments.Size = new System.Drawing.Size(103, 23);
            this.btnEditAssignments.TabIndex = 0;
            this.btnEditAssignments.Text = "Edit Assignments";
            this.btnEditAssignments.UseVisualStyleBackColor = true;
            this.btnEditAssignments.Click += new System.EventHandler(this.btnEditAssignments_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(11, 24);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(38, 13);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "{Time}";
            // 
            // flpAssignedRoles
            // 
            this.flpAssignedRoles.AutoScroll = true;
            this.flpAssignedRoles.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAssignedRoles.Location = new System.Drawing.Point(11, 54);
            this.flpAssignedRoles.Name = "flpAssignedRoles";
            this.flpAssignedRoles.Size = new System.Drawing.Size(205, 211);
            this.flpAssignedRoles.TabIndex = 3;
            this.flpAssignedRoles.WrapContents = false;
            // 
            // cntrlRotaInstance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "cntrlRotaInstance";
            this.Size = new System.Drawing.Size(233, 294);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.FlowLayoutPanel flpAssignedRoles;
        private System.Windows.Forms.Button btnEditAssignments;
    }
}
