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

        [BindProperty]
        public Tournament? Tournament { get; set; }

        [BindProperty]
        public string StateMessage { get; set; } = string.Empty;

        [BindProperty]
        public int? TournamentID { get; set; }

        [BindProperty]
        public List<Match> Matches { get; set; } = new List<Match>();

        [BindProperty]
        public List<Contestant> Leaderboard { get; set; } = new List<Contestant>();
        
        public void OnGet(int? id)
        {
            if (id.HasValue)
            {
                LoadPageInfo(id.Value);
            }
            else
            {
                RedirectToPage("Error");
            }
        }

        public IActionResult OnPostRegister()
        {
            if (TournamentID.HasValue)
            {
                Tournament = tournamentRegistry.GetByID(TournamentID.Value);
                int userID = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                string userType = User.FindFirstValue("TeamType");
                if(Tournament != null)
                {
                    try
                    {
                        if (contestantRegistry.Register(userID, userType, Tournament))
                        {
                            TempData["success"] = "You have succesfully registered for this tournament.";
                        }
                        else
                        {
                            TempData["error"] = "You have already been registered.";
                        }
                    }
                    catch (Exception ex)
                    {
                        TempData["error"] = ex.Message;
                    }
                    return RedirectToPage("./Tournament", new { id = Tournament!.ID });
                }
                else
                {
                    TempData["error"] = "Could not retrieve tournament. Please contact system administrators.";
                }
            }
            return Page();
        }

        public IActionResult OnPostDeregister()
        {
            if (TournamentID.HasValue)
            {
                Tournament = tournamentRegistry.GetByID(TournamentID.Value);
                int userID = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (contestantRegistry.Deregister(userID, Tournament!.ID))
                {
                    TempData["success"] = "You have been deregistered.";
                }
                else
                {
                    TempData["error"] = "You have not registered for this tournament.";
                }
                return RedirectToPage("./Tournament", new { id = Tournament!.ID });
            }
            return Page();
        }

        public void LoadPageInfo(int id)
        {
            Tournament = tournamentRegistry.GetByID(id);
            Matches = matchRegistry.GetMatches(id).ToList();
            Leaderboard = tournamentRegistry.GetLeaderboard(id).ToList();
        }

        public bool CheckForFreeSpots()
        {
            if(Tournament != null)
            {
                return FreeSpotsLeft() > 0;
            }
            return false;
        }

        public int FreeSpotsLeft()
        {
            if(Tournament != null)
            {
                int spotsLeft = Tournament.MaxContestants - contestantRegistry.GetContestants(Tournament.ID).Count;
                return spotsLeft > 0 ? spotsLeft : 0;
            }
            return 0;
        }
    }
}
