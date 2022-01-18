using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Amm.Partners;

namespace Amm.Partners
{
    [RemoteService(Name = "Amm")]
    [Area("amm")]
    [ControllerName("Partner")]
    [Route("api/amm/partners")]
    public class PartnerController : AbpController, IPartnersAppService
    {
        private readonly IPartnersAppService _partnersAppService;

        public PartnerController(IPartnersAppService partnersAppService)
        {
            _partnersAppService = partnersAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<PartnerDto>> GetListAsync(GetPartnersInput input)
        {
            return _partnersAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<PartnerDto> GetAsync(Guid id)
        {
            return _partnersAppService.GetAsync(id);
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