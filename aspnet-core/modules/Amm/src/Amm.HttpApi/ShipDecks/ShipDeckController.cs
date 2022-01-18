using Amm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Amm.ShipDecks;

namespace Amm.ShipDecks
{
    [RemoteService(Name = "Amm")]
    [Area("amm")]
    [ControllerName("ShipDeck")]
    [Route("api/amm/ship-decks")]
    public class ShipDeckController : AbpController, IShipDecksAppService
    {
        private readonly IShipDecksAppService _shipDecksAppService;

        public ShipDeckController(IShipDecksAppService shipDecksAppService)
        {
            _shipDecksAppService = shipDecksAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<ShipDeckWithNavigationPropertiesDto>> GetListAsync(GetShipDecksInput input)
        {
            return _shipDecksAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<ShipDeckWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _shipDecksAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShipDeckDto> GetAsync(Guid id)
        {
            return _shipDecksAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("master-data-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input)
        {
            return _shipDecksAppService.GetMasterDataLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<ShipDeckDto> CreateAsync(ShipDeckCreateDto input)
        {
            return _shipDecksAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShipDeckDto> UpdateAsync(Guid id, ShipDeckUpdateDto input)
        {
            return _shipDecksAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shipDecksAppService.DeleteAsync(id);
        }
    }
}