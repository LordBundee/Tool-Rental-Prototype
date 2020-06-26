namespace ToolRental_Win
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnTools = new System.Windows.Forms.Button();
            this.btnMembers = new System.Windows.Forms.Button();
            this.btnWorkspaces = new System.Windows.Forms.Button();
            this.btnRentals = new System.Windows.Forms.Button();
            this.btnNewRental = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(224, 278);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Location = new System.Drawing.Point(177, 207);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(120, 40);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnTools
            // 
            this.btnTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTools.Location = new System.Drawing.Point(177, 161);
            this.btnTools.Name = "btnTools";
            this.btnTools.Size = new System.Drawing.Size(120, 40);
            this.btnTools.TabIndex = 2;
            this.btnTools.Text = "Add / Manage Tools";
            this.btnTools.UseVisualStyleBackColor = true;
            this.btnTools.Click += new System.EventHandler(this.btnTools_Click);
            // 
            // btnMembers
            // 
            this.btnMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMembers.Location = new System.Drawing.Point(12, 207);
            this.btnMembers.Name = "btnMembers";
            this.btnMembers.Size = new System.Drawing.Size(150, 40);
            this.btnMembers.TabIndex = 3;
            this.btnMembers.Text = "CREATE / AMMEND MEMBER ACCOUNTS";
            this.btnMembers.UseVisualStyleBackColor = true;
            this.btnMembers.Click += new System.EventHandler(this.btnMembers_Click);
            // 
            // btnWorkspaces
            // 
            this.btnWorkspaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWorkspaces.Location = new System.Drawing.Point(177, 112);
            this.btnWorkspaces.Name = "btnWorkspaces";
            this.btnWorkspaces.Size = new System.Drawing.Size(120, 40);
            this.btnWorkspaces.TabIndex = 4;
            this.btnWorkspaces.Text = "Manage Workspaces";
            this.btnWorkspaces.UseVisualStyleBackColor = true;
            this.btnWorkspaces.Click += new System.EventHandler(this.btnWorkspaces_Click);
            // 
            // btnRentals
            // 
            this.btnRentals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRentals.Location = new System.Drawing.Point(177, 62);
            this.btnRentals.Name = "btnRentals";
            this.btnRentals.Size = new System.Drawing.Size(120, 40);
            this.btnRentals.TabIndex = 5;
            this.btnRentals.Text = "View Rental History";
            this.btnRentals.UseVisualStyleBackColor = true;
            this.btnRentals.Click += new System.EventHandler(this.btnRentals_Click);
            // 
            // btnNewRental
            // 
            this.btnNewRental.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewRental.Location = new System.Drawing.Point(12, 161);
            this.btnNewRental.Name = "btnNewRental";
            this.btnNewRental.Size = new System.Drawing.Size(150, 40);
            this.btnNewRental.TabIndex = 6;
            this.btnNewRental.Text = "CREATE / MANAGE TOOL RENTALS";
            this.btnNewRental.UseVisualStyleBackColor = true;
            this.btnNewRental.Click += new System.EventHandler(this.btnNewRental_Click);
            // 
            // btnReports
            // 
            this.btnReports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReports.Location = new System.Drawing.Point(177, 12);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(120, 40);
            this.btnReports.TabIndex = 7;
            this.btnReports.Text = "Generate Tool Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 313);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnNewRental);
            this.Controls.Add(this.btnRentals);
            this.Controls.Add(this.btnWorkspaces);
            this.Controls.Add(this.btnMembers);
            this.Controls.Add(this.btnTools);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool Rental";
            this.Activated += new System.EventHandler(this.frmMenu_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnTools;
        private System.Windows.Forms.Button btnMembers;
        private System.Windows.Forms.Button btnWorkspaces;
        private System.Windows.Forms.Button btnRentals;
        private System.Windows.Forms.Button btnNewRental;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

