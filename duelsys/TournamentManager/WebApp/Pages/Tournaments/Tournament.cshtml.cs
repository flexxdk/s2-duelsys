using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

using DAL;
using DAL.Repositories;
using BLL.Objects;
using BLL.Registries;
using BLL.Objects.Users;
using System.Security.Claims;

namespace WebApp.Pages.Tournaments
{
    public class TournamentModel : PageModel
    {
        private TournamentRegistry tournamentRegistry = new TournamentRegistry(new TournamentRepository(new DbContext()));
        private MatchRegistry matchRegistry = new MatchRegistry(new MatchRepository(new DbContext()));
        private ContestantRegistry contestantRegistry = new ContestantRegistry(new ContestantRepository(new DbContext()));

        public Tournament? Tournament { get; set; }

        public List<Match> Matches { get; set; } = new List<Match>();

        public List<Contestant> Leaderboard { get; set; } = new List<Contestant>();

        public void OnGet(int? id)
        {
            if (id.HasValue)
            {
                Tournament = tournamentRegistry.GetByID(id.Value);
                Matches = matchRegistry.GetMatches(id.Value).ToList();
                Leaderboard = tournamentRegistry.GetLeaderboard(id.Value).ToList();
            }
            else
            {
                return ;
            }
        }

        public IActionResult OnPostRegister()
        {
            int userID = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //if(contestantRegistry.Register(userID, Tournament.ID))
            return Page();
        }
    }
}
