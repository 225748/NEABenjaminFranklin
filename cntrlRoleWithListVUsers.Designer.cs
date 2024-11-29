namespace NEABenjaminFranklin
{
    partial class cntrlRoleWithListVUsers
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
            this.lblRoleName = new System.Windows.Forms.Label();
            this.lstVUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoSize = true;
            this.lblRoleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleName.Location = new System.Drawing.Point(3, 9);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(43, 13);
            this.lblRoleName.TabIndex = 0;
            this.lblRoleName.Text = "{Role}";
            // 
            // lstVUsers
            // 
            this.lstVUsers.CheckBoxes = true;
            this.lstVUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstVUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstVUsers.HideSelection = false;
            this.lstVUsers.Location = new System.Drawing.Point(6, 28);
            this.lstVUsers.Name = "lstVUsers";
            this.lstVUsers.Size = new System.Drawing.Size(250, 89);
            this.lstVUsers.TabIndex = 1;
            this.lstVUsers.UseCompatibleStateImageBehavior = false;
            this.lstVUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "User";
            this.columnHeader1.Width = 169;
            // 
            // cntrlRoleWithListVUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lstVUsers);
            this.Controls.Add(this.lblRoleName);
            this.Name = "cntrlRoleWithListVUsers";
            this.Size = new System.Drawing.Size(259, 120);
            this.Load += new System.EventHandler(this.cntrlRoleWithListVUsers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.ListView lstVUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
