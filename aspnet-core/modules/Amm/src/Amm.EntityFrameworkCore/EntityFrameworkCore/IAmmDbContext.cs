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
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Amm.EntityFrameworkCore
{
    [ConnectionStringName(AmmDbProperties.ConnectionStringName)]
    public interface IAmmDbContext : IEfCoreDbContext
    {
        DbSet<Marina> Marinas { get; set; }
        DbSet<ShipOperator> ShipOperators { get; set; }
        DbSet<ShpCabin> ShpCabins { get; set; }
        DbSet<ShipCabinType> ShipCabinTypes { get; set; }
        DbSet<ShipDeck> ShipDecks { get; set; }
        DbSet<Ship> Ships { get; set; }
        DbSet<Partner> Partners { get; set; }
       
        DbSet<Destination> Destinations { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<MasterData> MasterDatas { get; set; }
        DbSet<CruiseRegion> CruiseRegions { get; set; }
        DbSet<BookingStatus> BookingStatuses { get; set; }
        DbSet<AppDefault> AppDefaults { get; set; }
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}