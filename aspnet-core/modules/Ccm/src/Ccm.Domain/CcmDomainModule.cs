using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Ccm
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(CcmDomainSharedModule)
    )]
    public class CcmDomainModule : AbpModule
    {

    }
}
