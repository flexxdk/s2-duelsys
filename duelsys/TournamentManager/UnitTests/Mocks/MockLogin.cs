using System.Collections.Generic;

using DAL.Interfaces;
using DTO.Users;
using BLL.Encryption;
using BLL.Enums;

namespace UnitTests.Mocks
{
    public class MockLogin : ILoginRepository
    {
        private readonly List<AccountDTO> accounts = new List<AccountDTO>();

        public MockLogin()
        {
            List<AccountDTO> preset = new List<AccountDTO>()
            {
                new AccountDTO(1, "Lex", "de Kort", UserRole.Administrator.ToString(), TeamType.Solo.ToString(), "lexdekort@gmail.com", "1234", string.Empty),
                new AccountDTO(2, "Nick", "Blom", UserRole.Player.ToString(), TeamType.Solo.ToString(), "nickblom@gmail.com", "5678", string.Empty),
                new AccountDTO(3, "Emilia", "Stoyanova", UserRole.Player.ToString(), TeamType.Solo.ToString(), "emilia@gmail.com", "abcd", string.Empty),
                new AccountDTO(4, "Sem", "Storms", UserRole.Staff.ToString(), TeamType.Solo.ToString(), "semstorms@gmail.com", "efgh", string.Empty)
            };

            foreach (AccountDTO acc in preset) 
            {
                SaltKey sk = new Encryptor().Hash(acc.Password);
                accounts.Add(new AccountDTO(acc.ID, acc.Name, acc.SurName, acc.Role, acc.Type, acc.Email, sk.Key, sk.Salt));
            }
        }

        public AccountDTO? GetCredentials(string email)
        {
            return accounts.Find(acc => acc.Email == email);
        }

        internal List<AccountDTO> GenerateGarbage()
        {
            return new List<AccountDTO>();
        }
    }
}
