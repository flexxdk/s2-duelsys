using DAL.Interfaces.Generic;
using DTO.Users;
using DTO;

namespace DAL.Interfaces
{
    public interface IContestantRepository
    {
        public ContestantDTO? GetContestant(int tournamentID, int contestantID);
        public IList<ContestantDTO> GetContestants(int tournamentID);
        public bool Register(int userID, int tournamentID);
        public bool Deregister(int userID, int tournamentID);
        public TournamentDTO? GetTournament(int tournamentID);
    }
}
