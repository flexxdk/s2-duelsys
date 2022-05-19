using BLL.Encryption;
using BLL.Validation;
using BLL.Enums;
using BLL.Objects.Users;
using DAL.Interfaces;
using DTO.Users;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Registries
{
    public class UserRegistry
    {
        private readonly IUserRepository repository;
        private Dictionary<int, User> users;
        private Encryptor encryptor;

        public UserRegistry(IUserRepository repository)
        {
            this.repository = repository;
            users = new Dictionary<int, User>();
            encryptor = new Encryptor();
            LoadUsers();
        }

        public void LoadUsers()
        {
            users.Clear();
            foreach(UserDTO dto in repository.Load())
            {
                users.Add(dto.ID, new User(){
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Role = (UserRole)Enum.Parse(typeof(UserRole), dto.Role),
                    Password = dto.Password,
                    Salt = dto.Salt
                });
            }
        }

        public IList<User> GetAll()
        {
            if (users.Count == 0) LoadUsers();
            return users.Values.ToList();
        }

        public User? GetByID(int id)
        {
            if (users.ContainsKey(id))
            {
                return users[id];
            }
            return null;
        }

        public bool RegisterAccount(User user)
        {
            try
            {
                List<string> results = Validate.AsModel(user).ToList();
                if (!results.Any())
                {
                    if (CheckIfEmailUnique(user.Email!))
                    {
                        SaltKey hashed = encryptor.Hash(user.Password!);
                        user.Password = hashed.Key;
                        user.Salt = hashed.Salt;
                        UserDTO dto = new UserDTO(0, user.FirstName!, user.LastName!, user.Role.ToString(), user.Email!, user.Password, user.Salt);
                        user.ID = repository.Register(dto);
                        return users.TryAdd(user.ID, user);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    StringBuilder sbMessage = new StringBuilder();
                    sbMessage.AppendLine("The following errors have occurred: ");
                    foreach(string error in results)
                    {
                        sbMessage.Append("- ");
                        sbMessage.AppendLine(error);
                    }
                    throw new ValidationException(sbMessage.ToString());
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckIfEmailUnique(string email)
        {
            return !users.Values.Any(user => user.Email == email);
        }
    }
}
