using DAL.Interfaces.Generics;
using DTO;
using DTO.Users;

namespace DAL.Interfaces
{
    public interface ITournamentRepository : IObjectManipulator<TournamentDTO>
    {
        public void DeleteTournament(int tournamentID);
        public IList<ContestantDTO> GetLeaderboard(int tournamentID);
    }
}
