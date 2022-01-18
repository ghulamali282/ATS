using Amm.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Amm
{
    public abstract class AmmController : AbpControllerBase
    {
        protected AmmController()
        {
            LocalizationResource = typeof(AmmResource);
        }
    }
}
