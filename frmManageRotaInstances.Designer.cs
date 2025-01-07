namespace NEABenjaminFranklin
{
    partial class frmManageRotaInstances
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageRotaInstances));
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.picRotaConnect = new System.Windows.Forms.PictureBox();
            this.lblHostView = new System.Windows.Forms.Label();
            this.btnThemeColour = new System.Windows.Forms.Button();
            this.lblFacility = new System.Windows.Forms.Label();
            this.lblRotaName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpInstances = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddInstance = new System.Windows.Forms.Button();
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
            this.pnlTopBar.Size = new System.Drawing.Size(800, 31);
            this.pnlTopBar.TabIndex = 16;
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
            // btnThemeColour
            // 
            this.btnThemeColour.BackColor = System.Drawing.Color.Silver;
            this.btnThemeColour.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnThemeColour.Enabled = false;
            this.btnThemeColour.FlatAppearance.BorderSize = 0;
            this.btnThemeColour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemeColour.Location = new System.Drawing.Point(0, 0);
            this.btnThemeColour.Name = "btnThemeColour";
            this.btnThemeColour.Size = new System.Drawing.Size(10, 29);
            this.btnThemeColour.TabIndex = 19;
            this.btnThemeColour.UseVisualStyleBackColor = false;
            // 
            // lblFacility
            // 
            this.lblFacility.AutoSize = true;
            this.lblFacility.Location = new System.Drawing.Point(682, 8);
            this.lblFacility.Name = "lblFacility";
            this.lblFacility.Size = new System.Drawing.Size(50, 13);
            this.lblFacility.TabIndex = 18;
            this.lblFacility.Text = "{locaton}";
            // 
            // lblRotaName
            // 
            this.lblRotaName.AutoSize = true;
            this.lblRotaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotaName.Location = new System.Drawing.Point(16, 6);
            this.lblRotaName.Name = "lblRotaName";
            this.lblRotaName.Size = new System.Drawing.Size(97, 16);
            this.lblRotaName.TabIndex = 17;
            this.lblRotaName.Text = "{Rota Name}";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblRotaName);
            this.panel1.Controls.Add(this.btnThemeColour);
            this.panel1.Controls.Add(this.lblFacility);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 29);
            this.panel1.TabIndex = 20;
            // 
            // flpInstances
            // 
            this.flpInstances.AutoScroll = true;
            this.flpInstances.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpInstances.Location = new System.Drawing.Point(12, 81);
            this.flpInstances.Name = "flpInstances";
            this.flpInstances.Size = new System.Drawing.Size(622, 357);
            this.flpInstances.TabIndex = 22;
            // 
            // btnAddInstance
            // 
            this.btnAddInstance.Location = new System.Drawing.Point(669, 81);
            this.btnAddInstance.Name = "btnAddInstance";
            this.btnAddInstance.Size = new System.Drawing.Size(109, 57);
            this.btnAddInstance.TabIndex = 23;
            this.btnAddInstance.Text = "Add a new Date";
            this.btnAddInstance.UseVisualStyleBackColor = true;
            this.btnAddInstance.Click += new System.EventHandler(this.btnAddInstance_Click);
            // 
            // frmManageRotaInstances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddInstance);
            this.Controls.Add(this.flpInstances);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTopBar);
            this.Name = "frmManageRotaInstances";
            this.Text = "frmManageRotaInstance";
            this.Load += new System.EventHandler(this.frmManageRotaInstance_Load);
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
        private System.Windows.Forms.Button btnThemeColour;
        private System.Windows.Forms.Label lblFacility;
        private System.Windows.Forms.Label lblRotaName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpInstances;
        private System.Windows.Forms.Button btnAddInstance;
    }
}