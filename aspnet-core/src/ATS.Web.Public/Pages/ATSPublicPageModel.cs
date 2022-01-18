using ATS.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ATS.Web.Public.Pages
{
    /* Inherit your Page Model classes from this class.
     */
    public abstract class ATSPublicPageModel : AbpPageModel
    {
        protected ATSPublicPageModel()
        {
            LocalizationResourceType = typeof(ATSResource);
        }
    }
}
