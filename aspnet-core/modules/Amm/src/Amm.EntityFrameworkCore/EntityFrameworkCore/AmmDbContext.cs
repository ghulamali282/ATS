using Amm.Marinas;
using Amm.ShipOperators;
using Amm.ShpCabins;
using Amm.ShipCabinTypes;
using Amm.ShipDecks;
using Amm.Ships;
using Amm.Partners;
using Amm.Destinations;
using Amm.Countries;
using Amm.MasterDatas;
using Amm.CruiseRegions;
using Amm.BookingStatuses;
using Amm.AppDefaults;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Amm.EntityFrameworkCore
{
    [ConnectionStringName(AmmDbProperties.ConnectionStringName)]
    public class AmmDbContext : AbpDbContext<AmmDbContext>, IAmmDbContext
    {
        public DbSet<Marina> Marinas { get; set; }
        public DbSet<ShipOperator> ShipOperators { get; set; }
        public DbSet<ShpCabin> ShpCabins { get; set; }
        public DbSet<ShipCabinType> ShipCabinTypes { get; set; }
        public DbSet<ShipDeck> ShipDecks { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Partner> Partners { get; set; }
      
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<MasterData> MasterDatas { get; set; }
        public DbSet<CruiseRegion> CruiseRegions { get; set; }
        public DbSet<BookingStatus> BookingStatuses { get; set; }
        public DbSet<AppDefault> AppDefaults { get; set; }
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public AmmDbContext(DbContextOptions<AmmDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureAmm();
        }
    }
}