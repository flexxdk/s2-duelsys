using DTO.Users;
using BLL.Enums;

namespace BLL.Objects.Users
{
    public class User : Account
    {
        public UserRole Role { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }

        public User(UserDTO dto)  : base(dto.ID, dto.FirstName, dto.LastName)
        {
            Role = (UserRole)Enum.Parse(typeof(UserRole), dto.Role);
            Email = dto.Email;
            Password = dto.Password;
            Salt = dto.Salt;
        }
    }
}
