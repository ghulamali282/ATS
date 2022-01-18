using Ccm.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Ccm
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(CcmEntityFrameworkCoreTestModule)
        )]
    public class CcmDomainTestModule : AbpModule
    {
        
    }
}
