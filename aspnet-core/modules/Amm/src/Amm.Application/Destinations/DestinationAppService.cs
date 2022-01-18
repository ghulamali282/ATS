using Amm.Shared;
using Amm.Countries;
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
using Amm.Permissions;
using Amm.Destinations;

namespace Amm.Destinations
{

    [Authorize(AmmPermissions.Destinations.Default)]
    public class DestinationsAppService : ApplicationService, IDestinationsAppService
    {
        private readonly IDestinationRepository _destinationRepository;
        private readonly IRepository<Country, string> _countryRepository;

        public DestinationsAppService(IDestinationRepository destinationRepository, IRepository<Country, string> countryRepository)
        {
            _destinationRepository = destinationRepository; _countryRepository = countryRepository;
        }

        public virtual async Task<PagedResultDto<DestinationWithNavigationPropertiesDto>> GetListAsync(GetDestinationsInput input)
        {
            var totalCount = await _destinationRepository.GetCountAsync(input.FilterText, input.City, input.CityLocalName, input.latitudeMin, input.latitudeMax, input.longitudeMin, input.longitudeMax, input.VideoUrl, input.PlaceId, input.DestCountry);
            var items = await _destinationRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.City, input.CityLocalName, input.latitudeMin, input.latitudeMax, input.longitudeMin, input.longitudeMax, input.VideoUrl, input.PlaceId, input.DestCountry, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<DestinationWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<DestinationWithNavigationProperties>, List<DestinationWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<DestinationWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<DestinationWithNavigationProperties, DestinationWithNavigationPropertiesDto>
                (await _destinationRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<DestinationDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Destination, DestinationDto>(await _destinationRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<string>>> GetCountryLookupAsync(LookupRequestDto input)
        {
            var query = (await _countryRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.CountryName != null &&
                         x.CountryName.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Country>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<string>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Country>, List<LookupDto<string>>>(lookupData)
            };
        }

        [Authorize(AmmPermissions.Destinations.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _destinationRepository.DeleteAsync(id);
        }

        [Authorize(AmmPermissions.Destinations.Create)]
        public virtual async Task<DestinationDto> CreateAsync(DestinationCreateDto input)
        {
            if (input.DestCountry == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Country"]]);
            }

            var destination = ObjectMapper.Map<DestinationCreateDto, Destination>(input);

            destination = await _destinationRepository.InsertAsync(destination, autoSave: true);
            return ObjectMapper.Map<Destination, DestinationDto>(destination);
        }

        [Authorize(AmmPermissions.Destinations.Edit)]
        public virtual async Task<DestinationDto> UpdateAsync(Guid id, DestinationUpdateDto input)
        {
            if (input.DestCountry == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Country"]]);
            }

            var destination = await _destinationRepository.GetAsync(id);
            ObjectMapper.Map(input, destination);
            destination = await _destinationRepository.UpdateAsync(destination, autoSave: true);
            return ObjectMapper.Map<Destination, DestinationDto>(destination);
        }
    }
}