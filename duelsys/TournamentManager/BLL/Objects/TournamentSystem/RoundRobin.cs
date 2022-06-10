using BLL.Objects.Users;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Objects.TournamentSystem
{
    public class RoundRobin : ITournamentSystem
    {
        public string Name { get; }

        public RoundRobin()
        {
            Name = "RoundRobin";
        }

        public bool CanGenerateMatches(IEnumerable<Match> matches)
        {
            return !matches.Any();
        }

        public IEnumerable<MatchDTO> GenerateMatches(int tournamentID, IEnumerable<Contestant> contestants)
        {
            IList<MatchDTO> generated = new List<MatchDTO>();

            // Dequeue next contestant in line and iterate over other contestants
            // to generate matches
            Queue<Contestant> contestantQueue = new Queue<Contestant>(contestants);
            while (contestantQueue.Count > 0)
            {
                Contestant home = contestantQueue.Dequeue();
                foreach (Contestant away in contestantQueue)
                {
                    generated.Add(new MatchDTO(0, tournamentID, false, home.ID, home.Name!, 0, away.ID, away.Name!, 0));
                }
            }

            return generated;
        }
    }
}
