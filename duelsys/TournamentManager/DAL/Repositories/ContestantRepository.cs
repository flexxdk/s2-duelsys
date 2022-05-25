using DAL.Interfaces;
using DTO.Users;
using DTO;

namespace DAL.Repositories
{
    public class ContestantRepository : BaseRepository, IContestantRepository
    {
        public ContestantRepository(DbContext dbContext) : base(dbContext) { }

        public bool Deregister(int userID, int tournamentID)
        {
            throw new NotImplementedException();
        }

        public ContestantDTO? GetContestant(int tournamentID, int contestantID)
        {
            throw new NotImplementedException();
        }

        public IList<ContestantDTO> GetContestants(int tournamentID)
        {
            throw new NotImplementedException();
        }

        public bool Register(int userID, int tournamentID)
        {
            throw new NotImplementedException();
        }

        public TournamentDTO GetTournament(int tournamentID)
        {
            throw new NotImplementedException();
        }
    }
}
