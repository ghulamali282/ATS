using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Amm
{
    [DependsOn(
        typeof(AmmApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class AmmHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AmmApplicationContractsModule).Assembly,
                AmmRemoteServiceConsts.RemoteServiceName
            );

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AmmHttpApiClientModule>();
            });
        }
    }
}
