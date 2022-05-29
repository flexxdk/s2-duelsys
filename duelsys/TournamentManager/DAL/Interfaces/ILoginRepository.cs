using DTO.Users;

namespace DAL.Interfaces
{
    public interface ILoginRepository
    {
        public bool CheckIfEmailExists(string email);
        public bool VerifyCredentials(CredentialsDTO credentials);
        public UserDTO? GetCredentials(string email);
    }
}
