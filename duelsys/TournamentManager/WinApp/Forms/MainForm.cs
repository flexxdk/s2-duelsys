using WinApp.Pages;

namespace WinApp.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SwitchUserControls(new HomePage());
        }

        private void SwitchUserControls(UserControl control)
        {
            ucContainer.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            control.Size = ucContainer.Size;
            ucContainer.Controls.Add(control);
        }

        private void navHome_Click(object sender, EventArgs e)
        {
            SwitchUserControls(new HomePage());
        }

        private void navTournaments_Click(object sender, EventArgs e)
        {
            SwitchUserControls(new TournamentPage());
        }

        private void navMatches_Click(object sender, EventArgs e)
        {
            SwitchUserControls(new MatchesPage());
        }
    }
}
