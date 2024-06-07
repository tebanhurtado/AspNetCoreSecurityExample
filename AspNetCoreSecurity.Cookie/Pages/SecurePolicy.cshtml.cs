using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreSecurity.Pages
{
    [Authorize("Users")]
    public class SecurePolicyModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
