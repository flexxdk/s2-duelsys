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

        public MockTournament()
        {
            tournaments = new List<TournamentDTO>()
            {
                new TournamentDTO(1, "BAD!-Minton Championship", "It's badminton innit", "Badminton", "Solo", "Helmond", "Wethouder Ebbenlaan 30", 8, 32, DateTime.UtcNow.ToString("d"), DateTime.UtcNow.AddDays(7).ToString("d"), "Planned", "SingleElimination"),
                new TournamentDTO(2, "GOOD!-Minton Championship", "It's badminton innit", "Badminton", "Solo", "Helmond", "Wethouder Ebbenlaan 30", 4, 16, DateTime.UtcNow.AddDays(8).ToString("d"), DateTime.UtcNow.AddDays(13).ToString("d"), "Planned", "RoundRobin"),
                new TournamentDTO(3, "Regular-Minton Cup", "It's badminton innit", "Badminton", "Solo", "Helmond", "Wethouder Ebbenlaan 30", 5, 20, DateTime.UtcNow.AddDays(20).ToString("d"), DateTime.UtcNow.AddDays(30).ToString("d"), "Planned", "RoundRobin"),
                new TournamentDTO(4, "It's-A-Minton Cup", "It's badminton innit", "Badminton", "Solo", "Helmond", "Wethouder Ebbenlaan 30", 5, 12, DateTime.UtcNow.AddDays(20).ToString("d"), DateTime.UtcNow.AddDays(30).ToString("d"), "Planned", "RoundRobin"),
                new TournamentDTO(5, "It's Another Cup", "It's badminton innit", "Badminton", "Solo", "Helmond", "Wethouder Ebbenlaan 30", 5, 12, DateTime.UtcNow.AddDays(20).ToString("d"), DateTime.UtcNow.AddDays(30).ToString("d"), "Planned", "RoundRobin"),
                new TournamentDTO(6, "Active-Ton Cup", "Active tournament", "Badminton", "Solo", "Helmond", "Wethouder Ebbenlaan 30", 5, 12, DateTime.UtcNow.AddDays(20).ToString("d"), DateTime.UtcNow.AddDays(30).ToString("d"), "Running", "RoundRobin"),
                new TournamentDTO(7, "Finish-Ton Cup", "Finished tournament", "Badminton", "Solo", "Helmond", "Wethouder Ebbenlaan 30", 5, 12, DateTime.UtcNow.AddDays(20).ToString("d"), DateTime.UtcNow.AddDays(30).ToString("d"), "Planned", "RoundRobin"),
                new TournamentDTO(8, "Cancel-Ton Cup", "Cancelled tournament", "Badminton", "Solo", "Helmond", "Wethouder Ebbenlaan 30", 5, 12, DateTime.UtcNow.AddDays(20).ToString("d"), DateTime.UtcNow.AddDays(30).ToString("d"), "Planned", "RoundRobin")
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
                new ContestantDTO(8, "Kew", "Guy",  3, 0, 0),

                new ContestantDTO(3, "Sem", "Storms",  4, 0, 0),
                new ContestantDTO(1, "Lex", "de Kort", 4, 0, 0),
                new ContestantDTO(4, "Emilia", "Stoyanova", 4, 0, 0),
                new ContestantDTO(2, "Nick", "Blom",  4, 0, 0),
                new ContestantDTO(5, "Fontys", "Man",  4, 0, 0),
                new ContestantDTO(6, "New", "Guy",  4, 0, 0),
                new ContestantDTO(7, "Dew", "Guy",  4, 0, 0),
                new ContestantDTO(8, "Kew", "Guy",  4, 0, 0),

                new ContestantDTO(3, "Sem", "Storms",  5, 0, 0),
                new ContestantDTO(1, "Lex", "de Kort", 5, 0, 0),
                new ContestantDTO(4, "Emilia", "Stoyanova", 5, 0, 0),
                new ContestantDTO(2, "Nick", "Blom",  5, 0, 0)
            };
        }

        public int Create(TournamentDTO dto)
        {
            int newID = tournaments.Count + 1;
            tournaments.Add(new TournamentDTO(newID, dto.Title, dto.Description, dto.Sport, dto.Type, dto.City, dto.Address, dto.MinContestants, dto.MaxContestants, dto.StartDate, dto.EndDate, dto.Status, dto.System));
            return newID;
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
            return tournaments.Find(trn => trn.ID == id);
        }

        public IEnumerable<TournamentDTO> FilterTournamentsOnStatus(string filter)
        {
            return tournaments.FindAll(trn => trn.Status == filter);
        }
    }
}
