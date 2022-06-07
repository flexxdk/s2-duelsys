using System.Collections.Generic;
using System;
using DAL.Interfaces;
using DTO.Users;
using DTO;

namespace UnitTests.Mocks
{
    public class MockContestant : IContestantRepository
    {
        private List<ContestantDTO> contestants;
        private List<AccountDTO> users;
        private List<TournamentDTO> tournaments;

        public MockContestant()
        {
            users = new List<AccountDTO>()
            {
                new AccountDTO(1, "Lex", "de Kort", "Administrator", "Solo", "lexdekort@gmail.com", "1234", "1234"),
                new AccountDTO(2, "Nick", "Blom", "Player", "Solo", "nickmeister@gmail.com", "abcd", "abcd"),
                new AccountDTO(3, "Sem", "Storms", "Staff", "Solo", "localcoholic@gmail.com", "hello", "world"),
                new AccountDTO(4, "Emilia", "Stoyanova", "Staff", "Solo", "devops@gmail.com", "linux", "rules"),
                new AccountDTO(5, "John", "Doe", "Player", "Solo", "johndoe@gmail.com", "leave her johnny", "sea shanty"),
                new AccountDTO(6, "Pepe", "Silvia", "Player", "Solo", "pepesilvia@gmail.com", "it's always sunny", "iasip")
            };

            contestants = new List<ContestantDTO>()
            {
                new ContestantDTO(1, "Lex", "de Kort", 1, 1, 1),
                new ContestantDTO(2, "Nick", "Blom",  1, 2, 0),
                new ContestantDTO(3, "Sem", "Storms",  1, 0, 2),

                new ContestantDTO(4, "Emilia", "Stoyanova", 2, 1, 1),
                new ContestantDTO(2, "Nick", "Blom",  2, 1, 1),
                new ContestantDTO(3, "Sem", "Storms",  2, 3, 0),
                new ContestantDTO(6, "Sem", "Storms",  2, 3, 0),
                new ContestantDTO(1, "Lex", "de Kort", 2, 2, 1),
                new ContestantDTO(5, "John", "Doe", 2, 2, 1),

                new ContestantDTO(3, "Sem", "Storms",  3, 3, 0),
                new ContestantDTO(1, "Lex", "de Kort", 3, 2, 1),
                new ContestantDTO(4, "Emilia", "Stoyanova", 3, 2, 2),
                new ContestantDTO(2, "Nick", "Blom",  3, 1, 2),
            };

            tournaments = new List<TournamentDTO>()
            {
                new TournamentDTO(1, "BAD!-Minton Championship", "It's badminton innit", "Badminton", "Solo", "Helmond", "Wethouder Ebbenlaan 30", 8, 32, DateTime.UtcNow.ToString("d"), DateTime.UtcNow.AddDays(7).ToString("d"), "Planned", "SingleElimination")
            };
        }

        public ContestantDTO? GetContestant(int tournamentID, int contestantID)
        {
            return contestants.Find(cont => cont.TournamentID == tournamentID && cont.ID == contestantID);
        }

        public IList<ContestantDTO> GetContestants(int tournamentID)
        {
            return contestants.FindAll(cont => cont.TournamentID == tournamentID);
        }

        public TournamentDTO? GetTournament(int tournamentID)
        {
            return tournaments.Find(trn => trn.ID == tournamentID);
        }

        public bool Register(int userID, int tournamentID)
        {
            ContestantDTO? contestant = GetContestant(tournamentID, userID);
            AccountDTO? user = users.Find(user => user.ID == userID);
            if (contestant == null && user != null)
            {
                contestants.Add(new ContestantDTO(userID, user.Name, user.SurName, tournamentID, 0, 0));
                return true;
            }
            return false;
        }

        public bool Deregister(int userID, int tournamentID)
        {
            ContestantDTO? contestant = GetContestant(tournamentID, userID);
            if (contestant != null)
            {
                contestants.Remove(contestant);
                return true;
            }
            return false;
        }

        public void SaveResults(int tournamentID, int winnerID, int wins, int loserID, int losses)
        {
            throw new NotImplementedException();
        }
    }
}
