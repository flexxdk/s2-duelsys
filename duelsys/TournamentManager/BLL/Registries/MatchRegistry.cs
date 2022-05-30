﻿using BLL.Objects;
using BLL.Objects.Users;
using DAL.Interfaces;
using DTO;

namespace BLL.Registries
{
    public class MatchRegistry : BaseRegistry
    {
        private readonly IMatchRepository repository;
        private MatchGenerator matchGenerator;

        public MatchRegistry(IMatchRepository repository)
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

        public bool GenerateMatches(Tournament tournament, IEnumerable<Contestant> contestants)
        {
            IEnumerable<Match> currentMatches = GetMatches(tournament.ID);
            if(currentMatches.Count() == 0 || !currentMatches.Any(c => c.IsFinished == false))
            {
                List<MatchDTO> matches = matchGenerator.GenerateMatches(tournament.System, tournament.ID, contestants).ToList();
                foreach (MatchDTO match in matches)
                {
                    repository.Create(match);
                }
                return true;
            }
            return false;
        }

        public void SaveResults(Match match)
        {
            try
            {
                ValidateModel(match);
                repository.Update(new MatchDTO(match.ID, match.TournamentID, true, match.HomeID, match.HomeName!, match.HomeScore, match.AwayID, match.AwayName!, match.AwayScore));
            }
            catch
            {
                throw;
            }
        }
    }
}
