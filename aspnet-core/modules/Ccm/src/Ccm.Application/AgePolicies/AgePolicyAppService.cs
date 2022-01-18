using Ccm.Shared;
using Ccm.Partners;
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
using Ccm.AgePolicies;

namespace Ccm.AgePolicies
{

    [Authorize(CcmPermissions.AgePolicies.Default)]
    public class AgePoliciesAppService : ApplicationService, IAgePoliciesAppService
    {
        private readonly IAgePolicyRepository _agePolicyRepository;
        private readonly IRepository<MasterData, Guid> _masterDataRepository;
        private readonly IRepository<Partner, Guid> _partnerRepository;

        public AgePoliciesAppService(IAgePolicyRepository agePolicyRepository, IRepository<MasterData, Guid> masterDataRepository, IRepository<Partner, Guid> partnerRepository)
        {
            _agePolicyRepository = agePolicyRepository; _masterDataRepository = masterDataRepository;
            _partnerRepository = partnerRepository;
        }

        public virtual async Task<PagedResultDto<AgePolicyWithNavigationPropertiesDto>> GetListAsync(GetAgePoliciesInput input)
        {
            var totalCount = await _agePolicyRepository.GetCountAsync(input.FilterText, input.DemoField, input.Name, input.OperatorName);
            var items = await _agePolicyRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.DemoField, input.Name, input.OperatorName, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<AgePolicyWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<AgePolicyWithNavigationProperties>, List<AgePolicyWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<AgePolicyWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<AgePolicyWithNavigationProperties, AgePolicyWithNavigationPropertiesDto>
                (await _agePolicyRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<AgePolicyDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<AgePolicy, AgePolicyDto>(await _agePolicyRepository.GetAsync(id));
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

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetPartnerLookupAsync(LookupRequestDto input)
        {
            var query = (await _partnerRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.PartnerName != null &&
                         x.PartnerName.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Partner>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Partner>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(CcmPermissions.AgePolicies.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _agePolicyRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.AgePolicies.Create)]
        public virtual async Task<AgePolicyDto> CreateAsync(AgePolicyCreateDto input)
        {
            if (input.Name == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }
            if (input.OperatorName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Partner"]]);
            }

            var agePolicy = ObjectMapper.Map<AgePolicyCreateDto, AgePolicy>(input);
            agePolicy.TenantId = CurrentTenant.Id;
            agePolicy = await _agePolicyRepository.InsertAsync(agePolicy, autoSave: true);
            return ObjectMapper.Map<AgePolicy, AgePolicyDto>(agePolicy);
        }

        [Authorize(CcmPermissions.AgePolicies.Edit)]
        public virtual async Task<AgePolicyDto> UpdateAsync(Guid id, AgePolicyUpdateDto input)
        {
            if (input.Name == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }
            if (input.OperatorName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Partner"]]);
            }

            var agePolicy = await _agePolicyRepository.GetAsync(id);
            ObjectMapper.Map(input, agePolicy);
            agePolicy = await _agePolicyRepository.UpdateAsync(agePolicy, autoSave: true);
            return ObjectMapper.Map<AgePolicy, AgePolicyDto>(agePolicy);
        }
    }
}