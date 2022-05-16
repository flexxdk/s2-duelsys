using DAL.Interfaces;
using DTO.Users;

namespace DAL.Repositories
{
    public class ContestantRepository : BaseRepository, IContestantRepository
    {
        public ContestantRepository(DbContext dbContext) : base(dbContext) { }

        public void Deregister(ContestantDTO contestantDTO)
        {
            throw new NotImplementedException();
        }

        public ContestantDTO GetContestant(int contestantID)
        {
            throw new NotImplementedException();
        }

        public IList<ContestantDTO> GetContestantsInTournament(int tournamentID)
        {
            throw new NotImplementedException();
        }

        public IList<ContestantDTO> Load()
        {
            throw new NotImplementedException();
        }

        public void Register(ContestantDTO contestantDTO)
        {
            throw new NotImplementedException();
        }
    }
}
