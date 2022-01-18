using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Ccm.AgePolicies;

namespace Ccm.AgePolicies
{
    [RemoteService(Name = "Ccm")]
    [Area("ccm")]
    [ControllerName("AgePolicy")]
    [Route("api/ccm/age-policies")]
    public class AgePolicyController : AbpController, IAgePoliciesAppService
    {
        private readonly IAgePoliciesAppService _agePoliciesAppService;

        public AgePolicyController(IAgePoliciesAppService agePoliciesAppService)
        {
            _agePoliciesAppService = agePoliciesAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<AgePolicyWithNavigationPropertiesDto>> GetListAsync(GetAgePoliciesInput input)
        {
            return _agePoliciesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<AgePolicyWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _agePoliciesAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<AgePolicyDto> GetAsync(Guid id)
        {
            return _agePoliciesAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("master-data-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input)
        {
            return _agePoliciesAppService.GetMasterDataLookupAsync(input);
        }

        [HttpGet]
        [Route("partner-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetPartnerLookupAsync(LookupRequestDto input)
        {
            return _agePoliciesAppService.GetPartnerLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<AgePolicyDto> CreateAsync(AgePolicyCreateDto input)
        {
            return _agePoliciesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<AgePolicyDto> UpdateAsync(Guid id, AgePolicyUpdateDto input)
        {
            return _agePoliciesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _agePoliciesAppService.DeleteAsync(id);
        }
    }
}