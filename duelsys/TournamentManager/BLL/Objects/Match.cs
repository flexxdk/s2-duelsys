using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using BLL.Validation.Exceptions;

namespace BLL.Objects
{
    public class Match
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required (ErrorMessage = "No tournament was assigned to the match.")]
        public int TournamentID { get; set; }

        [Browsable(false)]
        public int HomeID { get; set; }

        [Required]
        [DisplayName("Home Contestant")]
        public string? HomeName { get; set; }

        [Required]
        [DisplayName("Home Score")]
        public int HomeScore { get; set; }

        [Browsable(false)]
        public int AwayID { get; set; }

        [Required]
        [DisplayName("Away Contestant")]
        public string? AwayName { get; set; }

        [Required]
        [DisplayName("Away Score")]
        public int AwayScore { get; set; }

        [Required]
        [DisplayName("Match Played")]
        public bool IsFinished { get; set; }

        public int GetWinner()
        {
            if (IsFinished)
            {
                if (HomeScore > AwayScore)
                {
                    return HomeID;
                }
                else if (HomeScore < AwayScore)
                {
                    return AwayID;
                }
                else
                {
                    //Use '-1' to denote draw
                    return -1;
                }
            }
            throw new MatchNotPlayedException("This match has not taken place.");
        }
        public int GetLoser()
        {
            if (IsFinished)
            {
                if (HomeScore < AwayScore)
                {
                    return HomeID;
                }
                else if (HomeScore > AwayScore)
                {
                    return AwayID;
                }
                else
                {
                    //Use '-1' to denote draw
                    return -1;
                }
            }
            throw new MatchNotPlayedException("This match has not taken place.");
        }
    }
}
