using BLL.Interfaces.Generic;
using DTO.Users;

namespace BLL.Interfaces
{
    public interface ILoginRepository
    {
        public bool CheckIfEmailExists(string email);
        public bool VerifyCredentials(CredentialsDTO credentials);
    }
}
