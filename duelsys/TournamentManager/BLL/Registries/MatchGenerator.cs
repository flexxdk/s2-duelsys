using DTO;
using DTO.Users;
using BLL.Enums;

namespace BLL.Registries
{
    public class MatchGenerator
    {
        public MatchGenerator() { }

        public IEnumerable<MatchDTO> GenerateMatches(TournamentSystem system, int tournamentID, IList<ContestantDTO> contestants)
        {
            IEnumerable<MatchDTO> matches;
            switch (system)
            {
                default:
                case TournamentSystem.RoundRobin:
                    matches = RoundRobin(tournamentID, contestants);
                    break;

                case TournamentSystem.SingleElimination:
                    matches = SingleElimination(tournamentID, contestants);
                    break;
            }
            return matches;
        }

        private IEnumerable<MatchDTO> RoundRobin(int tournamentID, IList<ContestantDTO> contestants)
        {
            IList<MatchDTO> generated = new List<MatchDTO>();

            Queue<ContestantDTO> contestantQueue = new Queue<ContestantDTO>(contestants);
            while(contestantQueue.Count > 0)
            {
                ContestantDTO contestantHome = contestantQueue.Dequeue();
                foreach(ContestantDTO contestant in contestantQueue)
                {
                    generated.Add(new MatchDTO(0, tournamentID, false, 0, 0, contestantHome.ID, contestant.ID));
                }
            }

            return generated;
        }

        private IEnumerable<MatchDTO> SingleElimination(int tournamentID, IList<ContestantDTO> contestants)
        {
            IList<MatchDTO> generated = new List<MatchDTO>();

            //Remove all contestants that have lost a match and thus have been eliminated
            IEnumerable<ContestantDTO> validContestants = contestants.Where(c => c.Losses == 0);

            //Calculate the nearest power of two based on the list size
            int validCount = validContestants.Count();
            int pow = CalculateNextPowerOfTwo(validCount);

            //Calculate the for-loop start position
            //based on the previously evaluated power
            int range = pow - validCount;

            for(int i = range; i < validCount; i += 2)
            {
                //Ensure we never go out of bounds of the list
                if (i < validCount - 1)
                {
                    ContestantDTO home = validContestants.ElementAt(i);
                    ContestantDTO away = validContestants.ElementAt(i + 1);
                    generated.Add(new MatchDTO(0, tournamentID, false, 0, 0, home.ID, away.ID));
                }
            }

            return generated;
        }

        private int CalculateNextPowerOfTwo(int n)
        {
            int count = 1;

            while(n > count)
            {
                count <<= 1;
            }

            return count;
        }
    }
}
