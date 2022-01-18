using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Ccm.ItineraryDetails;

namespace Ccm.ItineraryDetails
{
    [RemoteService(Name = "Ccm")]
    [Area("ccm")]
    [ControllerName("ItineraryDetail")]
    [Route("api/ccm/itinerary-details")]
    public class ItineraryDetailController : AbpController, IItineraryDetailsAppService
    {
        private readonly IItineraryDetailsAppService _itineraryDetailsAppService;

        public ItineraryDetailController(IItineraryDetailsAppService itineraryDetailsAppService)
        {
            _itineraryDetailsAppService = itineraryDetailsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ItineraryDetailDto>> GetListAsync(GetItineraryDetailsInput input)
        {
            return _itineraryDetailsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ItineraryDetailDto> GetAsync(Guid id)
        {
            return _itineraryDetailsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ItineraryDetailDto> CreateAsync(ItineraryDetailCreateDto input)
        {
            return _itineraryDetailsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ItineraryDetailDto> UpdateAsync(Guid id, ItineraryDetailUpdateDto input)
        {
            return _itineraryDetailsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _itineraryDetailsAppService.DeleteAsync(id);
        }
    }
}