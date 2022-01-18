using Crm.Passengers;
using Crm.Clients;
using Crm.Contracts;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Crm.EntityFrameworkCore
{
    [ConnectionStringName(CrmDbProperties.ConnectionStringName)]
    public interface ICrmDbContext : IEfCoreDbContext
    {
        DbSet<Passenger> Passengers { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Contract> Contracts { get; set; }
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}