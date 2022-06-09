using System.Linq;
using System.Collections.Generic;
using System.Collections;

using DTO;
using BLL.Objects.Users;
using BLL.Enums;
using DAL.Interfaces;

namespace BLL.Registries
{
    public class MatchGenerator
    {
        private IMatchRepository repository;

        public MatchGenerator(IMatchRepository repository) 
        {
            this.repository = repository;
        }

        public IEnumerable<MatchDTO> GenerateMatches(TournamentSystem system, int tournamentID, IEnumerable<Contestant> contestants)
        {
            IEnumerable<MatchDTO> matches;
            switch (system)
            {
                default:
                    matches = RoundRobin(tournamentID, contestants);
                    //matches = RecursiveRoundRobin(0, tournamentID, contestants.ToList());
                    break;

                case TournamentSystem.SingleElimination:
                    matches = SingleElimination(tournamentID, contestants);
                    break;
            }
            return matches;
        }

        public bool CheckCanGenerate(int tournamentID, TournamentSystem system)
        {
            IEnumerable<MatchDTO> matches = repository.GetMatches(tournamentID);
            switch (system)
            {
                //RoundRobin should always be default
                default:
                    return !matches.Any();
                case TournamentSystem.SingleElimination:
                    return !matches.Any() || (!matches.Any(match => match.IsFinished == false) && matches.Count() > 1);
            }
        }

        private IEnumerable<MatchDTO> RoundRobin(int tournamentID, IEnumerable<Contestant> contestants)
        {
            IList<MatchDTO> generated = new List<MatchDTO>();

            Queue<Contestant> contestantQueue = new Queue<Contestant>(contestants);
            while(contestantQueue.Count > 0)
            {
                Contestant home = contestantQueue.Dequeue();
                foreach(Contestant away in contestantQueue)
                {
                    generated.Add(new MatchDTO(0, tournamentID, false, home.ID, home.Name!, 0, away.ID, away.Name!, 0));
                }
            }

            return generated;
        }

        private IEnumerable<MatchDTO> RecursiveRoundRobin(int start, int tournamentID, IList<Contestant> contestants)
        {
            List<MatchDTO> generated = new List<MatchDTO>();
            if(start + 1 <= contestants.Count())
            {
                for(int i = start + 1; i < contestants.Count(); i++)
                {
                    generated.Add(new MatchDTO(0, tournamentID, false, contestants[start].ID, contestants[start].Name!, 0, contestants[i].ID, contestants[i].Name!, 0));
                }
                generated.AddRange(RecursiveRoundRobin(start + 1, tournamentID, contestants));
            }
            return generated;
        }

        private IEnumerable<MatchDTO> SingleElimination(int tournamentID, IEnumerable<Contestant> contestants)
        {
            IList<MatchDTO> generated = new List<MatchDTO>();

            //Remove all contestants that have lost a match and thus have been eliminated
            IEnumerable<Contestant> validContestants = contestants.Where(c => c.Losses == 0);

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
                    Contestant home = validContestants.ElementAt(i);
                    Contestant away = validContestants.ElementAt(i + 1); 
                    generated.Add(new MatchDTO(0, tournamentID, false, home.ID, home.Name!, 0, away.ID, away.Name!, 0));
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
