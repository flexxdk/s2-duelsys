using DTO;
using DTO.Users;

namespace DAL.Interfaces
{
    public interface ITournamentRepository
    {
        public IList<TournamentDTO> Load();
        public IEnumerable<TournamentDTO> FilterTournamentsOnStatus(string filter);
        public TournamentDTO? GetByID(int id);
        public int Create(TournamentDTO dto);
        public int Update(TournamentDTO dto);
        public bool Delete(int id);
    }
}
