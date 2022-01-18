using Amm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Amm.CruiseRegions;

namespace Amm.CruiseRegions
{
    [RemoteService(Name = "Amm")]
    [Area("amm")]
    [ControllerName("CruiseRegion")]
    [Route("api/amm/cruise-regions")]
    public class CruiseRegionController : AbpController, ICruiseRegionsAppService
    {
        private readonly ICruiseRegionsAppService _cruiseRegionsAppService;

        public CruiseRegionController(ICruiseRegionsAppService cruiseRegionsAppService)
        {
            _cruiseRegionsAppService = cruiseRegionsAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<CruiseRegionWithNavigationPropertiesDto>> GetListAsync(GetCruiseRegionsInput input)
        {
            return _cruiseRegionsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<CruiseRegionWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _cruiseRegionsAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CruiseRegionDto> GetAsync(Guid id)
        {
            return _cruiseRegionsAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("master-data-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input)
        {
            return _cruiseRegionsAppService.GetMasterDataLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<CruiseRegionDto> CreateAsync(CruiseRegionCreateDto input)
        {
            return _cruiseRegionsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CruiseRegionDto> UpdateAsync(Guid id, CruiseRegionUpdateDto input)
        {
            return _cruiseRegionsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _cruiseRegionsAppService.DeleteAsync(id);
        }
    }
}