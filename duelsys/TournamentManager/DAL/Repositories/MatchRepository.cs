﻿using DAL.Interfaces;
using DTO;
using DTO.Users;

namespace DAL.Repositories
{
    public class MatchRepository : BaseRepository, IMatchRepository
    {
        public MatchRepository(DbContext dbContext) : base(dbContext) { }

        public MatchDTO? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public int Create(MatchDTO obj)
        {
            throw new NotImplementedException();
        }

        public IList<MatchDTO> GetMatches(int tournamentID)
        {
            throw new NotImplementedException();
        }

        public IList<MatchDTO> Load()
        {
            throw new NotImplementedException();
        }

        public int Update(MatchDTO obj)
        {
            throw new NotImplementedException();
        }

        public IList<ContestantDTO> GetTournamentContestants(int tournamentID)
        {
            throw new NotImplementedException();
        }
    }
}
