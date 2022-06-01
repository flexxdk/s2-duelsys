using DTO.Users;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        public UserDTO? GetByID(int id);
        public bool Register(UserDTO userDTO);
        public bool CheckIfEmailExists(string email);
    }
}
