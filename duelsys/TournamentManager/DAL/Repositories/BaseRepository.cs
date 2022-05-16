using System.Data;
using MySql.Data.MySqlClient;

namespace DAL.Repositories
{
    public abstract class BaseRepository
    {
        protected DbContext dbContext { get; private set; }

        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(dbContext.DbConnectionString);
        }

        protected void OpenConnection(MySqlConnection connection)
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        protected int ExecuteNonQuery(MySqlCommand command)
        {
            try
            {
                using(command.Connection = GetConnection())
                {
                    OpenConnection(command.Connection);
                    return command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        protected object? ExecuteScalar(MySqlCommand command)
        {
            try
            {
                using(command.Connection = GetConnection())
                {
                    OpenConnection(command.Connection);
                    return command.ExecuteScalar();
                }
            }
            catch
            {
                throw;
            }
        }

        protected DataTable ExecuteReader(MySqlCommand command)
        {
            try
            {
                using(command.Connection = GetConnection())
                {
                    OpenConnection(command.Connection);
                    DataTable results = new DataTable();
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        results.Load(reader);
                    }
                    return results;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
