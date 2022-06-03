using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using DAL;
using BLL.Objects.Users;
using BLL.Registries;
using DAL.Repositories;
using System.Security.Authentication;
using MySql.Data.MySqlClient;

namespace WebApp.Pages.Users
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credentials LoginCredentials { get; set; } = new Credentials();

        private LoginHandler loginHandler = new LoginHandler(new LoginRepository(new DbContext()));

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Account account = loginHandler.AuthenticateWebsite(LoginCredentials!);
                    await CreateCookie(account);
                    return RedirectToPage("/Index");
                }
                catch (AuthenticationException)
                {
                    ModelState.AddModelError(string.Empty, "The combination of email and password is incorrect.");
                    return Page();
                }
                catch (MySqlException)
                {
                    ModelState.AddModelError(string.Empty, "Could not connect to database, please contact the owner of the website.");
                    return Page();
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "An unknown error occured, please try again later.");
                    return Page();
                }
            }
            return Page();
        }

        public async Task CreateCookie(Account account)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, string.Concat(account.Name, account.SurName)),
                new Claim(ClaimTypes.NameIdentifier, account.ID.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
        }
    }
}
