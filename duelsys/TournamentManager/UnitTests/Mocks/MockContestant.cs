using System.Collections.Generic;

using DAL.Interfaces;
using DTO.Users;

namespace UnitTests.Mocks
{
    public class MockContestant : IContestantRepository
    {
        private List<ContestantDTO> contestants;
        private List<UserDTO> users;
        private int idSeeder = 0;

        public MockContestant()
        {
            users = new List<UserDTO>()
            {
                new UserDTO(1, "Lex", "de Kort", "Administrator", "lexdekort@gmail.com", "1234", "1234"),
                new UserDTO(2, "Nick", "Blom", "Player", "nickmeister@gmail.com", "abcd", "abcd"),
                new UserDTO(3, "Sem", "Storms", "Staff", "localcoholic@gmail.com", "hello", "world"),
                new UserDTO(4, "Emilia", "Stoyanova", "Staff", "devops@gmail.com", "linux", "rules"),
                new UserDTO(5, "John", "Doe", "Player", "johndoe@gmail.com", "leave her johnny", "sea shanty")
            };

            contestants = new List<ContestantDTO>()
            {
                new ContestantDTO(1, "Lex", "de Kort", 1, 1, 1),
                new ContestantDTO(2, "Nick", "Blom",  1, 2, 0),
                new ContestantDTO(3, "Sem", "Storms",  1, 0, 2),

                new ContestantDTO(4, "Emilia", "Stoyanova", 2, 1, 1),
                new ContestantDTO(2, "Nick", "Blom",  2, 1, 1),

                new ContestantDTO(3, "Sem", "Storms",  3, 3, 0),
                new ContestantDTO(1, "Lex", "de Kort", 3, 2, 1),
                new ContestantDTO(4, "Emilia", "Stoyanova", 3, 2, 2),
                new ContestantDTO(2, "Nick", "Blom",  3, 1, 2),
            };
        }

        public ContestantDTO? GetContestant(int tournamentID, int contestantID)
        {
            return contestants.Find(cont => cont.TournamentID == tournamentID && cont.ID == contestantID);
        }

        public IList<ContestantDTO> GetRegistrants(int tournamentID)
        {
            return contestants.FindAll(cont => cont.TournamentID == tournamentID);
        }

        public bool Register(int userID, int tournamentID)
        {
            ContestantDTO? contestant = GetContestant(tournamentID, userID);
            UserDTO? user = users.Find(user => user.ID == userID);
            if (contestant == null && user != null)
            {
                contestants.Add(new ContestantDTO(userID, user.FirstName, user.LastName, tournamentID, 0, 0));
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
    }
}
