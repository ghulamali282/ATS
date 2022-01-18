using ATS.Features;
using Ccm.Localization;
using Volo.Abp.Application.Services;
using Volo.Abp.Features;

namespace Ccm
{
    [RequiresFeature(ATSFeatures.Ccm)]
    public abstract class CcmAppService : ApplicationService
    {
        protected CcmAppService()
        {
            LocalizationResource = typeof(CcmResource);
            ObjectMapperContext = typeof(CcmApplicationModule);
        }
    }
}
