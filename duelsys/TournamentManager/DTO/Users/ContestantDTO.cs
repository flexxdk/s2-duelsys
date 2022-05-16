using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Users
{
    public class ContestantDTO
    {
        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int TournamentID { get; private set; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }

        public ContestantDTO(int id, string firstName, string lastName, int tournamentID, int wins, int losses)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            TournamentID = tournamentID;
            Wins = wins;
            Losses = losses;
        }
    }
}
}
