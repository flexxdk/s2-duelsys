using DAL.Interfaces.Generics;
using DTO.Users;

namespace DAL.Interfaces
{
    public interface IContestantRepository : IObjectLoader<ContestantDTO>
    {
        public ContestantDTO GetContestant(int contestantID);
        public IList<ContestantDTO> GetContestantsInTournament(int tournamentID);
        public void Register(ContestantDTO contestantDTO);
        public void Deregister(ContestantDTO contestantDTO);
    }
}
