using BLL.Objects;
using DAL.Interfaces;
using DTO;

namespace BLL.Registries
{
    public class MatchScheduler
    {
        private readonly IMatchRepository repository;
        private MatchGenerator matchGenerator;

        public MatchScheduler(IMatchRepository repository)
        {
            this.repository = repository;
            matchGenerator = new MatchGenerator();
        }

        public Match? GetByID(int matchID)
        {
            MatchDTO? dto = repository.GetByID(matchID);
            if(dto != null)
            {
                return new Match()
                {
                    ID = dto.ID,
                    TournamentID = dto.TournamentID,
                    HomeScore = dto.HomeScore,
                    AwayScore = dto.AwayScore,
                    HomeContestantID = dto.HomeContestantID,
                    AwayContestantID = dto.AwayContestantID,
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
                    HomeScore = dto.HomeScore,
                    AwayScore = dto.AwayScore,
                    HomeContestantID = dto.HomeContestantID,
                    AwayContestantID = dto.AwayContestantID,
                    IsFinished = dto.IsFinished
                });
            }
            return matches;
        }

        public void GenerateMatches(Tournament tournament)
        {
            List<MatchDTO> matches = matchGenerator.GenerateMatches(tournament.System, tournament.ID, repository.GetTournamentContestants(tournament.ID)).ToList();
            foreach(MatchDTO match in matches)
            {
                repository.Create(match);
            }
        }
    }
}
