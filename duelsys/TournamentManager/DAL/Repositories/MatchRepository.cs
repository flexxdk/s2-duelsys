using System.Data;
using MySql.Data.MySqlClient;

using DAL.Interfaces;
using DTO;
using DTO.Users;

namespace DAL.Repositories
{
    public class MatchRepository : BaseRepository, IMatchRepository
    {
        public MatchRepository(DbContext dbContext) : base(dbContext) { }

        public MatchDTO? GetByID(int id)
        {
            try
            {
                string query = "SELECT * FROM syn_matches WHERE id = @ID;";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@ID", id);
                DataRow? row = ExecuteReader(cmd).Rows[0];
                return InstantiateDTO(row);
            }
            catch
            {
                return null;
            }
        }

        public int Create(MatchDTO dto)
        {
            try
            {
                string query = @"INSERT INTO syn_matches (
                                    tournament_id, home_id, home_score, away_id, away_score, is_finished
                                ) 
                                VALUES (
                                    @TournamentID, @HomeID, @HomeScore, @AwayID, @AwayScore, @IsFinished
                                );";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@TournamentID", dto.TournamentID);
                cmd.Parameters.AddWithValue("@HomeID", dto.HomeID);
                cmd.Parameters.AddWithValue("@HomeScore", dto.HomeScore);
                cmd.Parameters.AddWithValue("@AwayID", dto.AwayID);
                cmd.Parameters.AddWithValue("@AwayScore", dto.AwayScore);
                cmd.Parameters.AddWithValue("@IsFinished", dto.IsFinished);
                ExecuteNonQuery(cmd);
                return Convert.ToInt32(cmd.LastInsertedId);
            }
            catch
            {
                throw;
            }
        }

        public IList<MatchDTO> GetMatches(int tournamentID)
        {
            try
            {
                string query = @"SELECT m.*, CONCAT(home.name, home.surname) AS home_name, CONCAT(away.name, away.surname) AS away_name
                                    FROM syn_matches AS m
                                    INNER JOIN syn_accounts AS home
                                    ON home.id = m.home_id
                                    INNER JOIN syn_accounts AS away
                                    ON away.id = m.away_id
                                    WHERE m.tournament_id = @TournamentID;";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@TournamentID", tournamentID);
                DataTable results = ExecuteReader(cmd);
                List<MatchDTO> matches = new List<MatchDTO>();
                foreach(DataRow row in results.Rows)
                {
                    matches.Add(InstantiateDTO(row));
                }
                return matches;
            }
            catch
            {
                throw;
            }
        }

        public int Update(MatchDTO dto)
        {
            try
            {
                string query = @"UPDATE syn_matches (home_score, away_score, isfinished)
                                    VALUES (@HomeScore, @AwayScore, @IsFinished);";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@HomeScore", dto.HomeScore);
                cmd.Parameters.AddWithValue("@AwayScore", dto.AwayScore);
                cmd.Parameters.AddWithValue("@IsFinished", dto.IsFinished);
                return ExecuteNonQuery(cmd);
            }
            catch
            {
                throw;
            }
        }

        private MatchDTO InstantiateDTO(DataRow row)
        {
            return new MatchDTO(
                    Convert.ToInt32(row["id"]),
                    Convert.ToInt32(row["tournament_id"]),
                    Convert.ToBoolean(row["is_finished"]),
                    Convert.ToInt32(row["home_id"]),
                    row["home_name"].ToString()!,
                    Convert.ToInt32(row["home_score"]),
                    Convert.ToInt32(row["away_id"]),
                    row["away_name"].ToString()!,
                    Convert.ToInt32(row["away_score"])
                );
        }
    }
}
