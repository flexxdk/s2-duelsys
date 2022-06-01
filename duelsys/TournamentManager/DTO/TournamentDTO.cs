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
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Sport { get; private set; }
        public string Type { get; set; }
        public string Scoring { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }
        public int MinContestants { get; private set; }
        public int MaxContestants { get; private set; }
        public string StartDate { get; private set; }
        public string EndDate { get; private set; }
        public string Status { get; private set; }
        public string System { get; private set; }

        public TournamentDTO(int id, string title, string description, string sport, string type, string scoring, string city, string address, int minContestants, int maxContestants, string startDate, string endDate, string status, string system)
        {
            ID = id;
            Title = title;
            Description = description;
            Sport = sport;
            Type = type;
            Scoring = scoring;
            City = city;
            Address = address;
            MinContestants = minContestants;
            MaxContestants = maxContestants;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            System = system;
        }
    }
}
