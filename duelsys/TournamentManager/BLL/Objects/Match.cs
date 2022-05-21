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
        public int ID { get; private set; }
        [Required]
        public string Sport { get; private set; }
        public int HomeScore { get; private set; }
        public int AwayScore { get; private set; }
        [Required]
        public int HomeContestantID { get; private set; }
        [Required]
        public int AwayContestantID { get; private set; }
        [Required]
        public bool IsFinished { get; private set; }

        public Match(MatchDTO dto)
        {
            ID = dto.ID;
            Sport = dto.Sport;
            IsFinished = dto.IsFinished;
            HomeScore = dto.HomeScore;
            AwayScore = dto.AwayScore;
            HomeContestantID = dto.HomeContestantID;
            AwayContestantID = dto.AwayContestantID;
        }
    }
}
