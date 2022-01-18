using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Ccm.Cruises;

namespace Ccm.Cruises
{
    [RemoteService(Name = "Ccm")]
    [Area("ccm")]
    [ControllerName("Cruise")]
    [Route("api/ccm/cruises")]
    public class CruiseController : AbpController, ICruisesAppService
    {
        private readonly ICruisesAppService _cruisesAppService;

        public CruiseController(ICruisesAppService cruisesAppService)
        {
            _cruisesAppService = cruisesAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<CruiseWithNavigationPropertiesDto>> GetListAsync(GetCruisesInput input)
        {
            return _cruisesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<CruiseWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _cruisesAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CruiseDto> GetAsync(Guid id)
        {
            return _cruisesAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("ship-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetShipLookupAsync(LookupRequestDto input)
        {
            return _cruisesAppService.GetShipLookupAsync(input);
        }

        [HttpGet]
        [Route("itinerary-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetItineraryLookupAsync(LookupRequestDto input)
        {
            return _cruisesAppService.GetItineraryLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<CruiseDto> CreateAsync(CruiseCreateDto input)
        {
            return _cruisesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CruiseDto> UpdateAsync(Guid id, CruiseUpdateDto input)
        {
            return _cruisesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _cruisesAppService.DeleteAsync(id);
        }
    }
}