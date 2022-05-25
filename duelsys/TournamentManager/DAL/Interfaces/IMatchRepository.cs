using DAL.Interfaces.Generic;
using DTO;
using DTO.Users;

namespace DAL.Interfaces
{
    public interface IMatchRepository : IObjectManipulator<MatchDTO>
    {
        public MatchDTO? GetByID(int id);
        public IList<MatchDTO> GetMatches(int tournamentID);
        public IList<ContestantDTO> GetTournamentContestants(int tournamentID);
    }
}
