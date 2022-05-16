using DAL.Interfaces.Generics;
using DTO;

namespace DAL.Interfaces
{
    public interface IMatchRepository : IObjectManipulator<MatchDTO>
    {
        public IList<MatchDTO> GetMatches(int tournamentID);
    }
}
