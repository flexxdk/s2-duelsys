using BLL.Interfaces.Generic;
using DTO;

namespace BLL.Interfaces
{
    public interface IMatchRepository : IObjectManipulator<MatchDTO>
    {
        public IList<MatchDTO> GetMatches(int tournamentID);
    }
}
