namespace WinApp.Forms
{
    partial class MainForm
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
            this.navPanel = new System.Windows.Forms.Panel();
            this.navRegistration = new System.Windows.Forms.Button();
            this.navMatches = new System.Windows.Forms.Button();
            this.navTournaments = new System.Windows.Forms.Button();
            this.navHome = new System.Windows.Forms.Button();
            this.ucContainer = new System.Windows.Forms.Panel();
            this.navPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // navPanel
            // 
            this.navPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.navPanel.Controls.Add(this.navRegistration);
            this.navPanel.Controls.Add(this.navMatches);
            this.navPanel.Controls.Add(this.navTournaments);
            this.navPanel.Controls.Add(this.navHome);
            this.navPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.navPanel.Location = new System.Drawing.Point(0, 0);
            this.navPanel.Name = "navPanel";
            this.navPanel.Size = new System.Drawing.Size(231, 684);
            this.navPanel.TabIndex = 0;
            // 
            // navRegistration
            // 
            this.navRegistration.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.navRegistration.Location = new System.Drawing.Point(0, 441);
            this.navRegistration.Name = "navRegistration";
            this.navRegistration.Size = new System.Drawing.Size(231, 80);
            this.navRegistration.TabIndex = 3;
            this.navRegistration.Text = "Account Registration";
            this.navRegistration.UseVisualStyleBackColor = true;
            // 
            // navMatches
            // 
            this.navMatches.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.navMatches.Location = new System.Drawing.Point(0, 355);
            this.navMatches.Name = "navMatches";
            this.navMatches.Size = new System.Drawing.Size(231, 80);
            this.navMatches.TabIndex = 2;
            this.navMatches.Text = "Matches";
            this.navMatches.UseVisualStyleBackColor = true;
            this.navMatches.Click += new System.EventHandler(this.navMatches_Click);
            // 
            // navTournaments
            // 
            this.navTournaments.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.navTournaments.Location = new System.Drawing.Point(0, 269);
            this.navTournaments.Name = "navTournaments";
            this.navTournaments.Size = new System.Drawing.Size(231, 80);
            this.navTournaments.TabIndex = 1;
            this.navTournaments.Text = "Tournaments";
            this.navTournaments.UseVisualStyleBackColor = true;
            this.navTournaments.Click += new System.EventHandler(this.navTournaments_Click);
            // 
            // navHome
            // 
            this.navHome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.navHome.Location = new System.Drawing.Point(0, 183);
            this.navHome.Name = "navHome";
            this.navHome.Size = new System.Drawing.Size(231, 80);
            this.navHome.TabIndex = 0;
            this.navHome.Text = "Home";
            this.navHome.UseVisualStyleBackColor = true;
            this.navHome.Click += new System.EventHandler(this.navHome_Click);
            // 
            // ucContainer
            // 
            this.ucContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucContainer.Location = new System.Drawing.Point(231, 0);
            this.ucContainer.Margin = new System.Windows.Forms.Padding(0);
            this.ucContainer.Name = "ucContainer";
            this.ucContainer.Size = new System.Drawing.Size(902, 684);
            this.ucContainer.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1133, 684);
            this.Controls.Add(this.ucContainer);
            this.Controls.Add(this.navPanel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.navPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel navPanel;
        private Button navHome;
        private Button navRegistration;
        private Button navMatches;
        private Button navTournaments;
        private Pages.TournamentPage pageTournaments;
        private Panel ucContainer;
    }
}