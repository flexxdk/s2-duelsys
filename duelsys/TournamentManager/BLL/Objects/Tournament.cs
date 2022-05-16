using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using BLL.Enums;

namespace BLL.Objects
{
    public class Tournament
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool AllowRegistration { get; private set; }
        public int MinContestants { get; private set; }
        public int MaxContestants { get; private set; }
        public string StartDate { get; private set; }
        public string EndDate { get; private set; }
        public TournamentSystem System { get; private set; }

        public Tournament(TournamentDTO dto)
        {
            ID = dto.ID;
            Name = dto.Name;
            AllowRegistration = dto.AllowRegistration;
            MinContestants = dto.MinContestants;
            MaxContestants = dto.MaxContestants;
            StartDate = dto.StartDate;
            EndDate = dto.EndDate;
            System = (TournamentSystem)Enum.Parse(typeof(TournamentSystem), dto.System);
        }
    }
}
