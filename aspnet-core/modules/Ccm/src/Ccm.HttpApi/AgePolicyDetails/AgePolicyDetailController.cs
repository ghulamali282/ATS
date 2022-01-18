using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Ccm.AgePolicyDetails;

namespace Ccm.AgePolicyDetails
{
    [RemoteService(Name = "Ccm")]
    [Area("ccm")]
    [ControllerName("AgePolicyDetail")]
    [Route("api/ccm/age-policy-details")]
    public class AgePolicyDetailController : AbpController, IAgePolicyDetailsAppService
    {
        private readonly IAgePolicyDetailsAppService _agePolicyDetailsAppService;

        public AgePolicyDetailController(IAgePolicyDetailsAppService agePolicyDetailsAppService)
        {
            _agePolicyDetailsAppService = agePolicyDetailsAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<AgePolicyDetailWithNavigationPropertiesDto>> GetListAsync(GetAgePolicyDetailsInput input)
        {
            return _agePolicyDetailsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<AgePolicyDetailWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _agePolicyDetailsAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<AgePolicyDetailDto> GetAsync(Guid id)
        {
            return _agePolicyDetailsAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("master-data-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input)
        {
            return _agePolicyDetailsAppService.GetMasterDataLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<AgePolicyDetailDto> CreateAsync(AgePolicyDetailCreateDto input)
        {
            return _agePolicyDetailsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<AgePolicyDetailDto> UpdateAsync(Guid id, AgePolicyDetailUpdateDto input)
        {
            return _agePolicyDetailsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _agePolicyDetailsAppService.DeleteAsync(id);
        }
    }
}