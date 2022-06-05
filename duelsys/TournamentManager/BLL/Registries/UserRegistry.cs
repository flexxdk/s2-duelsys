using BLL.Encryption;
using BLL.Validation;
using BLL.Enums;
using BLL.Objects.Users;
using DAL.Interfaces;
using DTO.Users;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Registries
{
    public class UserRegistry : BaseRegistry
    {
        private readonly IUserRepository repository;
        private Encryptor encryptor;

        public UserRegistry(IUserRepository repository)
        {
            this.repository = repository;
            this.encryptor = new Encryptor();
        }

        public Account? GetByID(int id)
        {
            AccountDTO? dto = repository.GetByID(id);
            if(dto == null)
            {
                return null;
            }
            return new Account()
            {
                ID = dto.ID,
                Name = dto.Name,
                Role = (UserRole)Enum.Parse(typeof(UserRole), dto.Role),
                Type = (TeamType)Enum.Parse(typeof(TeamType), dto.Type),
                Email = dto.Email,
                Password = dto.Password,
                Salt = dto.Salt
            };
        }

        public bool RegisterAccount(Account account)
        {
            try
            {
                ValidateModel(account);
                if (!repository.CheckIfEmailExists(account.Email!))
                {
                    SaltKey hashed = encryptor.Hash(account.Password!);
                    account.Password = hashed.Key;
                    account.Salt = hashed.Salt;
                    AccountDTO dto = new AccountDTO(0, account.Name!, account.SurName!, account.Role.ToString(), account.Type.ToString(), account.Email!, account.Password, account.Salt);
                    return repository.Register(dto);
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}
