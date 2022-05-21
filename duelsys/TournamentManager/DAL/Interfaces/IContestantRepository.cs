using DAL.Interfaces.Generic;
using DTO.Users;

namespace DAL.Interfaces
{
    public interface IContestantRepository
    {
        public ContestantDTO GetContestant(int tournamentID, int contestantID);
        public IList<ContestantDTO> GetRegistrants(int tournamentID);
        public void Register(ContestantDTO contestantDTO);
        public void Deregister(ContestantDTO contestantDTO);
    }
}
