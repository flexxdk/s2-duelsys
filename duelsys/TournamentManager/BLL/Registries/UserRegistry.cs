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

        public UserRegistry(IUserRepository repository)
        {
            this.repository = repository;
            users = new Dictionary<int, User>();
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
    }
}
