using DAL.Interfaces;
using DTO;
using DTO.Users;

using System.Data;
using MySql.Data.MySqlClient;

namespace DAL.Repositories
{
    public class TournamentRepository : BaseRepository, ITournamentRepository
    {
        public TournamentRepository(DbContext dbContext) : base(dbContext) { }

        public IList<TournamentDTO> Load()
        {
            try
            {
                string query = "SELECT * FROM syn_tournaments;";
                DataTable results = ExecuteReader(new MySqlCommand(query));
                List<TournamentDTO> tournaments = new List<TournamentDTO>();
                foreach (DataRow row in results.Rows)
                {
                    tournaments.Add(InstantiateDTO(row));
                }
                return tournaments;
            }
            catch
            {
                throw;
            }
        }

        public TournamentDTO? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public int Create(TournamentDTO dto)
        {
            try
            {
                string query = @"INSERT INTO syn_tournaments (
                                    title, description, sport, contestant_type, scoring, city, address, 
                                    min_contestants, max_contestants, start_date, end_date, status, system
                                ) 
                                VALUES (
                                    @Title, @Description, @Sport, @Type, @Scoring, @City, @Address,
                                    @MinContestants, @MaxContestants, @StartDate, @EndDate, @Status, @System
                                );";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@Title", dto.Title);
                cmd.Parameters.AddWithValue("@Description", dto.Description);
                cmd.Parameters.AddWithValue("@Sport", dto.Sport);
                cmd.Parameters.AddWithValue("@Type", dto.Type);
                cmd.Parameters.AddWithValue("@Scoring", dto.Scoring);
                cmd.Parameters.AddWithValue("@City", dto.City);
                cmd.Parameters.AddWithValue("@Address", dto.Address);
                cmd.Parameters.AddWithValue("@MinContestants", dto.MinContestants);
                cmd.Parameters.AddWithValue("@MaxContestants", dto.MaxContestants);
                cmd.Parameters.AddWithValue("@StartDate", dto.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", dto.EndDate);
                cmd.Parameters.AddWithValue("@Status", dto.Status);
                cmd.Parameters.AddWithValue("@System", dto.System);
                ExecuteNonQuery(cmd);
                return Convert.ToInt32(cmd.LastInsertedId);
            }
            catch
            {
                return 0;
            }
        }

        public int Update(TournamentDTO dto)
        {
            try
            {
                string query = @"UPDATE syn_tournaments SET
                                    title = @Title, description = @Description, sport = @Sport, contestant_type = @Type, scoring = @Scoring, city = @City, address = @Address, 
                                    min_contestants = @MinContestants, max_contestants = @MaxContestants, start_date = @StartDate, end_date = @EndDate, status = @Status, system = @System
                                    WHERE id = @ID;";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@ID", dto.ID);
                cmd.Parameters.AddWithValue("@Title", dto.Title);
                cmd.Parameters.AddWithValue("@Description", dto.Description);
                cmd.Parameters.AddWithValue("@Sport", dto.Sport);
                cmd.Parameters.AddWithValue("@Type", dto.Type);
                cmd.Parameters.AddWithValue("@Scoring", dto.Scoring);
                cmd.Parameters.AddWithValue("@City", dto.City);
                cmd.Parameters.AddWithValue("@Address", dto.Address);
                cmd.Parameters.AddWithValue("@MinContestants", dto.MinContestants);
                cmd.Parameters.AddWithValue("@MaxContestants", dto.MaxContestants);
                cmd.Parameters.AddWithValue("@StartDate", dto.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", dto.EndDate);
                cmd.Parameters.AddWithValue("@Status", dto.Status);
                cmd.Parameters.AddWithValue("@System", dto.System);
                ExecuteNonQuery(cmd);
                return Convert.ToInt32(cmd.LastInsertedId);
            }
            catch
            {
                return 0;
            }
        }

        public bool Delete(int tournamentID)
        {
            try
            {
                string query = "DELETE FROM syn_tournaments WHERE id = @ID;";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@ID", tournamentID);
                ExecuteNonQuery(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<ContestantDTO> GetStandings(int tournamentID)
        {
            try
            {
                string query = @"SELECT c.user_id, a.name, a.surname, c.tournament_id, c.wins, c.losses
                                    FROM syn_contestants AS c
                                    INNER JOIN syn_accounts AS a
                                    ON c.user_id = a.id
                                    WHERE c.tournament_id = @ID;";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@ID", tournamentID);
                DataTable results = ExecuteReader(cmd);
                List<ContestantDTO> contestants = new List<ContestantDTO>();
                foreach (DataRow row in results.Rows)
                {
                    contestants.Add(new ContestantDTO(
                            Convert.ToInt32(row["user_id"]),
                            row["name"].ToString()!,
                            row["surname"].ToString(),
                            Convert.ToInt32(row["tournament_id"]),
                            Convert.ToInt32(row["wins"]),
                            Convert.ToInt32(row["losses"])
                        )
                    );
                }
                return contestants;
            }
            catch
            {
                throw;
            }
        }

        private TournamentDTO InstantiateDTO(DataRow row)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return new TournamentDTO(
                Convert.ToInt32(row["id"]),
                row["title"].ToString(),
                row["description"].ToString(),
                row["sport"].ToString(),
                row["contestant_type"].ToString(),
                row["scoring"].ToString(),
                row["city"].ToString(),
                row["address"].ToString(),
                Convert.ToInt32(row["min_contestants"]),
                Convert.ToInt32(row["max_contestants"]),
                row["start_date"].ToString(),
                row["end_date"].ToString(),
                row["status"].ToString(),
                row["system"].ToString()
                );
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
