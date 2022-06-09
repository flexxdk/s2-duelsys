using BLL.Enums;
using BLL;
using BLL.Registries;
using DAL.Repositories;
using DAL;
using BLL.Objects;
using BLL.Objects.Users;
using System.ComponentModel.DataAnnotations;
using System.Data;
using BLL.Objects.Sports;
using System.Collections;
using System.Windows.Forms;

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

        public MainForm(Account account)
        {
            InitializeComponent();
            ActiveUser = account;

            tournamentRegistry = new TournamentRegistry(new TournamentRepository(new DbContext()));
            userRegistry = new UserRegistry(new UserRepository(new DbContext()));
            matchRegistry = new MatchRegistry(new MatchRepository(new DbContext()));
            contestantRegistry = new ContestantRegistry(new ContestantRepository(new DbContext()));

            sportAssigner = new SportAssigner();

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
            pickStartDate.MinDate = DateTime.Now;
            pickStartDate.CustomFormat = "dddd dd MMMM";
            pickEndDate.MinDate = DateTime.Now;
            pickEndDate.CustomFormat = "dddd dd MMMM";

            //Setup combo boxes with enum values
            comboTeamType.DataSource = Enum.GetValues(typeof(TeamType));
            comboTournamentSystem.DataSource = Enum.GetValues(typeof(TournamentSystem));
            comboTypes.DataSource = Enum.GetValues(typeof(TeamType));
            comboRoles.DataSource = Enum.GetValues(typeof(UserRole));
            comboSport.DataSource = sportAssigner.GetNames();

            lblUserName.Text = ActiveUser.Name;
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

        private void CancelTournamentUpdating()
        {
            tournamentBindingSource.DataSource = typeof(Tournament);
            btnUpdateTournament.Enabled = false;
            btnCreateTournament.Enabled = true;
            gpbTournamentUpdateStatus.Enabled = true;
            gpbModifyTournament.Enabled = true;
            numMinContestants.Value = numMinContestants.Minimum;
            numMinContestants.Enabled = true;
            numMaxContestants.Value = numMaxContestants.Minimum;
            numMaxContestants.Enabled = true;
            pickStartDate.Value = DateTime.Now;
            pickEndDate.Value = DateTime.Now;
            comboTeamType.Enabled = true;
            comboTeamType.SelectedIndex = 0;
            comboTournamentSystem.Enabled = true;
            comboTournamentSystem.SelectedIndex = 0;
            comboSport.SelectedIndex = 0;
            comboSport.Enabled = true;
            gpbTournamentCreation.Text = "Create Tournament";

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
            if (dgvTournaments.SelectedRows[0] != null)
            {
                int id = GetIDFromDataGridView(dgvTournaments, "dgvColAllTournamentsID");
                ToggleTournamentStatusButtons(tournamentRegistry.GetByID(id)!.Status);
                if (btnUpdateTournament.Enabled)
                {
                    CancelTournamentUpdating();
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
            if (dgvActiveTournaments.SelectedRows[0] != null)
            {
                int id = GetIDFromDataGridView(dgvActiveTournaments, "dgvColActiveTournamentsID");
                RefreshMatches(id);
            }
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
                    Sport = sportAssigner.RetrieveSport(comboSport.SelectedIndex),
                    City = inputCity.Text,
                    Address = inputAddress.Text,
                    StartDate = pickStartDate.Value,
                    EndDate = pickEndDate.Value,
                    MinContestants = Convert.ToInt32(numMinContestants.Value),
                    MaxContestants = Convert.ToInt32(numMaxContestants.Value),
                    System = (TournamentSystem)Enum.Parse(typeof(TournamentSystem), comboTournamentSystem.Text),
                    Type = (TeamType)Enum.Parse(typeof(TeamType), comboTeamType.Text),
                    Status = TournamentStatus.Planned
                });
                if (result)
                {
                    MessageBox.Show("Tournament successfully created!");
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
        }

        private void btnUpdateTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows[0] != null)
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
                            System = tournament.System,
                            Type = tournament.Type,
                            Status = tournament.Status
                        });
                        if (result)
                        {
                            MessageBox.Show("Tournament updated!");
                            CancelTournamentUpdating();
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
        }


        private void btnAdjustTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows[0] != null)
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
                    comboSport.Enabled = false;
                    comboSport.SelectedItem = tournament.Sport!;
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
                        numMinContestants.Enabled = false;
                        numMaxContestants.Enabled = false;
                    }
                }
            }
        }

        private void btnDeleteTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows[0] != null)
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
            RefreshTournaments();
        }

        #endregion

        #region TOURNAMENT STATUS UPDATING

        private void btnStartTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows[0] != null)
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
                        MessageBox.Show("Cannot start a tournament that has less than minimum contestants.");
                    }
                    RefreshTournaments();
                }
            }
        }

        private void btnFinishTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows[0] != null)
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
        }

        private void btnCancelTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows[0] != null)
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
        }

        #endregion

        #region MATCHES

        private void btnGenerateMatches_Click(object sender, EventArgs e)
        {
            if (dgvActiveTournaments.SelectedRows[0] != null)
            {
                int id = GetIDFromDataGridView(dgvActiveTournaments, "dgvColActiveTournamentsID");
                Tournament? tournament = tournamentRegistry.GetByID(id);
                if (tournament != null)
                {
                    bool possible = matchRegistry.CheckCanGenerate(tournament);
                    if (possible)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        bool result = matchRegistry.GenerateMatches(tournament, contestantRegistry.GetContestants(id));
                        if (result)
                        {
                            MessageBox.Show("Matches have been generated");
                            RefreshMatches(id);
                        }
                        else
                        {
                            MessageBox.Show("Could not generate matches.");
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
            if (dgvTournamentMatches.SelectedRows[0] != null)
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
                        matchRegistry.SaveMatch(result);
                        MessageBox.Show("Match results saved!");
                        RefreshMatches(result.TournamentID);
                    }

                    matchForm.Dispose();
                }
                else
                {
                    MessageBox.Show("This match has already been finished.");
                }
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
