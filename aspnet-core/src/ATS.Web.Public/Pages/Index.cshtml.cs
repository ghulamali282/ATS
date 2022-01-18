using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace ATS.Web.Public.Pages
{
    public class IndexModel : ATSPublicPageModel
    {
        public void OnGet()
        {

        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}
