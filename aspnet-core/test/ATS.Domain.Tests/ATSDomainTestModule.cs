using ATS.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ATS
{
    [DependsOn(
        typeof(ATSEntityFrameworkCoreTestModule)
        )]
    public class ATSDomainTestModule : AbpModule
    {

    }
}