namespace NEABenjaminFranklin
{
    partial class frmUserLandingPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserLandingPage));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.btnUnavailability = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.picRotaConnect = new System.Windows.Forms.PictureBox();
            this.btnAccountSettings = new System.Windows.Forms.Button();
            this.lblUserView = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlDatesGroup = new System.Windows.Forms.Panel();
            this.flpDates = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDates = new System.Windows.Forms.Label();
            this.tbUserLanding = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flpRotas = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbStats = new System.Windows.Forms.TabControl();
            this.pgAcknowledgements = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.pcRefresh = new System.Windows.Forms.PictureBox();
            this.lblNyaNum = new System.Windows.Forms.Label();
            this.lblDeclinedNum = new System.Windows.Forms.Label();
            this.lblAcceptedNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUpcoming = new System.Windows.Forms.Label();
            this.pgRoles = new System.Windows.Forms.TabPage();
            this.lblHighestAssigner = new System.Windows.Forms.Label();
            this.crtRoles = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRotaConnect)).BeginInit();
            this.pnlDatesGroup.SuspendLayout();
            this.tbUserLanding.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tbStats.SuspendLayout();
            this.pgAcknowledgements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcRefresh)).BeginInit();
            this.pgRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopBar.Controls.Add(this.btnUnavailability);
            this.pnlTopBar.Controls.Add(this.btnLogout);
            this.pnlTopBar.Controls.Add(this.picRotaConnect);
            this.pnlTopBar.Controls.Add(this.btnAccountSettings);
            this.pnlTopBar.Controls.Add(this.lblUserView);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(800, 31);
            this.pnlTopBar.TabIndex = 14;
            // 
            // btnUnavailability
            // 
            this.btnUnavailability.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnUnavailability.Location = new System.Drawing.Point(378, 3);
            this.btnUnavailability.Name = "btnUnavailability";
            this.btnUnavailability.Size = new System.Drawing.Size(130, 23);
            this.btnUnavailability.TabIndex = 0;
            this.btnUnavailability.Text = "My Unavailability";
            this.btnUnavailability.UseVisualStyleBackColor = false;
            this.btnUnavailability.Click += new System.EventHandler(this.btnUnavailability_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnLogout.Location = new System.Drawing.Point(715, 3);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(72, 23);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
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
            // btnAccountSettings
            // 
            this.btnAccountSettings.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAccountSettings.Location = new System.Drawing.Point(242, 3);
            this.btnAccountSettings.Name = "btnAccountSettings";
            this.btnAccountSettings.Size = new System.Drawing.Size(130, 23);
            this.btnAccountSettings.TabIndex = 0;
            this.btnAccountSettings.Text = "Account Information";
            this.btnAccountSettings.UseVisualStyleBackColor = false;
            this.btnAccountSettings.Click += new System.EventHandler(this.btnAccountSettings_Click);
            // 
            // lblUserView
            // 
            this.lblUserView.AutoSize = true;
            this.lblUserView.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserView.Location = new System.Drawing.Point(140, 3);
            this.lblUserView.Name = "lblUserView";
            this.lblUserView.Size = new System.Drawing.Size(86, 21);
            this.lblUserView.TabIndex = 8;
            this.lblUserView.Text = "User View";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Nirmala UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(17, 39);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(144, 40);
            this.lblWelcome.TabIndex = 15;
            this.lblWelcome.Text = "Welcome";
            // 
            // pnlDatesGroup
            // 
            this.pnlDatesGroup.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlDatesGroup.Controls.Add(this.flpDates);
            this.pnlDatesGroup.Controls.Add(this.lblDates);
            this.pnlDatesGroup.Location = new System.Drawing.Point(12, 118);
            this.pnlDatesGroup.Name = "pnlDatesGroup";
            this.pnlDatesGroup.Size = new System.Drawing.Size(247, 320);
            this.pnlDatesGroup.TabIndex = 16;
            // 
            // flpDates
            // 
            this.flpDates.AutoScroll = true;
            this.flpDates.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.flpDates.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpDates.Location = new System.Drawing.Point(12, 27);
            this.flpDates.Name = "flpDates";
            this.flpDates.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.flpDates.Size = new System.Drawing.Size(222, 290);
            this.flpDates.TabIndex = 14;
            this.flpDates.WrapContents = false;
            // 
            // lblDates
            // 
            this.lblDates.AutoSize = true;
            this.lblDates.Location = new System.Drawing.Point(16, 11);
            this.lblDates.Name = "lblDates";
            this.lblDates.Size = new System.Drawing.Size(176, 13);
            this.lblDates.TabIndex = 12;
            this.lblDates.Text = "Upcoming Dates (Accept / Decline)";
            // 
            // tbUserLanding
            // 
            this.tbUserLanding.Controls.Add(this.tabPage1);
            this.tbUserLanding.Controls.Add(this.tabPage2);
            this.tbUserLanding.Location = new System.Drawing.Point(282, 118);
            this.tbUserLanding.Name = "tbUserLanding";
            this.tbUserLanding.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbUserLanding.SelectedIndex = 0;
            this.tbUserLanding.Size = new System.Drawing.Size(368, 320);
            this.tbUserLanding.TabIndex = 17;
            this.tbUserLanding.SelectedIndexChanged += new System.EventHandler(this.tbUserLanding_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flpRotas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(360, 294);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "My Rotas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flpRotas
            // 
            this.flpRotas.AutoScroll = true;
            this.flpRotas.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.flpRotas.Location = new System.Drawing.Point(6, 5);
            this.flpRotas.Name = "flpRotas";
            this.flpRotas.Size = new System.Drawing.Size(348, 280);
            this.flpRotas.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbStats);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(360, 294);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "My Stats";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbStats
            // 
            this.tbStats.Controls.Add(this.pgAcknowledgements);
            this.tbStats.Controls.Add(this.pgRoles);
            this.tbStats.Location = new System.Drawing.Point(-4, 0);
            this.tbStats.Name = "tbStats";
            this.tbStats.SelectedIndex = 0;
            this.tbStats.Size = new System.Drawing.Size(364, 298);
            this.tbStats.TabIndex = 0;
            // 
            // pgAcknowledgements
            // 
            this.pgAcknowledgements.Controls.Add(this.label4);
            this.pgAcknowledgements.Controls.Add(this.pcRefresh);
            this.pgAcknowledgements.Controls.Add(this.lblNyaNum);
            this.pgAcknowledgements.Controls.Add(this.lblDeclinedNum);
            this.pgAcknowledgements.Controls.Add(this.lblAcceptedNum);
            this.pgAcknowledgements.Controls.Add(this.label3);
            this.pgAcknowledgements.Controls.Add(this.label2);
            this.pgAcknowledgements.Controls.Add(this.label1);
            this.pgAcknowledgements.Controls.Add(this.lblUpcoming);
            this.pgAcknowledgements.Location = new System.Drawing.Point(4, 22);
            this.pgAcknowledgements.Name = "pgAcknowledgements";
            this.pgAcknowledgements.Padding = new System.Windows.Forms.Padding(3);
            this.pgAcknowledgements.Size = new System.Drawing.Size(356, 272);
            this.pgAcknowledgements.TabIndex = 0;
            this.pgAcknowledgements.Text = "Acknowledgements";
            this.pgAcknowledgements.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Click to refresh this page to update the statistics";
            // 
            // pcRefresh
            // 
            this.pcRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pcRefresh.Image")));
            this.pcRefresh.Location = new System.Drawing.Point(245, 243);
            this.pcRefresh.Name = "pcRefresh";
            this.pcRefresh.Size = new System.Drawing.Size(20, 20);
            this.pcRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcRefresh.TabIndex = 6;
            this.pcRefresh.TabStop = false;
            this.pcRefresh.Click += new System.EventHandler(this.pcRefresh_Click);
            // 
            // lblNyaNum
            // 
            this.lblNyaNum.AutoSize = true;
            this.lblNyaNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNyaNum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNyaNum.Location = new System.Drawing.Point(157, 85);
            this.lblNyaNum.Name = "lblNyaNum";
            this.lblNyaNum.Size = new System.Drawing.Size(40, 42);
            this.lblNyaNum.TabIndex = 5;
            this.lblNyaNum.Text = "0";
            // 
            // lblDeclinedNum
            // 
            this.lblDeclinedNum.AutoSize = true;
            this.lblDeclinedNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeclinedNum.ForeColor = System.Drawing.Color.Crimson;
            this.lblDeclinedNum.Location = new System.Drawing.Point(266, 85);
            this.lblDeclinedNum.Name = "lblDeclinedNum";
            this.lblDeclinedNum.Size = new System.Drawing.Size(40, 42);
            this.lblDeclinedNum.TabIndex = 4;
            this.lblDeclinedNum.Text = "0";
            // 
            // lblAcceptedNum
            // 
            this.lblAcceptedNum.AutoSize = true;
            this.lblAcceptedNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcceptedNum.ForeColor = System.Drawing.Color.Green;
            this.lblAcceptedNum.Location = new System.Drawing.Point(38, 85);
            this.lblAcceptedNum.Name = "lblAcceptedNum";
            this.lblAcceptedNum.Size = new System.Drawing.Size(40, 42);
            this.lblAcceptedNum.TabIndex = 0;
            this.lblAcceptedNum.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Declined";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Unacknowledged";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Accepted";
            // 
            // lblUpcoming
            // 
            this.lblUpcoming.AutoSize = true;
            this.lblUpcoming.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcoming.Location = new System.Drawing.Point(7, 7);
            this.lblUpcoming.Name = "lblUpcoming";
            this.lblUpcoming.Size = new System.Drawing.Size(238, 15);
            this.lblUpcoming.TabIndex = 0;
            this.lblUpcoming.Text = "Your Upcoming Assignments Status:";
            // 
            // pgRoles
            // 
            this.pgRoles.Controls.Add(this.lblHighestAssigner);
            this.pgRoles.Controls.Add(this.crtRoles);
            this.pgRoles.Controls.Add(this.label5);
            this.pgRoles.Location = new System.Drawing.Point(4, 22);
            this.pgRoles.Name = "pgRoles";
            this.pgRoles.Padding = new System.Windows.Forms.Padding(3);
            this.pgRoles.Size = new System.Drawing.Size(356, 272);
            this.pgRoles.TabIndex = 1;
            this.pgRoles.Text = "Roles";
            this.pgRoles.UseVisualStyleBackColor = true;
            // 
            // lblHighestAssigner
            // 
            this.lblHighestAssigner.AutoSize = true;
            this.lblHighestAssigner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighestAssigner.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHighestAssigner.Location = new System.Drawing.Point(6, 244);
            this.lblHighestAssigner.Name = "lblHighestAssigner";
            this.lblHighestAssigner.Size = new System.Drawing.Size(82, 16);
            this.lblHighestAssigner.TabIndex = 6;
            this.lblHighestAssigner.Text = "{HostName}";
            // 
            // crtRoles
            // 
            this.crtRoles.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Name = "ChartArea1";
            this.crtRoles.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.crtRoles.Legends.Add(legend1);
            this.crtRoles.Location = new System.Drawing.Point(3, 0);
            this.crtRoles.Name = "crtRoles";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "My Assignments";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Average";
            this.crtRoles.Series.Add(series1);
            this.crtRoles.Series.Add(series2);
            this.crtRoles.Size = new System.Drawing.Size(350, 217);
            this.crtRoles.TabIndex = 2;
            this.crtRoles.Text = "chart1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Most Commonly Assigned By:";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFullName.Location = new System.Drawing.Point(20, 77);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(109, 25);
            this.lblFullName.TabIndex = 18;
            this.lblFullName.Text = "{Full Name}";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(656, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(132, 295);
            this.panel1.TabIndex = 19;
            // 
            // frmUserLandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.pnlDatesGroup);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.tbUserLanding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUserLandingPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Landing Page";
            this.Load += new System.EventHandler(this.frmUserLandingPage_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRotaConnect)).EndInit();
            this.pnlDatesGroup.ResumeLayout(false);
            this.pnlDatesGroup.PerformLayout();
            this.tbUserLanding.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tbStats.ResumeLayout(false);
            this.pgAcknowledgements.ResumeLayout(false);
            this.pgAcknowledgements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcRefresh)).EndInit();
            this.pgRoles.ResumeLayout(false);
            this.pgRoles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.PictureBox picRotaConnect;
        private System.Windows.Forms.Button btnAccountSettings;
        private System.Windows.Forms.Label lblUserView;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlDatesGroup;
        private System.Windows.Forms.FlowLayoutPanel flpDates;
        private System.Windows.Forms.Label lblDates;
        private System.Windows.Forms.TabControl tbUserLanding;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flpRotas;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TabControl tbStats;
        private System.Windows.Forms.TabPage pgAcknowledgements;
        private System.Windows.Forms.TabPage pgRoles;
        private System.Windows.Forms.Label lblNyaNum;
        private System.Windows.Forms.Label lblDeclinedNum;
        private System.Windows.Forms.Label lblAcceptedNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUpcoming;
        private System.Windows.Forms.PictureBox pcRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHighestAssigner;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtRoles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUnavailability;
    }
}