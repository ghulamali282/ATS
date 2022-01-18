using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Amm.ShpCabins;

namespace Amm.ShpCabins
{
    [RemoteService(Name = "Amm")]
    [Area("amm")]
    [ControllerName("ShpCabin")]
    [Route("api/amm/shp-cabins")]
    public class ShpCabinController : AbpController, IShpCabinsAppService
    {
        private readonly IShpCabinsAppService _shpCabinsAppService;

        public ShpCabinController(IShpCabinsAppService shpCabinsAppService)
        {
            _shpCabinsAppService = shpCabinsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ShpCabinDto>> GetListAsync(GetShpCabinsInput input)
        {
            return _shpCabinsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShpCabinDto> GetAsync(Guid id)
        {
            return _shpCabinsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ShpCabinDto> CreateAsync(ShpCabinCreateDto input)
        {
            return _shpCabinsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShpCabinDto> UpdateAsync(Guid id, ShpCabinUpdateDto input)
        {
            return _shpCabinsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shpCabinsAppService.DeleteAsync(id);
        }
    }
}