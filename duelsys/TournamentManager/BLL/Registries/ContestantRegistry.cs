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

        public IList<Contestant> GetRegistrants(int tournamentID)
        {

        }
    }
}
