using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ccm.Cruises
{
    public interface ICruisesAppService : IApplicationService
    {
        Task<PagedResultDto<CruiseWithNavigationPropertiesDto>> GetListAsync(GetCruisesInput input);

        Task<CruiseWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<CruiseDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetShipLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetItineraryLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<CruiseDto> CreateAsync(CruiseCreateDto input);

        Task<CruiseDto> UpdateAsync(Guid id, CruiseUpdateDto input);
    }
}