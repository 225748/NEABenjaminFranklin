namespace NEABenjaminFranklin
{
    partial class frmManageFacilities
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageFacilities));
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.picRotaConnect = new System.Windows.Forms.PictureBox();
            this.lblHostView = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlUserControls = new System.Windows.Forms.Panel();
            this.lblFacilityName = new System.Windows.Forms.Label();
            this.btnAddNewFacility = new System.Windows.Forms.Button();
            this.btnUpdateFacility = new System.Windows.Forms.Button();
            this.txtFacilityName = new System.Windows.Forms.TextBox();
            this.btnDeleteFacility = new System.Windows.Forms.Button();
            this.cmbFacility = new System.Windows.Forms.ComboBox();
            this.lstVFacility = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRotaConnect)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlUserControls.SuspendLayout();
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
            this.pnlTopBar.Size = new System.Drawing.Size(417, 31);
            this.pnlTopBar.TabIndex = 29;
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnlUserControls);
            this.panel1.Controls.Add(this.cmbFacility);
            this.panel1.Controls.Add(this.lstVFacility);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 333);
            this.panel1.TabIndex = 30;
            // 
            // pnlUserControls
            // 
            this.pnlUserControls.Controls.Add(this.lblFacilityName);
            this.pnlUserControls.Controls.Add(this.btnAddNewFacility);
            this.pnlUserControls.Controls.Add(this.btnUpdateFacility);
            this.pnlUserControls.Controls.Add(this.txtFacilityName);
            this.pnlUserControls.Controls.Add(this.btnDeleteFacility);
            this.pnlUserControls.Location = new System.Drawing.Point(182, 68);
            this.pnlUserControls.Name = "pnlUserControls";
            this.pnlUserControls.Size = new System.Drawing.Size(186, 209);
            this.pnlUserControls.TabIndex = 28;
            // 
            // lblFacilityName
            // 
            this.lblFacilityName.AutoSize = true;
            this.lblFacilityName.Location = new System.Drawing.Point(8, 9);
            this.lblFacilityName.Name = "lblFacilityName";
            this.lblFacilityName.Size = new System.Drawing.Size(73, 13);
            this.lblFacilityName.TabIndex = 25;
            this.lblFacilityName.Text = "Facility Name:";
            // 
            // btnAddNewFacility
            // 
            this.btnAddNewFacility.Location = new System.Drawing.Point(11, 64);
            this.btnAddNewFacility.Name = "btnAddNewFacility";
            this.btnAddNewFacility.Size = new System.Drawing.Size(168, 34);
            this.btnAddNewFacility.TabIndex = 27;
            this.btnAddNewFacility.Text = "Add New Facility";
            this.btnAddNewFacility.UseVisualStyleBackColor = true;
            this.btnAddNewFacility.Click += new System.EventHandler(this.btnAddNewFacility_Click);
            // 
            // btnUpdateFacility
            // 
            this.btnUpdateFacility.Location = new System.Drawing.Point(11, 104);
            this.btnUpdateFacility.Name = "btnUpdateFacility";
            this.btnUpdateFacility.Size = new System.Drawing.Size(168, 34);
            this.btnUpdateFacility.TabIndex = 21;
            this.btnUpdateFacility.Text = "Update Selected Facility";
            this.btnUpdateFacility.UseVisualStyleBackColor = true;
            this.btnUpdateFacility.Click += new System.EventHandler(this.btnUpdateFacility_Click);
            // 
            // txtFacilityName
            // 
            this.txtFacilityName.Location = new System.Drawing.Point(11, 25);
            this.txtFacilityName.Name = "txtFacilityName";
            this.txtFacilityName.Size = new System.Drawing.Size(168, 20);
            this.txtFacilityName.TabIndex = 26;
            // 
            // btnDeleteFacility
            // 
            this.btnDeleteFacility.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteFacility.Location = new System.Drawing.Point(11, 144);
            this.btnDeleteFacility.Name = "btnDeleteFacility";
            this.btnDeleteFacility.Size = new System.Drawing.Size(168, 19);
            this.btnDeleteFacility.TabIndex = 24;
            this.btnDeleteFacility.Text = "Delete Facility";
            this.btnDeleteFacility.UseVisualStyleBackColor = false;
            this.btnDeleteFacility.Click += new System.EventHandler(this.btnDeleteFacility_Click);
            // 
            // cmbFacility
            // 
            this.cmbFacility.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFacility.FormattingEnabled = true;
            this.cmbFacility.Location = new System.Drawing.Point(182, 22);
            this.cmbFacility.Name = "cmbFacility";
            this.cmbFacility.Size = new System.Drawing.Size(186, 21);
            this.cmbFacility.TabIndex = 22;
            this.cmbFacility.SelectedIndexChanged += new System.EventHandler(this.cmbFacility_SelectedIndexChanged);
            // 
            // lstVFacility
            // 
            this.lstVFacility.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstVFacility.FullRowSelect = true;
            this.lstVFacility.HideSelection = false;
            this.lstVFacility.Location = new System.Drawing.Point(17, 22);
            this.lstVFacility.MultiSelect = false;
            this.lstVFacility.Name = "lstVFacility";
            this.lstVFacility.Size = new System.Drawing.Size(143, 289);
            this.lstVFacility.TabIndex = 20;
            this.lstVFacility.UseCompatibleStateImageBehavior = false;
            this.lstVFacility.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Facility";
            this.columnHeader1.Width = 138;
            // 
            // frmManageFacilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 389);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmManageFacilities";
            this.Text = "frmManageFacilities";
            this.Load += new System.EventHandler(this.frmManageFacilities_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRotaConnect)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlUserControls.ResumeLayout(false);
            this.pnlUserControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.PictureBox picRotaConnect;
        private System.Windows.Forms.Label lblHostView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlUserControls;
        private System.Windows.Forms.Label lblFacilityName;
        private System.Windows.Forms.Button btnAddNewFacility;
        private System.Windows.Forms.Button btnUpdateFacility;
        private System.Windows.Forms.TextBox txtFacilityName;
        private System.Windows.Forms.Button btnDeleteFacility;
        private System.Windows.Forms.ComboBox cmbFacility;
        private System.Windows.Forms.ListView lstVFacility;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}