using Volo.Abp.Modularity;

namespace Ccm
{
    [DependsOn(
        typeof(CcmApplicationModule),
        typeof(CcmDomainTestModule)
        )]
    public class CcmApplicationTestModule : AbpModule
    {

    }
}
