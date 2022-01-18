using Amm.Shared;
using Amm.MasterDatas;
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
using Amm.CruiseRegions;

namespace Amm.CruiseRegions
{

    [Authorize(AmmPermissions.CruiseRegions.Default)]
    public class CruiseRegionsAppService : ApplicationService, ICruiseRegionsAppService
    {
        private readonly ICruiseRegionRepository _cruiseRegionRepository;
        private readonly IRepository<MasterData, Guid> _masterDataRepository;

        public CruiseRegionsAppService(ICruiseRegionRepository cruiseRegionRepository, IRepository<MasterData, Guid> masterDataRepository)
        {
            _cruiseRegionRepository = cruiseRegionRepository; _masterDataRepository = masterDataRepository;
        }

        public virtual async Task<PagedResultDto<CruiseRegionWithNavigationPropertiesDto>> GetListAsync(GetCruiseRegionsInput input)
        {
            var totalCount = await _cruiseRegionRepository.GetCountAsync(input.FilterText, input.FreeEntry, input.CruiseRegionName);
            var items = await _cruiseRegionRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.FreeEntry, input.CruiseRegionName, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CruiseRegionWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CruiseRegionWithNavigationProperties>, List<CruiseRegionWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<CruiseRegionWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<CruiseRegionWithNavigationProperties, CruiseRegionWithNavigationPropertiesDto>
                (await _cruiseRegionRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<CruiseRegionDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CruiseRegion, CruiseRegionDto>(await _cruiseRegionRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input)
        {
            var query = (await _masterDataRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<MasterData>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<MasterData>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(AmmPermissions.CruiseRegions.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _cruiseRegionRepository.DeleteAsync(id);
        }

        [Authorize(AmmPermissions.CruiseRegions.Create)]
        public virtual async Task<CruiseRegionDto> CreateAsync(CruiseRegionCreateDto input)
        {
            if (input.CruiseRegionName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var cruiseRegion = ObjectMapper.Map<CruiseRegionCreateDto, CruiseRegion>(input);

            cruiseRegion = await _cruiseRegionRepository.InsertAsync(cruiseRegion, autoSave: true);
            return ObjectMapper.Map<CruiseRegion, CruiseRegionDto>(cruiseRegion);
        }

        [Authorize(AmmPermissions.CruiseRegions.Edit)]
        public virtual async Task<CruiseRegionDto> UpdateAsync(Guid id, CruiseRegionUpdateDto input)
        {
            if (input.CruiseRegionName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var cruiseRegion = await _cruiseRegionRepository.GetAsync(id);
            ObjectMapper.Map(input, cruiseRegion);
            cruiseRegion = await _cruiseRegionRepository.UpdateAsync(cruiseRegion, autoSave: true);
            return ObjectMapper.Map<CruiseRegion, CruiseRegionDto>(cruiseRegion);
        }
    }
}