using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Ccm.Destinations;

namespace Ccm.Destinations
{
    [RemoteService(Name = "Ccm")]
    [Area("ccm")]
    [ControllerName("Destination")]
    [Route("api/ccm/destinations")]
    public class DestinationController : AbpController, IDestinationsAppService
    {
        private readonly IDestinationsAppService _destinationsAppService;

        public DestinationController(IDestinationsAppService destinationsAppService)
        {
            _destinationsAppService = destinationsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<DestinationDto>> GetListAsync(GetDestinationsInput input)
        {
            return _destinationsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<DestinationDto> GetAsync(Guid id)
        {
            return _destinationsAppService.GetAsync(id);
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