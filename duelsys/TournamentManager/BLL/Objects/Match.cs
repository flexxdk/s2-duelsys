using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;

namespace BLL.Objects
{
    public class Match
    {
        public int ID { get; private set; }
        public string Sport { get; private set; }
        public bool IsFinished { get; private set; }
        public int HomeScore { get; private set; }
        public int AwayScore { get; private set; }
        public int HomeContestantID { get; private set; }
        public int AwayContestantID { get; private set; }

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
