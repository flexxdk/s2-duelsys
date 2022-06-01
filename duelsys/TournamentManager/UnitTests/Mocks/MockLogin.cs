using System.Collections.Generic;

using DAL.Interfaces;
using DTO.Users;

namespace UnitTests.Mocks
{
    public class MockLogin : ILoginRepository
    {
        public UserDTO? GetCredentials(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}
