using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using DTO;

namespace BLL.Objects
{
    public class Match
    {
        [Required]
        [Key]
        [Browsable(false)]
        public int ID { get; set; }

        [Required]
        public int TournamentID { get; set; }

        public int HomeScore { get; set; }

        public int AwayScore { get; set; }

        [Required]
        public int HomeContestantID { get; set; }

        [Required]
        public int AwayContestantID { get; set; }

        [Required]
        public bool IsFinished { get; set; }
    }
}
