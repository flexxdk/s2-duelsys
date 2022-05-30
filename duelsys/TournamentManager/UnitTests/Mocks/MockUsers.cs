using System.Collections.Generic;
using System;
using System.Linq;

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
                new UserDTO(++idSeeder, "Lex", "de Kort", "Administrator", "Solo", "lexdekort@gmail.com", "1234", "1234"),
                new UserDTO(++idSeeder, "Nick", "Blom", "Player", "Solo", "nickmeister@gmail.com", "abcd", "abcd"),
                new UserDTO(++idSeeder, "Sem", "Storms", "Staff", "Solo", "localcoholic@gmail.com", "hello", "world"),
                new UserDTO(++idSeeder, "Emilia", "Stoyanova", "Staff", "Solo", "devops@gmail.com", "linux", "rules")
            };
        }

        public bool Register(UserDTO dto)
        {
            users.Add(new UserDTO(++idSeeder, dto.Name, dto.SurName, dto.Role, dto.Type, dto.Email, dto.Password, dto.Salt));
            return true;
        }
        public bool CheckIfEmailExists(string email)
        {
            return users.Any(user => user.Email == email);
        }

        public UserDTO? GetByID(int id)
        {
            return users.Find(user => user.ID == id);
        }
    }
}
