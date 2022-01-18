using Amm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Amm.Destinations
{
    public interface IDestinationsAppService : IApplicationService
    {
        Task<PagedResultDto<DestinationWithNavigationPropertiesDto>> GetListAsync(GetDestinationsInput input);

        Task<DestinationWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<DestinationDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<string>>> GetCountryLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<DestinationDto> CreateAsync(DestinationCreateDto input);

        Task<DestinationDto> UpdateAsync(Guid id, DestinationUpdateDto input);
    }
}