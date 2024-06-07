using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AspNetCoreSecurity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if(!string.IsNullOrWhiteSpace(UserName) && UserName == Password)
            {
                var claims = new List<Claim>
                {
                    new("sub", "123"),
                    new("name", UserName),
                    new("role", "User"),
                    new("department","IT")
                };
                
                var ci = new ClaimsIdentity(claims, "password", "name", "role");
                var cp = new ClaimsPrincipal(ci);
                await HttpContext.SignInAsync("cookie", cp);
                return LocalRedirect(ReturnUrl);
            }
            return Page();
        }
    }
}
