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
using Ccm.Countries;

namespace Ccm.Countries
{

    [Authorize(CcmPermissions.Countries.Default)]
    public class CountriesAppService : ApplicationService, ICountriesAppService
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesAppService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public virtual async Task<PagedResultDto<CountryDto>> GetListAsync(GetCountriesInput input)
        {
            var totalCount = await _countryRepository.GetCountAsync(input.FilterText, input.CountryName, input.CultureName);
            var items = await _countryRepository.GetListAsync(input.FilterText, input.CountryName, input.CultureName, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CountryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Country>, List<CountryDto>>(items)
            };
        }

        public virtual async Task<CountryDto> GetAsync(string id)
        {
            return ObjectMapper.Map<Country, CountryDto>(await _countryRepository.GetAsync(id));
        }

        [Authorize(CcmPermissions.Countries.Delete)]
        public virtual async Task DeleteAsync(string id)
        {
            await _countryRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.Countries.Create)]
        public virtual async Task<CountryDto> CreateAsync(CountryCreateDto input)
        {

            var country = ObjectMapper.Map<CountryCreateDto, Country>(input);
            country.TenantId = CurrentTenant.Id;
            country = await _countryRepository.InsertAsync(country, autoSave: true);
            return ObjectMapper.Map<Country, CountryDto>(country);
        }

        [Authorize(CcmPermissions.Countries.Edit)]
        public virtual async Task<CountryDto> UpdateAsync(string id, CountryUpdateDto input)
        {

            var country = await _countryRepository.GetAsync(id);
            ObjectMapper.Map(input, country);
            country = await _countryRepository.UpdateAsync(country, autoSave: true);
            return ObjectMapper.Map<Country, CountryDto>(country);
        }
    }
}