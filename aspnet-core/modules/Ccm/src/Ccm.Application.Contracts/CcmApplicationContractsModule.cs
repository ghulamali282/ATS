using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Ccm
{
    [DependsOn(
        typeof(CcmDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationAbstractionsModule)
        )]
    public class CcmApplicationContractsModule : AbpModule
    {

    }
}
