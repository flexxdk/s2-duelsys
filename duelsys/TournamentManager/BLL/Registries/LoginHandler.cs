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

        public Account? VerifyCredentials(Credentials creds)
        {
            try
            {
                ValidateModel(creds);

                UserDTO? dto = repository.GetCredentials(creds.Email!);

                if (dto != null)
                {
                    if (dto.Role != UserRole.Staff.ToString() || dto.Role != UserRole.Administrator.ToString())
                    {
                        if (encryptor.Verify(creds.Password!, dto.Password, dto.Salt))
                        {
                            return new Account()
                            {
                                ID = dto.ID,
                                Name = dto.Name,
                                SurName = dto.SurName,
                                Role = (UserRole)Enum.Parse(typeof(UserRole), dto.Role),
                                Type = (TeamType)Enum.Parse(typeof(TeamType), dto.Type),
                                Email = dto.Email,
                                Password = dto.Password,
                                Salt = dto.Salt
                            };
                        }
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
