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
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Ccm.EntityFrameworkCore
{
    [ConnectionStringName(CcmDbProperties.ConnectionStringName)]
    public interface ICcmDbContext : IEfCoreDbContext
    {
        DbSet<Ship> Ships { get; set; }
        DbSet<PaymentPolicy> PaymentPolicies { get; set; }
        DbSet<CancellationPolicy> CancellationPolicies { get; set; }
        DbSet<Destination> Destinations { get; set; }
        DbSet<CharterShip> CharterShips { get; set; }
        DbSet<Cruise> Cruises { get; set; }
        DbSet<ItineraryDetail> ItineraryDetails { get; set; }
        DbSet<Itinerary> Itineraries { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<AgePolicyDetail> AgePolicyDetails { get; set; }
        DbSet<AgePolicy> AgePolicies { get; set; }
        DbSet<Departure> Departures { get; set; }
        DbSet<DepartureSeason> DepartureSeasons { get; set; }
        DbSet<Partner> Partners { get; set; }
        DbSet<MasterData> MasterDatas { get; set; }
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}