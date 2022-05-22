using DAL.Interfaces;
using DTO.Users;

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

        public IList<ContestantDTO> GetRegistrants(int tournamentID)
        {
            throw new NotImplementedException();
        }

        public bool Register(int userID, int tournamentID)
        {
            throw new NotImplementedException();
        }
    }
}
