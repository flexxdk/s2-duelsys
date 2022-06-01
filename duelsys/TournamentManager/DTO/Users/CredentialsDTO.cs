using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Users
{
    public class CredentialsDTO
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public CredentialsDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
