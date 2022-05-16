using System.Collections.Generic;

using DAL.Interfaces;
using DTO;
using DTO.Users;

namespace UnitTests.Mocks
{
    public class MockTournament : ITournamentRepository
    {
        public void Create(TournamentDTO obj)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTournament(int tournamentID)
        {
            throw new System.NotImplementedException();
        }

        public IList<ContestantDTO> GetLeaderboard(int tournamentID)
        {
            throw new System.NotImplementedException();
        }

        public IList<TournamentDTO> Load()
        {
            throw new System.NotImplementedException();
        }

        public void Update(TournamentDTO obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
