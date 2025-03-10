namespace NEABenjaminFranklin
{
    partial class frmUnavailability
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnavailability));
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.picRotaConnect = new System.Windows.Forms.PictureBox();
            this.lblView = new System.Windows.Forms.Label();
            this.pnlNewUnavailability = new System.Windows.Forms.Panel();
            this.btnAddUnavailability = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.flpUnavailability = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRotaConnect)).BeginInit();
            this.pnlNewUnavailability.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopBar.Controls.Add(this.picRotaConnect);
            this.pnlTopBar.Controls.Add(this.lblView);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(630, 31);
            this.pnlTopBar.TabIndex = 15;
            // 
            // picRotaConnect
            // 
            this.picRotaConnect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRotaConnect.Image = ((System.Drawing.Image)(resources.GetObject("picRotaConnect.Image")));
            this.picRotaConnect.Location = new System.Drawing.Point(0, 0);
            this.picRotaConnect.Name = "picRotaConnect";
            this.picRotaConnect.Size = new System.Drawing.Size(121, 31);
            this.picRotaConnect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRotaConnect.TabIndex = 7;
            this.picRotaConnect.TabStop = false;
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblView.Location = new System.Drawing.Point(140, 3);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(86, 21);
            this.lblView.TabIndex = 8;
            this.lblView.Text = "User View";
            // 
            // pnlNewUnavailability
            // 
            this.pnlNewUnavailability.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNewUnavailability.Controls.Add(this.btnAddUnavailability);
            this.pnlNewUnavailability.Controls.Add(this.dtpEnd);
            this.pnlNewUnavailability.Controls.Add(this.lblEndDate);
            this.pnlNewUnavailability.Controls.Add(this.dtpStart);
            this.pnlNewUnavailability.Controls.Add(this.lblStartDate);
            this.pnlNewUnavailability.Location = new System.Drawing.Point(363, 89);
            this.pnlNewUnavailability.Name = "pnlNewUnavailability";
            this.pnlNewUnavailability.Size = new System.Drawing.Size(222, 159);
            this.pnlNewUnavailability.TabIndex = 29;
            // 
            // btnAddUnavailability
            // 
            this.btnAddUnavailability.Location = new System.Drawing.Point(41, 114);
            this.btnAddUnavailability.Name = "btnAddUnavailability";
            this.btnAddUnavailability.Size = new System.Drawing.Size(131, 23);
            this.btnAddUnavailability.TabIndex = 4;
            this.btnAddUnavailability.Text = "Add New Unavailability";
            this.btnAddUnavailability.UseVisualStyleBackColor = true;
            this.btnAddUnavailability.Click += new System.EventHandler(this.btnAddUnavailability_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(25, 79);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(174, 20);
            this.dtpEnd.TabIndex = 3;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(22, 63);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(55, 13);
            this.lblEndDate.TabIndex = 2;
            this.lblEndDate.Text = "End Date:";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(25, 27);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(174, 20);
            this.dtpStart.TabIndex = 1;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(22, 11);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(58, 13);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Start Date:";
            // 
            // flpUnavailability
            // 
            this.flpUnavailability.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flpUnavailability.Location = new System.Drawing.Point(22, 38);
            this.flpUnavailability.Name = "flpUnavailability";
            this.flpUnavailability.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.flpUnavailability.Size = new System.Drawing.Size(296, 269);
            this.flpUnavailability.TabIndex = 31;
            // 
            // cmbUsers
            // 
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(363, 38);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(214, 21);
            this.cmbUsers.TabIndex = 32;
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);
            // 
            // frmUnavailability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 319);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.flpUnavailability);
            this.Controls.Add(this.pnlNewUnavailability);
            this.Controls.Add(this.pnlTopBar);
            this.Name = "frmUnavailability";
            this.Text = "frmUserUnavailability";
            this.Load += new System.EventHandler(this.frmUserUnavailability_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRotaConnect)).EndInit();
            this.pnlNewUnavailability.ResumeLayout(false);
            this.pnlNewUnavailability.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.PictureBox picRotaConnect;
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.Panel pnlNewUnavailability;
        private System.Windows.Forms.Button btnAddUnavailability;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.FlowLayoutPanel flpUnavailability;
        private System.Windows.Forms.ComboBox cmbUsers;
    }
}