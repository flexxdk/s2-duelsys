using BLL.Interfaces.Generic;
using DTO;
using DTO.Users;

namespace BLL.Interfaces
{
    public interface ITournamentRepository : IObjectManipulator<TournamentDTO>
    {
        public void DeleteTournament(int tournamentID);
        public IList<ContestantDTO> GetLeaderboard(int tournamentID);
    }
}
