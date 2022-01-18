using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Amm
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AmmDomainSharedModule)
    )]
    public class AmmDomainModule : AbpModule
    {

    }
}
