using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Interfaces.Generic;
using DTO.Users;

namespace BLL.Interfaces
{
    public interface IUserRepository : IObjectLoader<UserDTO>
    {
        public void Register(UserDTO userDTO);
    }
}
