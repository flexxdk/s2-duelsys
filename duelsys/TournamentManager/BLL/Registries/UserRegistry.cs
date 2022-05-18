using DAL.Interfaces;
using BLL.Objects.Users;
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
    }
}
