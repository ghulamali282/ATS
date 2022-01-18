using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ccm.PaymentPolicies
{
    public interface IPaymentPoliciesAppService : IApplicationService
    {
        Task<PagedResultDto<PaymentPolicyWithNavigationPropertiesDto>> GetListAsync(GetPaymentPoliciesInput input);

        Task<PaymentPolicyWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<PaymentPolicyDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetPartnerLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<PaymentPolicyDto> CreateAsync(PaymentPolicyCreateDto input);

        Task<PaymentPolicyDto> UpdateAsync(Guid id, PaymentPolicyUpdateDto input);
    }
}