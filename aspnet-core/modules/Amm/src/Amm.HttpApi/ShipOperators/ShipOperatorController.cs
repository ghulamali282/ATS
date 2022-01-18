using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Amm.ShipOperators;

namespace Amm.ShipOperators
{
    [RemoteService(Name = "Amm")]
    [Area("amm")]
    [ControllerName("ShipOperator")]
    [Route("api/amm/ship-operators")]
    public class ShipOperatorController : AbpController, IShipOperatorsAppService
    {
        private readonly IShipOperatorsAppService _shipOperatorsAppService;

        public ShipOperatorController(IShipOperatorsAppService shipOperatorsAppService)
        {
            _shipOperatorsAppService = shipOperatorsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ShipOperatorDto>> GetListAsync(GetShipOperatorsInput input)
        {
            return _shipOperatorsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShipOperatorDto> GetAsync(Guid id)
        {
            return _shipOperatorsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ShipOperatorDto> CreateAsync(ShipOperatorCreateDto input)
        {
            return _shipOperatorsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShipOperatorDto> UpdateAsync(Guid id, ShipOperatorUpdateDto input)
        {
            return _shipOperatorsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shipOperatorsAppService.DeleteAsync(id);
        }
    }
}