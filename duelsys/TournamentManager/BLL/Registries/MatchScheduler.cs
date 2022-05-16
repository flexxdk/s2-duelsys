using DAL.Interfaces;

namespace BLL.Registries
{
    public class MatchScheduler
    {
        private readonly IMatchRepository repository;

        public MatchScheduler(IMatchRepository repository)
        {
            this.repository = repository;
        }
    }
}
