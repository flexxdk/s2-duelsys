﻿using BLL.Enums;
using BLL;
using BLL.Registries;
using DAL.Repositories;
using DAL;
using BLL.Objects;
using BLL.Objects.Users;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WinApp.Forms
{
    public partial class MainForm : Form
    {
        private TournamentRegistry tournamentRegistry;
        private UserRegistry userRegistry;
        private MatchRegistry matchRegistry;

        public MainForm()
        {
            InitializeComponent();
            //SwitchPage(new HomePage());
            SetupFormGUI();

            tournamentRegistry = new TournamentRegistry(new TournamentRepository(new DbContext()), true);
            userRegistry = new UserRegistry(new UserRepository(new DbContext()));
            matchRegistry = new MatchRegistry(new MatchRepository(new DbContext()));

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
            comboContestantType.DataSource = Enum.GetValues(typeof(ContestantType));
            comboTournamentSystem.DataSource = Enum.GetValues(typeof(TournamentSystem));
            comboTypes.DataSource = Enum.GetValues(typeof(ContestantType));
            comboRoles.DataSource = Enum.GetValues(typeof(UserRole));
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

        private void btnCreateTournament_Click(object sender, EventArgs e)
        {
            string title = inputTitle.Text;
            string description = inputDescription.Text;
            string sport = inputSport.Text;
            string scoring = inputScoring.Text;
            string city = inputCity.Text;
            string address = inputAddress.Text;
            DateTime startDate = pickStartDate.Value;
            DateTime endDate = pickEndDate.Value;
            int minContestants = Convert.ToInt32(numMinContestants.Value);
            int maxContestants = Convert.ToInt32(numMaxContestants.Value);

            try
            {
                TournamentSystem system = (TournamentSystem)Enum.Parse(typeof(TournamentSystem), comboTournamentSystem.Text);
                ContestantType type = (ContestantType)Enum.Parse(typeof(ContestantType), comboContestantType.Text);

                bool result = tournamentRegistry.CreateTournament(new Tournament()
                {
                    Title = title,
                    Description = description,
                    Sport = sport,
                    Scoring = scoring,
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
                int id = GetIDFromDataGridView(dgvTournaments, "TournamentID");
                ToggleTournamentStatusButtons(tournamentRegistry.GetByID(id)!.Status);
            }
            else
            {
                btnStartTournament.Enabled = false;
                btnFinishTournament.Enabled = false;
                btnCancelTournament.Enabled = false;
                btnDeleteTournament.Enabled = false;
            }
        }

        private void btnStartTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows[0] != null)
            {
                int id = GetIDFromDataGridView(dgvTournaments, "TournamentID");
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
                int id = GetIDFromDataGridView(dgvTournaments, "TournamentID");
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
                int id = GetIDFromDataGridView(dgvTournaments, "TournamentID");
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
                int id = GetIDFromDataGridView(dgvTournaments, "TournamentID");
                Tournament? tournament = tournamentRegistry.GetByID(id);
                if (tournament != null)
                {
                    btnCreateTournament.Enabled = false;
                    btnUpdateTournament.Enabled = true;
                }
            }
            RefreshTournaments();
        }

        private void btnDeleteTournament_Click(object sender, EventArgs e)
        {
            if (dgvTournaments.SelectedRows[0] != null)
            {
                int id = GetIDFromDataGridView(dgvTournaments, "TournamentID");
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
            return Convert.ToInt32(dgvTournaments.SelectedRows[0].Cells[columnName].Value);
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
                ContestantType type = (ContestantType)Enum.Parse(typeof(ContestantType), comboTypes.Text);

                bool result = userRegistry.RegisterAccount(new User()
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
                int id = GetIDFromDataGridView(dgvActiveTournaments, "iDDataGridViewTextBoxColumn");
                //if (tournament != null)
                //{
                //    matchRegistry.GenerateMatches(id);
                //}
            }
        }
    }
}
