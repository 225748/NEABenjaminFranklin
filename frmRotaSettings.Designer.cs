namespace NEABenjaminFranklin
{
    partial class frmRotaSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRotaSettings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnColourDisplay = new System.Windows.Forms.Button();
            this.lstVRoles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnChangeThemeColour = new System.Windows.Forms.Button();
            this.btnDeleteRota = new System.Windows.Forms.Button();
            this.cmbFacility = new System.Windows.Forms.ComboBox();
            this.btnUpdateRota = new System.Windows.Forms.Button();
            this.lblRoles = new System.Windows.Forms.Label();
            this.txtRotaName = new System.Windows.Forms.TextBox();
            this.lblVenue = new System.Windows.Forms.Label();
            this.lblRotaName = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.picRotaConnect = new System.Windows.Forms.PictureBox();
            this.lblHostView = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRotaConnect)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnColourDisplay);
            this.panel1.Controls.Add(this.lstVRoles);
            this.panel1.Controls.Add(this.btnChangeThemeColour);
            this.panel1.Controls.Add(this.btnDeleteRota);
            this.panel1.Controls.Add(this.cmbFacility);
            this.panel1.Controls.Add(this.btnUpdateRota);
            this.panel1.Controls.Add(this.lblRoles);
            this.panel1.Controls.Add(this.txtRotaName);
            this.panel1.Controls.Add(this.lblVenue);
            this.panel1.Controls.Add(this.lblRotaName);
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 279);
            this.panel1.TabIndex = 20;
            // 
            // btnColourDisplay
            // 
            this.btnColourDisplay.BackColor = System.Drawing.Color.Silver;
            this.btnColourDisplay.Enabled = false;
            this.btnColourDisplay.FlatAppearance.BorderSize = 0;
            this.btnColourDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColourDisplay.Location = new System.Drawing.Point(23, 159);
            this.btnColourDisplay.Name = "btnColourDisplay";
            this.btnColourDisplay.Size = new System.Drawing.Size(105, 10);
            this.btnColourDisplay.TabIndex = 25;
            this.btnColourDisplay.UseVisualStyleBackColor = false;
            // 
            // lstVRoles
            // 
            this.lstVRoles.CheckBoxes = true;
            this.lstVRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstVRoles.HideSelection = false;
            this.lstVRoles.Location = new System.Drawing.Point(146, 76);
            this.lstVRoles.Name = "lstVRoles";
            this.lstVRoles.Size = new System.Drawing.Size(122, 180);
            this.lstVRoles.TabIndex = 24;
            this.lstVRoles.UseCompatibleStateImageBehavior = false;
            this.lstVRoles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Roles";
            this.columnHeader1.Width = 117;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "RoleNumber";
            this.columnHeader2.Width = 0;
            // 
            // btnChangeThemeColour
            // 
            this.btnChangeThemeColour.Location = new System.Drawing.Point(22, 118);
            this.btnChangeThemeColour.Name = "btnChangeThemeColour";
            this.btnChangeThemeColour.Size = new System.Drawing.Size(106, 35);
            this.btnChangeThemeColour.TabIndex = 22;
            this.btnChangeThemeColour.Text = "Change Rota Colour";
            this.btnChangeThemeColour.UseVisualStyleBackColor = true;
            this.btnChangeThemeColour.Click += new System.EventHandler(this.btnChangeThemeColour_Click);
            // 
            // btnDeleteRota
            // 
            this.btnDeleteRota.Location = new System.Drawing.Point(22, 221);
            this.btnDeleteRota.Name = "btnDeleteRota";
            this.btnDeleteRota.Size = new System.Drawing.Size(106, 35);
            this.btnDeleteRota.TabIndex = 20;
            this.btnDeleteRota.Text = "Delete Rota";
            this.btnDeleteRota.UseVisualStyleBackColor = true;
            this.btnDeleteRota.Click += new System.EventHandler(this.btnDeleteRota_Click);
            // 
            // cmbFacility
            // 
            this.cmbFacility.FormattingEnabled = true;
            this.cmbFacility.Location = new System.Drawing.Point(145, 41);
            this.cmbFacility.Name = "cmbFacility";
            this.cmbFacility.Size = new System.Drawing.Size(122, 21);
            this.cmbFacility.TabIndex = 21;
            // 
            // btnUpdateRota
            // 
            this.btnUpdateRota.Location = new System.Drawing.Point(22, 180);
            this.btnUpdateRota.Name = "btnUpdateRota";
            this.btnUpdateRota.Size = new System.Drawing.Size(106, 35);
            this.btnUpdateRota.TabIndex = 19;
            this.btnUpdateRota.Text = "Update Rota";
            this.btnUpdateRota.UseVisualStyleBackColor = true;
            this.btnUpdateRota.Click += new System.EventHandler(this.btnUpdateRota_Click);
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Location = new System.Drawing.Point(8, 76);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(120, 13);
            this.lblRoles.TabIndex = 20;
            this.lblRoles.Text = "Select roles for this rota:";
            // 
            // txtRotaName
            // 
            this.txtRotaName.Location = new System.Drawing.Point(145, 15);
            this.txtRotaName.Name = "txtRotaName";
            this.txtRotaName.Size = new System.Drawing.Size(122, 20);
            this.txtRotaName.TabIndex = 5;
            // 
            // lblVenue
            // 
            this.lblVenue.AutoSize = true;
            this.lblVenue.Location = new System.Drawing.Point(8, 41);
            this.lblVenue.Name = "lblVenue";
            this.lblVenue.Size = new System.Drawing.Size(93, 13);
            this.lblVenue.TabIndex = 1;
            this.lblVenue.Text = "Venue / Location:";
            // 
            // lblRotaName
            // 
            this.lblRotaName.AutoSize = true;
            this.lblRotaName.Location = new System.Drawing.Point(8, 15);
            this.lblRotaName.Name = "lblRotaName";
            this.lblRotaName.Size = new System.Drawing.Size(56, 13);
            this.lblRotaName.TabIndex = 0;
            this.lblRotaName.Text = "Rota Title:";
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopBar.Controls.Add(this.picRotaConnect);
            this.pnlTopBar.Controls.Add(this.lblHostView);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(298, 31);
            this.pnlTopBar.TabIndex = 21;
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
            // frmRotaSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 331);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRotaSettings";
            this.Text = "frmUpdateDeleteRota";
            this.Load += new System.EventHandler(this.frmRotaSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRotaConnect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteRota;
        private System.Windows.Forms.ComboBox cmbFacility;
        private System.Windows.Forms.Button btnUpdateRota;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.TextBox txtRotaName;
        private System.Windows.Forms.Label lblVenue;
        private System.Windows.Forms.Label lblRotaName;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.PictureBox picRotaConnect;
        private System.Windows.Forms.Label lblHostView;
        private System.Windows.Forms.Button btnChangeThemeColour;
        private System.Windows.Forms.ListView lstVRoles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnColourDisplay;
    }
}