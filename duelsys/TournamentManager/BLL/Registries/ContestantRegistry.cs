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
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    TournamentID = dto.TournamentID,
                    Wins = dto.Wins,
                    Losses = dto.Losses
                };
            }
            return null;
        }

        public IList<Contestant> GetRegistrants(int tournamentID)
        {
            List<Contestant> contestants = new List<Contestant>();
            foreach(ContestantDTO cont in repository.GetRegistrants(tournamentID))
            {
                contestants.Add(new Contestant()
                {
                    ID = cont.ID,
                    FirstName = cont.FirstName,
                    LastName = cont.LastName,
                    TournamentID = cont.TournamentID,
                    Wins = cont.Wins,
                    Losses = cont.Losses
                });
            }
            return contestants;
        }

        public bool Register(int userID, int tournamentID)
        {
            return repository.Register(userID, tournamentID);
        }

        public bool Deregister(int userID, int tournamentID)
        {
            return repository.Deregister(userID, tournamentID);
        }
    }
}
