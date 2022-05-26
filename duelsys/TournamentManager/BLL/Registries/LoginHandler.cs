using DAL.Interfaces;
using BLL.Objects.Users;
using DTO.Users;
using BLL.Encryption;
using BLL.Validation;
using BLL.Enums;

namespace BLL.Registries
{
    public class LoginHandler : BaseRegistry
    {
        private readonly ILoginRepository repository;
        private Encryptor encryptor;

        public LoginHandler(ILoginRepository repository)
        {
            this.repository = repository;
            this.encryptor = new Encryptor();
        }

        public User? VerifyCredentials(Credentials creds)
        {
            try
            {
                ValidateModel(creds);

                UserDTO? dto = repository.GetCredentials(creds.Email!);

                if (dto != null)
                {
                    if (encryptor.Verify(creds.Password!, dto.Password, dto.Salt))
                    {
                        return new User()
                        {
                            ID = dto.ID,
                            Name = dto.Name,
                            SurName = dto.SurName,
                            Role = (UserRole)Enum.Parse(typeof(UserRole), dto.Role),
                            Type = (ContestantType)Enum.Parse(typeof(ContestantType), dto.Type),
                            Email = dto.Email,
                            Password = dto.Password,
                            Salt = dto.Salt
                        };
                    }
                }
                return null;
            }
            catch
            {
                throw;
            }
        }
    }
}
