using System.Collections.Generic;

using DAL.Interfaces;
using DTO.Users;

namespace UnitTests.Mocks
{
    public class MockUsers : IUserRepository
    {
        public IList<UserDTO> Load()
        {
            return new List<UserDTO>()
            { 
                new UserDTO(1, "Lex", "de Kort", "Administrator", "lexdekort@gmail.com", "1234", "1234"),
                new UserDTO(2, "Nick", "Blom", "Player", "nickmeister@gmail.com", "abcd", "abcd"),
                new UserDTO(3, "Sem", "Storms", "Staff", "fontys_man@gmail.com", "hello", "world"),
                new UserDTO(4, "Emilia", "Stoyanova", "Staff", "devops@gmail.com", "linux", "rules")
            };
        }

        public void Register(UserDTO userDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
