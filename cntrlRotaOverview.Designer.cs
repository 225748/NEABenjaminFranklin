﻿namespace NEABenjaminFranklin
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
            this.SuspendLayout();
            // 
            // lblRotaName
            // 
            this.lblRotaName.AutoSize = true;
            this.lblRotaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotaName.Location = new System.Drawing.Point(8, 10);
            this.lblRotaName.Name = "lblRotaName";
            this.lblRotaName.Size = new System.Drawing.Size(97, 16);
            this.lblRotaName.TabIndex = 1;
            this.lblRotaName.Text = "{Rota Name}";
            // 
            // lblFacility
            // 
            this.lblFacility.AutoSize = true;
            this.lblFacility.Location = new System.Drawing.Point(8, 33);
            this.lblFacility.Name = "lblFacility";
            this.lblFacility.Size = new System.Drawing.Size(50, 13);
            this.lblFacility.TabIndex = 2;
            this.lblFacility.Text = "{locaton}";
            // 
            // btnEditRotaSettings
            // 
            this.btnEditRotaSettings.Location = new System.Drawing.Point(129, 7);
            this.btnEditRotaSettings.Name = "btnEditRotaSettings";
            this.btnEditRotaSettings.Size = new System.Drawing.Size(101, 23);
            this.btnEditRotaSettings.TabIndex = 3;
            this.btnEditRotaSettings.Text = "Rota Settings";
            this.btnEditRotaSettings.UseVisualStyleBackColor = true;
            this.btnEditRotaSettings.Click += new System.EventHandler(this.btnEditRotaSettings_Click);
            // 
            // btnMangeRotaInstances
            // 
            this.btnMangeRotaInstances.Location = new System.Drawing.Point(129, 31);
            this.btnMangeRotaInstances.Name = "btnMangeRotaInstances";
            this.btnMangeRotaInstances.Size = new System.Drawing.Size(101, 23);
            this.btnMangeRotaInstances.TabIndex = 4;
            this.btnMangeRotaInstances.Text = "Edit Rota Dates";
            this.btnMangeRotaInstances.UseVisualStyleBackColor = true;
            this.btnMangeRotaInstances.Click += new System.EventHandler(this.btnMangeRotaInstances_Click);
            // 
            // cntrlRotaOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnMangeRotaInstances);
            this.Controls.Add(this.btnEditRotaSettings);
            this.Controls.Add(this.lblFacility);
            this.Controls.Add(this.lblRotaName);
            this.Name = "cntrlRotaOverview";
            this.Size = new System.Drawing.Size(253, 63);
            this.Load += new System.EventHandler(this.cntrlRotaOverview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRotaName;
        private System.Windows.Forms.Label lblFacility;
        private System.Windows.Forms.Button btnEditRotaSettings;
        private System.Windows.Forms.Button btnMangeRotaInstances;
    }
}
