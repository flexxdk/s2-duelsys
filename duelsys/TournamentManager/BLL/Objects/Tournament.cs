using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using BLL.Enums;

namespace BLL.Objects
{
    public class Tournament
    {
        [Key]
        [Required]
        [Browsable(false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "No title was given")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "No description was given")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "No sport was given")]
        public string? Sport { get; set; }

        [Required(ErrorMessage = "Invalid team type")]
        public ContestantType Type { get; set; }

        [Required(ErrorMessage = "Specify a scoring system")]
        public string? Scoring { get; set; }

        [Required(ErrorMessage = "Specify the city of the event")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Specify the address of the event")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Minimum contestants needs to be set")]
        [Range(2, int.MaxValue, ErrorMessage = "Minimum contestants needs to be at least 2")]
        public int MinContestants { get; set; }

        [Required(ErrorMessage = "No start date was entered")]
        [Range(2, int.MaxValue, ErrorMessage = "Maximum contestants needs to be at least 2")]
        public int MaxContestants { get; set; }

        [Required(ErrorMessage = "No start date was entered")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "No end date was entered")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "The status is invalid")]
        public TournamentStatus Status { get; set; }

        [Required(ErrorMessage = "No tournament system was given")]
        public TournamentSystem System { get; set; }
    }
}
