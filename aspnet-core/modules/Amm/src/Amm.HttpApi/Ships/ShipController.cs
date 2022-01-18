using Amm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Amm.Ships;

namespace Amm.Ships
{
    [RemoteService(Name = "Amm")]
    [Area("amm")]
    [ControllerName("Ship")]
    [Route("api/amm/ships")]
    public class ShipController : AbpController, IShipsAppService
    {
        private readonly IShipsAppService _shipsAppService;

        public ShipController(IShipsAppService shipsAppService)
        {
            _shipsAppService = shipsAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<ShipWithNavigationPropertiesDto>> GetListAsync(GetShipsInput input)
        {
            return _shipsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<ShipWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _shipsAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShipDto> GetAsync(Guid id)
        {
            return _shipsAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("destination-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetDestinationLookupAsync(LookupRequestDto input)
        {
            return _shipsAppService.GetDestinationLookupAsync(input);
        }

        [HttpGet]
        [Route("country-lookup")]
        public Task<PagedResultDto<LookupDto<string>>> GetCountryLookupAsync(LookupRequestDto input)
        {
            return _shipsAppService.GetCountryLookupAsync(input);
        }

        [HttpGet]
        [Route("master-data-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input)
        {
            return _shipsAppService.GetMasterDataLookupAsync(input);
        }

        [HttpGet]
        [Route("ship-operator-lookup")]
        public Task<PagedResultDto<LookupDto<Guid?>>> GetShipOperatorLookupAsync(LookupRequestDto input)
        {
            return _shipsAppService.GetShipOperatorLookupAsync(input);
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