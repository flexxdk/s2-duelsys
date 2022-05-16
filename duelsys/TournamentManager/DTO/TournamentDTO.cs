using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TournamentDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool AllowRegistration { get; private set; }
        public int MinContestants { get; private set; }
        public int MaxContestants { get; private set; }
        public string StartDate { get; private set; }
        public string EndDate { get; private set; }
        public string System { get; private set; }

        public TournamentDTO(int id, string name, bool allowRegistration, int minContestants, int maxContestants, string startDate, string endDate, string system)
        {
            ID = id;
            Name = name;
            AllowRegistration = allowRegistration;
            MinContestants = minContestants;
            MaxContestants = maxContestants;
            StartDate = startDate;
            EndDate = endDate;
            System = system;
        }
    }
}
