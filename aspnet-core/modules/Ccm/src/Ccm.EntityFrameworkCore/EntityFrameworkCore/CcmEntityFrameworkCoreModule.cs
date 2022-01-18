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
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Ccm.EntityFrameworkCore
{
    [DependsOn(
        typeof(CcmDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class CcmEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CcmDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<MasterData, MasterDatas.EfCoreMasterDataRepository>();

                options.AddRepository<Partner, Partners.EfCorePartnerRepository>();

                options.AddRepository<DepartureSeason, DepartureSeasons.EfCoreDepartureSeasonRepository>();

                options.AddRepository<Departure, Departures.EfCoreDepartureRepository>();

                options.AddRepository<AgePolicy, AgePolicies.EfCoreAgePolicyRepository>();

                options.AddRepository<AgePolicyDetail, AgePolicyDetails.EfCoreAgePolicyDetailRepository>();

                options.AddRepository<Country, Countries.EfCoreCountryRepository>();

                options.AddRepository<Company, Companies.EfCoreCompanyRepository>();

                options.AddRepository<Itinerary, Itineraries.EfCoreItineraryRepository>();

                options.AddRepository<ItineraryDetail, ItineraryDetails.EfCoreItineraryDetailRepository>();

                options.AddRepository<Cruise, Cruises.EfCoreCruiseRepository>();

                options.AddRepository<CharterShip, CharterShips.EfCoreCharterShipRepository>();

                options.AddRepository<Destination, Destinations.EfCoreDestinationRepository>();

                options.AddRepository<CancellationPolicy, CancellationPolicies.EfCoreCancellationPolicyRepository>();

                options.AddRepository<PaymentPolicy, PaymentPolicies.EfCorePaymentPolicyRepository>();

                options.AddRepository<Ship, Ships.EfCoreShipRepository>();

            });
        }
    }
}