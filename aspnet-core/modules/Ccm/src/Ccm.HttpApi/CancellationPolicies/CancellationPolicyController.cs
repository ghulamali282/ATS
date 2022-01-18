using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Ccm.CancellationPolicies;

namespace Ccm.CancellationPolicies
{
    [RemoteService(Name = "Ccm")]
    [Area("ccm")]
    [ControllerName("CancellationPolicy")]
    [Route("api/ccm/cancellation-policies")]
    public class CancellationPolicyController : AbpController, ICancellationPoliciesAppService
    {
        private readonly ICancellationPoliciesAppService _cancellationPoliciesAppService;

        public CancellationPolicyController(ICancellationPoliciesAppService cancellationPoliciesAppService)
        {
            _cancellationPoliciesAppService = cancellationPoliciesAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<CancellationPolicyWithNavigationPropertiesDto>> GetListAsync(GetCancellationPoliciesInput input)
        {
            return _cancellationPoliciesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<CancellationPolicyWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _cancellationPoliciesAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CancellationPolicyDto> GetAsync(Guid id)
        {
            return _cancellationPoliciesAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("partner-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetPartnerLookupAsync(LookupRequestDto input)
        {
            return _cancellationPoliciesAppService.GetPartnerLookupAsync(input);
        }

        [HttpGet]
        [Route("master-data-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input)
        {
            return _cancellationPoliciesAppService.GetMasterDataLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<CancellationPolicyDto> CreateAsync(CancellationPolicyCreateDto input)
        {
            return _cancellationPoliciesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CancellationPolicyDto> UpdateAsync(Guid id, CancellationPolicyUpdateDto input)
        {
            return _cancellationPoliciesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _cancellationPoliciesAppService.DeleteAsync(id);
        }
    }
}