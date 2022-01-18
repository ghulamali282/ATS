using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Amm.MasterDatas;

namespace Amm.MasterDatas
{
    [RemoteService(Name = "Amm")]
    [Area("amm")]
    [ControllerName("MasterData")]
    [Route("api/amm/master-datas")]
    public class MasterDataController : AbpController, IMasterDatasAppService
    {
        private readonly IMasterDatasAppService _masterDatasAppService;

        public MasterDataController(IMasterDatasAppService masterDatasAppService)
        {
            _masterDatasAppService = masterDatasAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<MasterDataDto>> GetListAsync(GetMasterDatasInput input)
        {
            return _masterDatasAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<MasterDataDto> GetAsync(Guid id)
        {
            return _masterDatasAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<MasterDataDto> CreateAsync(MasterDataCreateDto input)
        {
            return _masterDatasAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<MasterDataDto> UpdateAsync(Guid id, MasterDataUpdateDto input)
        {
            return _masterDatasAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _masterDatasAppService.DeleteAsync(id);
        }
    }
}