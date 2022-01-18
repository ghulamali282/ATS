using Amm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Amm.Destinations;

namespace Amm.Destinations
{
    [RemoteService(Name = "Amm")]
    [Area("amm")]
    [ControllerName("Destination")]
    [Route("api/amm/destinations")]
    public class DestinationController : AbpController, IDestinationsAppService
    {
        private readonly IDestinationsAppService _destinationsAppService;

        public DestinationController(IDestinationsAppService destinationsAppService)
        {
            _destinationsAppService = destinationsAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<DestinationWithNavigationPropertiesDto>> GetListAsync(GetDestinationsInput input)
        {
            return _destinationsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<DestinationWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _destinationsAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<DestinationDto> GetAsync(Guid id)
        {
            return _destinationsAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("country-lookup")]
        public Task<PagedResultDto<LookupDto<string>>> GetCountryLookupAsync(LookupRequestDto input)
        {
            return _destinationsAppService.GetCountryLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<DestinationDto> CreateAsync(DestinationCreateDto input)
        {
            return _destinationsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<DestinationDto> UpdateAsync(Guid id, DestinationUpdateDto input)
        {
            return _destinationsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _destinationsAppService.DeleteAsync(id);
        }
    }
}