using BLL.Enums;
using BLL.Registries;
using DAL.Repositories;
using DAL;
using BLL.Objects;
using BLL.Objects.Users;
using System.ComponentModel.DataAnnotations;
using System.Data;
using BLL.Objects.Assigners;
using BLL.Validation.Exceptions;

namespace WinApp.Forms
{
    public partial class MainForm : Form
    {
        private Account ActiveUser { get; }

        private MatchForm? matchForm;

        private TournamentRegistry tournamentRegistry;
        private UserRegistry userRegistry;
        private MatchRegistry matchRegistry;
        private ContestantRegistry contestantRegistry;
        private SportAssigner sportAssigner;
        private TournamentSystemAssigner tournamentSystemAssigner;

        public MainForm(Account account)
        {
            InitializeComponent();
            ActiveUser = account;

            tournamentRegistry = new TournamentRegistry(new TournamentRepository(new DbContext()));
            userRegistry = new UserRegistry(new UserRepository(new DbContext()));
            matchRegistry = new MatchRegistry(new MatchRepository(new DbContext()));
            contestantRegistry = new ContestantRegistry(new ContestantRepository(new DbContext()));

            sportAssigner = new SportAssigner();
            tournamentSystemAssigner = new TournamentSystemAssigner();

            RefreshTournaments();
            SetupFormGUI();
        }

        #region FORM GUI

        public void SetupFormGUI()
        {
            //Disable standard tab controls
            tabsControl.Appearance = TabAppearance.FlatButtons;
            tabsControl.ItemSize = new Size(0, 1);
            tabsControl.SizeMode = TabSizeMode.Fixed;

            //Set format of datetime pickers
            pickStartDate.MinDate = DateTime.Now.Date;
            pickStartDate.CustomFormat = "dddd dd MMMM";
            pickEndDate.MinDate = DateTime.Now.Date;
            pickEndDate.CustomFormat = "dddd dd MMMM";

            //Setup combo boxes with enum values
            comboTeamType.DataSource = Enum.GetValues(typeof(TeamType));
            comboTypes.DataSource = Enum.GetValues(typeof(TeamType));
            
            //Any account that isn't an administrator cannot create administrator accounts
            if(ActiveUser.Role == UserRole.Administrator)
            {
                comboRoles.DataSource = Enum.GetValues(typeof(UserRole));
            }
            else
            {
                comboRoles.DataSource = Enum.GetValues(typeof(UserRole))
                    .Cast<UserRole>()
                    .Where(role => role != UserRole.Administrator)
                    .ToList();
            }

            comboSport.DataSource = sportAssigner.GetNames();
            comboTournamentSystem.DataSource = tournamentSystemAssigner.GetNames();

            lblUserName.Text = string.Concat(ActiveUser.Name, " ",ActiveUser.SurName);
            lblWelcome.Text = $"Welcome {string.Concat(ActiveUser.Name, " ", ActiveUser.SurName)}!";
        }
        private void RefreshTournaments()
        {
            dgvTournaments.DataSource = tournamentRegistry.GetAll(false);
            dgvActiveTournaments.DataSource = tournamentRegistry.GetActiveTournaments();
        }

        private void RefreshMatches(int tournamentID)
        {
            dgvTournamentMatches.DataSource = matchRegistry.GetMatches(tournamentID);
        }

        private void ResetTournamentInputFields()
        {
            if (btnUpdateTournament.Enabled)
            {
                btnUpdateTournament.Enabled = false;
                btnCreateTournament.Enabled = true;
                numMinContestants.Enabled = true;
                numMaxContestants.Enabled = true;
                gpbTournamentUpdateStatus.Enabled = true;
                gpbModifyTournament.Enabled = true;
                pickStartDate.MinDate = DateTime.Now;
                pickEndDate.MinDate = DateTime.Now;
                comboTeamType.Enabled = true;
                comboTournamentSystem.Enabled = true;
                comboSport.Enabled = true;
                gpbTournamentCreation.Text = "Create Tournament";
            }

            numMinContestants.Value = numMinContestants.Minimum;
            numMaxContestants.Value = numMaxContestants.Minimum;
            pickStartDate.Value = DateTime.Now;
            pickEndDate.Value = DateTime.Now;
            comboTeamType.SelectedIndex = 0;
            comboTournamentSystem.SelectedIndex = 0;
            comboSport.SelectedIndex = 0;

            inputTitle.Clear();
            inputDescription.Clear();
            inputCity.Clear();
            inputAddress.Clear();
        }

        private int GetIDFromDataGridView(DataGridView dgv, string columnName)
        {
            return Convert.ToInt32(dgv.SelectedRows[0].Cells[columnName].Value);
        }

        private void ToggleTournamentStatusButtons(TournamentStatus status)
        {
            btnStartTournament.Enabled = status == TournamentStatus.Planned;
            btnFinishTournament.Enabled = status == TournamentStatus.Running;
            btnCancelTournament.Enabled = status != TournamentStatus.Cancelled && status != TournamentStatus.Finished;
        }
        #endregion

        #region FORM NAVIGATION

        private void SwitchTab(TabPage tab)
        {
            tabsControl.SelectedTab = tab;
        }

        private void NavHome_Click(object sender, EventArgs e)
        {
            SwitchTab(tabHome);
        }

        private void NavTournaments_Click(object sender, EventArgs e)
        {
            SwitchTab(tabTournaments);
        }

        private void NavMatches_Click(object sender, EventArgs e)
        {
            SwitchTab(tabMatches);
        }

        private void NavRegistration_Click(object sender, EventArgs e)
        {
            SwitchTab(tabAccounts);
        }

        private void NavLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion

        #region DATAGRIDVIEWS

        private void dgvTournaments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTournaments.SelectedRows.Count > 0)
            {
                int id = GetIDFromDataGridView(dgvTournaments, "dgvColAllTournamentsID");
                ToggleTournamentStatusButtons(tournamentRegistry.GetByID(id)!.Status);
                if (btnUpdateTournament.Enabled)
                {
                    ResetTournamentInputFields();
                }
            }
            else
            {
                gpbTournamentUpdateStatus.Enabled = false;
                gpbModifyTournament.Enabled = false;
            }
        }

        private void dgvActiveTournaments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvActiveTournaments.SelectedRows.Count > 0)
            {
                int id = GetIDFromDataGridView(dgvActiveTournaments, "dgvColActiveTournamentsID");
                RefreshMatches(id);
            }
        }
        private void dgvTournaments_SelectionChanged(object sender, EventArgs e)
        {
            if (!gpbTournamentUpdateStatus.Enabled) gpbTournamentUpdateStatus.Enabled = true;
        }

        #endregion

        #region TOURNAMENT CRUD
        private void btnCreateTournament_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = tournamentRegistry.CreateTournament(new Tournament()
                {
                    Title = inputTitle.Text,
                    Description = inputDescription.Text,
                    Sport = sportAssigner.Retrieve(comboSport.SelectedIndex),
                    City = inputCity.Text,
                    Address = inputAddress.Text,
                    StartDate = pickStartDate.Value.Date,
                    EndDate = pickEndDate.Value.Date,
                    MinContestants = Convert.ToInt32(numMinContestants.Value),
                    MaxContestants = Convert.ToInt32(numMaxContestants.Value),
                    System = tournamentSystemAssigner.Retrieve(comboTournamentSystem.SelectedIndex),
                    Type = (TeamType)Enum.Parse(typeof(TeamType), comboTeamType.Text),
                    Status = TournamentStatus.Planned
                }); ;
                if (result)
                {
                    MessageBox.Show("Tournament successfully created!");
                    ResetTournamentInputFields();
                    RefreshTournaments();
                }
                else
                {
                    MessageBox.Show("Couldn't create tournament, please try again later.");
                }
            }
            catch(ValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(ArgumentException)
            {
                MessageBox.Show("One of the dropdown boxes contained an invalid value, please enter a valid value.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "An unknown error occured:");
            }
            gpbTournamentUpdateStatus.Enabled = false;
        }

        private void btnUpdateTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows.Count > 0)
            {
                int id = GetIDFromDataGridView(dgvTournaments, "dgvColAllTournamentsID");
                Tournament? tournament = tournamentRegistry.GetByID(id);

                if (tournament != null)
                {
                    try
                    {
                        bool result = tournamentRegistry.UpdateTournament(new Tournament()
                        {
                            ID = tournament.ID,
                            Title = inputTitle.Text,
                            Description = inputDescription.Text,
                            Sport = tournament.Sport,
                            City = inputCity.Text,
                            Address = inputAddress.Text,
                            StartDate = pickStartDate.Value,
                            EndDate = pickEndDate.Value,
                            MinContestants = Convert.ToInt32(numMinContestants.Value),
                            MaxContestants = Convert.ToInt32(numMaxContestants.Value),
                            System = comboTournamentSystem.Enabled ? tournamentSystemAssigner.Retrieve(comboTournamentSystem.SelectedIndex) : tournament.System,
                            Type = tournament.Type,
                            Status = tournament.Status
                        });
                        if (result)
                        {
                            MessageBox.Show("Tournament updated!");
                            ResetTournamentInputFields();
                            RefreshTournaments();
                        }
                        else
                        {
                            MessageBox.Show("Couldn't update tournament, please try again later.");
                        }
                    }
                    catch (ValidationException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("One of the dropdown boxes contained an invalid value, please enter a valid value.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "An unknown error occured:");
                    }
                }
            }
            gpbTournamentUpdateStatus.Enabled = false;
        }


        private void btnAdjustTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows.Count > 0)
            {
                int id = GetIDFromDataGridView(dgvTournaments, "dgvColAllTournamentsID");
                Tournament? tournament = tournamentRegistry.GetByID(id);
                if (tournament != null)
                {
                    gpbTournamentUpdateStatus.Enabled = false;
                    gpbModifyTournament.Enabled = false;
                    btnCreateTournament.Enabled = false;
                    btnUpdateTournament.Enabled = true;
                    comboTeamType.Enabled = false;
                    comboTeamType.SelectedItem = tournament.Type;
                    comboSport.Enabled = false;
                    comboSport.SelectedItem = tournament.SportName;
                    comboTournamentSystem.SelectedItem = tournament.SystemName;
                    gpbTournamentCreation.Text = "Adjust Tournament";

                    inputTitle.Text = tournament.Title;
                    inputDescription.Text = tournament.Description;
                    inputCity.Text = tournament.City;
                    inputAddress.Text = tournament.Address;
                    pickStartDate.MinDate = (tournament.StartDate < DateTime.Now) ? tournament.StartDate : DateTime.Now;
                    pickStartDate.Value = tournament.StartDate;
                    pickEndDate.MinDate = (tournament.StartDate < DateTime.Now) ? tournament.StartDate : DateTime.Now;
                    pickEndDate.Value = tournament.EndDate;
                    numMinContestants.Value = tournament.MinContestants;
                    numMaxContestants.Value = tournament.MaxContestants;

                    if (tournament.Status != TournamentStatus.Planned)
                    {
                        comboTournamentSystem.Enabled = false;
                        comboTournamentSystem.SelectedItem = tournament.System!.Name;
                        numMinContestants.Enabled = false;
                        numMaxContestants.Enabled = false;
                    }
                }
            }
        }

        private void btnDeleteTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows.Count > 0)
            {
                int id = GetIDFromDataGridView(dgvTournaments, "dgvColAllTournamentsID");
                DialogResult confirmation = MessageBox.Show("Are you sure you want to delete this tournament? This action cannot be undone!", "Confirm Deletion?", MessageBoxButtons.YesNo);
                if (confirmation == DialogResult.Yes)
                {
                    bool result = tournamentRegistry.DeleteTournament(id);
                    if (result)
                    {
                        MessageBox.Show("Tournament succesfully deleted");
                    }
                    else
                    {
                        MessageBox.Show("Could not delete tournament");
                    }
                }
            }
            gpbTournamentUpdateStatus.Enabled = false;
            RefreshTournaments();
        }

        #endregion

        #region TOURNAMENT STATUS UPDATING

        private void btnStartTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows.Count > 0)
            {
                int id = GetIDFromDataGridView(dgvTournaments, "dgvColAllTournamentsID");
                Tournament? tournament = tournamentRegistry.GetByID(id);
                if(tournament != null){
                    bool result = tournamentRegistry.StartTournament(id, TournamentStatus.Running, contestantRegistry.GetContestants(id).Count);
                    if (result)
                    {
                        MessageBox.Show("Tournament is now started.");
                    }
                    else
                    {
                        MessageBox.Show("This tournament cannot be started as there are either not enough contestants or the tournament is more than a week away from starting.");
                    }
                    RefreshTournaments();
                }
            }
            gpbTournamentUpdateStatus.Enabled = false;
        }

        private void btnFinishTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows.Count > 0)
            {
                int id = GetIDFromDataGridView(dgvTournaments, "dgvColAllTournamentsID");
                bool result = tournamentRegistry.UpdateTournamentStatus(id, TournamentStatus.Finished);
                if (result)
                {
                    MessageBox.Show("Tournament status succesfully updated");
                }
                else
                {
                    MessageBox.Show("Could not update tournament status.");
                }
                RefreshTournaments();
            }
            gpbTournamentUpdateStatus.Enabled = false;
        }

        private void btnCancelTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows.Count > 0)
            {
                int id = GetIDFromDataGridView(dgvTournaments, "dgvColAllTournamentsID");
                bool result = tournamentRegistry.UpdateTournamentStatus(id, TournamentStatus.Cancelled);
                if (result)
                {
                    MessageBox.Show("Tournament status succesfully updated");
                }
                else
                {
                    MessageBox.Show("Could not update tournament status");
                }
                RefreshTournaments();
            }
            gpbTournamentUpdateStatus.Enabled = false;
        }

        #endregion

        #region MATCHES

        private void btnGenerateMatches_Click(object sender, EventArgs e)
        {
            if (dgvActiveTournaments.SelectedRows.Count > 0)
            {
                int id = GetIDFromDataGridView(dgvActiveTournaments, "dgvColActiveTournamentsID");
                Tournament? tournament = tournamentRegistry.GetByID(id);
                if (tournament != null)
                {
                    bool possible = tournament.System!.CanGenerateMatches(matchRegistry.GetMatches(tournament.ID));
                    if (possible)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        try
                        {
                            bool result = matchRegistry.CreateMatches(tournament.System!.GenerateMatches(tournament.ID, contestantRegistry.GetContestants(tournament.ID)));

                            if (result)
                            {
                                MessageBox.Show("Matches have been generated");
                                RefreshMatches(id);
                            }
                            else
                            {
                                MessageBox.Show("Cannot generate any more matches as all possible matches have been generated.");
                            }
                        }
                        catch(NoValidContestantsException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        MessageBox.Show("Cannot generate matches. Either not all matches have been finished or the minimum contestant count has not been reached.");
                    }
                }
            }
        }

        private void btnPlayMatch_Click(object sender, EventArgs e)
        {
            if (dgvTournamentMatches.SelectedRows.Count > 0)
            {
                int matchID = GetIDFromDataGridView(dgvTournamentMatches, "dgvColMatchesID");
                int tournamentID = GetIDFromDataGridView(dgvTournamentMatches, "dgvColMatchesTournamentID");
                Match? match = matchRegistry.GetByID(matchID);
                Tournament? tournament = tournamentRegistry.GetByID(tournamentID);
                if (match != null && tournament != null && !match.IsFinished)
                {
                    matchForm = new MatchForm(tournament.Sport!, match);
                    matchForm.ShowDialog();

                    if (matchForm.DialogResult == DialogResult.OK)
                    {
                        Match result = matchForm.CurrentMatch;
                        contestantRegistry.SaveResults(match.TournamentID, match.GetWinner(), match.GetLoser());
                        bool success = matchRegistry.SaveMatch(result);
                        if (success)
                        {
                            MessageBox.Show("Match results saved!");
                            RefreshMatches(result.TournamentID);
                        }
                        else
                        {
                            MessageBox.Show("Could not update match, please contact system administrators.");
                        }
                    }

                    matchForm.Dispose();
                }
                else
                {
                    MessageBox.Show("This match has already been finished.");
                }
            }
            else
            {
                MessageBox.Show("No match selected, select a match first.");
            }
        }

        #endregion

        #region ACCOUNTS

        private void btnRegisterAccount_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = userRegistry.RegisterAccount(new Account()
                {
                    Name = inputName.Text,
                    SurName = inputSurname.Text,
                    Email = inputEmail.Text,
                    Password = inputPassword.Text,
                    Role = (UserRole)Enum.Parse(typeof(UserRole), comboRoles.Text),
                    Type = (TeamType)Enum.Parse(typeof(TeamType), comboTypes.Text)
                });
                if (result)
                {
                    MessageBox.Show("Account successfully registered!");
                    inputName.Clear();
                    inputSurname.Clear();
                    inputEmail.Clear();
                    inputPassword.Clear();
                    comboRoles.SelectedIndex = 0;
                    comboTypes.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("This email is already taken.");
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("One of the dropdown boxes contained an invalid value, please enter a valid value.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An unknown error occured:");
            }
        }

        #endregion

    }
}
