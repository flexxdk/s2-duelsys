using System.ComponentModel.DataAnnotations;

using DTO.Users;

namespace BLL.Objects.Users
{
    public class Contestant : Account
    {
        [Required]
        public int TournamentID { get; set; }
        [Required]
        public int Wins { get; set; }
        [Required]
        public int Losses { get; set; }
    }
}
