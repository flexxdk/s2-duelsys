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
        public string Name { get; private set; }
        public string SurName { get; private set; }
        public int TournamentID { get; private set; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }

        public ContestantDTO(int id, string name, string surName, int tournamentID, int wins, int losses)
        {
            ID = id;
            Name = name;
            SurName = surName;
            TournamentID = tournamentID;
            Wins = wins;
            Losses = losses;
        }
    }
}
