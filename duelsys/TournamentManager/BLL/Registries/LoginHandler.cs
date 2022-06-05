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

        public Account AuthenticateForm(Credentials creds)
        {
            try
            {
                ValidateModel(creds);

                Account account = VerifyCredentials(creds.Email!, creds.Password!);

                if (account.Role == UserRole.Staff || account.Role == UserRole.Administrator)
                {
                    return account;
                }
                throw new AuthenticationException();
            }
            catch
            {
                throw;
            }
        }

        public Account AuthenticateWebsite(Credentials creds)
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

        private Account VerifyCredentials(string email, string password)
        {
            AccountDTO? dto = repository.GetCredentials(email);

            if (dto != null)
            {
                if (encryptor.Verify(password, dto.Password, dto.Salt))
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
            throw new AuthenticationException();
        }
    }
}
