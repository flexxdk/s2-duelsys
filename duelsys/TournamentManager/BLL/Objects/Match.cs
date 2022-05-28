using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using DTO;

namespace BLL.Objects
{
    public class Match
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required (ErrorMessage = "No tournament was assigned to the match.")]
        [Browsable(false)]
        public int TournamentID { get; set; }

        [Browsable(false)]
        public int HomeID { get; set; }

        [Required]
        public string? HomeName { get; set; }

        [Required]
        public int HomeScore { get; set; }

        [Browsable(false)]
        public int AwayID { get; set; }

        [Required]
        public string? AwayName { get; set; }

        [Required]
        public int AwayScore { get; set; }

        [Required]
        public bool IsFinished { get; set; }
    }
}
