using Localization.Resources.AbpUi;
using Amm.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Amm
{
    [DependsOn(
        typeof(AmmApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class AmmHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AmmHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AmmResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
