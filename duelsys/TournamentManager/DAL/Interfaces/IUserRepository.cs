using DTO.Users;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        public int Register(UserDTO userDTO);
        public IList<UserDTO> Load();
    }
}
