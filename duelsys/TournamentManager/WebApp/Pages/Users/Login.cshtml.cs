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
        public Credentials? UserCredentials { get; set; }

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
                    User user = loginHandler.AuthenticateWebsite(UserCredentials!);
                    await CreateCookie(user);
                    return new RedirectToPageResult("Index");
                }
                catch (AuthenticationException)
                {
                    ModelState.AddModelError(string.Empty, "The combination of email and password is incorrect.");
                    return RedirectToPage("Login");
                }
                catch (MySqlException)
                {
                    ModelState.AddModelError(string.Empty, "Could not connect to database, please contact the system administrator.");
                    return RedirectToPage("Login");
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "An unknown error occured, please contact the system administrator.");
                    return RedirectToPage("Login");
                }
            }
            return Page();
        }

        public async Task CreateCookie(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, string.Concat(user.Name, user.SurName)),
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
        }
    }
}
