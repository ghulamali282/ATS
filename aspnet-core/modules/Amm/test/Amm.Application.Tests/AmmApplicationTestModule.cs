using Volo.Abp.Modularity;

namespace Amm
{
    [DependsOn(
        typeof(AmmApplicationModule),
        typeof(AmmDomainTestModule)
        )]
    public class AmmApplicationTestModule : AbpModule
    {

    }
}
