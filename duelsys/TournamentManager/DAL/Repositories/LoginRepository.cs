using MySql.Data.MySqlClient;
using System.Data;

using DAL.Interfaces;
using DTO.Users;

namespace DAL.Repositories
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public LoginRepository(DbContext dbContext) : base(dbContext) { }

        public UserDTO? GetCredentials(string email)
        {
            try
            {
                string query = "SELECT * FROM syn_accounts WHERE email = @Email;";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@Email", email);
                DataTable results = ExecuteReader(cmd);
                return new UserDTO(
                    Convert.ToInt32(results.Rows[0]["id"]),
                    results.Rows[0]["name"].ToString()!,
                    results.Rows[0]["surname"].ToString()!,
                    results.Rows[0]["role"].ToString()!,
                    results.Rows[0]["contestant_type"].ToString()!,
                    results.Rows[0]["email"].ToString()!,
                    results.Rows[0]["password"].ToString()!,
                    results.Rows[0]["salt"].ToString()!
                    );
            }
            catch
            {
                throw;
            }
        }
    }
}
