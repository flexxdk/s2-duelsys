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
        public int TournamentID { get; private set; }
        public bool IsFinished { get; private set; }
        public int HomeID { get; private set; }
        public string HomeName { get; private set; }
        public int HomeScore { get; private set; }
        public int AwayID { get; private set; }
        public string AwayName { get; private set; }
        public int AwayScore { get; private set; }

        public MatchDTO(int id, int tournamentID, bool isFinished, int homeID, string homeName, int homeScore, int awayID, string awayName, int awayScore)
        {
            ID = id;
            TournamentID = tournamentID;
            IsFinished = isFinished;
            HomeID = homeID;
            HomeName = homeName;
            HomeScore = homeScore;
            AwayID = awayID;
            AwayName = awayName;
            AwayScore = awayScore;
        }
    }
}
