using DTO;
using DTO.Users;

namespace DAL.Interfaces
{
    public interface ITournamentRepository
    {
        public bool Delete(int tournamentID);
        public IList<ContestantDTO> GetStandings(int tournamentID);
        public IEnumerable<TournamentDTO> FilterTournamentsOnStatus(string filter);
        public TournamentDTO? GetByID(int id);
        public int Create(TournamentDTO obj);
        public int Update(TournamentDTO obj);
        public IList<TournamentDTO> Load();
    }
}
