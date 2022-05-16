using DAL.Interfaces;
using DTO;
using DTO.Users;

namespace DAL.Repositories
{
    public class TournamentRepository : BaseRepository, ITournamentRepository
    {
        public TournamentRepository(DbContext dbContext) : base(dbContext) { }

        public void Create(TournamentDTO obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteTournament(int tournamentID)
        {
            throw new NotImplementedException();
        }

        public IList<ContestantDTO> GetLeaderboard(int tournamentID)
        {
            throw new NotImplementedException();
        }

        public IList<TournamentDTO> Load()
        {
            throw new NotImplementedException();
        }

        public void Update(TournamentDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
