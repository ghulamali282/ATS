using Ccm.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Ccm
{
    public abstract class CcmController : AbpControllerBase
    {
        protected CcmController()
        {
            LocalizationResource = typeof(CcmResource);
        }
    }
}
