using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Ccm.Partners;

namespace Ccm.Partners
{
    [RemoteService(Name = "Ccm")]
    [Area("ccm")]
    [ControllerName("Partner")]
    [Route("api/ccm/partners")]
    public class PartnerController : AbpController, IPartnersAppService
    {
        private readonly IPartnersAppService _partnersAppService;

        public PartnerController(IPartnersAppService partnersAppService)
        {
            _partnersAppService = partnersAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<PartnerWithNavigationPropertiesDto>> GetListAsync(GetPartnersInput input)
        {
            return _partnersAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<PartnerWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _partnersAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<PartnerDto> GetAsync(Guid id)
        {
            return _partnersAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("country-lookup")]
        public Task<PagedResultDto<LookupDto<string>>> GetCountryLookupAsync(LookupRequestDto input)
        {
            return _partnersAppService.GetCountryLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<PartnerDto> CreateAsync(PartnerCreateDto input)
        {
            return _partnersAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<PartnerDto> UpdateAsync(Guid id, PartnerUpdateDto input)
        {
            return _partnersAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _partnersAppService.DeleteAsync(id);
        }
    }
}