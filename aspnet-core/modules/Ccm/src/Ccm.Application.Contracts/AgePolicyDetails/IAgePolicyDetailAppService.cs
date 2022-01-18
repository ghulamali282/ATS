using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ccm.AgePolicyDetails
{
    public interface IAgePolicyDetailsAppService : IApplicationService
    {
        Task<PagedResultDto<AgePolicyDetailWithNavigationPropertiesDto>> GetListAsync(GetAgePolicyDetailsInput input);

        Task<AgePolicyDetailWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<AgePolicyDetailDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<AgePolicyDetailDto> CreateAsync(AgePolicyDetailCreateDto input);

        Task<AgePolicyDetailDto> UpdateAsync(Guid id, AgePolicyDetailUpdateDto input);
    }
}