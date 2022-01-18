using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ccm.AgePolicies
{
    public interface IAgePoliciesAppService : IApplicationService
    {
        Task<PagedResultDto<AgePolicyWithNavigationPropertiesDto>> GetListAsync(GetAgePoliciesInput input);

        Task<AgePolicyWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<AgePolicyDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetPartnerLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<AgePolicyDto> CreateAsync(AgePolicyCreateDto input);

        Task<AgePolicyDto> UpdateAsync(Guid id, AgePolicyUpdateDto input);
    }
}