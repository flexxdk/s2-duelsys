using BLL.Interfaces.Generic;
using BLL.Objects;
using BLL.Objects.Users;

namespace BLL.Interfaces
{
    public interface ITournamentRepository : IObjectManipulator<Tournament>
    {
        public void DeleteTournament(int id);
        public IList<Contestant> GetLeaderboard(int id);
    }
}
