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
            this.components = new System.ComponentModel.Container();
            this.navPanel = new System.Windows.Forms.Panel();
            this.NavRegistration = new System.Windows.Forms.Button();
            this.NavMatches = new System.Windows.Forms.Button();
            this.NavTournaments = new System.Windows.Forms.Button();
            this.NavHome = new System.Windows.Forms.Button();
            this.tabsControl = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.tabTournaments = new System.Windows.Forms.TabPage();
            this.dgvTournaments = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sportDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tournamentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gpbTournamentCreation = new System.Windows.Forms.GroupBox();
            this.btnCreateTournament = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.pickEndDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboTournamentSystem = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numMaxContestants = new System.Windows.Forms.NumericUpDown();
            this.numMinContestants = new System.Windows.Forms.NumericUpDown();
            this.inputAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.inputCity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.inputScoring = new System.Windows.Forms.TextBox();
            this.comboContestantType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.inputSport = new System.Windows.Forms.TextBox();
            this.inputDescription = new System.Windows.Forms.RichTextBox();
            this.inputTitle = new System.Windows.Forms.TextBox();
            this.pickStartDate = new System.Windows.Forms.DateTimePicker();
            this.tabMatches = new System.Windows.Forms.TabPage();
            this.tabAccounts = new System.Windows.Forms.TabPage();
            this.navPanel.SuspendLayout();
            this.tabsControl.SuspendLayout();
            this.tabTournaments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournaments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tournamentBindingSource)).BeginInit();
            this.gpbTournamentCreation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxContestants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinContestants)).BeginInit();
            this.SuspendLayout();
            // 
            // navPanel
            // 
            this.navPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.navPanel.Controls.Add(this.NavRegistration);
            this.navPanel.Controls.Add(this.NavMatches);
            this.navPanel.Controls.Add(this.NavTournaments);
            this.navPanel.Controls.Add(this.NavHome);
            this.navPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.navPanel.Location = new System.Drawing.Point(0, 0);
            this.navPanel.Name = "navPanel";
            this.navPanel.Size = new System.Drawing.Size(204, 684);
            this.navPanel.TabIndex = 0;
            // 
            // NavRegistration
            // 
            this.NavRegistration.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NavRegistration.Location = new System.Drawing.Point(0, 441);
            this.NavRegistration.Name = "NavRegistration";
            this.NavRegistration.Size = new System.Drawing.Size(204, 80);
            this.NavRegistration.TabIndex = 3;
            this.NavRegistration.Text = "Account Registration";
            this.NavRegistration.UseVisualStyleBackColor = true;
            this.NavRegistration.Click += new System.EventHandler(this.NavRegistration_Click);
            // 
            // NavMatches
            // 
            this.NavMatches.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NavMatches.Location = new System.Drawing.Point(0, 355);
            this.NavMatches.Name = "NavMatches";
            this.NavMatches.Size = new System.Drawing.Size(204, 80);
            this.NavMatches.TabIndex = 2;
            this.NavMatches.Text = "Matches";
            this.NavMatches.UseVisualStyleBackColor = true;
            this.NavMatches.Click += new System.EventHandler(this.NavMatches_Click);
            // 
            // NavTournaments
            // 
            this.NavTournaments.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NavTournaments.Location = new System.Drawing.Point(0, 269);
            this.NavTournaments.Name = "NavTournaments";
            this.NavTournaments.Size = new System.Drawing.Size(204, 80);
            this.NavTournaments.TabIndex = 1;
            this.NavTournaments.Text = "Tournaments";
            this.NavTournaments.UseVisualStyleBackColor = true;
            this.NavTournaments.Click += new System.EventHandler(this.NavTournaments_Click);
            // 
            // NavHome
            // 
            this.NavHome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NavHome.Location = new System.Drawing.Point(0, 183);
            this.NavHome.Name = "NavHome";
            this.NavHome.Size = new System.Drawing.Size(204, 80);
            this.NavHome.TabIndex = 0;
            this.NavHome.Text = "Home";
            this.NavHome.UseVisualStyleBackColor = true;
            this.NavHome.Click += new System.EventHandler(this.NavHome_Click);
            // 
            // tabsControl
            // 
            this.tabsControl.Controls.Add(this.tabHome);
            this.tabsControl.Controls.Add(this.tabTournaments);
            this.tabsControl.Controls.Add(this.tabMatches);
            this.tabsControl.Controls.Add(this.tabAccounts);
            this.tabsControl.Location = new System.Drawing.Point(210, 12);
            this.tabsControl.Name = "tabsControl";
            this.tabsControl.SelectedIndex = 0;
            this.tabsControl.Size = new System.Drawing.Size(946, 660);
            this.tabsControl.TabIndex = 1;
            // 
            // tabHome
            // 
            this.tabHome.Location = new System.Drawing.Point(4, 24);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(938, 632);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // tabTournaments
            // 
            this.tabTournaments.Controls.Add(this.dgvTournaments);
            this.tabTournaments.Controls.Add(this.groupBox1);
            this.tabTournaments.Controls.Add(this.gpbTournamentCreation);
            this.tabTournaments.Location = new System.Drawing.Point(4, 24);
            this.tabTournaments.Name = "tabTournaments";
            this.tabTournaments.Padding = new System.Windows.Forms.Padding(3);
            this.tabTournaments.Size = new System.Drawing.Size(938, 632);
            this.tabTournaments.TabIndex = 1;
            this.tabTournaments.Text = "Tournaments";
            this.tabTournaments.UseVisualStyleBackColor = true;
            // 
            // dgvTournaments
            // 
            this.dgvTournaments.AllowUserToAddRows = false;
            this.dgvTournaments.AllowUserToDeleteRows = false;
            this.dgvTournaments.AutoGenerateColumns = false;
            this.dgvTournaments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTournaments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.sportDataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dgvTournaments.DataSource = this.tournamentBindingSource;
            this.dgvTournaments.Location = new System.Drawing.Point(6, 6);
            this.dgvTournaments.MultiSelect = false;
            this.dgvTournaments.Name = "dgvTournaments";
            this.dgvTournaments.ReadOnly = true;
            this.dgvTournaments.RowTemplate.Height = 25;
            this.dgvTournaments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTournaments.Size = new System.Drawing.Size(565, 383);
            this.dgvTournaments.TabIndex = 3;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Width = 104;
            // 
            // sportDataGridViewTextBoxColumn
            // 
            this.sportDataGridViewTextBoxColumn.DataPropertyName = "Sport";
            this.sportDataGridViewTextBoxColumn.HeaderText = "Sport";
            this.sportDataGridViewTextBoxColumn.Name = "sportDataGridViewTextBoxColumn";
            this.sportDataGridViewTextBoxColumn.ReadOnly = true;
            this.sportDataGridViewTextBoxColumn.Width = 105;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            this.cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            this.cityDataGridViewTextBoxColumn.HeaderText = "City";
            this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            this.cityDataGridViewTextBoxColumn.ReadOnly = true;
            this.cityDataGridViewTextBoxColumn.Width = 104;
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "Start Date";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            this.startDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.startDateDataGridViewTextBoxColumn.Width = 105;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Tournament Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 104;
            // 
            // tournamentBindingSource
            // 
            this.tournamentBindingSource.DataSource = typeof(BLL.Objects.Tournament);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(6, 395);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(565, 231);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Tournament Status";
            // 
            // gpbTournamentCreation
            // 
            this.gpbTournamentCreation.Controls.Add(this.btnCreateTournament);
            this.gpbTournamentCreation.Controls.Add(this.label12);
            this.gpbTournamentCreation.Controls.Add(this.pickEndDate);
            this.gpbTournamentCreation.Controls.Add(this.label11);
            this.gpbTournamentCreation.Controls.Add(this.label10);
            this.gpbTournamentCreation.Controls.Add(this.comboTournamentSystem);
            this.gpbTournamentCreation.Controls.Add(this.label9);
            this.gpbTournamentCreation.Controls.Add(this.label8);
            this.gpbTournamentCreation.Controls.Add(this.numMaxContestants);
            this.gpbTournamentCreation.Controls.Add(this.numMinContestants);
            this.gpbTournamentCreation.Controls.Add(this.inputAddress);
            this.gpbTournamentCreation.Controls.Add(this.label7);
            this.gpbTournamentCreation.Controls.Add(this.inputCity);
            this.gpbTournamentCreation.Controls.Add(this.label6);
            this.gpbTournamentCreation.Controls.Add(this.label5);
            this.gpbTournamentCreation.Controls.Add(this.inputScoring);
            this.gpbTournamentCreation.Controls.Add(this.comboContestantType);
            this.gpbTournamentCreation.Controls.Add(this.label4);
            this.gpbTournamentCreation.Controls.Add(this.label3);
            this.gpbTournamentCreation.Controls.Add(this.label2);
            this.gpbTournamentCreation.Controls.Add(this.label1);
            this.gpbTournamentCreation.Controls.Add(this.inputSport);
            this.gpbTournamentCreation.Controls.Add(this.inputDescription);
            this.gpbTournamentCreation.Controls.Add(this.inputTitle);
            this.gpbTournamentCreation.Controls.Add(this.pickStartDate);
            this.gpbTournamentCreation.Location = new System.Drawing.Point(577, 6);
            this.gpbTournamentCreation.Name = "gpbTournamentCreation";
            this.gpbTournamentCreation.Size = new System.Drawing.Size(355, 620);
            this.gpbTournamentCreation.TabIndex = 1;
            this.gpbTournamentCreation.TabStop = false;
            this.gpbTournamentCreation.Text = "Create Tournament";
            // 
            // btnCreateTournament
            // 
            this.btnCreateTournament.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreateTournament.Location = new System.Drawing.Point(6, 538);
            this.btnCreateTournament.Name = "btnCreateTournament";
            this.btnCreateTournament.Size = new System.Drawing.Size(343, 76);
            this.btnCreateTournament.TabIndex = 2;
            this.btnCreateTournament.Text = "Create Tournament";
            this.btnCreateTournament.UseVisualStyleBackColor = true;
            this.btnCreateTournament.Click += new System.EventHandler(this.btnCreateTournament_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(190, 363);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 19);
            this.label12.TabIndex = 23;
            this.label12.Text = "End Date";
            // 
            // pickEndDate
            // 
            this.pickEndDate.Location = new System.Drawing.Point(190, 385);
            this.pickEndDate.Name = "pickEndDate";
            this.pickEndDate.Size = new System.Drawing.Size(159, 23);
            this.pickEndDate.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(6, 363);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 19);
            this.label11.TabIndex = 21;
            this.label11.Text = "Start Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(6, 475);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 19);
            this.label10.TabIndex = 20;
            this.label10.Text = "Tournament System";
            // 
            // comboTournamentSystem
            // 
            this.comboTournamentSystem.FormattingEnabled = true;
            this.comboTournamentSystem.Location = new System.Drawing.Point(6, 497);
            this.comboTournamentSystem.Name = "comboTournamentSystem";
            this.comboTournamentSystem.Size = new System.Drawing.Size(161, 23);
            this.comboTournamentSystem.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(190, 422);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "Maximum Contestants";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(6, 422);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 19);
            this.label8.TabIndex = 17;
            this.label8.Text = "Minimum Contestants";
            // 
            // numMaxContestants
            // 
            this.numMaxContestants.Location = new System.Drawing.Point(190, 444);
            this.numMaxContestants.Name = "numMaxContestants";
            this.numMaxContestants.Size = new System.Drawing.Size(75, 23);
            this.numMaxContestants.TabIndex = 16;
            // 
            // numMinContestants
            // 
            this.numMinContestants.Location = new System.Drawing.Point(6, 444);
            this.numMinContestants.Name = "numMinContestants";
            this.numMinContestants.Size = new System.Drawing.Size(75, 23);
            this.numMinContestants.TabIndex = 15;
            // 
            // inputAddress
            // 
            this.inputAddress.Location = new System.Drawing.Point(190, 326);
            this.inputAddress.Name = "inputAddress";
            this.inputAddress.Size = new System.Drawing.Size(159, 23);
            this.inputAddress.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(190, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "Address";
            // 
            // inputCity
            // 
            this.inputCity.Location = new System.Drawing.Point(6, 326);
            this.inputCity.Name = "inputCity";
            this.inputCity.Size = new System.Drawing.Size(159, 23);
            this.inputCity.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(6, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "City";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(190, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Contestant Type";
            // 
            // inputScoring
            // 
            this.inputScoring.Location = new System.Drawing.Point(190, 271);
            this.inputScoring.Name = "inputScoring";
            this.inputScoring.Size = new System.Drawing.Size(159, 23);
            this.inputScoring.TabIndex = 9;
            // 
            // comboContestantType
            // 
            this.comboContestantType.FormattingEnabled = true;
            this.comboContestantType.Location = new System.Drawing.Point(190, 497);
            this.comboContestantType.Name = "comboContestantType";
            this.comboContestantType.Size = new System.Drawing.Size(159, 23);
            this.comboContestantType.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(6, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sport";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(190, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Scoring System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(6, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Title";
            // 
            // inputSport
            // 
            this.inputSport.Location = new System.Drawing.Point(6, 271);
            this.inputSport.Name = "inputSport";
            this.inputSport.Size = new System.Drawing.Size(159, 23);
            this.inputSport.TabIndex = 3;
            // 
            // inputDescription
            // 
            this.inputDescription.Location = new System.Drawing.Point(6, 149);
            this.inputDescription.Name = "inputDescription";
            this.inputDescription.Size = new System.Drawing.Size(343, 96);
            this.inputDescription.TabIndex = 2;
            this.inputDescription.Text = "";
            // 
            // inputTitle
            // 
            this.inputTitle.Location = new System.Drawing.Point(6, 95);
            this.inputTitle.Name = "inputTitle";
            this.inputTitle.Size = new System.Drawing.Size(343, 23);
            this.inputTitle.TabIndex = 1;
            // 
            // pickStartDate
            // 
            this.pickStartDate.Location = new System.Drawing.Point(6, 385);
            this.pickStartDate.Name = "pickStartDate";
            this.pickStartDate.Size = new System.Drawing.Size(159, 23);
            this.pickStartDate.TabIndex = 0;
            // 
            // tabMatches
            // 
            this.tabMatches.Location = new System.Drawing.Point(4, 24);
            this.tabMatches.Name = "tabMatches";
            this.tabMatches.Size = new System.Drawing.Size(938, 632);
            this.tabMatches.TabIndex = 2;
            this.tabMatches.Text = "Matches";
            this.tabMatches.UseVisualStyleBackColor = true;
            // 
            // tabAccounts
            // 
            this.tabAccounts.Location = new System.Drawing.Point(4, 24);
            this.tabAccounts.Name = "tabAccounts";
            this.tabAccounts.Size = new System.Drawing.Size(938, 632);
            this.tabAccounts.TabIndex = 3;
            this.tabAccounts.Text = "Accounts";
            this.tabAccounts.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1168, 684);
            this.Controls.Add(this.tabsControl);
            this.Controls.Add(this.navPanel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.navPanel.ResumeLayout(false);
            this.tabsControl.ResumeLayout(false);
            this.tabTournaments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournaments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tournamentBindingSource)).EndInit();
            this.gpbTournamentCreation.ResumeLayout(false);
            this.gpbTournamentCreation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxContestants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinContestants)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel navPanel;
        private Button NavHome;
        private Button NavRegistration;
        private Button NavMatches;
        private Button NavTournaments;
        private TabControl tabsControl;
        private TabPage tabHome;
        private TabPage tabTournaments;
        private TabPage tabMatches;
        private TabPage tabAccounts;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn scoringDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn minContestantsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn maxContestantsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn systemDataGridViewTextBoxColumn;
        private GroupBox gpbTournamentCreation;
        private GroupBox groupBox1;
        private TextBox inputSport;
        private RichTextBox inputDescription;
        private TextBox inputTitle;
        private DateTimePicker pickStartDate;
        private Label label12;
        private DateTimePicker pickEndDate;
        private Label label11;
        private Label label10;
        private ComboBox comboTournamentSystem;
        private Label label9;
        private Label label8;
        private NumericUpDown numMaxContestants;
        private NumericUpDown numMinContestants;
        private TextBox inputAddress;
        private Label label7;
        private TextBox inputCity;
        private Label label6;
        private Label label5;
        private TextBox inputScoring;
        private ComboBox comboContestantType;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnCreateTournament;
        private DataGridView dgvTournaments;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sportDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private BindingSource tournamentBindingSource;
    }
}