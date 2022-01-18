using Ccm.Shared;
using Ccm.MasterDatas;
using Ccm.Partners;
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
using Ccm.CancellationPolicies;

namespace Ccm.CancellationPolicies
{

    [Authorize(CcmPermissions.CancellationPolicies.Default)]
    public class CancellationPoliciesAppService : ApplicationService, ICancellationPoliciesAppService
    {
        private readonly ICancellationPolicyRepository _cancellationPolicyRepository;
        private readonly IRepository<Partner, Guid> _partnerRepository;
        private readonly IRepository<MasterData, Guid> _masterDataRepository;

        public CancellationPoliciesAppService(ICancellationPolicyRepository cancellationPolicyRepository, IRepository<Partner, Guid> partnerRepository, IRepository<MasterData, Guid> masterDataRepository)
        {
            _cancellationPolicyRepository = cancellationPolicyRepository; _partnerRepository = partnerRepository;
            _masterDataRepository = masterDataRepository;
        }

        public virtual async Task<PagedResultDto<CancellationPolicyWithNavigationPropertiesDto>> GetListAsync(GetCancellationPoliciesInput input)
        {
            var totalCount = await _cancellationPolicyRepository.GetCountAsync(input.FilterText, input.NameString, input.OperatorName, input.PolicyName);
            var items = await _cancellationPolicyRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.NameString, input.OperatorName, input.PolicyName, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CancellationPolicyWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CancellationPolicyWithNavigationProperties>, List<CancellationPolicyWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<CancellationPolicyWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<CancellationPolicyWithNavigationProperties, CancellationPolicyWithNavigationPropertiesDto>
                (await _cancellationPolicyRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<CancellationPolicyDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CancellationPolicy, CancellationPolicyDto>(await _cancellationPolicyRepository.GetAsync(id));
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

        [Authorize(CcmPermissions.CancellationPolicies.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _cancellationPolicyRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.CancellationPolicies.Create)]
        public virtual async Task<CancellationPolicyDto> CreateAsync(CancellationPolicyCreateDto input)
        {
            if (input.OperatorName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Partner"]]);
            }
            if (input.PolicyName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var cancellationPolicy = ObjectMapper.Map<CancellationPolicyCreateDto, CancellationPolicy>(input);
            cancellationPolicy.TenantId = CurrentTenant.Id;
            cancellationPolicy = await _cancellationPolicyRepository.InsertAsync(cancellationPolicy, autoSave: true);
            return ObjectMapper.Map<CancellationPolicy, CancellationPolicyDto>(cancellationPolicy);
        }

        [Authorize(CcmPermissions.CancellationPolicies.Edit)]
        public virtual async Task<CancellationPolicyDto> UpdateAsync(Guid id, CancellationPolicyUpdateDto input)
        {
            if (input.OperatorName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Partner"]]);
            }
            if (input.PolicyName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var cancellationPolicy = await _cancellationPolicyRepository.GetAsync(id);
            ObjectMapper.Map(input, cancellationPolicy);
            cancellationPolicy = await _cancellationPolicyRepository.UpdateAsync(cancellationPolicy, autoSave: true);
            return ObjectMapper.Map<CancellationPolicy, CancellationPolicyDto>(cancellationPolicy);
        }
    }
}