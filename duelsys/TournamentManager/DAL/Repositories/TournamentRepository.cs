using DAL.Interfaces;
using DTO;
using DTO.Users;

namespace DAL.Repositories
{
    public class TournamentRepository : BaseRepository, ITournamentRepository
    {
        public TournamentRepository(DbContext dbContext) : base(dbContext) { }

        public int Create(TournamentDTO obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int tournamentID)
        {
            throw new NotImplementedException();
        }

        public IList<ContestantDTO> GetStandings(int tournamentID)
        {
            throw new NotImplementedException();
        }

        public IList<TournamentDTO> Load()
        {
            throw new NotImplementedException();
        }

        public int Update(TournamentDTO obj)
        {
            throw new NotImplementedException();
        }

        public TournamentDTO? GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
