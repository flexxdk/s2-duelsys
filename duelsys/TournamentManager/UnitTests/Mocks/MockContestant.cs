using System.Collections.Generic;

using DAL.Interfaces;
using DTO.Users;

namespace UnitTests.Mocks
{
    public class MockContestant : IContestantRepository
    {
        private List<ContestantDTO> contestants;

        public MockContestant()
        {
            contestants = new List<ContestantDTO>()
            {
                new ContestantDTO(2, "Nick", "Blom",  1, 2, 0),
                new ContestantDTO(1, "Lex", "de Kort", 1, 1, 1),
                new ContestantDTO(3, "Sem", "Storms",  1, 0, 2),

                new ContestantDTO(4, "Emilia", "Stoyanova", 2, 1, 1),
                new ContestantDTO(2, "Nick", "Blom",  2, 1, 1),

                new ContestantDTO(3, "Sem", "Storms",  3, 3, 0),
                new ContestantDTO(1, "Lex", "de Kort", 3, 2, 1),
                new ContestantDTO(4, "Emilia", "Stoyanova", 3, 2, 2),
                new ContestantDTO(2, "Nick", "Blom",  3, 1, 2),
                new ContestantDTO(5, "Fontys", "Man",  3, 1, 2),
                new ContestantDTO(6, "New", "Guy",  3, 0, 1),
                new ContestantDTO(7, "Dew", "Guy",  3, 0, 0),
                new ContestantDTO(8, "Kew", "Guy",  3, 0, 0)
            };
        }

        public ContestantDTO GetContestant(int tournamentID, int contestantID)
        {
            throw new System.NotImplementedException();
        }

        public IList<ContestantDTO> GetRegistrants(int tournamentID)
        {
            throw new System.NotImplementedException();
        }

        public void Register(ContestantDTO contestantDTO)
        {
            throw new System.NotImplementedException();
        }

        public void Deregister(ContestantDTO contestantDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
