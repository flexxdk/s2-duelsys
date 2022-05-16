using DAL.Interfaces;
using DTO.Users;

namespace DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }

        public IList<UserDTO> Load()
        {
            throw new NotImplementedException();
        }

        public void Register(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
