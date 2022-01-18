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
using System;
using Amm.Shared;
using Volo.Abp.AutoMapper;
using Amm.AppDefaults;
using AutoMapper;

namespace Amm
{
    public class AmmApplicationAutoMapperProfile : Profile
    {
        public AmmApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<AppDefaultCreateDto, AppDefault>().Ignore(x => x.Id);
            CreateMap<AppDefaultUpdateDto, AppDefault>().Ignore(x => x.Id);
            CreateMap<AppDefault, AppDefaultDto>();

            CreateMap<BookingStatusCreateDto, BookingStatus>().Ignore(x => x.Id);
            CreateMap<BookingStatusUpdateDto, BookingStatus>().Ignore(x => x.Id);
            CreateMap<BookingStatus, BookingStatusDto>();
            CreateMap<BookingStatusWithNavigationProperties, BookingStatusWithNavigationPropertiesDto>();
            CreateMap<MasterData, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

            CreateMap<CountryCreateDto, Country>().Ignore(x => x.Id);
            CreateMap<CountryUpdateDto, Country>().Ignore(x => x.Id);
            CreateMap<Country, CountryDto>();
            CreateMap<CountryWithNavigationProperties, CountryWithNavigationPropertiesDto>();
            CreateMap<CruiseRegion, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.FreeEntry));

            CreateMap<CruiseRegionCreateDto, CruiseRegion>().Ignore(x => x.Id);
            CreateMap<CruiseRegionUpdateDto, CruiseRegion>().Ignore(x => x.Id);
            CreateMap<CruiseRegion, CruiseRegionDto>();
            CreateMap<CruiseRegionWithNavigationProperties, CruiseRegionWithNavigationPropertiesDto>();

            CreateMap<DestinationCreateDto, Destination>().Ignore(x => x.Id);
            CreateMap<DestinationUpdateDto, Destination>().Ignore(x => x.Id);
            CreateMap<Destination, DestinationDto>();
            CreateMap<DestinationWithNavigationProperties, DestinationWithNavigationPropertiesDto>();
            CreateMap<Country, LookupDto<string>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.CountryName));

            CreateMap<MasterDataCreateDto, MasterData>().Ignore(x => x.Id);
            CreateMap<MasterDataUpdateDto, MasterData>().Ignore(x => x.Id);
            CreateMap<MasterData, MasterDataDto>();

            CreateMap<PartnerCreateDto, Partner>().Ignore(x => x.Id);
            CreateMap<PartnerUpdateDto, Partner>().Ignore(x => x.Id);
            CreateMap<Partner, PartnerDto>();

            CreateMap<ShipCreateDto, Ship>().Ignore(x => x.Id);
            CreateMap<ShipUpdateDto, Ship>().Ignore(x => x.Id);
            CreateMap<Ship, ShipDto>();
            CreateMap<ShipWithNavigationProperties, ShipWithNavigationPropertiesDto>();
            CreateMap<Destination, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.City));
            CreateMap<Partner, LookupDto<Guid?>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.PartnerName));

            CreateMap<ShipDeckCreateDto, ShipDeck>().Ignore(x => x.Id);
            CreateMap<ShipDeckUpdateDto, ShipDeck>().Ignore(x => x.Id);
            CreateMap<ShipDeck, ShipDeckDto>();
            CreateMap<ShipDeckWithNavigationProperties, ShipDeckWithNavigationPropertiesDto>();

            CreateMap<ShipCabinTypeCreateDto, ShipCabinType>().Ignore(x => x.Id);
            CreateMap<ShipCabinTypeUpdateDto, ShipCabinType>().Ignore(x => x.Id);
            CreateMap<ShipCabinType, ShipCabinTypeDto>();
            CreateMap<ShipCabinTypeWithNavigationProperties, ShipCabinTypeWithNavigationPropertiesDto>();
            CreateMap<ShipDeck, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.ShipDeckNameTEMP));
            CreateMap<MasterData, LookupDto<Guid?>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

            CreateMap<ShpCabinCreateDto, ShpCabin>().Ignore(x => x.Id);
            CreateMap<ShpCabinUpdateDto, ShpCabin>().Ignore(x => x.Id);
            CreateMap<ShpCabin, ShpCabinDto>();

            CreateMap<ShipOperatorCreateDto, ShipOperator>().Ignore(x => x.Id);
            CreateMap<ShipOperatorUpdateDto, ShipOperator>().Ignore(x => x.Id);
            CreateMap<ShipOperator, ShipOperatorDto>();

            CreateMap<ShipOperator, LookupDto<Guid?>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.OperatorName));

            CreateMap<MarinaCreateDto, Marina>().Ignore(x => x.Id);
            CreateMap<MarinaUpdateDto, Marina>().Ignore(x => x.Id);
            CreateMap<Marina, MarinaDto>();

            CreateMap<MarinaWithNavigationProperties, MarinaWithNavigationPropertiesDto>();
        }
    }
}