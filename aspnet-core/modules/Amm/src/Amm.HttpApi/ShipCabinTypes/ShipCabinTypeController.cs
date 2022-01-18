using Amm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Amm.ShipCabinTypes;

namespace Amm.ShipCabinTypes
{
    [RemoteService(Name = "Amm")]
    [Area("amm")]
    [ControllerName("ShipCabinType")]
    [Route("api/amm/ship-cabin-types")]
    public class ShipCabinTypeController : AbpController, IShipCabinTypesAppService
    {
        private readonly IShipCabinTypesAppService _shipCabinTypesAppService;

        public ShipCabinTypeController(IShipCabinTypesAppService shipCabinTypesAppService)
        {
            _shipCabinTypesAppService = shipCabinTypesAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<ShipCabinTypeWithNavigationPropertiesDto>> GetListAsync(GetShipCabinTypesInput input)
        {
            return _shipCabinTypesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<ShipCabinTypeWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _shipCabinTypesAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShipCabinTypeDto> GetAsync(Guid id)
        {
            return _shipCabinTypesAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("master-data-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input)
        {
            return _shipCabinTypesAppService.GetMasterDataLookupAsync(input);
        }

        [HttpGet]
        [Route("ship-deck-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetShipDeckLookupAsync(LookupRequestDto input)
        {
            return _shipCabinTypesAppService.GetShipDeckLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<ShipCabinTypeDto> CreateAsync(ShipCabinTypeCreateDto input)
        {
            return _shipCabinTypesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShipCabinTypeDto> UpdateAsync(Guid id, ShipCabinTypeUpdateDto input)
        {
            return _shipCabinTypesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shipCabinTypesAppService.DeleteAsync(id);
        }
    }
}