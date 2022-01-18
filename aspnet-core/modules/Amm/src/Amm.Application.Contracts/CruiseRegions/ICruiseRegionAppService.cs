using Amm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Amm.CruiseRegions
{
    public interface ICruiseRegionsAppService : IApplicationService
    {
        Task<PagedResultDto<CruiseRegionWithNavigationPropertiesDto>> GetListAsync(GetCruiseRegionsInput input);

        Task<CruiseRegionWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<CruiseRegionDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<CruiseRegionDto> CreateAsync(CruiseRegionCreateDto input);

        Task<CruiseRegionDto> UpdateAsync(Guid id, CruiseRegionUpdateDto input);
    }
}