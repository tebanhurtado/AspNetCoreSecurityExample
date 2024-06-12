using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
namespace AspNetCoreSecurity.Pages
{
    public class SecureModel : PageModel
    {
        public SessionData Session { get; set; }
        public async Task OnGet()
        {
            var authResult = await HttpContext.AuthenticateAsync();
            
            var userClaims = authResult.Principal.Claims;
            var metadata = authResult.Properties.Items;
            Session = new SessionData(userClaims, metadata);
        }

        public record SessionData(IEnumerable<Claim> Claims, IDictionary<string, string> Metadata);
    }
}
