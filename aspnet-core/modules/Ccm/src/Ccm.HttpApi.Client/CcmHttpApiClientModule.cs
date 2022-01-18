using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Ccm
{
    [DependsOn(
        typeof(CcmApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class CcmHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(CcmApplicationContractsModule).Assembly,
                CcmRemoteServiceConsts.RemoteServiceName
            );

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CcmHttpApiClientModule>();
            });
        }
    }
}
