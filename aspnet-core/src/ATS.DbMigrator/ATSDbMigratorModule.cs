using ATS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ATS.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ATSEntityFrameworkCoreModule),
        typeof(ATSApplicationContractsModule)
    )]
    public class ATSDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = false;
            });
        }
    }
}
