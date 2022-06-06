using DTO.Users;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        public AccountDTO? GetByID(int id);
        public bool Register(AccountDTO dto);
        public bool CheckIfEmailExists(string email);
    }
}
