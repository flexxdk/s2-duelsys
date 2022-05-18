using DAL.Interfaces.Generic;
using DTO.Users;

namespace DAL.Interfaces
{
    public interface IUserRepository : IObjectLoader<UserDTO>
    {
        public int Register(UserDTO userDTO);
    }
}
