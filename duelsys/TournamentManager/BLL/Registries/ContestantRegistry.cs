using BLL.Validation;
using BLL.Enums;
using DAL.Interfaces;
using DTO;
using DTO.Users;
using BLL.Objects;
using BLL.Objects.Users;
using System.Globalization;

namespace BLL.Registries
{
    public class ContestantRegistry : BaseRegistry
    {
        private readonly IContestantRepository repository;

        public ContestantRegistry(IContestantRepository repository)
        {
            this.repository = repository;
        }

        public Contestant? GetContestant(int tournamentID, int contestantID)
        {
            ContestantDTO? dto = repository.GetContestant(tournamentID, contestantID);
            if(dto != null)
            {
                return new Contestant()
                {
                    ID = dto.ID,
                    Name = dto.Name,
                    SurName = dto.SurName,
                    TournamentID = dto.TournamentID,
                    Wins = dto.Wins,
                    Losses = dto.Losses
                };
            }
            return null;
        }

        public IList<Contestant> GetContestants(int tournamentID)
        {
            List<Contestant> contestants = new List<Contestant>();
            foreach(ContestantDTO cont in repository.GetContestants(tournamentID))
            {
                contestants.Add(new Contestant()
                {
                    ID = cont.ID,
                    Name = cont.Name,
                    SurName = cont.SurName,
                    TournamentID = cont.TournamentID,
                    Wins = cont.Wins,
                    Losses = cont.Losses
                });
            }
            return contestants;
        }

        public bool Register(int userID, string teamType, Tournament tournament)
        {
            if (Validate.AsEnum<TeamType>(teamType))
            {
                if(DateTime.Now.AddDays(7) < tournament.StartDate)
                {
                    if (GetContestants(tournament.ID).Count < tournament.MaxContestants)
                    {
                        if (tournament.Type == (TeamType)Enum.Parse(typeof(TeamType), teamType))
                        {
                            if (GetContestant(tournament.ID, userID) == null)
                            {
                                return repository.Register(userID, tournament.ID);
                            }
                            return false;
                        }
                        throw new Exception($"Cannot register {teamType} account for a {tournament.Type} tournament.");
                    }
                    throw new Exception("There are no more spots left in this tournament.");
                }
                throw new Exception("Cannot register for a tournament that is starting in less than a week.");
            }
            throw new Exception("Invalid team type, please contact website administrators.");
        }

        public bool Deregister(int userID, int tournamentID)
        {
            if (GetContestant(tournamentID, userID) != null)
            {
                return repository.Deregister(userID, tournamentID);
            }
            return false;
        }

        public bool SaveResults(int tournamentID, int winnerID, int loserID)
        {
            try
            {
                Contestant? winner = GetContestant(tournamentID, winnerID);
                Contestant? loser = GetContestant(tournamentID, loserID);
                if(winner != null && loser != null)
                {
                    winner.Wins++;
                    loser.Losses++;
                    repository.SaveResults(tournamentID, winner.ID, winner.Wins, loser.ID, loser.Losses);
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
