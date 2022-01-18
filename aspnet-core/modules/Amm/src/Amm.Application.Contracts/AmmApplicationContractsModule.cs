using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Amm
{
    [DependsOn(
        typeof(AmmDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationAbstractionsModule)
        )]
    public class AmmApplicationContractsModule : AbpModule
    {

    }
}
