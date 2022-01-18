using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Ccm
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(CcmHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class CcmConsoleApiClientModule : AbpModule
    {

    }
}
