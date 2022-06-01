using DAL.Interfaces;
using BLL.Objects.Users;
using DTO.Users;
using BLL.Encryption;
using BLL.Validation;
using BLL.Enums;
using System.Security.Authentication;

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

        public User AuthenticateForm(Credentials creds)
        {
            try
            {
                ValidateModel(creds);

                User user = VerifyCredentials(creds.Email!, creds.Password!);

                if (user.Role == UserRole.Staff || user.Role == UserRole.Administrator)
                {
                    return user;
                }
                throw new AuthenticationException();
            }
            catch
            {
                throw;
            }
        }

        public User AuthenticateWebsite(Credentials creds)
        {
            try
            {
                return VerifyCredentials(creds.Email!, creds.Password!);
            }
            catch
            {
                throw;
            }
        }

        private User VerifyCredentials(string email, string password)
        {
            UserDTO? dto = repository.GetCredentials(email);

            if (dto != null)
            {
                if (encryptor.Verify(password, dto.Password, dto.Salt))
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
            throw new AuthenticationException();
        }
    }
}
