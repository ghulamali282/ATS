using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Ccm.Ships;

namespace Ccm.Ships
{
    [RemoteService(Name = "Ccm")]
    [Area("ccm")]
    [ControllerName("Ship")]
    [Route("api/ccm/ships")]
    public class ShipController : AbpController, IShipsAppService
    {
        private readonly IShipsAppService _shipsAppService;

        public ShipController(IShipsAppService shipsAppService)
        {
            _shipsAppService = shipsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ShipDto>> GetListAsync(GetShipsInput input)
        {
            return _shipsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShipDto> GetAsync(Guid id)
        {
            return _shipsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ShipDto> CreateAsync(ShipCreateDto input)
        {
            return _shipsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShipDto> UpdateAsync(Guid id, ShipUpdateDto input)
        {
            return _shipsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shipsAppService.DeleteAsync(id);
        }
    }
}