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

        [Required(ErrorMessage = "No name was entered")]
        public string? Name { get; set; }

        public bool AllowRegistration { get; set; }

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

        [Required(ErrorMessage = "No tournament system was given")]
        public TournamentSystem System { get; set; }
    }
}
