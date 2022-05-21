using DAL.Interfaces;
using DTO;

namespace DAL.Repositories
{
    public class MatchRepository : BaseRepository, IMatchRepository
    {
        public MatchRepository(DbContext dbContext) : base(dbContext) { }

        public int Create(MatchDTO obj)
        {
            throw new NotImplementedException();
        }

        public IList<MatchDTO> GetMatches(int tournamentID)
        {
            throw new NotImplementedException();
        }

        public IList<MatchDTO> Load()
        {
            throw new NotImplementedException();
        }

        public int Update(MatchDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
