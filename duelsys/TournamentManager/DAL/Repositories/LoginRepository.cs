using MySql.Data.MySqlClient;

using DAL.Interfaces;
using DTO.Users;

namespace DAL.Repositories
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public LoginRepository(DbContext dbContext) : base(dbContext) { }

        public bool CheckIfEmailExists(string email)
        {
            try
            {
                string query = "SELECT * FROM syn_accounts WHERE email = @Email;";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@Email", email);
                return ExecuteScalar(cmd) != null;
            }
            catch
            {
                throw;
            }
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
