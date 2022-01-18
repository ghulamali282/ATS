using Ccm.Shared;
using Ccm.Itineraries;
using Ccm.Ships;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Ccm.Permissions;
using Ccm.Cruises;

namespace Ccm.Cruises
{

    [Authorize(CcmPermissions.Cruises.Default)]
    public class CruisesAppService : ApplicationService, ICruisesAppService
    {
        private readonly ICruiseRepository _cruiseRepository;
        private readonly IRepository<Ship, Guid> _shipRepository;
        private readonly IRepository<Itinerary, Guid> _itineraryRepository;

        public CruisesAppService(ICruiseRepository cruiseRepository, IRepository<Ship, Guid> shipRepository, IRepository<Itinerary, Guid> itineraryRepository)
        {
            _cruiseRepository = cruiseRepository; _shipRepository = shipRepository;
            _itineraryRepository = itineraryRepository;
        }

        public virtual async Task<PagedResultDto<CruiseWithNavigationPropertiesDto>> GetListAsync(GetCruisesInput input)
        {
            var totalCount = await _cruiseRepository.GetCountAsync(input.FilterText, input.SeasonMin, input.SeasonMax, input.CruiseEnabled, input.Featured, input.FreeInternetOnBoard, input.InternetOnBoard, input.Video, input.B2B, input.B2C, input.B2B_Agent, input.B2C_Agent, input.CruiseDescriptions, input.ShipAmenities, input.ShipArticles, input.ShipPhotos, input.CabinAmenities, input.CabinArticles, input.CabinPhotos, input.Ship, input.Itinerary);
            var items = await _cruiseRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.SeasonMin, input.SeasonMax, input.CruiseEnabled, input.Featured, input.FreeInternetOnBoard, input.InternetOnBoard, input.Video, input.B2B, input.B2C, input.B2B_Agent, input.B2C_Agent, input.CruiseDescriptions, input.ShipAmenities, input.ShipArticles, input.ShipPhotos, input.CabinAmenities, input.CabinArticles, input.CabinPhotos, input.Ship, input.Itinerary, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CruiseWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CruiseWithNavigationProperties>, List<CruiseWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<CruiseWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<CruiseWithNavigationProperties, CruiseWithNavigationPropertiesDto>
                (await _cruiseRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<CruiseDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Cruise, CruiseDto>(await _cruiseRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetShipLookupAsync(LookupRequestDto input)
        {
            var query = (await _shipRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.ShipName != null &&
                         x.ShipName.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Ship>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Ship>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetItineraryLookupAsync(LookupRequestDto input)
        {
            var query = (await _itineraryRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.ItineraryNameString != null &&
                         x.ItineraryNameString.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Itinerary>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Itinerary>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(CcmPermissions.Cruises.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _cruiseRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.Cruises.Create)]
        public virtual async Task<CruiseDto> CreateAsync(CruiseCreateDto input)
        {
            if (input.Ship == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Ship"]]);
            }
            if (input.Itinerary == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Itinerary"]]);
            }

            var cruise = ObjectMapper.Map<CruiseCreateDto, Cruise>(input);
            cruise.TenantId = CurrentTenant.Id;
            cruise = await _cruiseRepository.InsertAsync(cruise, autoSave: true);
            return ObjectMapper.Map<Cruise, CruiseDto>(cruise);
        }

        [Authorize(CcmPermissions.Cruises.Edit)]
        public virtual async Task<CruiseDto> UpdateAsync(Guid id, CruiseUpdateDto input)
        {
            if (input.Ship == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Ship"]]);
            }
            if (input.Itinerary == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Itinerary"]]);
            }

            var cruise = await _cruiseRepository.GetAsync(id);
            ObjectMapper.Map(input, cruise);
            cruise = await _cruiseRepository.UpdateAsync(cruise, autoSave: true);
            return ObjectMapper.Map<Cruise, CruiseDto>(cruise);
        }
    }
}