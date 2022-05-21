using DAL.Interfaces.Generic;
using DTO;
using DTO.Users;

namespace DAL.Interfaces
{
    public interface ITournamentRepository : IObjectManipulator<TournamentDTO>
    {
        public bool Delete(int tournamentID);
        public IList<ContestantDTO> GetStandings(int tournamentID);
    }
}
