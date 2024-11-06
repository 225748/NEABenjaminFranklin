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
            this.btnChangeThemeColour = new System.Windows.Forms.Button();
            this.btnDeleteRota = new System.Windows.Forms.Button();
            this.cmbFacility = new System.Windows.Forms.ComboBox();
            this.btnUpdateRota = new System.Windows.Forms.Button();
            this.lblRoles = new System.Windows.Forms.Label();
            this.txtRotaName = new System.Windows.Forms.TextBox();
            this.lblVenue = new System.Windows.Forms.Label();
            this.chklstRoles = new System.Windows.Forms.CheckedListBox();
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
            this.panel1.Controls.Add(this.btnChangeThemeColour);
            this.panel1.Controls.Add(this.btnDeleteRota);
            this.panel1.Controls.Add(this.cmbFacility);
            this.panel1.Controls.Add(this.btnUpdateRota);
            this.panel1.Controls.Add(this.lblRoles);
            this.panel1.Controls.Add(this.txtRotaName);
            this.panel1.Controls.Add(this.lblVenue);
            this.panel1.Controls.Add(this.chklstRoles);
            this.panel1.Controls.Add(this.lblRotaName);
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 279);
            this.panel1.TabIndex = 20;
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
            // chklstRoles
            // 
            this.chklstRoles.CheckOnClick = true;
            this.chklstRoles.FormattingEnabled = true;
            this.chklstRoles.Location = new System.Drawing.Point(145, 76);
            this.chklstRoles.Name = "chklstRoles";
            this.chklstRoles.Size = new System.Drawing.Size(122, 184);
            this.chklstRoles.TabIndex = 16;
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
            this.Name = "frmRotaSettings";
            this.Text = "frmUpdateDeleteRota";
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
        private System.Windows.Forms.CheckedListBox chklstRoles;
        private System.Windows.Forms.Label lblRotaName;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.PictureBox picRotaConnect;
        private System.Windows.Forms.Label lblHostView;
        private System.Windows.Forms.Button btnChangeThemeColour;
    }
}