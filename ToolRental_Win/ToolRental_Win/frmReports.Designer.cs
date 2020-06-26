namespace ToolRental_Win
{
    partial class frmReports
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
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvTools = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkRetired = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.chkAtRepair = new System.Windows.Forms.CheckBox();
            this.chkWaiting = new System.Windows.Forms.CheckBox();
            this.chkOnRental = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTools)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(613, 389);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvTools
            // 
            this.dgvTools.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTools.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTools.Location = new System.Drawing.Point(13, 56);
            this.dgvTools.Name = "dgvTools";
            this.dgvTools.Size = new System.Drawing.Size(675, 327);
            this.dgvTools.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(13, 389);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(148, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export To CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "FILTER REPORT BY:";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(12, 33);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(66, 17);
            this.chkAll.TabIndex = 4;
            this.chkAll.Text = "All Tools";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Click += new System.EventHandler(this.chkAll_Click);
            // 
            // chkRetired
            // 
            this.chkRetired.AutoSize = true;
            this.chkRetired.Location = new System.Drawing.Point(232, 33);
            this.chkRetired.Name = "chkRetired";
            this.chkRetired.Size = new System.Drawing.Size(60, 17);
            this.chkRetired.TabIndex = 5;
            this.chkRetired.Text = "Retired";
            this.chkRetired.UseVisualStyleBackColor = true;
            this.chkRetired.Click += new System.EventHandler(this.chkRetired_Click);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(127, 33);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 6;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.Click += new System.EventHandler(this.chkActive_Click);
            // 
            // chkAtRepair
            // 
            this.chkAtRepair.AutoSize = true;
            this.chkAtRepair.Location = new System.Drawing.Point(609, 33);
            this.chkAtRepair.Name = "chkAtRepair";
            this.chkAtRepair.Size = new System.Drawing.Size(79, 17);
            this.chkAtRepair.TabIndex = 7;
            this.chkAtRepair.Text = "At Repairer";
            this.chkAtRepair.UseVisualStyleBackColor = true;
            this.chkAtRepair.Click += new System.EventHandler(this.chkAtRepair_Click);
            // 
            // chkWaiting
            // 
            this.chkWaiting.AutoSize = true;
            this.chkWaiting.Location = new System.Drawing.Point(464, 33);
            this.chkWaiting.Name = "chkWaiting";
            this.chkWaiting.Size = new System.Drawing.Size(96, 17);
            this.chkWaiting.TabIndex = 8;
            this.chkWaiting.Text = "Waiting Repair";
            this.chkWaiting.UseVisualStyleBackColor = true;
            this.chkWaiting.Click += new System.EventHandler(this.chkWaiting_Click);
            // 
            // chkOnRental
            // 
            this.chkOnRental.AutoSize = true;
            this.chkOnRental.Location = new System.Drawing.Point(341, 34);
            this.chkOnRental.Name = "chkOnRental";
            this.chkOnRental.Size = new System.Drawing.Size(74, 17);
            this.chkOnRental.TabIndex = 9;
            this.chkOnRental.Text = "On Rental";
            this.chkOnRental.UseVisualStyleBackColor = true;
            this.chkOnRental.Click += new System.EventHandler(this.chkOnRental_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 424);
            this.Controls.Add(this.chkOnRental);
            this.Controls.Add(this.chkWaiting);
            this.Controls.Add(this.chkAtRepair);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.chkRetired);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvTools);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Reports";
            this.Activated += new System.EventHandler(this.frmReports_Activated);
            this.Load += new System.EventHandler(this.frmReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTools)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvTools;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkRetired;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.CheckBox chkAtRepair;
        private System.Windows.Forms.CheckBox chkWaiting;
        private System.Windows.Forms.CheckBox chkOnRental;
    }
}