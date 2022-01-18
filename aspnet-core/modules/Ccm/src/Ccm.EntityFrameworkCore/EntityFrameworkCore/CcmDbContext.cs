using Ccm.Ships;
using Ccm.PaymentPolicies;
using Ccm.CancellationPolicies;
using Ccm.Destinations;
using Ccm.CharterShips;
using Ccm.Cruises;
using Ccm.ItineraryDetails;
using Ccm.Itineraries;
using Ccm.Companies;
using Ccm.Countries;
using Ccm.AgePolicyDetails;
using Ccm.AgePolicies;
using Ccm.Departures;
using Ccm.DepartureSeasons;
using Ccm.Partners;
using Ccm.MasterDatas;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Ccm.EntityFrameworkCore
{
    [ConnectionStringName(CcmDbProperties.ConnectionStringName)]
    public class CcmDbContext : AbpDbContext<CcmDbContext>, ICcmDbContext
    {
        public DbSet<Ship> Ships { get; set; }
        public DbSet<PaymentPolicy> PaymentPolicies { get; set; }
        public DbSet<CancellationPolicy> CancellationPolicies { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<CharterShip> CharterShips { get; set; }
        public DbSet<Cruise> Cruises { get; set; }
        public DbSet<ItineraryDetail> ItineraryDetails { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<AgePolicyDetail> AgePolicyDetails { get; set; }
        public DbSet<AgePolicy> AgePolicies { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<DepartureSeason> DepartureSeasons { get; set; }
        public DbSet<Partner> Partners { get; set; }

        public DbSet<MasterData> MasterDatas { get; set; }
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public CcmDbContext(DbContextOptions<CcmDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureCcm();
        }
    }
}