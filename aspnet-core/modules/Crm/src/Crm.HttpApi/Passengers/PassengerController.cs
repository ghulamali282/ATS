using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Crm.Passengers;

namespace Crm.Passengers
{
    [RemoteService(Name = "Crm")]
    [Area("crm")]
    [ControllerName("Passenger")]
    [Route("api/crm/passengers")]
    public class PassengerController : AbpController, IPassengersAppService
    {
        private readonly IPassengersAppService _passengersAppService;

        public PassengerController(IPassengersAppService passengersAppService)
        {
            _passengersAppService = passengersAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<PassengerDto>> GetListAsync(GetPassengersInput input)
        {
            return _passengersAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<PassengerDto> GetAsync(Guid id)
        {
            return _passengersAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<PassengerDto> CreateAsync(PassengerCreateDto input)
        {
            return _passengersAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<PassengerDto> UpdateAsync(Guid id, PassengerUpdateDto input)
        {
            return _passengersAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _passengersAppService.DeleteAsync(id);
        }
    }
}