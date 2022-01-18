using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Amm.Permissions;
using Amm.AppDefaults;

namespace Amm.AppDefaults
{

    [Authorize(AmmPermissions.AppDefaults.Default)]
    public class AppDefaultsAppService : ApplicationService, IAppDefaultsAppService
    {
        private readonly IAppDefaultRepository _appDefaultRepository;

        public AppDefaultsAppService(IAppDefaultRepository appDefaultRepository)
        {
            _appDefaultRepository = appDefaultRepository;
        }

        public virtual async Task<PagedResultDto<AppDefaultDto>> GetListAsync(GetAppDefaultsInput input)
        {
            var totalCount = await _appDefaultRepository.GetCountAsync(input.FilterText, input.SettingsName, input.SettingsValue);
            var items = await _appDefaultRepository.GetListAsync(input.FilterText, input.SettingsName, input.SettingsValue, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<AppDefaultDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<AppDefault>, List<AppDefaultDto>>(items)
            };
        }

        public virtual async Task<AppDefaultDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<AppDefault, AppDefaultDto>(await _appDefaultRepository.GetAsync(id));
        }

        [Authorize(AmmPermissions.AppDefaults.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _appDefaultRepository.DeleteAsync(id);
        }

        [Authorize(AmmPermissions.AppDefaults.Create)]
        public virtual async Task<AppDefaultDto> CreateAsync(AppDefaultCreateDto input)
        {

            var appDefault = ObjectMapper.Map<AppDefaultCreateDto, AppDefault>(input);

            appDefault = await _appDefaultRepository.InsertAsync(appDefault, autoSave: true);
            return ObjectMapper.Map<AppDefault, AppDefaultDto>(appDefault);
        }

        [Authorize(AmmPermissions.AppDefaults.Edit)]
        public virtual async Task<AppDefaultDto> UpdateAsync(Guid id, AppDefaultUpdateDto input)
        {

            var appDefault = await _appDefaultRepository.GetAsync(id);
            ObjectMapper.Map(input, appDefault);
            appDefault = await _appDefaultRepository.UpdateAsync(appDefault, autoSave: true);
            return ObjectMapper.Map<AppDefault, AppDefaultDto>(appDefault);
        }
    }
}