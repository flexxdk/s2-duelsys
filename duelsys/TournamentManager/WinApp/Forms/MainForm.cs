using BLL.Enums;
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

        public MainForm()
        {
            InitializeComponent();
            //SwitchPage(new HomePage());
            SetupFormGraphics();
            SetupComboBoxes();

            pickStartDate.MinDate = DateTime.Now;
            pickStartDate.CustomFormat = "dddd dd MMMM";
            pickEndDate.MinDate = DateTime.Now;

            tournamentRegistry = new TournamentRegistry(new TournamentRepository(new DbContext()), true);
            RefreshTournaments();
        }

        public void SetupFormGraphics()
        {
            //Disable standard tab controls
            tabsControl.Appearance = TabAppearance.FlatButtons;
            tabsControl.ItemSize = new Size(0, 1);
            tabsControl.SizeMode = TabSizeMode.Fixed;

            //Change button borders
        }

        private void SetupComboBoxes()
        {
            comboContestantType.DataSource = Enum.GetValues(typeof(ContestantType));
            comboTournamentSystem.DataSource = Enum.GetValues(typeof(TournamentSystem));
            comboTypes.DataSource = Enum.GetValues(typeof(ContestantType));
            comboRoles.DataSource = Enum.GetValues(typeof(UserRole));
        }

        //private void SwitchPage(UserControl control)
        //{
        //    ucContainer.Controls.Clear();
        //    control.Dock = DockStyle.Fill;
        //    control.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
        //    control.Size = ucContainer.Size;
        //    ucContainer.Controls.Add(control);
        //}

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
                int id = GetIDFromDataGridView(dgvTournaments, "iDDataGridViewTextColumn");
                Tournament tournament = tournamentRegistry.GetByID(id)!;
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
                int id = GetIDFromDataGridView(dgvTournaments, "iDDataGridViewTextColumn");
                Tournament tournament = tournamentRegistry.GetByID(id)!;
                tournament.Status = TournamentStatus.Running;
                tournamentRegistry.UpdateTournament(tournament);
            }
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
