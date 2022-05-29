using System;
using System.Linq;
using System.Collections.Generic;

using DAL.Interfaces;
using DTO;
using DTO.Users;

namespace UnitTests.Mocks
{
    public class MockTournament : ITournamentRepository
    {
        private List<TournamentDTO> tournaments;
        private List<ContestantDTO> contestants;
        private int trnSeeder = 0;

        public MockTournament()
        {
            tournaments = new List<TournamentDTO>()
            {
                new TournamentDTO(++trnSeeder, "BAD!-Minton Championship", "It's badminton innit", "Badminton", "Solo", "Points", "Helmond", "Wethouder Ebbenlaan 30", 8, 32, DateTime.UtcNow.ToString("d"), DateTime.UtcNow.AddDays(7).ToString("d"), "Planned", "SingleElimination"),
                new TournamentDTO(++trnSeeder, "GOOD!-Minton Championship", "It's badminton innit", "Badminton", "Solo", "Points", "Helmond", "Wethouder Ebbenlaan 30", 4, 16, DateTime.UtcNow.AddDays(8).ToString("d"), DateTime.UtcNow.AddDays(13).ToString("d"), "Planned", "RoundRobin"),
                new TournamentDTO(++trnSeeder, "Regular-Minton Cup", "It's badminton innit", "Badminton", "Solo", "Points", "Helmond", "Wethouder Ebbenlaan 30", 10, 20, DateTime.UtcNow.AddDays(20).ToString("d"), DateTime.UtcNow.AddDays(30).ToString("d"), "Planned", "RoundRobin")
            };

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

        public int Create(TournamentDTO dto)
        {
            tournaments.Add(new TournamentDTO(++trnSeeder, dto.Title, dto.Description, dto.Sport, dto.Type, dto.Scoring, dto.City, dto.Address, dto.MinContestants, dto.MaxContestants, dto.StartDate, dto.EndDate, dto.Status, dto.System));
            return trnSeeder;
        }

        public int Update(TournamentDTO dto)
        {
            int index = tournaments.IndexOf(tournaments.Find(trn => trn.ID == dto.ID)!);
            if (index > -1)
            {
                tournaments[index] = dto;
            }
            return 1;
        }

        public bool Delete(int tournamentID)
        {
            TournamentDTO? dto = tournaments.Find(trn => trn.ID == tournamentID);
            if (dto != null)
            {
                tournaments.Remove(dto);
                return true;
            }
            return false;
        }

        public IList<ContestantDTO> GetStandings(int tournamentID)
        {
            List<ContestantDTO> ordered = new List<ContestantDTO>();
            ordered = contestants.FindAll(contestant => contestant.TournamentID == tournamentID);
            return ordered;
        }

        public IList<TournamentDTO> Load()
        {
            return tournaments;
        }

        public TournamentDTO? GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
