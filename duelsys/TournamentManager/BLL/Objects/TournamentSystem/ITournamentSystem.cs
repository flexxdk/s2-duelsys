using DTO;
using BLL.Objects.Users;

namespace BLL.Objects.TournamentSystem
{
    public interface ITournamentSystem
    {
        public string Name { get; }
        public bool CanGenerateMatches(IEnumerable<Match> matches);
        public IEnumerable<MatchDTO> GenerateMatches(int tournamentID, IEnumerable<Contestant> contestants);
    }
}
