using Crm.Passengers;
using Crm.Clients;
using Crm.Contracts;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Crm.EntityFrameworkCore
{
    [ConnectionStringName(CrmDbProperties.ConnectionStringName)]
    public class CrmDbContext : AbpDbContext<CrmDbContext>, ICrmDbContext
    {
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public CrmDbContext(DbContextOptions<CrmDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureCrm();
        }
    }
}