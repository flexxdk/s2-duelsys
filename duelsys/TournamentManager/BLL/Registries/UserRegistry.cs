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
    public class UserRegistry
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
            UserDTO? dto = repository.GetByID(id);
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

        public bool RegisterAccount(Account user)
        {
            try
            {
                ValidateModel(user);
                if (!repository.CheckIfEmailExists(user.Email!))
                {
                    SaltKey hashed = encryptor.Hash(user.Password!);
                    user.Password = hashed.Key;
                    user.Salt = hashed.Salt;
                    UserDTO dto = new UserDTO(0, user.Name!, user.SurName!, user.Role.ToString(), user.Type.ToString(), user.Email!, user.Password, user.Salt);
                    return repository.Register(dto);
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        private void ValidateModel(Account user)
        {
            List<string> results = Validate.AsModel(user).ToList();

            if (results.Any())
            {
                StringBuilder sbMessage = new StringBuilder();
                sbMessage.AppendLine("The following errors have occurred: ");
                foreach (string error in results)
                {
                    sbMessage.Append("- ");
                    sbMessage.AppendLine(error);
                }
                throw new ValidationException(sbMessage.ToString());
            }
        }
    }
}
