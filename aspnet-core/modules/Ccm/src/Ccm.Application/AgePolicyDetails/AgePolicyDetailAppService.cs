using Ccm.Shared;
using Ccm.MasterDatas;
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
using Ccm.AgePolicyDetails;

namespace Ccm.AgePolicyDetails
{

    [Authorize(CcmPermissions.AgePolicyDetails.Default)]
    public class AgePolicyDetailsAppService : ApplicationService, IAgePolicyDetailsAppService
    {
        private readonly IAgePolicyDetailRepository _agePolicyDetailRepository;
        private readonly IRepository<MasterData, Guid> _masterDataRepository;

        public AgePolicyDetailsAppService(IAgePolicyDetailRepository agePolicyDetailRepository, IRepository<MasterData, Guid> masterDataRepository)
        {
            _agePolicyDetailRepository = agePolicyDetailRepository; _masterDataRepository = masterDataRepository;
        }

        public virtual async Task<PagedResultDto<AgePolicyDetailWithNavigationPropertiesDto>> GetListAsync(GetAgePolicyDetailsInput input)
        {
            var totalCount = await _agePolicyDetailRepository.GetCountAsync(input.FilterText, input.AgeFromMin, input.AgeFromMax, input.AgePolicy, input.AgeToMin, input.AgeToMax, input.Service);
            var items = await _agePolicyDetailRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.AgeFromMin, input.AgeFromMax, input.AgePolicy, input.AgeToMin, input.AgeToMax, input.Service, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<AgePolicyDetailWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<AgePolicyDetailWithNavigationProperties>, List<AgePolicyDetailWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<AgePolicyDetailWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<AgePolicyDetailWithNavigationProperties, AgePolicyDetailWithNavigationPropertiesDto>
                (await _agePolicyDetailRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<AgePolicyDetailDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<AgePolicyDetail, AgePolicyDetailDto>(await _agePolicyDetailRepository.GetAsync(id));
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

        [Authorize(CcmPermissions.AgePolicyDetails.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _agePolicyDetailRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.AgePolicyDetails.Create)]
        public virtual async Task<AgePolicyDetailDto> CreateAsync(AgePolicyDetailCreateDto input)
        {
            if (input.Service == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var agePolicyDetail = ObjectMapper.Map<AgePolicyDetailCreateDto, AgePolicyDetail>(input);
            agePolicyDetail.TenantId = CurrentTenant.Id;
            agePolicyDetail = await _agePolicyDetailRepository.InsertAsync(agePolicyDetail, autoSave: true);
            return ObjectMapper.Map<AgePolicyDetail, AgePolicyDetailDto>(agePolicyDetail);
        }

        [Authorize(CcmPermissions.AgePolicyDetails.Edit)]
        public virtual async Task<AgePolicyDetailDto> UpdateAsync(Guid id, AgePolicyDetailUpdateDto input)
        {
            if (input.Service == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var agePolicyDetail = await _agePolicyDetailRepository.GetAsync(id);
            ObjectMapper.Map(input, agePolicyDetail);
            agePolicyDetail = await _agePolicyDetailRepository.UpdateAsync(agePolicyDetail, autoSave: true);
            return ObjectMapper.Map<AgePolicyDetail, AgePolicyDetailDto>(agePolicyDetail);
        }
    }
}