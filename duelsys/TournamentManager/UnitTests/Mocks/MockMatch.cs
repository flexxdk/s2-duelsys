using System.Collections.Generic;

using DAL.Interfaces;
using DTO;
using DTO.Users;

namespace UnitTests.Mocks
{
    public class MockMatch : IMatchRepository
    {
        private List<MatchDTO> matches;
        private List<ContestantDTO> contestants;
        private int idSeeder = 0;

        public MockMatch()
        {
            matches = new List<MatchDTO>()
            {
                new MatchDTO(++idSeeder, 1, false, 0, 0, 1, 2),
                new MatchDTO(++idSeeder, 1, false, 0, 0, 4, 3),
                new MatchDTO(++idSeeder, 1, false, 0, 0, 1, 3),
                new MatchDTO(++idSeeder, 1, false, 0, 0, 2, 4),
                new MatchDTO(++idSeeder, 1, false, 0, 0, 1, 3),
                new MatchDTO(++idSeeder, 1, false, 0, 0, 4, 2),
            };

            contestants = new List<ContestantDTO>() {
                new ContestantDTO(1, "Lex", "de Kort", 1, 0, 0),
                new ContestantDTO(2, "Nick", "Blom", 1, 0, 0),
                new ContestantDTO(3, "Sem", "Storms", 1, 0, 0),
                new ContestantDTO(4, "Emilia", "Stoyanova", 1, 0, 0),
                new ContestantDTO(5, "Lex", "de Kort", 1, 0, 0),
                new ContestantDTO(6, "Nick", "Blom", 1, 0, 0),
                new ContestantDTO(7, "Sem", "Storms", 1, 0, 0),
                new ContestantDTO(8, "Emilia", "Stoyanova", 1, 0, 0),

                new ContestantDTO(9, "Lex", "de Kort", 2, 0, 0),
                new ContestantDTO(10, "Nick", "Blom", 2, 0, 0),
                new ContestantDTO(11, "Sem", "Storms", 2, 0, 0),
                new ContestantDTO(12, "Emilia", "Stoyanova", 2, 0, 0),
                new ContestantDTO(13, "Lex", "de Kort", 2, 0, 0),
                new ContestantDTO(14, "Nick", "Blom", 2, 0, 0),
                new ContestantDTO(15, "Sem", "Storms", 2, 0, 0),
                new ContestantDTO(16, "Emilia", "Stoyanova", 2, 0, 0),
            };
        }

        public MatchDTO? GetByID(int id)
        {
            return matches.Find(match => match.ID == id);
        }

        public int Create(MatchDTO obj)
        {
            matches.Add(new MatchDTO(++idSeeder, obj.TournamentID, obj.IsFinished, obj.HomeScore, obj.AwayScore, obj.HomeContestantID, obj.AwayContestantID));
            return idSeeder;
        }

        public IList<MatchDTO> GetMatches(int tournamentID)
        {
            return matches.FindAll(m => m.TournamentID == tournamentID);
        }

        public IList<ContestantDTO> GetTournamentContestants(int tournamentID)
        {
            return contestants.FindAll(c => c.TournamentID == tournamentID);
        }

        public IList<MatchDTO> Load()
        {
            throw new System.NotImplementedException();
        }

        public int Update(MatchDTO obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
