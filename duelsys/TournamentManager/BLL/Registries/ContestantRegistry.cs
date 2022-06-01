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
    public class ContestantRegistry
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

        public bool Register(int userID, string userType, int tournamentID)
        {
            if (Validate.AsEnum<ContestantType>(userType))
            {
                TournamentDTO? dto = repository.GetTournament(tournamentID);
                if (dto != null && dto.Type == userType)
                {
                    if (GetContestant(userID, tournamentID) == null)
                    {
                        return repository.Register(userID, tournamentID);
                    }
                }
            }
            return false;
        }

        public bool Deregister(int userID, int tournamentID)
        {
            TournamentDTO? dto = repository.GetTournament(tournamentID);
            if(dto != null)
            {
                if (GetContestant(userID, tournamentID) != null)
                {
                    return repository.Deregister(userID, tournamentID);
                }
            }
            return false;
        }
    }
}
