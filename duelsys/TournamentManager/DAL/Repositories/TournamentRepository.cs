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

        public bool Delete(int tournamentID)
        {
            throw new NotImplementedException();
        }

        public IList<ContestantDTO> GetStandings(int tournamentID)
        {
            throw new NotImplementedException();
        }

        public IList<TournamentDTO> Load()
        {
            try
            {
                string query = "SELECT * FROM syn_tournaments;";
                DataTable results = ExecuteReader(new MySqlCommand(query));
                List <TournamentDTO> tournaments = new List<TournamentDTO>();
                foreach(DataRow row in results.Rows)
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

        public int Update(TournamentDTO obj)
        {
            throw new NotImplementedException();
        }

        public TournamentDTO? GetByID(int id)
        {
            throw new NotImplementedException();
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
