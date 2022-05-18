using BLL.Objects.Users;
using BLL.Encryption;
using DAL.Interfaces;
using DTO.Users;

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
                users.Add(dto.ID, new User(dto));
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

        public bool RegisterAccount(string firstName, string lastName, string role, string email, string password)
        {
            if (CheckIfEmailUnique(email))
            {
                SaltKey hashed = encryptor.Hash(password);
                UserDTO dto = new UserDTO(0, firstName, lastName, role, email, hashed.Key, hashed.Salt);
                int newUserID = repository.Register(dto);
                return users.TryAdd(newUserID, new User(dto, newUserID));
            }
            return false;
        }

        public bool CheckIfEmailUnique(string email)
        {
            return !users.Values.Any(user => user.Email == email);
        }
    }
}
