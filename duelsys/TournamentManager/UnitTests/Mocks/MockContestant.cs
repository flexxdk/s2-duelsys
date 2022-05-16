using System.Collections.Generic;

using DAL.Interfaces;
using DTO.Users;

namespace UnitTests.Mocks
{
    public class MockContestant : IContestantRepository
    {
        public void Deregister(ContestantDTO contestantDTO)
        {
            throw new System.NotImplementedException();
        }

        public ContestantDTO GetContestant(int contestantID)
        {
            throw new System.NotImplementedException();
        }

        public IList<ContestantDTO> GetContestantsInTournament(int tournamentID)
        {
            throw new System.NotImplementedException();
        }

        public IList<ContestantDTO> Load()
        {
            throw new System.NotImplementedException();
        }

        public void Register(ContestantDTO contestantDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
