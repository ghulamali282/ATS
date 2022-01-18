using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Ccm.PaymentPolicies;

namespace Ccm.PaymentPolicies
{
    [RemoteService(Name = "Ccm")]
    [Area("ccm")]
    [ControllerName("PaymentPolicy")]
    [Route("api/ccm/payment-policies")]
    public class PaymentPolicyController : AbpController, IPaymentPoliciesAppService
    {
        private readonly IPaymentPoliciesAppService _paymentPoliciesAppService;

        public PaymentPolicyController(IPaymentPoliciesAppService paymentPoliciesAppService)
        {
            _paymentPoliciesAppService = paymentPoliciesAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<PaymentPolicyWithNavigationPropertiesDto>> GetListAsync(GetPaymentPoliciesInput input)
        {
            return _paymentPoliciesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<PaymentPolicyWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _paymentPoliciesAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<PaymentPolicyDto> GetAsync(Guid id)
        {
            return _paymentPoliciesAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("partner-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetPartnerLookupAsync(LookupRequestDto input)
        {
            return _paymentPoliciesAppService.GetPartnerLookupAsync(input);
        }

        [HttpGet]
        [Route("master-data-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input)
        {
            return _paymentPoliciesAppService.GetMasterDataLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<PaymentPolicyDto> CreateAsync(PaymentPolicyCreateDto input)
        {
            return _paymentPoliciesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<PaymentPolicyDto> UpdateAsync(Guid id, PaymentPolicyUpdateDto input)
        {
            return _paymentPoliciesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _paymentPoliciesAppService.DeleteAsync(id);
        }
    }
}