using System.Collections.Generic;
using System;
using System.Linq;

using DAL.Interfaces;
using DTO.Users;

namespace UnitTests.Mocks
{
    public class MockUsers : IUserRepository
    {
        private List<AccountDTO> users;
        private int idSeeder = 0;

        public MockUsers()
        {
            users = new List<AccountDTO>()
            {
                new AccountDTO(++idSeeder, "Lex", "de Kort", "Administrator", "Solo", "lexdekort@gmail.com", "1234", "1234"),
                new AccountDTO(++idSeeder, "Nick", "Blom", "Player", "Solo", "nickmeister@gmail.com", "abcd", "abcd"),
                new AccountDTO(++idSeeder, "Sem", "Storms", "Staff", "Solo", "localcoholic@gmail.com", "hello", "world"),
                new AccountDTO(++idSeeder, "Emilia", "Stoyanova", "Staff", "Solo", "devops@gmail.com", "linux", "rules")
            };
        }

        public bool Register(AccountDTO dto)
        {
            users.Add(new AccountDTO(++idSeeder, dto.Name, dto.SurName, dto.Role, dto.Type, dto.Email, dto.Password, dto.Salt));
            return true;
        }
        public bool CheckIfEmailExists(string email)
        {
            return users.Any(user => user.Email == email);
        }

        public AccountDTO? GetByID(int id)
        {
            return users.Find(user => user.ID == id);
        }
    }
}
