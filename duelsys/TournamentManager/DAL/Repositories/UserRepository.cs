using MySql.Data.MySqlClient;
using System.Data;

using DAL.Interfaces;
using DTO.Users;

namespace DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }

        public AccountDTO? GetByID(int id)
        {
            try
            {
                string query = "SELECT * FROM syn_accounts WHERE id = @ID;";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@ID", id);
                DataTable results = ExecuteReader(cmd);
                return new AccountDTO(
                    Convert.ToInt32(results.Rows[0]["id"]),
                    results.Rows[0]["name"].ToString()!,
                    results.Rows[0]["surname"].ToString()!,
                    results.Rows[0]["role"].ToString()!,
                    results.Rows[0]["team_type"].ToString()!,
                    results.Rows[0]["email"].ToString()!,
                    results.Rows[0]["password"].ToString()!,
                    results.Rows[0]["salt"].ToString()!
                    );
            }
            catch
            {
                return null;
            }
        }

        public bool Register(AccountDTO dto)
        {
            try
            {
                string query = @"INSERT INTO syn_accounts (name, surname, role, team_type, email, password, salt)
                                    VALUES (@Name, @SurName, @Role, @Type, @Email, @Password, @Salt);";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@Name", dto.Name);
                cmd.Parameters.AddWithValue("@SurName", dto.SurName);
                cmd.Parameters.AddWithValue("@Role", dto.Role);
                cmd.Parameters.AddWithValue("@Type", dto.Type);
                cmd.Parameters.AddWithValue("@Email", dto.Email);
                cmd.Parameters.AddWithValue("@Password", dto.Password);
                cmd.Parameters.AddWithValue("@Salt", dto.Salt);
                ExecuteNonQuery(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

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
    }
}
