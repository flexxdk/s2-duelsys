using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Objects;
using BLL.Objects.Users;
using DTO;
using DTO.Users;
using BLL.Enums;

namespace BLL.Registries
{
    public class MatchGenerator
    {
        public MatchGenerator() { }

        public IList<MatchDTO> GenerateMatches(Tournament tournament, List<ContestantDTO> contestants)
        {
            List<MatchDTO> matches;
            switch (tournament.System)
            {
                default:
                case TournamentSystem.RoundRobin:
                    matches = RoundRobin(tournament, contestants).ToList();
                    break;

                case TournamentSystem.SingleElimination:
                    matches = SingleElimination(tournament, contestants).ToList();
                    break;
            }
            return matches;
        }

        private IList<MatchDTO> RoundRobin(Tournament tournament, List<ContestantDTO> contestants)
        { 
            List<MatchDTO> generated = new List<MatchDTO>();

            Queue<ContestantDTO> contestantQueue = new Queue<ContestantDTO>(contestants);
            while(contestantQueue.Count > 0)
            {
                ContestantDTO contestantHome = contestantQueue.Dequeue();
                foreach(ContestantDTO contestant in contestantQueue)
                {
                    generated.Add(new MatchDTO(0, tournament.ID, false, 0, 0, contestantHome.ID, contestant.ID));
                }
            }

            return generated;
        }

        private IList<MatchDTO> SingleElimination(Tournament tournament, List<ContestantDTO> contestants)
        {
            List<MatchDTO> generated = new List<MatchDTO>();

            //Remove all contestants that have lost a match and thus have been eliminated
            List<ContestantDTO> validContestants = contestants.FindAll(c => c.Losses < 1);

            //Calculate the power of
            int validCount = validContestants.Count;
            int pow = 1;
            while (validCount > 2 * pow) pow *= 2;

            //Calculate the for-loop start position
            //based on the previously evaluated power
            int range = 0;
            if(validCount % (2 * pow) != 0) range = 2 * pow - validCount;

            for(int i = range; i < validCount; i += 2)
            {
                //Ensure we never go out of bounds of the list
                if (i < validCount - 1)
                {
                    ContestantDTO home = validContestants[i];
                    ContestantDTO away = validContestants[i + 1];
                    generated.Add(new MatchDTO(0, tournament.ID, false, 0, 0, home.ID, away.ID));
                }
            }

            return generated;
        }
    }
}
