using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Amm.AppDefaults;

namespace Amm.AppDefaults
{
    [RemoteService(Name = "Amm")]
    [Area("amm")]
    [ControllerName("AppDefault")]
    [Route("api/amm/app-defaults")]
    public class AppDefaultController : AbpController, IAppDefaultsAppService
    {
        private readonly IAppDefaultsAppService _appDefaultsAppService;

        public AppDefaultController(IAppDefaultsAppService appDefaultsAppService)
        {
            _appDefaultsAppService = appDefaultsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<AppDefaultDto>> GetListAsync(GetAppDefaultsInput input)
        {
            return _appDefaultsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<AppDefaultDto> GetAsync(Guid id)
        {
            return _appDefaultsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<AppDefaultDto> CreateAsync(AppDefaultCreateDto input)
        {
            return _appDefaultsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<AppDefaultDto> UpdateAsync(Guid id, AppDefaultUpdateDto input)
        {
            return _appDefaultsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _appDefaultsAppService.DeleteAsync(id);
        }
    }
}