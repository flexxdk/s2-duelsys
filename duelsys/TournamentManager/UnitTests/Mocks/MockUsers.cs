using System.Collections.Generic;

using DAL.Interfaces;
using DTO.Users;

namespace UnitTests.Mocks
{
    public class MockUsers : IUserRepository
    {
        public IList<UserDTO> Load()
        {
            throw new System.NotImplementedException();
        }

        public void Register(UserDTO userDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
