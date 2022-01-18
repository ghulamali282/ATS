using Amm.Localization;
using Volo.Abp.Application.Services;

namespace Amm
{
    public abstract class AmmAppService : ApplicationService
    {
        protected AmmAppService()
        {
            LocalizationResource = typeof(AmmResource);
            ObjectMapperContext = typeof(AmmApplicationModule);
        }
    }
}
