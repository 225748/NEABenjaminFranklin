namespace NEABenjaminFranklin
{
    partial class frmHostLandingPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHostLandingPage));
            this.pnlHostView = new System.Windows.Forms.Panel();
            this.lblFullName = new System.Windows.Forms.Label();
            this.pnlRotasGroup = new System.Windows.Forms.Panel();
            this.flpRotas = new System.Windows.Forms.FlowLayoutPanel();
            this.btnManageRotas = new System.Windows.Forms.Button();
            this.btnCreateRota = new System.Windows.Forms.Button();
            this.btnManageFacilities = new System.Windows.Forms.Button();
            this.lblRotas = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnVMCRoles = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblRoles = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlUsersGroup = new System.Windows.Forms.Panel();
            this.flpUsers = new System.Windows.Forms.FlowLayoutPanel();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.btnPasswordReset = new System.Windows.Forms.Button();
            this.btnUnavailability = new System.Windows.Forms.Button();
            this.lblUsers = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.picRotaConnect = new System.Windows.Forms.PictureBox();
            this.lblHostView = new System.Windows.Forms.Label();
            this.pnlHostView.SuspendLayout();
            this.pnlRotasGroup.SuspendLayout();
            this.flpRotas.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlUsersGroup.SuspendLayout();
            this.flpUsers.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRotaConnect)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHostView
            // 
            this.pnlHostView.BackColor = System.Drawing.Color.White;
            this.pnlHostView.Controls.Add(this.pnlRotasGroup);
            this.pnlHostView.Controls.Add(this.lblFullName);
            this.pnlHostView.Controls.Add(this.panel1);
            this.pnlHostView.Controls.Add(this.lblWelcome);
            this.pnlHostView.Controls.Add(this.pnlUsersGroup);
            this.pnlHostView.Controls.Add(this.pnlTopBar);
            this.pnlHostView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHostView.Location = new System.Drawing.Point(0, 0);
            this.pnlHostView.Name = "pnlHostView";
            this.pnlHostView.Size = new System.Drawing.Size(697, 364);
            this.pnlHostView.TabIndex = 0;
            this.pnlHostView.Tag = "";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFullName.Location = new System.Drawing.Point(33, 97);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(109, 25);
            this.lblFullName.TabIndex = 20;
            this.lblFullName.Text = "{Full Name}";
            // 
            // pnlRotasGroup
            // 
            this.pnlRotasGroup.Controls.Add(this.flpRotas);
            this.pnlRotasGroup.Controls.Add(this.lblRotas);
            this.pnlRotasGroup.Location = new System.Drawing.Point(247, 134);
            this.pnlRotasGroup.Name = "pnlRotasGroup";
            this.pnlRotasGroup.Size = new System.Drawing.Size(205, 210);
            this.pnlRotasGroup.TabIndex = 16;
            // 
            // flpRotas
            // 
            this.flpRotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpRotas.Controls.Add(this.btnManageRotas);
            this.flpRotas.Controls.Add(this.btnCreateRota);
            this.flpRotas.Controls.Add(this.btnManageFacilities);
            this.flpRotas.Location = new System.Drawing.Point(12, 27);
            this.flpRotas.Name = "flpRotas";
            this.flpRotas.Padding = new System.Windows.Forms.Padding(7, 3, 0, 0);
            this.flpRotas.Size = new System.Drawing.Size(179, 177);
            this.flpRotas.TabIndex = 14;
            // 
            // btnManageRotas
            // 
            this.btnManageRotas.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageRotas.Location = new System.Drawing.Point(10, 6);
            this.btnManageRotas.Name = "btnManageRotas";
            this.btnManageRotas.Size = new System.Drawing.Size(153, 50);
            this.btnManageRotas.TabIndex = 12;
            this.btnManageRotas.Text = "View and Manage Current Rotas";
            this.btnManageRotas.UseVisualStyleBackColor = true;
            this.btnManageRotas.Click += new System.EventHandler(this.btnManageRotas_Click);
            // 
            // btnCreateRota
            // 
            this.btnCreateRota.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.btnCreateRota.Location = new System.Drawing.Point(10, 62);
            this.btnCreateRota.Name = "btnCreateRota";
            this.btnCreateRota.Size = new System.Drawing.Size(153, 50);
            this.btnCreateRota.TabIndex = 13;
            this.btnCreateRota.Text = "Create New Rota";
            this.btnCreateRota.UseVisualStyleBackColor = true;
            this.btnCreateRota.Click += new System.EventHandler(this.btnCreateRota_Click);
            // 
            // btnManageFacilities
            // 
            this.btnManageFacilities.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageFacilities.Location = new System.Drawing.Point(10, 118);
            this.btnManageFacilities.Name = "btnManageFacilities";
            this.btnManageFacilities.Size = new System.Drawing.Size(153, 50);
            this.btnManageFacilities.TabIndex = 14;
            this.btnManageFacilities.Text = "Create and Manage Facilities";
            this.btnManageFacilities.UseVisualStyleBackColor = true;
            this.btnManageFacilities.Click += new System.EventHandler(this.btnManageFacilities_Click);
            // 
            // lblRotas
            // 
            this.lblRotas.AutoSize = true;
            this.lblRotas.Location = new System.Drawing.Point(16, 11);
            this.lblRotas.Name = "lblRotas";
            this.lblRotas.Size = new System.Drawing.Size(35, 13);
            this.lblRotas.TabIndex = 12;
            this.lblRotas.Text = "Rotas";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.lblRoles);
            this.panel1.Location = new System.Drawing.Point(26, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 210);
            this.panel1.TabIndex = 17;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btnVMCRoles);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(177, 177);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // btnVMCRoles
            // 
            this.btnVMCRoles.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVMCRoles.Location = new System.Drawing.Point(10, 6);
            this.btnVMCRoles.Name = "btnVMCRoles";
            this.btnVMCRoles.Size = new System.Drawing.Size(153, 50);
            this.btnVMCRoles.TabIndex = 12;
            this.btnVMCRoles.Text = "View, Manage and Create Roles";
            this.btnVMCRoles.UseVisualStyleBackColor = true;
            this.btnVMCRoles.Click += new System.EventHandler(this.btnVMCRoles_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(10, 62);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(153, 50);
            this.button4.TabIndex = 13;
            this.button4.Text = "Search Users by Role";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Location = new System.Drawing.Point(16, 11);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(34, 13);
            this.lblRoles.TabIndex = 12;
            this.lblRoles.Text = "Roles";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Nirmala UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(31, 59);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(144, 40);
            this.lblWelcome.TabIndex = 19;
            this.lblWelcome.Text = "Welcome";
            // 
            // pnlUsersGroup
            // 
            this.pnlUsersGroup.Controls.Add(this.flpUsers);
            this.pnlUsersGroup.Controls.Add(this.lblUsers);
            this.pnlUsersGroup.Location = new System.Drawing.Point(469, 78);
            this.pnlUsersGroup.Name = "pnlUsersGroup";
            this.pnlUsersGroup.Size = new System.Drawing.Size(207, 266);
            this.pnlUsersGroup.TabIndex = 15;
            // 
            // flpUsers
            // 
            this.flpUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpUsers.Controls.Add(this.btnManageUsers);
            this.flpUsers.Controls.Add(this.btnAddNewUser);
            this.flpUsers.Controls.Add(this.btnPasswordReset);
            this.flpUsers.Controls.Add(this.btnUnavailability);
            this.flpUsers.Location = new System.Drawing.Point(12, 27);
            this.flpUsers.Name = "flpUsers";
            this.flpUsers.Padding = new System.Windows.Forms.Padding(7, 3, 0, 0);
            this.flpUsers.Size = new System.Drawing.Size(178, 233);
            this.flpUsers.TabIndex = 14;
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageUsers.Location = new System.Drawing.Point(10, 6);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(153, 50);
            this.btnManageUsers.TabIndex = 10;
            this.btnManageUsers.Text = "Manage Current Users";
            this.btnManageUsers.UseVisualStyleBackColor = true;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.btnAddNewUser.Location = new System.Drawing.Point(10, 62);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(153, 50);
            this.btnAddNewUser.TabIndex = 11;
            this.btnAddNewUser.Text = "Add New User";
            this.btnAddNewUser.UseVisualStyleBackColor = true;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // btnPasswordReset
            // 
            this.btnPasswordReset.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.btnPasswordReset.Location = new System.Drawing.Point(10, 118);
            this.btnPasswordReset.Name = "btnPasswordReset";
            this.btnPasswordReset.Size = new System.Drawing.Size(153, 50);
            this.btnPasswordReset.TabIndex = 12;
            this.btnPasswordReset.Text = "Password Reset";
            this.btnPasswordReset.UseVisualStyleBackColor = true;
            this.btnPasswordReset.Click += new System.EventHandler(this.btnPasswordReset_Click);
            // 
            // btnUnavailability
            // 
            this.btnUnavailability.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnavailability.Location = new System.Drawing.Point(10, 174);
            this.btnUnavailability.Name = "btnUnavailability";
            this.btnUnavailability.Size = new System.Drawing.Size(153, 50);
            this.btnUnavailability.TabIndex = 13;
            this.btnUnavailability.Text = "View\r\nUnavailability";
            this.btnUnavailability.UseVisualStyleBackColor = true;
            this.btnUnavailability.Click += new System.EventHandler(this.btnUnavailability_Click);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Location = new System.Drawing.Point(16, 11);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(34, 13);
            this.lblUsers.TabIndex = 12;
            this.lblUsers.Text = "Users";
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopBar.Controls.Add(this.btnLogout);
            this.pnlTopBar.Controls.Add(this.picRotaConnect);
            this.pnlTopBar.Controls.Add(this.lblHostView);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(697, 31);
            this.pnlTopBar.TabIndex = 13;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnLogout.Location = new System.Drawing.Point(603, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(72, 23);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
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
            // frmHostLandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 364);
            this.Controls.Add(this.pnlHostView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHostLandingPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Host View";
            this.Load += new System.EventHandler(this.frmHostLandingPage_Load);
            this.pnlHostView.ResumeLayout(false);
            this.pnlHostView.PerformLayout();
            this.pnlRotasGroup.ResumeLayout(false);
            this.pnlRotasGroup.PerformLayout();
            this.flpRotas.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlUsersGroup.ResumeLayout(false);
            this.pnlUsersGroup.PerformLayout();
            this.flpUsers.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRotaConnect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHostView;
        private System.Windows.Forms.PictureBox picRotaConnect;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label lblHostView;
        private System.Windows.Forms.FlowLayoutPanel flpUsers;
        private System.Windows.Forms.Panel pnlRotasGroup;
        private System.Windows.Forms.FlowLayoutPanel flpRotas;
        private System.Windows.Forms.Button btnCreateRota;
        private System.Windows.Forms.Button btnManageRotas;
        private System.Windows.Forms.Label lblRotas;
        private System.Windows.Forms.Panel pnlUsersGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnVMCRoles;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.Button btnManageFacilities;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnPasswordReset;
        private System.Windows.Forms.Button btnUnavailability;
    }
}