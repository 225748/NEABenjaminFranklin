namespace NEABenjaminFranklin
{
    partial class frmManageUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageUsers));
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.picRotaConnect = new System.Windows.Forms.PictureBox();
            this.lblHostView = new System.Windows.Forms.Label();
            this.lstVUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.pnlUserInfoInputFields = new System.Windows.Forms.Panel();
            this.chkHostRole = new System.Windows.Forms.CheckBox();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblHostRole = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRotaConnect)).BeginInit();
            this.pnlUserInfoInputFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopBar.Controls.Add(this.picRotaConnect);
            this.pnlTopBar.Controls.Add(this.lblHostView);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(800, 31);
            this.pnlTopBar.TabIndex = 14;
            // 
            // picRotaConnect
            // 
            this.picRotaConnect.Image = ((System.Drawing.Image)(resources.GetObject("picRotaConnect.Image")));
            this.picRotaConnect.Location = new System.Drawing.Point(0, 0);
            this.picRotaConnect.Name = "picRotaConnect";
            this.picRotaConnect.Size = new System.Drawing.Size(121, 31);
            this.picRotaConnect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRotaConnect.TabIndex = 7;
            this.picRotaConnect.TabStop = false;
            // 
            // lblHostView
            // 
            this.lblHostView.AutoSize = true;
            this.lblHostView.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostView.Location = new System.Drawing.Point(134, 3);
            this.lblHostView.Name = "lblHostView";
            this.lblHostView.Size = new System.Drawing.Size(93, 21);
            this.lblHostView.TabIndex = 8;
            this.lblHostView.Text = "Host Mode";
            // 
            // lstVUsers
            // 
            this.lstVUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstVUsers.HideSelection = false;
            this.lstVUsers.Location = new System.Drawing.Point(12, 54);
            this.lstVUsers.Name = "lstVUsers";
            this.lstVUsers.Size = new System.Drawing.Size(563, 289);
            this.lstVUsers.TabIndex = 15;
            this.lstVUsers.UseCompatibleStateImageBehavior = false;
            this.lstVUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "First Name";
            this.columnHeader1.Width = 111;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Last Name";
            this.columnHeader2.Width = 115;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date Of Birth";
            this.columnHeader3.Width = 82;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Host";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 48;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Email";
            this.columnHeader5.Width = 188;
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Location = new System.Drawing.Point(603, 265);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(168, 53);
            this.btnUpdateUser.TabIndex = 16;
            this.btnUpdateUser.Text = "Update Selected User";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // cmbUsers
            // 
            this.cmbUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(603, 65);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(168, 21);
            this.cmbUsers.TabIndex = 17;
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);
            // 
            // pnlUserInfoInputFields
            // 
            this.pnlUserInfoInputFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUserInfoInputFields.Controls.Add(this.chkHostRole);
            this.pnlUserInfoInputFields.Controls.Add(this.dtpDOB);
            this.pnlUserInfoInputFields.Controls.Add(this.txtEmail);
            this.pnlUserInfoInputFields.Controls.Add(this.txtLastName);
            this.pnlUserInfoInputFields.Controls.Add(this.txtFirstName);
            this.pnlUserInfoInputFields.Controls.Add(this.lblHostRole);
            this.pnlUserInfoInputFields.Controls.Add(this.lblEmail);
            this.pnlUserInfoInputFields.Controls.Add(this.lblDOB);
            this.pnlUserInfoInputFields.Controls.Add(this.lblLastName);
            this.pnlUserInfoInputFields.Controls.Add(this.lblFirstName);
            this.pnlUserInfoInputFields.Location = new System.Drawing.Point(581, 102);
            this.pnlUserInfoInputFields.Name = "pnlUserInfoInputFields";
            this.pnlUserInfoInputFields.Size = new System.Drawing.Size(207, 157);
            this.pnlUserInfoInputFields.TabIndex = 18;
            // 
            // chkHostRole
            // 
            this.chkHostRole.AutoSize = true;
            this.chkHostRole.Location = new System.Drawing.Point(75, 120);
            this.chkHostRole.Name = "chkHostRole";
            this.chkHostRole.Size = new System.Drawing.Size(15, 14);
            this.chkHostRole.TabIndex = 9;
            this.chkHostRole.UseVisualStyleBackColor = true;
            // 
            // dtpDOB
            // 
            this.dtpDOB.Location = new System.Drawing.Point(75, 67);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(127, 20);
            this.dtpDOB.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(47, 93);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(155, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(72, 41);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(130, 20);
            this.txtLastName.TabIndex = 6;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(72, 12);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(130, 20);
            this.txtFirstName.TabIndex = 5;
            // 
            // lblHostRole
            // 
            this.lblHostRole.AutoSize = true;
            this.lblHostRole.Location = new System.Drawing.Point(6, 120);
            this.lblHostRole.Name = "lblHostRole";
            this.lblHostRole.Size = new System.Drawing.Size(63, 13);
            this.lblHostRole.TabIndex = 4;
            this.lblHostRole.Text = "Host Role?:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(6, 96);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email:";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(5, 67);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(69, 13);
            this.lblDOB.TabIndex = 2;
            this.lblDOB.Text = "Date of Birth:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(5, 41);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(6, 15);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteUser.Location = new System.Drawing.Point(603, 324);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(168, 19);
            this.btnDeleteUser.TabIndex = 19;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 365);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.pnlUserInfoInputFields);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.btnUpdateUser);
            this.Controls.Add(this.lstVUsers);
            this.Controls.Add(this.pnlTopBar);
            this.Name = "frmManageUsers";
            this.Text = "frmManageUsers";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRotaConnect)).EndInit();
            this.pnlUserInfoInputFields.ResumeLayout(false);
            this.pnlUserInfoInputFields.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.PictureBox picRotaConnect;
        private System.Windows.Forms.Label lblHostView;
        private System.Windows.Forms.ListView lstVUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.Panel pnlUserInfoInputFields;
        private System.Windows.Forms.CheckBox chkHostRole;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblHostRole;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Button btnDeleteUser;
    }
}