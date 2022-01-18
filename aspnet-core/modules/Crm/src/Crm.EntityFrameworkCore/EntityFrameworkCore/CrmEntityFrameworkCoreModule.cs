using Crm.Passengers;
using Crm.Clients;
using Crm.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Crm.EntityFrameworkCore
{
    [DependsOn(
        typeof(CrmDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class CrmEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CrmDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Contract, Contracts.EfCoreContractRepository>();

                options.AddRepository<Client, Clients.EfCoreClientRepository>();

                options.AddRepository<Passenger, Passengers.EfCorePassengerRepository>();

            });
        }
    }
}