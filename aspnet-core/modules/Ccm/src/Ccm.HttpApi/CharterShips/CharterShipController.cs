using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Ccm.CharterShips;

namespace Ccm.CharterShips
{
    [RemoteService(Name = "Ccm")]
    [Area("ccm")]
    [ControllerName("CharterShip")]
    [Route("api/ccm/charter-ships")]
    public class CharterShipController : AbpController, ICharterShipsAppService
    {
        private readonly ICharterShipsAppService _charterShipsAppService;

        public CharterShipController(ICharterShipsAppService charterShipsAppService)
        {
            _charterShipsAppService = charterShipsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CharterShipDto>> GetListAsync(GetCharterShipsInput input)
        {
            return _charterShipsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CharterShipDto> GetAsync(Guid id)
        {
            return _charterShipsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CharterShipDto> CreateAsync(CharterShipCreateDto input)
        {
            return _charterShipsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CharterShipDto> UpdateAsync(Guid id, CharterShipUpdateDto input)
        {
            return _charterShipsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _charterShipsAppService.DeleteAsync(id);
        }
    }
}