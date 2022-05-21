using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Objects.Users
{
    public class Contestant : Account
    {
        [Required]
        [Browsable(false)]
        public int TournamentID { get; set; }

        public int Rank { get; set; }

        [Required]
        public int Wins { get; set; }

        [Required]
        public int Losses { get; set; }
    }
}
