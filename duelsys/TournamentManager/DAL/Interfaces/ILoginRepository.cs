using DTO.Users;

namespace DAL.Interfaces
{
    public interface ILoginRepository
    {
        public AccountDTO? GetCredentials(string email);
    }
}
