namespace NEABenjaminFranklin
{
    partial class frmCreateNewRota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateNewRota));
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.picRotaConnect = new System.Windows.Forms.PictureBox();
            this.lblHostView = new System.Windows.Forms.Label();
            this.btnCreateRota = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstVRoles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnColourDisplay = new System.Windows.Forms.Button();
            this.btnThemeColour = new System.Windows.Forms.Button();
            this.cmbFacility = new System.Windows.Forms.ComboBox();
            this.lblRoles = new System.Windows.Forms.Label();
            this.txtRotaName = new System.Windows.Forms.TextBox();
            this.lblVenue = new System.Windows.Forms.Label();
            this.lblRotaName = new System.Windows.Forms.Label();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRotaConnect)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.pnlTopBar.Size = new System.Drawing.Size(319, 31);
            this.pnlTopBar.TabIndex = 15;
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
            // btnCreateRota
            // 
            this.btnCreateRota.Location = new System.Drawing.Point(157, 280);
            this.btnCreateRota.Name = "btnCreateRota";
            this.btnCreateRota.Size = new System.Drawing.Size(106, 35);
            this.btnCreateRota.TabIndex = 19;
            this.btnCreateRota.Text = "Create new rota";
            this.btnCreateRota.UseVisualStyleBackColor = true;
            this.btnCreateRota.Click += new System.EventHandler(this.btnCreateRota_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lstVRoles);
            this.panel1.Controls.Add(this.btnColourDisplay);
            this.panel1.Controls.Add(this.btnThemeColour);
            this.panel1.Controls.Add(this.cmbFacility);
            this.panel1.Controls.Add(this.btnCreateRota);
            this.panel1.Controls.Add(this.lblRoles);
            this.panel1.Controls.Add(this.txtRotaName);
            this.panel1.Controls.Add(this.lblVenue);
            this.panel1.Controls.Add(this.lblRotaName);
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 330);
            this.panel1.TabIndex = 18;
            // 
            // lstVRoles
            // 
            this.lstVRoles.CheckBoxes = true;
            this.lstVRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstVRoles.HideSelection = false;
            this.lstVRoles.Location = new System.Drawing.Point(151, 76);
            this.lstVRoles.Name = "lstVRoles";
            this.lstVRoles.Size = new System.Drawing.Size(122, 169);
            this.lstVRoles.TabIndex = 23;
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
            // btnColourDisplay
            // 
            this.btnColourDisplay.BackColor = System.Drawing.Color.Silver;
            this.btnColourDisplay.Enabled = false;
            this.btnColourDisplay.FlatAppearance.BorderSize = 0;
            this.btnColourDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColourDisplay.Location = new System.Drawing.Point(17, 157);
            this.btnColourDisplay.Name = "btnColourDisplay";
            this.btnColourDisplay.Size = new System.Drawing.Size(117, 10);
            this.btnColourDisplay.TabIndex = 19;
            this.btnColourDisplay.UseVisualStyleBackColor = false;
            // 
            // btnThemeColour
            // 
            this.btnThemeColour.Location = new System.Drawing.Point(17, 116);
            this.btnThemeColour.Name = "btnThemeColour";
            this.btnThemeColour.Size = new System.Drawing.Size(117, 35);
            this.btnThemeColour.TabIndex = 22;
            this.btnThemeColour.Text = "Set Rota Theme Colour";
            this.btnThemeColour.UseVisualStyleBackColor = true;
            this.btnThemeColour.Click += new System.EventHandler(this.btnThemeColour_Click);
            // 
            // cmbFacility
            // 
            this.cmbFacility.FormattingEnabled = true;
            this.cmbFacility.Location = new System.Drawing.Point(151, 41);
            this.cmbFacility.Name = "cmbFacility";
            this.cmbFacility.Size = new System.Drawing.Size(122, 21);
            this.cmbFacility.TabIndex = 21;
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Location = new System.Drawing.Point(14, 76);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(120, 13);
            this.lblRoles.TabIndex = 20;
            this.lblRoles.Text = "Select roles for this rota:";
            // 
            // txtRotaName
            // 
            this.txtRotaName.Location = new System.Drawing.Point(151, 15);
            this.txtRotaName.Name = "txtRotaName";
            this.txtRotaName.Size = new System.Drawing.Size(122, 20);
            this.txtRotaName.TabIndex = 5;
            // 
            // lblVenue
            // 
            this.lblVenue.AutoSize = true;
            this.lblVenue.Location = new System.Drawing.Point(14, 41);
            this.lblVenue.Name = "lblVenue";
            this.lblVenue.Size = new System.Drawing.Size(93, 13);
            this.lblVenue.TabIndex = 1;
            this.lblVenue.Text = "Venue / Location:";
            // 
            // lblRotaName
            // 
            this.lblRotaName.AutoSize = true;
            this.lblRotaName.Location = new System.Drawing.Point(14, 15);
            this.lblRotaName.Name = "lblRotaName";
            this.lblRotaName.Size = new System.Drawing.Size(56, 13);
            this.lblRotaName.TabIndex = 0;
            this.lblRotaName.Text = "Rota Title:";
            // 
            // frmCreateNewRota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 377);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTopBar);
            this.Name = "frmCreateNewRota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCreateNewRota";
            this.Load += new System.EventHandler(this.frmCreateNewRota_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRotaConnect)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.PictureBox picRotaConnect;
        private System.Windows.Forms.Label lblHostView;
        private System.Windows.Forms.Button btnCreateRota;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRotaName;
        private System.Windows.Forms.Label lblVenue;
        private System.Windows.Forms.Label lblRotaName;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.ComboBox cmbFacility;
        private System.Windows.Forms.Button btnThemeColour;
        private System.Windows.Forms.Button btnColourDisplay;
        private System.Windows.Forms.ListView lstVRoles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}