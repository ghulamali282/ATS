using Amm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Amm.Marinas;

namespace Amm.Marinas
{
    [RemoteService(Name = "Amm")]
    [Area("amm")]
    [ControllerName("Marina")]
    [Route("api/amm/marinas")]
    public class MarinaController : AbpController, IMarinasAppService
    {
        private readonly IMarinasAppService _marinasAppService;

        public MarinaController(IMarinasAppService marinasAppService)
        {
            _marinasAppService = marinasAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<MarinaWithNavigationPropertiesDto>> GetListAsync(GetMarinasInput input)
        {
            return _marinasAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<MarinaWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _marinasAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<MarinaDto> GetAsync(Guid id)
        {
            return _marinasAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("master-data-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input)
        {
            return _marinasAppService.GetMasterDataLookupAsync(input);
        }

        [HttpGet]
        [Route("destination-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetDestinationLookupAsync(LookupRequestDto input)
        {
            return _marinasAppService.GetDestinationLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<MarinaDto> CreateAsync(MarinaCreateDto input)
        {
            return _marinasAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<MarinaDto> UpdateAsync(Guid id, MarinaUpdateDto input)
        {
            return _marinasAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _marinasAppService.DeleteAsync(id);
        }
    }
}