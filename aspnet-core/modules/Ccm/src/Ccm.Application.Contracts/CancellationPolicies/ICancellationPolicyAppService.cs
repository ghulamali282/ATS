using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ccm.CancellationPolicies
{
    public interface ICancellationPoliciesAppService : IApplicationService
    {
        Task<PagedResultDto<CancellationPolicyWithNavigationPropertiesDto>> GetListAsync(GetCancellationPoliciesInput input);

        Task<CancellationPolicyWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<CancellationPolicyDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetPartnerLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<CancellationPolicyDto> CreateAsync(CancellationPolicyCreateDto input);

        Task<CancellationPolicyDto> UpdateAsync(Guid id, CancellationPolicyUpdateDto input);
    }
}