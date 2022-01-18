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
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Amm.EntityFrameworkCore
{
    [DependsOn(
        typeof(AmmDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class AmmEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AmmDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<AppDefault, AppDefaults.EfCoreAppDefaultRepository>();

                options.AddRepository<BookingStatus, BookingStatuses.EfCoreBookingStatusRepository>();

                options.AddRepository<CruiseRegion, CruiseRegions.EfCoreCruiseRegionRepository>();

                options.AddRepository<MasterData, MasterDatas.EfCoreMasterDataRepository>();

                options.AddRepository<Country, Countries.EfCoreCountryRepository>();

                options.AddRepository<Destination, Destinations.EfCoreDestinationRepository>();

                options.AddRepository<Partner, Partners.EfCorePartnerRepository>();

                options.AddRepository<Ship, Ships.EfCoreShipRepository>();

                options.AddRepository<ShipDeck, ShipDecks.EfCoreShipDeckRepository>();

                options.AddRepository<ShipCabinType, ShipCabinTypes.EfCoreShipCabinTypeRepository>();

                options.AddRepository<ShpCabin, ShpCabins.EfCoreShpCabinRepository>();

                options.AddRepository<ShipOperator, ShipOperators.EfCoreShipOperatorRepository>();

                options.AddRepository<Marina, Marinas.EfCoreMarinaRepository>();

            });
        }
    }
}