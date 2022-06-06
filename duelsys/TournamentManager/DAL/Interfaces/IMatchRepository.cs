using DTO;
using DTO.Users;

namespace DAL.Interfaces
{
    public interface IMatchRepository
    {
        public MatchDTO? GetByID(int id);
        public IList<MatchDTO> GetMatches(int tournamentID);
        public int Create(MatchDTO dto);
        public int SaveResults(MatchDTO dto);
    }
}
