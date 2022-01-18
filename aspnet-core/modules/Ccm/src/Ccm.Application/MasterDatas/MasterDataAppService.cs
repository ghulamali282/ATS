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
using Ccm.Permissions;
using Ccm.MasterDatas;

namespace Ccm.MasterDatas
{

    [Authorize(CcmPermissions.MasterDatas.Default)]
    public class MasterDatasAppService : ApplicationService, IMasterDatasAppService
    {
        private readonly IMasterDataRepository _masterDataRepository;

        public MasterDatasAppService(IMasterDataRepository masterDataRepository)
        {
            _masterDataRepository = masterDataRepository;
        }

        public virtual async Task<PagedResultDto<MasterDataDto>> GetListAsync(GetMasterDatasInput input)
        {
            var totalCount = await _masterDataRepository.GetCountAsync(input.FilterText, input.ParentId, input.Name, input.Value, input.InlineValue, input.VisibleToTenant, input.IsSection, input.IsRadio, input.IsExportable, input.Icon, input.CultureName, input.SortOrderMin, input.SortOrderMax);
            var items = await _masterDataRepository.GetListAsync(input.FilterText, input.ParentId, input.Name, input.Value, input.InlineValue, input.VisibleToTenant, input.IsSection, input.IsRadio, input.IsExportable, input.Icon, input.CultureName, input.SortOrderMin, input.SortOrderMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<MasterDataDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<MasterData>, List<MasterDataDto>>(items)
            };
        }

        public virtual async Task<MasterDataDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<MasterData, MasterDataDto>(await _masterDataRepository.GetAsync(id));
        }

        [Authorize(CcmPermissions.MasterDatas.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _masterDataRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.MasterDatas.Create)]
        public virtual async Task<MasterDataDto> CreateAsync(MasterDataCreateDto input)
        {

            var masterData = ObjectMapper.Map<MasterDataCreateDto, MasterData>(input);
            masterData.TenantId = CurrentTenant.Id;
            masterData = await _masterDataRepository.InsertAsync(masterData, autoSave: true);
            return ObjectMapper.Map<MasterData, MasterDataDto>(masterData);
        }

        [Authorize(CcmPermissions.MasterDatas.Edit)]
        public virtual async Task<MasterDataDto> UpdateAsync(Guid id, MasterDataUpdateDto input)
        {

            var masterData = await _masterDataRepository.GetAsync(id);
            ObjectMapper.Map(input, masterData);
            masterData = await _masterDataRepository.UpdateAsync(masterData, autoSave: true);
            return ObjectMapper.Map<MasterData, MasterDataDto>(masterData);
        }
    }
}