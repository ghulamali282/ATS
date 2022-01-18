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
using System;
using Ccm.Shared;
using Volo.Abp.AutoMapper;
using Ccm.MasterDatas;
using AutoMapper;

namespace Ccm
{
    public class CcmApplicationAutoMapperProfile : Profile
    {
        public CcmApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<MasterDataCreateDto, MasterData>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<MasterDataUpdateDto, MasterData>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<MasterData, MasterDataDto>();

            CreateMap<PartnerCreateDto, Partner>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<PartnerUpdateDto, Partner>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<Partner, PartnerDto>();

            CreateMap<DepartureSeasonCreateDto, DepartureSeason>().Ignore(x => x.Id);
            CreateMap<DepartureSeasonUpdateDto, DepartureSeason>().Ignore(x => x.Id);
            CreateMap<DepartureSeason, DepartureSeasonDto>();
            CreateMap<DepartureSeasonWithNavigationProperties, DepartureSeasonWithNavigationPropertiesDto>();
            CreateMap<Partner, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.PartnerName));

            CreateMap<DepartureSeasonCreateDto, DepartureSeason>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<DepartureSeasonUpdateDto, DepartureSeason>().Ignore(x => x.Id).Ignore(x => x.TenantId);

            CreateMap<DepartureCreateDto, Departure>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<DepartureUpdateDto, Departure>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<Departure, DepartureDto>();
            CreateMap<DepartureWithNavigationProperties, DepartureWithNavigationPropertiesDto>();
            CreateMap<DepartureSeason, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.SeasonName));

            CreateMap<AgePolicyCreateDto, AgePolicy>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<AgePolicyUpdateDto, AgePolicy>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<AgePolicy, AgePolicyDto>();
            CreateMap<AgePolicyWithNavigationProperties, AgePolicyWithNavigationPropertiesDto>();
            CreateMap<MasterData, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

            CreateMap<AgePolicyDetailCreateDto, AgePolicyDetail>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<AgePolicyDetailUpdateDto, AgePolicyDetail>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<AgePolicyDetail, AgePolicyDetailDto>();
            CreateMap<AgePolicyDetailWithNavigationProperties, AgePolicyDetailWithNavigationPropertiesDto>();

            CreateMap<CountryCreateDto, Country>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<CountryUpdateDto, Country>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<Country, CountryDto>();

            CreateMap<PartnerWithNavigationProperties, PartnerWithNavigationPropertiesDto>();
            CreateMap<Country, LookupDto<string>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.CountryName));
            CreateMap<PartnerCreateDto, Partner>().IgnoreAuditedObjectProperties().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<PartnerUpdateDto, Partner>().IgnoreAuditedObjectProperties().Ignore(x => x.Id).Ignore(x => x.TenantId);

            CreateMap<CompanyCreateDto, Company>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<CompanyUpdateDto, Company>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<Company, CompanyDto>();

            CreateMap<ItineraryCreateDto, Itinerary>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<ItineraryUpdateDto, Itinerary>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<Itinerary, ItineraryDto>();

            CreateMap<ItineraryDetailCreateDto, ItineraryDetail>().Ignore(x => x.Id);
            CreateMap<ItineraryDetailUpdateDto, ItineraryDetail>().Ignore(x => x.Id);
            CreateMap<ItineraryDetail, ItineraryDetailDto>();

            CreateMap<CruiseCreateDto, Cruise>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<CruiseUpdateDto, Cruise>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<Cruise, CruiseDto>();

            CreateMap<CharterShipCreateDto, CharterShip>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<CharterShipUpdateDto, CharterShip>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<CharterShip, CharterShipDto>();

            CreateMap<DestinationCreateDto, Destination>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<DestinationUpdateDto, Destination>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<Destination, DestinationDto>();

            CreateMap<CancellationPolicyCreateDto, CancellationPolicy>().Ignore(x => x.Id);
            CreateMap<CancellationPolicyUpdateDto, CancellationPolicy>().Ignore(x => x.Id);
            CreateMap<CancellationPolicy, CancellationPolicyDto>();
            CreateMap<CancellationPolicyWithNavigationProperties, CancellationPolicyWithNavigationPropertiesDto>();

            CreateMap<CancellationPolicyCreateDto, CancellationPolicy>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<CancellationPolicyUpdateDto, CancellationPolicy>().Ignore(x => x.Id).Ignore(x => x.TenantId);

            CreateMap<PaymentPolicyCreateDto, PaymentPolicy>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<PaymentPolicyUpdateDto, PaymentPolicy>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<PaymentPolicy, PaymentPolicyDto>();
            CreateMap<PaymentPolicyWithNavigationProperties, PaymentPolicyWithNavigationPropertiesDto>();

            CreateMap<ItineraryWithNavigationProperties, ItineraryWithNavigationPropertiesDto>();
            CreateMap<AgePolicy, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DemoField));
            CreateMap<Destination, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.City));
            CreateMap<Destination, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.City));
            CreateMap<CancellationPolicy, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.NameString));
            CreateMap<PaymentPolicy, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.PolicyString));

            CreateMap<ShipCreateDto, Ship>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<ShipUpdateDto, Ship>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<Ship, ShipDto>();

            CreateMap<CruiseWithNavigationProperties, CruiseWithNavigationPropertiesDto>();
            CreateMap<Ship, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.ShipName));

            CreateMap<Itinerary, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.ItineraryNameString));
        }
    }
}