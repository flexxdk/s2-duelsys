using BLL.Validation;
using BLL.Enums;
using BLL.Objects;
using DAL.Interfaces;
using DTO;
using DTO.Users;
using BLL.Objects.Users;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Globalization;

namespace BLL.Registries
{
    public class TournamentRegistry
    {
        private readonly ITournamentRepository repository;
        private Dictionary<int, Tournament> tournaments;

        public TournamentRegistry(ITournamentRepository repository)
        {
            this.repository = repository;
            this.tournaments = new Dictionary<int, Tournament>();
            LoadTournaments();
        }

        public void LoadTournaments()
        {
            tournaments.Clear();
            foreach (TournamentDTO dto in repository.Load())
            {
                tournaments.Add(dto.ID, new Tournament()
                {
                    ID = dto.ID,
                    Name = dto.Name,
                    AllowRegistration = dto.AllowRegistration,
                    MinContestants = dto.MinContestants,
                    MaxContestants = dto.MaxContestants,
                    StartDate = DateTime.Parse(dto.StartDate, new CultureInfo("nl-NL")),
                    EndDate = DateTime.Parse(dto.EndDate, new CultureInfo("nl-NL")),
                    System = (TournamentSystem)Enum.Parse(typeof(TournamentSystem), dto.System)
                });
            }
        }

        public IList<Tournament> GetAll()
        {
            if (tournaments.Count == 0) LoadTournaments();
            return tournaments.Values.ToList();
        }

        public Tournament? GetByID(int id)
        {
            if (tournaments.ContainsKey(id))
            {
                return tournaments[id];
            }
            return null;
        }

        public bool CreateTournament(Tournament tournament)
        {
            try
            {
                ValidateModel(tournament);
                TournamentDTO dto = new TournamentDTO(0, tournament.Name!, tournament.AllowRegistration, tournament.MinContestants, tournament.MaxContestants, tournament.StartDate.ToString()!, tournament.ToString()!, tournament.System.ToString());
                tournament.ID = repository.Create(dto);
                return tournaments.TryAdd(tournament.ID, tournament);
                
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateTournament(Tournament tournament)
        {
            try
            {
                ValidateModel(tournament);
                bool found = tournaments.ContainsKey(tournament.ID);
                if (found) 
                {
                    tournaments[tournament.ID] = tournament;
                }
                return found;
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteTournament(int id)
        {
            try
            {
                if (id > 0)
                {
                    if (tournaments.ContainsKey(id))
                    {
                        tournaments.Remove(id);
                        return repository.Delete(id);
                    }
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public IList<Contestant> GetLeaderboard(int tournamentID)
        {
            List<Contestant> contestants = new List<Contestant>();
            foreach (ContestantDTO dto in repository.GetStandings(tournamentID))
            {
                contestants.Add(new Contestant()
                {
                    ID = dto.ID,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    TournamentID = dto.TournamentID,
                    Wins = dto.Wins,
                    Losses = dto.Losses,
                });
            }
            CalculateRankings(contestants);
            return contestants;
        }

        private void CalculateRankings(List<Contestant> contestants)
        {
            for(int i = 0; i < contestants.Count; i++)
            {
                contestants[i].Rank = i + 1;
                if (i > 0)
                {
                    if(contestants[i].Wins == contestants[i - 1].Wins && contestants[i].Losses == contestants[i - 1].Losses)
                    {
                        contestants[i].Rank = contestants[i - 1].Rank;
                    }
                }
            }
        }

        private void ValidateModel(Tournament tournament)
        {
            List<string> results = Validate.AsModel(tournament).ToList();

            //Since there's no Data Annotation that checks against other properties,
            // perform any property-against-property checks here instead
            if (tournament.MaxContestants < tournament.MinContestants)
            {
                results.Add("The maximum contestants needs to be at least equal to the minimum contestants");
            }
            if(tournament.StartDate > tournament.EndDate)
            {
                results.Add("Cannot set start date after end date");
            }

            if (results.Any())
            {
                StringBuilder sbMessage = new StringBuilder();
                sbMessage.AppendLine("The following errors have occurred: ");
                foreach (string error in results)
                {
                    sbMessage.Append("- ");
                    sbMessage.AppendLine(error);
                }
                throw new ValidationException(sbMessage.ToString());
            }
        }
    }
}
