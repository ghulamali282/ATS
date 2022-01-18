using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Amm
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AmmHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class AmmConsoleApiClientModule : AbpModule
    {

    }
}
