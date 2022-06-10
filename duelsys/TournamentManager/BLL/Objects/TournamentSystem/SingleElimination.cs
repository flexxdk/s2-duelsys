using BLL.Objects.Users;
using DTO;
using BLL.Validation.Exceptions;
namespace BLL.Objects.TournamentSystem
{
    public class SingleElimination : ITournamentSystem
    {
        public string Name { get; }

        public SingleElimination()
        {
            Name = "SingleElimination";
        }

        public bool CanGenerateMatches(IEnumerable<Match> matches)
        {
            return !matches.Any() || !matches.Any(match => match.IsFinished == false);
        }

        public IEnumerable<MatchDTO> GenerateMatches(int tournamentID, IEnumerable<Contestant> contestants)
        {
            IList<MatchDTO> generated = new List<MatchDTO>();

            // Remove all contestants that have lost a match and thus have been eliminated
            IEnumerable<Contestant> validContestants = contestants.Where(c => c.Losses == 0);
            if (validContestants.Count() <= 1) throw new NoValidContestantsException("There are no more matches to be generated after the finals.");

            // Calculate the nearest power of two based on the list size
            int validCount = validContestants.Count();
            int pow = CalculateNextPowerOfTwo(validCount);

            // Calculate the for-loop start position
            // based on the previously evaluated power
            int range = pow - validCount;

            for (int i = range; i < validCount; i += 2)
            {
                // Ensure we never go out of bounds of the list
                if (i < validCount - 1)
                {
                    Contestant home = validContestants.ElementAt(i);
                    Contestant away = validContestants.ElementAt(i + 1);
                    generated.Add(new MatchDTO(0, tournamentID, false, home.ID, home.Name!, 0, away.ID, away.Name!, 0));
                }
            }

            return generated;
        }

        private int CalculateNextPowerOfTwo(int value)
        {
            // Start n at first bit
            int n = 1;

            // If value is larger than n, shift bit to the left
            // Keep shifting until we find the nearest upper power of two
            while (value > n)
            {
                n <<= 1;
            }

            return n;
        }
    }
}
