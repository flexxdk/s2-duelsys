using System.Collections.Generic;

using DAL.Interfaces;
using DTO;

namespace UnitTests.Mocks
{
    public class MockMatch : IMatchRepository
    {
        public void Create(MatchDTO obj)
        {
            throw new System.NotImplementedException();
        }

        public IList<MatchDTO> GetMatches(int tournamentID)
        {
            throw new System.NotImplementedException();
        }

        public IList<MatchDTO> Load()
        {
            throw new System.NotImplementedException();
        }

        public void Update(MatchDTO obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
