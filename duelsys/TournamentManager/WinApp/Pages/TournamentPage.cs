using BLL.Registries;
using BLL.Objects;
using DAL.Repositories;
using DAL;

namespace WinApp.Pages
{
    public partial class TournamentPage : UserControl
    {
        private TournamentRegistry registry;

        public TournamentPage()
        {
            InitializeComponent();
            registry = new TournamentRegistry(new TournamentRepository(new DbContext()), true);

        }
    }
}
