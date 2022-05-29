using DAL.Interfaces;
using DTO.Users;

namespace DAL.Repositories
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public LoginRepository(DbContext dbContext) : base(dbContext) { }

        public bool CheckIfEmailExists(string email)
        {
            throw new NotImplementedException();
        }

        public IList<UserDTO> Load()
        {
            throw new NotImplementedException();
        }

        public bool VerifyCredentials(CredentialsDTO credentials)
        {
            throw new NotImplementedException();
        }

        public UserDTO? GetCredentials(string email)
        {
            throw new NotImplementedException();
        }
    }
}
