using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Users
{
    public class CredentialsDTO
    {
        public string Password { get; private set; }
        public string Salt { get; private set; }

        public CredentialsDTO(string password, string salt)
        {
            Password = password;
            Salt = salt;
        }
    }
}
