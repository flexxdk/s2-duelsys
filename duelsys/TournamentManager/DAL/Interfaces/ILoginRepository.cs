using DAL.Interfaces.Generics;
using DTO.Users;

namespace DAL.Interfaces
{
    public interface ILoginRepository : IObjectLoader<UserDTO>
    {
        public bool CheckIfEmailExists(string email);
        public bool VerifyCredentials(CredentialsDTO credentials);
    }
}
