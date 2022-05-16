using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Users
{

    public class UserDTO
    {
        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Role { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }

        public UserDTO(int id, string firstName, string lastName, string role, string email, string password, string salt)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Email = email;
            Password = password;
            Salt = salt;
        }
    }
}
