using DTO.Users;

namespace BLL.Objects.Users
{
    public class Contestant : Account
    {
        public int TournamentID { get; private set; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }

        public Contestant(ContestantDTO dto) : base(dto.ID, dto.FirstName, dto.LastName)
        {
            TournamentID = dto.TournamentID;
            Wins = dto.Wins;
            Losses = dto.Losses;
        }
    }
}
