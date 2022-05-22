using DAL.Interfaces.Generic;
using DTO.Users;

namespace DAL.Interfaces
{
    public interface IContestantRepository
    {
        public ContestantDTO? GetContestant(int tournamentID, int contestantID);
        public IList<ContestantDTO> GetRegistrants(int tournamentID);
        public bool Register(int userID, int tournamentID);
        public bool Deregister(int userID, int tournamentID);
    }
}
