using DAL.Interfaces.Generics;
using DTO.Users;

namespace DAL.Interfaces
{
    public interface IUserRepository : IObjectLoader<UserDTO>
    {
        public void Register(UserDTO userDTO);
    }
}
