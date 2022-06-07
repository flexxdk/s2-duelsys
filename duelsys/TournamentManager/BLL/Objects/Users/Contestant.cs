using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Objects.Users
{
    public class Contestant : Person, IComparable<Contestant>
    {
        [Required]
        [Browsable(false)]
        public int TournamentID { get; set; }

        public int Rank { get; set; }

        [Required]
        public int Wins { get; set; }

        [Required]
        public int Losses { get; set; }

        public int CompareTo(Contestant? other)
        {
            if(other != null)
            {
                if (other.Wins > this.Wins)
                {
                    return 1;
                }
                else if (other.Wins < this.Wins)
                {
                    return -1;
                }
                else
                {
                    if (other.Losses < this.Losses)
                    {
                        return 1;
                    }
                    else if (other.Losses > this.Losses)
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }
    }
}
