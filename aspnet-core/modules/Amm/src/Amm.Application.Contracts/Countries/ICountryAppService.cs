using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Amm.Countries
{
    public interface ICountriesAppService : IApplicationService
    {
        Task<PagedResultDto<CountryDto>> GetListAsync(GetCountriesInput input);

        Task<CountryDto> GetAsync(string id);

        Task DeleteAsync(string id);

        Task<CountryDto> CreateAsync(CountryCreateDto input);

        Task<CountryDto> UpdateAsync(string id, CountryUpdateDto input);
    }
}