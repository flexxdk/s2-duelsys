using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

using DAL;
using DAL.Repositories;
using BLL.Objects;
using BLL.Registries;

namespace WebApp.Pages.Tournaments
{
    public class ListModel : PageModel
    {
        private TournamentRegistry registry = new TournamentRegistry(new TournamentRepository(new DbContext()));

        [BindProperty]
        public List<Tournament>? Tournaments { get; set; }

        public void OnGet()
        {
            Tournaments = registry.GetAll(false).ToList();
        }
    }
}
