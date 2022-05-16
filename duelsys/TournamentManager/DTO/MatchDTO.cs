using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MatchDTO
    {
        public int ID { get; private set; }
        public string Sport { get; private set; }
        public bool IsFinished { get; private set; }
        public int HomeScore { get; private set; }
        public int AwayScore { get; private set; }
        public int HomeContestantID { get; private set; }
        public int AwayContestantID { get; private set; }

        public MatchDTO(int id, string sport, bool isFinished, int homeScore, int awayScore, int homeContestantID, int awayContestantID)
        {
            ID = id;
            Sport = sport;
            IsFinished = isFinished;
            HomeScore = homeScore;
            AwayScore = awayScore;
            HomeContestantID = homeContestantID;
            AwayContestantID = awayContestantID;
        }
    }
}
