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
            this.button1 = new System.Windows.Forms.Button();
            this.NavRegistration = new System.Windows.Forms.Button();
            this.NavMatches = new System.Windows.Forms.Button();
            this.NavTournaments = new System.Windows.Forms.Button();
            this.NavHome = new System.Windows.Forms.Button();
            this.tabsControl = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.tabTournaments = new System.Windows.Forms.TabPage();
            this.dgvTournaments = new System.Windows.Forms.DataGridView();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sportDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tournamentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelTournament = new System.Windows.Forms.Button();
            this.btnDeleteTournament = new System.Windows.Forms.Button();
            this.btnFinishTournament = new System.Windows.Forms.Button();
            this.btnStartTournament = new System.Windows.Forms.Button();
            this.gpbTournamentCreation = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
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
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnPlayMatch = new System.Windows.Forms.Button();
            this.btnGenerateMatches = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.dgvTournamentMatches = new System.Windows.Forms.DataGridView();
            this.homeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.awayNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.homeScoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.awayScoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isFinishedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.matchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabAccounts = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGeneratePassword = new System.Windows.Forms.Button();
            this.btnRegisterAccount = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.inputName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.inputSurname = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.inputEmail = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.comboRoles = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.inputPassword = new System.Windows.Forms.TextBox();
            this.comboTypes = new System.Windows.Forms.ComboBox();
            this.navPanel.SuspendLayout();
            this.tabsControl.SuspendLayout();
            this.tabTournaments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournaments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tournamentBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gpbTournamentCreation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxContestants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinContestants)).BeginInit();
            this.tabMatches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournamentMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchBindingSource)).BeginInit();
            this.tabAccounts.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // navPanel
            // 
            this.navPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.navPanel.Controls.Add(this.button1);
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Image = global::WinApp.Properties.Resources.logout;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(0, 604);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 80);
            this.button1.TabIndex = 4;
            this.button1.Text = "Log Out";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // NavRegistration
            // 
            this.NavRegistration.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NavRegistration.Image = global::WinApp.Properties.Resources.registration;
            this.NavRegistration.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NavRegistration.Location = new System.Drawing.Point(0, 441);
            this.NavRegistration.Name = "NavRegistration";
            this.NavRegistration.Size = new System.Drawing.Size(204, 80);
            this.NavRegistration.TabIndex = 3;
            this.NavRegistration.Text = "Account Registration";
            this.NavRegistration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NavRegistration.UseVisualStyleBackColor = true;
            this.NavRegistration.Click += new System.EventHandler(this.NavRegistration_Click);
            // 
            // NavMatches
            // 
            this.NavMatches.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NavMatches.Image = global::WinApp.Properties.Resources.matches;
            this.NavMatches.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NavMatches.Location = new System.Drawing.Point(0, 355);
            this.NavMatches.Name = "NavMatches";
            this.NavMatches.Size = new System.Drawing.Size(204, 80);
            this.NavMatches.TabIndex = 2;
            this.NavMatches.Text = "Matches";
            this.NavMatches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NavMatches.UseVisualStyleBackColor = true;
            this.NavMatches.Click += new System.EventHandler(this.NavMatches_Click);
            // 
            // NavTournaments
            // 
            this.NavTournaments.FlatAppearance.BorderSize = 0;
            this.NavTournaments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NavTournaments.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NavTournaments.Image = global::WinApp.Properties.Resources.tournaments;
            this.NavTournaments.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NavTournaments.Location = new System.Drawing.Point(0, 242);
            this.NavTournaments.Margin = new System.Windows.Forms.Padding(0);
            this.NavTournaments.Name = "NavTournaments";
            this.NavTournaments.Size = new System.Drawing.Size(204, 80);
            this.NavTournaments.TabIndex = 1;
            this.NavTournaments.Text = "Tournaments";
            this.NavTournaments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NavTournaments.UseVisualStyleBackColor = true;
            this.NavTournaments.Click += new System.EventHandler(this.NavTournaments_Click);
            // 
            // NavHome
            // 
            this.NavHome.FlatAppearance.BorderSize = 0;
            this.NavHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NavHome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NavHome.Image = global::WinApp.Properties.Resources.home;
            this.NavHome.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NavHome.Location = new System.Drawing.Point(0, 162);
            this.NavHome.Margin = new System.Windows.Forms.Padding(0);
            this.NavHome.Name = "NavHome";
            this.NavHome.Size = new System.Drawing.Size(204, 80);
            this.NavHome.TabIndex = 0;
            this.NavHome.Text = "Home";
            this.NavHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dgvTournaments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTournaments_CellClick);
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
            this.groupBox1.Controls.Add(this.btnCancelTournament);
            this.groupBox1.Controls.Add(this.btnDeleteTournament);
            this.groupBox1.Controls.Add(this.btnFinishTournament);
            this.groupBox1.Controls.Add(this.btnStartTournament);
            this.groupBox1.Location = new System.Drawing.Point(310, 395);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 231);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Tournament Status";
            // 
            // btnCancelTournament
            // 
            this.btnCancelTournament.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelTournament.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnCancelTournament.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnCancelTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelTournament.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelTournament.ForeColor = System.Drawing.Color.Red;
            this.btnCancelTournament.Location = new System.Drawing.Point(49, 126);
            this.btnCancelTournament.Name = "btnCancelTournament";
            this.btnCancelTournament.Size = new System.Drawing.Size(165, 41);
            this.btnCancelTournament.TabIndex = 28;
            this.btnCancelTournament.Text = "Cancel Tournament";
            this.btnCancelTournament.UseVisualStyleBackColor = false;
            // 
            // btnDeleteTournament
            // 
            this.btnDeleteTournament.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeleteTournament.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnDeleteTournament.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnDeleteTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTournament.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteTournament.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteTournament.Location = new System.Drawing.Point(49, 173);
            this.btnDeleteTournament.Name = "btnDeleteTournament";
            this.btnDeleteTournament.Size = new System.Drawing.Size(165, 41);
            this.btnDeleteTournament.TabIndex = 25;
            this.btnDeleteTournament.Text = "Delete Tournament";
            this.btnDeleteTournament.UseVisualStyleBackColor = false;
            // 
            // btnFinishTournament
            // 
            this.btnFinishTournament.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFinishTournament.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.btnFinishTournament.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnFinishTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinishTournament.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFinishTournament.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnFinishTournament.Location = new System.Drawing.Point(49, 79);
            this.btnFinishTournament.Name = "btnFinishTournament";
            this.btnFinishTournament.Size = new System.Drawing.Size(165, 41);
            this.btnFinishTournament.TabIndex = 26;
            this.btnFinishTournament.Text = "Finish Tournament";
            this.btnFinishTournament.UseVisualStyleBackColor = false;
            // 
            // btnStartTournament
            // 
            this.btnStartTournament.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnStartTournament.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnStartTournament.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnStartTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartTournament.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStartTournament.ForeColor = System.Drawing.Color.Green;
            this.btnStartTournament.Location = new System.Drawing.Point(49, 32);
            this.btnStartTournament.Name = "btnStartTournament";
            this.btnStartTournament.Size = new System.Drawing.Size(165, 41);
            this.btnStartTournament.TabIndex = 26;
            this.btnStartTournament.Text = "Start Tournament";
            this.btnStartTournament.UseVisualStyleBackColor = false;
            this.btnStartTournament.Click += new System.EventHandler(this.btnStartTournament_Click);
            // 
            // gpbTournamentCreation
            // 
            this.gpbTournamentCreation.Controls.Add(this.button2);
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
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.DarkOrange;
            this.button2.Location = new System.Drawing.Point(190, 487);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 127);
            this.button2.TabIndex = 24;
            this.button2.Text = "Adjust Tournament";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnCreateTournament
            // 
            this.btnCreateTournament.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCreateTournament.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnCreateTournament.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCreateTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTournament.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreateTournament.ForeColor = System.Drawing.Color.Green;
            this.btnCreateTournament.Location = new System.Drawing.Point(6, 487);
            this.btnCreateTournament.Name = "btnCreateTournament";
            this.btnCreateTournament.Size = new System.Drawing.Size(161, 127);
            this.btnCreateTournament.TabIndex = 2;
            this.btnCreateTournament.Text = "Create Tournament";
            this.btnCreateTournament.UseVisualStyleBackColor = false;
            this.btnCreateTournament.Click += new System.EventHandler(this.btnCreateTournament_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(190, 312);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 19);
            this.label12.TabIndex = 23;
            this.label12.Text = "End Date";
            // 
            // pickEndDate
            // 
            this.pickEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pickEndDate.Location = new System.Drawing.Point(190, 334);
            this.pickEndDate.Name = "pickEndDate";
            this.pickEndDate.Size = new System.Drawing.Size(159, 23);
            this.pickEndDate.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(6, 312);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 19);
            this.label11.TabIndex = 21;
            this.label11.Text = "Start Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(6, 424);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 19);
            this.label10.TabIndex = 20;
            this.label10.Text = "Tournament System";
            // 
            // comboTournamentSystem
            // 
            this.comboTournamentSystem.FormattingEnabled = true;
            this.comboTournamentSystem.Location = new System.Drawing.Point(6, 446);
            this.comboTournamentSystem.Name = "comboTournamentSystem";
            this.comboTournamentSystem.Size = new System.Drawing.Size(161, 23);
            this.comboTournamentSystem.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(190, 371);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "Maximum Contestants";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(6, 371);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 19);
            this.label8.TabIndex = 17;
            this.label8.Text = "Minimum Contestants";
            // 
            // numMaxContestants
            // 
            this.numMaxContestants.Location = new System.Drawing.Point(190, 393);
            this.numMaxContestants.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMaxContestants.Name = "numMaxContestants";
            this.numMaxContestants.Size = new System.Drawing.Size(75, 23);
            this.numMaxContestants.TabIndex = 16;
            this.numMaxContestants.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numMinContestants
            // 
            this.numMinContestants.Location = new System.Drawing.Point(6, 393);
            this.numMinContestants.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMinContestants.Name = "numMinContestants";
            this.numMinContestants.Size = new System.Drawing.Size(75, 23);
            this.numMinContestants.TabIndex = 15;
            this.numMinContestants.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // inputAddress
            // 
            this.inputAddress.Location = new System.Drawing.Point(190, 275);
            this.inputAddress.Name = "inputAddress";
            this.inputAddress.Size = new System.Drawing.Size(159, 23);
            this.inputAddress.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(190, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "Address";
            // 
            // inputCity
            // 
            this.inputCity.Location = new System.Drawing.Point(6, 275);
            this.inputCity.Name = "inputCity";
            this.inputCity.Size = new System.Drawing.Size(161, 23);
            this.inputCity.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(6, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "City";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(190, 424);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Contestant Type";
            // 
            // inputScoring
            // 
            this.inputScoring.Location = new System.Drawing.Point(190, 220);
            this.inputScoring.Name = "inputScoring";
            this.inputScoring.Size = new System.Drawing.Size(159, 23);
            this.inputScoring.TabIndex = 9;
            // 
            // comboContestantType
            // 
            this.comboContestantType.FormattingEnabled = true;
            this.comboContestantType.Location = new System.Drawing.Point(190, 446);
            this.comboContestantType.Name = "comboContestantType";
            this.comboContestantType.Size = new System.Drawing.Size(159, 23);
            this.comboContestantType.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(6, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sport";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(190, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Scoring System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Title";
            // 
            // inputSport
            // 
            this.inputSport.Location = new System.Drawing.Point(6, 220);
            this.inputSport.Name = "inputSport";
            this.inputSport.Size = new System.Drawing.Size(161, 23);
            this.inputSport.TabIndex = 3;
            // 
            // inputDescription
            // 
            this.inputDescription.Location = new System.Drawing.Point(6, 98);
            this.inputDescription.Name = "inputDescription";
            this.inputDescription.Size = new System.Drawing.Size(343, 96);
            this.inputDescription.TabIndex = 2;
            this.inputDescription.Text = "";
            // 
            // inputTitle
            // 
            this.inputTitle.Location = new System.Drawing.Point(6, 44);
            this.inputTitle.Name = "inputTitle";
            this.inputTitle.Size = new System.Drawing.Size(343, 23);
            this.inputTitle.TabIndex = 1;
            // 
            // pickStartDate
            // 
            this.pickStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pickStartDate.Location = new System.Drawing.Point(6, 334);
            this.pickStartDate.Name = "pickStartDate";
            this.pickStartDate.Size = new System.Drawing.Size(161, 23);
            this.pickStartDate.TabIndex = 0;
            // 
            // tabMatches
            // 
            this.tabMatches.Controls.Add(this.label20);
            this.tabMatches.Controls.Add(this.label19);
            this.tabMatches.Controls.Add(this.btnPlayMatch);
            this.tabMatches.Controls.Add(this.btnGenerateMatches);
            this.tabMatches.Controls.Add(this.listView1);
            this.tabMatches.Controls.Add(this.dgvTournamentMatches);
            this.tabMatches.Location = new System.Drawing.Point(4, 24);
            this.tabMatches.Name = "tabMatches";
            this.tabMatches.Size = new System.Drawing.Size(938, 632);
            this.tabMatches.TabIndex = 2;
            this.tabMatches.Text = "Matches";
            this.tabMatches.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label20.Location = new System.Drawing.Point(125, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 21);
            this.label20.TabIndex = 6;
            this.label20.Text = "Tournaments:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(577, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(158, 21);
            this.label19.TabIndex = 5;
            this.label19.Text = "Tournament matches:";
            // 
            // btnPlayMatch
            // 
            this.btnPlayMatch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPlayMatch.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnPlayMatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPlayMatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayMatch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPlayMatch.ForeColor = System.Drawing.Color.Green;
            this.btnPlayMatch.Location = new System.Drawing.Point(517, 422);
            this.btnPlayMatch.Name = "btnPlayMatch";
            this.btnPlayMatch.Size = new System.Drawing.Size(277, 75);
            this.btnPlayMatch.TabIndex = 4;
            this.btnPlayMatch.Text = "Play Match";
            this.btnPlayMatch.UseVisualStyleBackColor = false;
            // 
            // btnGenerateMatches
            // 
            this.btnGenerateMatches.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerateMatches.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnGenerateMatches.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGenerateMatches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateMatches.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGenerateMatches.ForeColor = System.Drawing.Color.Green;
            this.btnGenerateMatches.Location = new System.Drawing.Point(39, 422);
            this.btnGenerateMatches.Name = "btnGenerateMatches";
            this.btnGenerateMatches.Size = new System.Drawing.Size(277, 75);
            this.btnGenerateMatches.TabIndex = 3;
            this.btnGenerateMatches.Text = "Generate Matches";
            this.btnGenerateMatches.UseVisualStyleBackColor = false;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(3, 35);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(367, 381);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // dgvTournamentMatches
            // 
            this.dgvTournamentMatches.AllowUserToAddRows = false;
            this.dgvTournamentMatches.AllowUserToDeleteRows = false;
            this.dgvTournamentMatches.AutoGenerateColumns = false;
            this.dgvTournamentMatches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTournamentMatches.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTournamentMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTournamentMatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.homeNameDataGridViewTextBoxColumn,
            this.awayNameDataGridViewTextBoxColumn,
            this.homeScoreDataGridViewTextBoxColumn,
            this.awayScoreDataGridViewTextBoxColumn,
            this.isFinishedDataGridViewCheckBoxColumn});
            this.dgvTournamentMatches.DataSource = this.matchBindingSource;
            this.dgvTournamentMatches.Location = new System.Drawing.Point(376, 35);
            this.dgvTournamentMatches.MultiSelect = false;
            this.dgvTournamentMatches.Name = "dgvTournamentMatches";
            this.dgvTournamentMatches.ReadOnly = true;
            this.dgvTournamentMatches.RowTemplate.Height = 25;
            this.dgvTournamentMatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTournamentMatches.Size = new System.Drawing.Size(559, 381);
            this.dgvTournamentMatches.TabIndex = 0;
            // 
            // homeNameDataGridViewTextBoxColumn
            // 
            this.homeNameDataGridViewTextBoxColumn.DataPropertyName = "HomeName";
            this.homeNameDataGridViewTextBoxColumn.HeaderText = "Home Player";
            this.homeNameDataGridViewTextBoxColumn.Name = "homeNameDataGridViewTextBoxColumn";
            this.homeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // awayNameDataGridViewTextBoxColumn
            // 
            this.awayNameDataGridViewTextBoxColumn.DataPropertyName = "AwayName";
            this.awayNameDataGridViewTextBoxColumn.HeaderText = "Away Player";
            this.awayNameDataGridViewTextBoxColumn.Name = "awayNameDataGridViewTextBoxColumn";
            this.awayNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // homeScoreDataGridViewTextBoxColumn
            // 
            this.homeScoreDataGridViewTextBoxColumn.DataPropertyName = "HomeScore";
            this.homeScoreDataGridViewTextBoxColumn.HeaderText = "Home Score";
            this.homeScoreDataGridViewTextBoxColumn.Name = "homeScoreDataGridViewTextBoxColumn";
            this.homeScoreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // awayScoreDataGridViewTextBoxColumn
            // 
            this.awayScoreDataGridViewTextBoxColumn.DataPropertyName = "AwayScore";
            this.awayScoreDataGridViewTextBoxColumn.HeaderText = "Away Score";
            this.awayScoreDataGridViewTextBoxColumn.Name = "awayScoreDataGridViewTextBoxColumn";
            this.awayScoreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isFinishedDataGridViewCheckBoxColumn
            // 
            this.isFinishedDataGridViewCheckBoxColumn.DataPropertyName = "IsFinished";
            this.isFinishedDataGridViewCheckBoxColumn.HeaderText = "Match Finished";
            this.isFinishedDataGridViewCheckBoxColumn.Name = "isFinishedDataGridViewCheckBoxColumn";
            this.isFinishedDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // matchBindingSource
            // 
            this.matchBindingSource.DataSource = typeof(BLL.Objects.Match);
            // 
            // tabAccounts
            // 
            this.tabAccounts.Controls.Add(this.groupBox2);
            this.tabAccounts.Location = new System.Drawing.Point(4, 24);
            this.tabAccounts.Name = "tabAccounts";
            this.tabAccounts.Size = new System.Drawing.Size(938, 632);
            this.tabAccounts.TabIndex = 3;
            this.tabAccounts.Text = "Accounts";
            this.tabAccounts.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGeneratePassword);
            this.groupBox2.Controls.Add(this.btnRegisterAccount);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.inputName);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.inputSurname);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.inputEmail);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.comboRoles);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.inputPassword);
            this.groupBox2.Controls.Add(this.comboTypes);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 375);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account Registration";
            // 
            // btnGeneratePassword
            // 
            this.btnGeneratePassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGeneratePassword.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.btnGeneratePassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnGeneratePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneratePassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGeneratePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGeneratePassword.Location = new System.Drawing.Point(297, 172);
            this.btnGeneratePassword.Name = "btnGeneratePassword";
            this.btnGeneratePassword.Size = new System.Drawing.Size(119, 23);
            this.btnGeneratePassword.TabIndex = 27;
            this.btnGeneratePassword.Text = "Generate Password";
            this.btnGeneratePassword.UseVisualStyleBackColor = false;
            // 
            // btnRegisterAccount
            // 
            this.btnRegisterAccount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegisterAccount.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnRegisterAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRegisterAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRegisterAccount.ForeColor = System.Drawing.Color.Green;
            this.btnRegisterAccount.Location = new System.Drawing.Point(142, 274);
            this.btnRegisterAccount.Name = "btnRegisterAccount";
            this.btnRegisterAccount.Size = new System.Drawing.Size(149, 54);
            this.btnRegisterAccount.TabIndex = 24;
            this.btnRegisterAccount.Text = "Register Account";
            this.btnRegisterAccount.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(34, 86);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 19);
            this.label13.TabIndex = 18;
            this.label13.Text = "(Team) Name: *";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(34, 231);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(103, 19);
            this.label18.TabIndex = 23;
            this.label18.Text = "Account type: *";
            // 
            // inputName
            // 
            this.inputName.Location = new System.Drawing.Point(142, 85);
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(149, 23);
            this.inputName.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(34, 202);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 19);
            this.label17.TabIndex = 22;
            this.label17.Text = "Role: *";
            // 
            // inputSurname
            // 
            this.inputSurname.Location = new System.Drawing.Point(142, 114);
            this.inputSurname.Name = "inputSurname";
            this.inputSurname.Size = new System.Drawing.Size(149, 23);
            this.inputSurname.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(34, 173);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 19);
            this.label16.TabIndex = 21;
            this.label16.Text = "Password: *";
            // 
            // inputEmail
            // 
            this.inputEmail.Location = new System.Drawing.Point(142, 143);
            this.inputEmail.Name = "inputEmail";
            this.inputEmail.Size = new System.Drawing.Size(149, 23);
            this.inputEmail.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(34, 144);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 19);
            this.label15.TabIndex = 20;
            this.label15.Text = "Email: *";
            // 
            // comboRoles
            // 
            this.comboRoles.FormattingEnabled = true;
            this.comboRoles.Location = new System.Drawing.Point(142, 201);
            this.comboRoles.Name = "comboRoles";
            this.comboRoles.Size = new System.Drawing.Size(149, 23);
            this.comboRoles.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(34, 115);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 19);
            this.label14.TabIndex = 19;
            this.label14.Text = "Surname:";
            // 
            // inputPassword
            // 
            this.inputPassword.Location = new System.Drawing.Point(142, 172);
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.Size = new System.Drawing.Size(149, 23);
            this.inputPassword.TabIndex = 4;
            // 
            // comboTypes
            // 
            this.comboTypes.FormattingEnabled = true;
            this.comboTypes.Location = new System.Drawing.Point(142, 230);
            this.comboTypes.Name = "comboTypes";
            this.comboTypes.Size = new System.Drawing.Size(149, 23);
            this.comboTypes.TabIndex = 5;
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
            this.groupBox1.ResumeLayout(false);
            this.gpbTournamentCreation.ResumeLayout(false);
            this.gpbTournamentCreation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxContestants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinContestants)).EndInit();
            this.tabMatches.ResumeLayout(false);
            this.tabMatches.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournamentMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchBindingSource)).EndInit();
            this.tabAccounts.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private Button btnDeleteTournament;
        private Button btnStartTournament;
        private Button btnCancelTournament;
        private Button btnFinishTournament;
        private Button button2;
        private DataGridView dgvTournamentMatches;
        private BindingSource matchBindingSource;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
        private TextBox inputPassword;
        private ComboBox comboRoles;
        private TextBox inputEmail;
        private TextBox inputSurname;
        private TextBox inputName;
        private ComboBox comboTypes;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private GroupBox groupBox2;
        private Button btnRegisterAccount;
        private Button btnGeneratePassword;
        private ListView listView1;
        private DataGridViewTextBoxColumn homeNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn awayNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn homeScoreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn awayScoreDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isFinishedDataGridViewCheckBoxColumn;
        private Button btnGenerateMatches;
        private Button btnPlayMatch;
        private Label label20;
        private Label label19;
        private Button button1;
    }
}