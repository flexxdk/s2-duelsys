using BLL.Objects;
using BLL.Objects.Users;
using DAL.Interfaces;
using DTO;
using BLL.Enums;

namespace BLL.Registries
{
    public class MatchRegistry : BaseRegistry
    {
        private readonly IMatchRepository repository;

        public MatchRegistry(IMatchRepository repository)
        {
            this.repository = repository;
        }

        public Match? GetByID(int id)
        {
            MatchDTO? dto = repository.GetByID(id);
            if(dto != null)
            {
                return new Match()
                {
                    ID = dto.ID,
                    TournamentID = dto.TournamentID,
                    HomeID = dto.HomeID,
                    HomeName = dto.HomeName,
                    HomeScore = dto.HomeScore,
                    AwayID = dto.AwayID,
                    AwayName = dto.AwayName,
                    AwayScore = dto.AwayScore,
                    IsFinished = dto.IsFinished
                };
            }
            return null;
        }

        public IList<Match> GetMatches(int tournamentID)
        {
            List<Match> matches = new List<Match>();
            foreach(MatchDTO dto in repository.GetMatches(tournamentID))
            {
                matches.Add(new Match()
                {
                    ID = dto.ID,
                    TournamentID = dto.TournamentID,
                    HomeID = dto.HomeID,
                    HomeName = dto.HomeName,
                    HomeScore = dto.HomeScore,
                    AwayID = dto.AwayID,
                    AwayName = dto.AwayName,
                    AwayScore = dto.AwayScore,
                    IsFinished = dto.IsFinished
                });
            }
            return matches;
        }

        public bool CreateMatches(IEnumerable<MatchDTO> matches)
        {
            foreach (MatchDTO match in matches)
            {
                repository.Create(match);
            }
            return matches.Any();
        }

        public bool SaveMatch(Match match)
        {
            try
            {
                ValidateModel(match);
                Match? obj = GetByID(match.ID);
                if(obj != null)
                {
                    repository.SaveResults(new MatchDTO(obj.ID, obj.TournamentID, true, match.HomeID, match.HomeName!, match.HomeScore, match.AwayID, match.AwayName!, match.AwayScore));
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}
