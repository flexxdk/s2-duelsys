using System.Collections.Generic;

using DAL.Interfaces;
using DTO.Users;

namespace UnitTests.Mocks
{
    public class MockUsers : IUserRepository
    {
        private List<UserDTO> users;
        private int idSeeder = 0;

        public MockUsers()
        {
            users = new List<UserDTO>()
            {
                new UserDTO(++idSeeder, "Lex", "de Kort", "Administrator", "lexdekort@gmail.com", "1234", "1234"),
                new UserDTO(++idSeeder, "Nick", "Blom", "Player", "nickmeister@gmail.com", "abcd", "abcd"),
                new UserDTO(++idSeeder, "Sem", "Storms", "Staff", "localcoholic@gmail.com", "hello", "world"),
                new UserDTO(++idSeeder, "Emilia", "Stoyanova", "Staff", "devops@gmail.com", "linux", "rules")
            };
        }

        public IList<UserDTO> Load()
        {
            return users;
        }

        public int Register(UserDTO dto)
        {
            users.Add(new UserDTO(++idSeeder, dto.FirstName, dto.LastName, dto.Role, dto.Email, dto.Password, dto.Salt));
            return idSeeder;
        }
    }
}
