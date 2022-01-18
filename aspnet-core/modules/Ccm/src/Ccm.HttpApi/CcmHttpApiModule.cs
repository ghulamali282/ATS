using Localization.Resources.AbpUi;
using Ccm.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Ccm
{
    [DependsOn(
        typeof(CcmApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class CcmHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(CcmHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<CcmResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
