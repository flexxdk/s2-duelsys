using DTO.Users;

namespace DAL.Interfaces
{
    public interface ILoginRepository
    {
        public UserDTO? GetCredentials(string email);
    }
}
