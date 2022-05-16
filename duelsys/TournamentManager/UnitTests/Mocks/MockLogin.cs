using System.Collections.Generic;

using DAL.Interfaces;
using DTO.Users;

namespace UnitTests.Mocks
{
    public class MockLogin : ILoginRepository
    {
        public bool CheckIfEmailExists(string email)
        {
            throw new System.NotImplementedException();
        }

        public IList<UserDTO> Load()
        {
            throw new System.NotImplementedException();
        }

        public bool VerifyCredentials(CredentialsDTO credentials)
        {
            throw new System.NotImplementedException();
        }
    }
}
