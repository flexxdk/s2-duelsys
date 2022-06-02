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

namespace WinApp.Forms
{
    public partial class MainForm : Form
    {
        private MatchForm? matchForm;

        private TournamentRegistry tournamentRegistry;
        private UserRegistry userRegistry;
        private MatchRegistry matchRegistry;
        private ContestantRegistry contestantRegistry;

        public MainForm()
        {
            InitializeComponent();
            SetupFormGUI();

            tournamentRegistry = new TournamentRegistry(new TournamentRepository(new DbContext()), true);
            userRegistry = new UserRegistry(new UserRepository(new DbContext()));
            matchRegistry = new MatchRegistry(new MatchRepository(new DbContext()));
            contestantRegistry = new ContestantRegistry(new ContestantRepository(new DbContext()));

            RefreshTournaments();
        }

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
            comboSport.DataSource = SportAssigner.GetNames();
        }

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

        private void RefreshTournaments()
        {
            dgvTournaments.DataSource = tournamentRegistry.GetAll(false);
            dgvActiveTournaments.DataSource = tournamentRegistry.GetActiveTournaments();
        }

        private void RefreshMatches(int tournamentID)
        {
            dgvTournamentMatches.DataSource = matchRegistry.GetMatches(tournamentID);
        }

        private void btnCreateTournament_Click(object sender, EventArgs e)
        {
            string title = inputTitle.Text;
            string description = inputDescription.Text;
            string city = inputCity.Text;
            string address = inputAddress.Text;
            DateTime startDate = pickStartDate.Value;
            DateTime endDate = pickEndDate.Value;
            int minContestants = Convert.ToInt32(numMinContestants.Value);
            int maxContestants = Convert.ToInt32(numMaxContestants.Value);

            try
            {
                TournamentSystem system = (TournamentSystem)Enum.Parse(typeof(TournamentSystem), comboTournamentSystem.Text);
                TeamType type = (TeamType)Enum.Parse(typeof(TeamType), comboTeamType.Text);

                bool result = tournamentRegistry.CreateTournament(new Tournament()
                {
                    Title = title,
                    Description = description,
                    Sport = SportAssigner.RetrieveSport(comboSport.SelectedIndex),
                    City = city,
                    Address = address,
                    StartDate = startDate,
                    EndDate = endDate,
                    MinContestants = minContestants,
                    MaxContestants = maxContestants,
                    System = system,
                    Type = type,
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

        private void CancelTournamentUpdating()
        {
            tournamentBindingSource.DataSource = typeof(Tournament);
            btnUpdateTournament.Enabled = false;
            btnCreateTournament.Enabled = true;
            gpbTournamentUpdateStatus.Enabled = true;
            gpbModifyTournament.Enabled = true;
            numMinContestants.Value = numMinContestants.Minimum;
            numMaxContestants.Value = numMaxContestants.Minimum;
            pickStartDate.MinDate = DateTime.Now;
            pickStartDate.Value = DateTime.Now;
            pickEndDate.MinDate = DateTime.Now;
            pickEndDate.Value = DateTime.Now;
            comboTeamType.Enabled = true;
            comboTeamType.SelectedIndex = 0;
            comboTournamentSystem.Enabled = true;
            comboTournamentSystem.SelectedIndex = 0;
            gpbTournamentCreation.Text = "Create Tournament";
        }

        private void btnStartTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows[0] != null)
            {
                int id = GetIDFromDataGridView(dgvTournaments, "dgvColAllTournamentsID");
                bool result = UpdateTournamentStatus(id, TournamentStatus.Running);
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

        private void btnFinishTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows[0] != null)
            {
                int id = GetIDFromDataGridView(dgvTournaments, "dgvColAllTournamentsID");
                bool result = UpdateTournamentStatus(id, TournamentStatus.Finished);
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

        private void btnCancelTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows[0] != null)
            {
                int id = GetIDFromDataGridView(dgvTournaments, "dgvColAllTournamentsID");
                bool result = UpdateTournamentStatus(id, TournamentStatus.Cancelled);
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
                    pickStartDate.MinDate = tournament.StartDate;
                    pickEndDate.MinDate = tournament.EndDate;
                    comboTeamType.Enabled = false;
                    comboTournamentSystem.Enabled = false;
                    tournamentBindingSource.DataSource = tournament;
                    gpbTournamentCreation.Text = "Adjust Tournament";
                }
            }
        }

        private void btnDeleteTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows[0] != null)
            {
                int id = GetIDFromDataGridView(dgvTournaments, "dgvColAllTournamentsID");
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
            RefreshTournaments();
        }

        private bool UpdateTournamentStatus(int id, TournamentStatus status)
        {
            Tournament? tournament = tournamentRegistry.GetByID(id);
            if (tournament != null)
            {
                tournament.Status = status;
                return tournamentRegistry.UpdateTournament(tournament);
            }
            return false;
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
            btnDeleteTournament.Enabled = status == TournamentStatus.Planned;
        }

        private void btnRegisterAccount_Click(object sender, EventArgs e)
        {
            string name = inputName.Text;
            string surname = inputSurname.Text;
            string email = inputEmail.Text;
            string password = inputPassword.Text;

            try
            {
                UserRole role = (UserRole)Enum.Parse(typeof(UserRole), comboRoles.Text);
                TeamType type = (TeamType)Enum.Parse(typeof(TeamType), comboTypes.Text);

                bool result = userRegistry.RegisterAccount(new Account()
                {
                    Name = name,
                    SurName = surname,
                    Email = email,
                    Password = password,
                    Role = role,
                    Type = type
                });
                if (result)
                {
                    MessageBox.Show("Account successfully registered!");
                }
                else
                {
                    MessageBox.Show("Couldn't register account with given email.");
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

        private void btnGenerateMatches_Click(object sender, EventArgs e)
        {
            if (dgvActiveTournaments.SelectedRows[0] != null)
            {
                int id = GetIDFromDataGridView(dgvActiveTournaments, "dgvColMatchesTournamentID");
                Tournament? tournament = tournamentRegistry.GetByID(id);
                if (tournament != null)
                {
                    bool possible = matchRegistry.CheckCanGenerate(tournament.ID, tournament.System);
                    if (possible)
                    {
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
                    }
                    else
                    {
                        MessageBox.Show("Cannot generate matches");
                    }
                }
            }
            btnGenerateMatches.Enabled = false;
        }

        private void dgvActiveTournaments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvActiveTournaments.SelectedRows[0] != null)
            {
                int id = GetIDFromDataGridView(dgvActiveTournaments, "dgvColActiveTournamentsID");
                Tournament? tournament = tournamentRegistry.GetByID(id);
                if (tournament != null) btnGenerateMatches.Enabled = matchRegistry.CheckCanGenerate(tournament.ID, tournament.System);
                else btnGenerateMatches.Enabled = false;
                RefreshMatches(id);
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
                if(match != null && tournament != null && !match.IsFinished)
                {
                    matchForm = new MatchForm(tournament.Sport!, match);
                    matchForm.ShowDialog();

                    if (matchForm.DialogResult == DialogResult.OK)
                    {
                        matchRegistry.SaveResults(matchForm.CurrentMatch);
                        MessageBox.Show("Match results saved!");
                        RefreshMatches(match.TournamentID);
                    }
                    else
                    {
                        
                    }

                    matchForm.Dispose();
                }
            }
        }

        private void NavLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void btnUpdateTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows[0] != null)
            {
                int id = GetIDFromDataGridView(dgvTournaments, "dgvColAllTournamentsID");
                Tournament? tournament = tournamentRegistry.GetByID(id);

                if(tournament != null)
                {
                    string title = inputTitle.Text;
                    string description = inputDescription.Text;
                    string city = inputCity.Text;
                    string address = inputAddress.Text;
                    DateTime startDate = pickStartDate.Value;
                    DateTime endDate = pickEndDate.Value;
                    int minContestants = Convert.ToInt32(numMinContestants.Value);
                    int maxContestants = Convert.ToInt32(numMaxContestants.Value);

                    try
                    {
                        TournamentSystem system = (TournamentSystem)Enum.Parse(typeof(TournamentSystem), comboTournamentSystem.Text);
                        TeamType type = (TeamType)Enum.Parse(typeof(TeamType), comboTeamType.Text);

                        bool result = tournamentRegistry.UpdateTournament(new Tournament()
                        {
                            ID = tournament.ID,
                            Title = title,
                            Description = description,
                            Sport = SportAssigner.RetrieveSport(comboSport.SelectedIndex),
                            City = city,
                            Address = address,
                            StartDate = startDate,
                            EndDate = endDate,
                            MinContestants = minContestants,
                            MaxContestants = maxContestants,
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
    }
}
