namespace NEABenjaminFranklin
{
    partial class cntrlRotaOverview
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
            this.lblRotaName = new System.Windows.Forms.Label();
            this.lblFacility = new System.Windows.Forms.Label();
            this.btnEditRotaSettings = new System.Windows.Forms.Button();
            this.btnMangeRotaInstances = new System.Windows.Forms.Button();
            this.btnThemeColour = new System.Windows.Forms.Button();
            this.pnlHostButtons = new System.Windows.Forms.Panel();
            this.pnlUserButtons = new System.Windows.Forms.Panel();
            this.btnViewRota = new System.Windows.Forms.Button();
            this.pnlHostButtons.SuspendLayout();
            this.pnlUserButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRotaName
            // 
            this.lblRotaName.AutoSize = true;
            this.lblRotaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotaName.Location = new System.Drawing.Point(16, 10);
            this.lblRotaName.Name = "lblRotaName";
            this.lblRotaName.Size = new System.Drawing.Size(97, 16);
            this.lblRotaName.TabIndex = 1;
            this.lblRotaName.Text = "{Rota Name}";
            // 
            // lblFacility
            // 
            this.lblFacility.AutoSize = true;
            this.lblFacility.Location = new System.Drawing.Point(16, 33);
            this.lblFacility.Name = "lblFacility";
            this.lblFacility.Size = new System.Drawing.Size(50, 13);
            this.lblFacility.TabIndex = 2;
            this.lblFacility.Text = "{locaton}";
            // 
            // btnEditRotaSettings
            // 
            this.btnEditRotaSettings.Location = new System.Drawing.Point(8, 4);
            this.btnEditRotaSettings.Name = "btnEditRotaSettings";
            this.btnEditRotaSettings.Size = new System.Drawing.Size(101, 23);
            this.btnEditRotaSettings.TabIndex = 3;
            this.btnEditRotaSettings.Text = "Rota Settings";
            this.btnEditRotaSettings.UseVisualStyleBackColor = true;
            this.btnEditRotaSettings.Click += new System.EventHandler(this.btnEditRotaSettings_Click);
            // 
            // btnMangeRotaInstances
            // 
            this.btnMangeRotaInstances.Location = new System.Drawing.Point(8, 29);
            this.btnMangeRotaInstances.Name = "btnMangeRotaInstances";
            this.btnMangeRotaInstances.Size = new System.Drawing.Size(101, 23);
            this.btnMangeRotaInstances.TabIndex = 4;
            this.btnMangeRotaInstances.Text = "Edit Rota Dates";
            this.btnMangeRotaInstances.UseVisualStyleBackColor = true;
            this.btnMangeRotaInstances.Click += new System.EventHandler(this.btnMangeRotaInstances_Click);
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
            this.btnThemeColour.Size = new System.Drawing.Size(10, 63);
            this.btnThemeColour.TabIndex = 5;
            this.btnThemeColour.UseVisualStyleBackColor = false;
            // 
            // pnlHostButtons
            // 
            this.pnlHostButtons.Controls.Add(this.btnEditRotaSettings);
            this.pnlHostButtons.Controls.Add(this.btnMangeRotaInstances);
            this.pnlHostButtons.Location = new System.Drawing.Point(194, 3);
            this.pnlHostButtons.Name = "pnlHostButtons";
            this.pnlHostButtons.Size = new System.Drawing.Size(117, 57);
            this.pnlHostButtons.TabIndex = 6;
            // 
            // pnlUserButtons
            // 
            this.pnlUserButtons.Controls.Add(this.btnViewRota);
            this.pnlUserButtons.Location = new System.Drawing.Point(186, 16);
            this.pnlUserButtons.Name = "pnlUserButtons";
            this.pnlUserButtons.Size = new System.Drawing.Size(125, 30);
            this.pnlUserButtons.TabIndex = 7;
            // 
            // btnViewRota
            // 
            this.btnViewRota.Location = new System.Drawing.Point(16, 3);
            this.btnViewRota.Name = "btnViewRota";
            this.btnViewRota.Size = new System.Drawing.Size(101, 23);
            this.btnViewRota.TabIndex = 0;
            this.btnViewRota.Text = "View Rota";
            this.btnViewRota.UseVisualStyleBackColor = true;
            this.btnViewRota.Click += new System.EventHandler(this.btnViewRota_Click);
            // 
            // cntrlRotaOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlUserButtons);
            this.Controls.Add(this.btnThemeColour);
            this.Controls.Add(this.lblFacility);
            this.Controls.Add(this.lblRotaName);
            this.Controls.Add(this.pnlHostButtons);
            this.Name = "cntrlRotaOverview";
            this.Size = new System.Drawing.Size(314, 63);
            this.Load += new System.EventHandler(this.cntrlRotaOverview_Load);
            this.pnlHostButtons.ResumeLayout(false);
            this.pnlUserButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRotaName;
        private System.Windows.Forms.Label lblFacility;
        private System.Windows.Forms.Button btnEditRotaSettings;
        private System.Windows.Forms.Button btnMangeRotaInstances;
        private System.Windows.Forms.Button btnThemeColour;
        private System.Windows.Forms.Panel pnlHostButtons;
        private System.Windows.Forms.Panel pnlUserButtons;
        private System.Windows.Forms.Button btnViewRota;
    }
}
